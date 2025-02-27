using CMS.ContentEngine.Internal;
using CMS.ContentEngine;
using CMS.DataEngine;
using CMS.FormEngine;

using Kentico.Xperience.UMT.Utils;

using System.Text.Json;

namespace Kentico.Xperience.UMT.Services
{
    internal class ContentItemReferencePopulator
    {
        /// <summary>
        /// Call before adapting the model
        /// </summary>
        internal static void Preprocess(
            string className,
            Dictionary<string, object?> customData
        )
        {
            foreach (var (fieldName, value) in SchemaHelper.GetRefFields(className)
                                                .Where(field => customData.ContainsKey(field.Name))
                                                .Select(field => (FieldName: field.Name, Value: customData[field.Name]))
                                                .Where(x => x.Value is not string))
            {
                customData[fieldName] = JsonSerializer.Serialize(value);
            }
        }

        /// <summary>
        /// Call after the model has been adapted and saved
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        internal void Postprocess(string className, Dictionary<string, object?> customData, int commonDataID)
        {
            // CMS_ContentItemReference table record contains ContentItemCommonData record and class form field GUID (named GroupGuid in the table).
            // Retrieve them
            var commonDataInfo = ContentItemCommonDataInfo.Provider.Get(commonDataID);
            var fi = FormHelper.GetFormInfo(className, false);
            var classRefFields = fi.GetFields(true, true).Where(x => x.DataType == SchemaHelper.CONTENT_ITEM_REFERENCE_DATA_TYPE_NAME);
            var reusableSchemaRefFields = SchemaHelper.UnpackReusableFieldSchemas(fi.GetFields<FormSchemaInfo>()).Where(x => x.DataType == SchemaHelper.CONTENT_ITEM_REFERENCE_DATA_TYPE_NAME);
            var refFields = classRefFields.Concat(reusableSchemaRefFields).ToArray();

            var refInfos = CreateContentItemReferenceInfos(refFields, customData, commonDataInfo);
            foreach (var refInfo in refInfos)
            {
                bool contentItemReferenceExists = Provider<ContentItemReferenceInfo>.Instance.Get()
                    .WhereEquals(nameof(ContentItemReferenceInfo.ContentItemReferenceGroupGUID), refInfo.ContentItemReferenceGroupGUID)
                    .WhereEquals(nameof(ContentItemReferenceInfo.ContentItemReferenceSourceCommonDataID), refInfo.ContentItemReferenceSourceCommonDataID)
                    .WhereEquals(nameof(ContentItemReferenceInfo.ContentItemReferenceTargetItemID), refInfo.ContentItemReferenceTargetItemID)
                .Any();

                if (!contentItemReferenceExists)
                {
                    ContentItemReferenceInfo.Provider.Set(refInfo);
                }
            }
        }

        private IEnumerable<ContentItemReferenceInfo> CreateContentItemReferenceInfos(
            IEnumerable<FormFieldInfo> referenceFormFieldInfos,
            Dictionary<string, object?> customData,
            ContentItemCommonDataInfo commonDataInfo
        )
        {
            foreach (var field in referenceFormFieldInfos)
            {
                var groupGuid = field.Guid;

                if (!customData.TryGetValue(field.Name, out object? contentItemReferenceFieldValue))
                {
                    continue;
                }

                if (contentItemReferenceFieldValue is not null)
                {
                    if (contentItemReferenceFieldValue is string serializedValue)
                    {
                        var value = JsonSerializer.Deserialize<IEnumerable<ContentItemReference>>(serializedValue);
                        if (value is not null)
                        {
                            foreach (var targetItemGuid in value.Select(x => x.Identifier))
                            {
                                var contentItemInfo = ContentItemInfo.Provider.Get(targetItemGuid) ?? throw new ArgumentNullException($"The linked content item with GUID '{targetItemGuid}' referenced by a ContentItemCommonData with GUID '{commonDataInfo.ContentItemCommonDataGUID}' does not exist or could not be found.");
                                yield return new()
                                {
                                    ContentItemReferenceGroupGUID = groupGuid,
                                    ContentItemReferenceSourceCommonDataID = commonDataInfo.ContentItemCommonDataID,
                                    ContentItemReferenceTargetItemID = contentItemInfo.ContentItemID,
                                };
                            }
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException($"{nameof(contentItemReferenceFieldValue)} expected to be string");
                    }
                }
            }
        }
    }
}
