using CMS.ContentEngine.Internal;
using CMS.FormEngine;

namespace Kentico.Xperience.UMT.Utils
{
    internal static class SchemaHelper
    {
        internal static IEnumerable<FormFieldInfo> UnpackReusableFieldSchemas(IEnumerable<FormSchemaInfo> schemaInfos)
        {
            using var siEnum = schemaInfos.GetEnumerator();

            if (siEnum.MoveNext() && FormHelper.GetFormInfo(ContentItemCommonDataInfo.TYPEINFO.ObjectClassName, true) is { } cfi)
            {
                do
                {
                    var fsi = siEnum.Current;
                    var formFieldInfos = cfi
                        .GetFields(true, true, true)
                        .Where(f => string.Equals(f.Properties[ReusableFieldSchemaConstants.SCHEMA_IDENTIFIER_KEY] as string, fsi.Guid.ToString(),
                            StringComparison.InvariantCultureIgnoreCase));

                    foreach (var formFieldInfo in formFieldInfos)
                    {
                        yield return formFieldInfo;
                    }
                } while (siEnum.MoveNext());
            }
        }

        internal const string CONTENT_ITEM_REFERENCE_DATA_TYPE_NAME = "contentitemreference";
        internal const string WEBPAGES_DATA_TYPE_NAME = "webpages";

        internal static IEnumerable<FormFieldInfo> GetRefFields(string className)
        {
            var fi = FormHelper.GetFormInfo(className, false);
            var classRefFields = fi.GetFields(true, true).Where(x => x.DataType == CONTENT_ITEM_REFERENCE_DATA_TYPE_NAME);
            var reusableSchemaRefFields = UnpackReusableFieldSchemas(fi.GetFields<FormSchemaInfo>()).Where(x => x.DataType == CONTENT_ITEM_REFERENCE_DATA_TYPE_NAME);
            var refFields = classRefFields.Concat(reusableSchemaRefFields!).ToArray();
            return refFields;
        }
    }
}
