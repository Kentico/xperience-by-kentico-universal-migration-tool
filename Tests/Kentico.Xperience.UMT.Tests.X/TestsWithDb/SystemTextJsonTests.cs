// using System.Text;
// using System.Text.Json;
// using FluentAssertions;
// using Kentico.Xperience.UMT.Model;
// using Kentico.Xperience.UMT.Serialization;
// using Kentico.Xperience.UMT.Services.Model;
// using Microsoft.Extensions.DependencyInjection;
//
// namespace Kentico.Xperience.UMT;
//
// [Collection("UMT.Tests")]
// public class SystemTextJsonTests
// {
//     [Fact]
//     public Task ImportService_NestedPagesImportAsync()
//     {
//         var provider = KenticoFixture.GetUmtServiceProvider();
//         var modelService = provider.GetRequiredService<UmtModelService>();
//
//         var firstNodeGuid = new Guid("DCBDE667-AC3F-4EF1-B092-61D7C3912E2C");
//         var firstDocumentGuid = new Guid("945AAABC-940B-42F6-BF99-3FCD6FFAB03B");
//         var secondNodeGuid = new Guid("BD089033-A00E-40F1-AFF3-00992293DF10");
//         var secondDocumentGuid = new Guid("03F3CDDF-B8AA-41A3-BC5D-7FD6D9909FD2");
//
//         var sample = new[]
//         {
//             new TreeNodeModel
//             {
//                 // NodeOwnerGuid = KenticoFixture.AdminUserGuid,
//                 NodeClassGuid = new Guid("ADEAF5CE-13CB-4457-A0BE-EFE29E23F513"), // custom page class Guid ("UMT.Page")
//                 // NodeParentGuid = KenticoFixture.RootNodeGuid,
//                 CustomProperties =
//                 {
//                     { "Perex", "Testing perex" }
//                 },
//                 NodeGUID = firstNodeGuid,
//                 NodeAlias = "umt.test.nestedpages1.nodealias",
//                 NodeName = "umt.test.nestedpages1.ndoename",
//                 // NodeOrder = null,
//                 DocumentCulture = "en-US",
//                 DocumentName = "umt.test.nestedpages1.documentname",
//                 DocumentLastPublished = new DateTime(2023, 01, 01),
//                 DocumentModifiedWhen = new DateTime(2023, 01, 01),
//                 DocumentCreatedWhen = new DateTime(2023, 01, 01),
//                 DocumentPublishFrom = new DateTime(2023, 01, 01),
//                 DocumentPublishTo = new DateTime(2026, 01, 01), // root node
//                 DocumentGUID = firstDocumentGuid,
//                 //DocumentCreatedByUserGuid = KenticoFixture.AdminUserGuid,
//                 // DocumentModifiedByUserGuid = KenticoFixture.AdminUserGuid,
//             },
//             new TreeNodeModel
//             {
//                 // NodeOwnerGuid = KenticoFixture.AdminUserGuid,
//                 NodeClassGuid = new Guid("ADEAF5CE-13CB-4457-A0BE-EFE29E23F513"), // custom page class Guid ("UMT.Page")
//                 // NodeParentGuid = firstNodeGuid, // parent is first node
//                 CustomProperties =
//                 {
//                     { "Perex", "Testing perex" }
//                 },
//                 NodeGUID = secondNodeGuid,
//                 NodeAlias = "umt.test.nestedpages2.nodealias",
//                 NodeName = "umt.test.nestedpages2.ndoename",
//                 // NodeOrder = null,
//                 DocumentCulture = "en-US",
//                 DocumentName = "umt.test.nestedpages2.documentname",
//                 DocumentLastPublished = new DateTime(2023, 01, 01),
//                 DocumentModifiedWhen = new DateTime(2023, 01, 01),
//                 DocumentCreatedWhen = new DateTime(2023, 01, 01),
//                 DocumentPublishFrom = new DateTime(2023, 01, 01),
//                 DocumentPublishTo = new DateTime(2026, 01, 01), // root node
//                 DocumentGUID = secondDocumentGuid,
//                 DocumentCreatedByUserGuid = KenticoFixture.AdminUserGuid,
//                 DocumentModifiedByUserGuid = KenticoFixture.AdminUserGuid,
//             }
//         };
//
//         
//         var converter = new UmtModelStjConverter(modelService.GetAll());
//         string actual = JsonSerializer.Serialize(sample, new JsonSerializerOptions
//         {
//             Converters = { converter }
//         });
//         
//         actual.Should().NotBeNullOrWhiteSpace();
//
//         actual.Should().Be("""[{"$type":"TreeNode","NodeClassGuid":"adeaf5ce-13cb-4457-a0be-efe29e23f513","NodeOwnerGuid":"6415b8ce-8072-4bcd-8e48-9d7178b826b7","NodeParentGuid":"acdd2058-bde0-4c9d-8332-45f417220571","NodeGUID":"dcbde667-ac3f-4ef1-b092-61d7c3912e2c","NodeAlias":"umt.test.nestedpages1.nodealias","NodeName":"umt.test.nestedpages1.ndoename","NodeOrder":null,"DocumentCulture":"en-US","DocumentName":"umt.test.nestedpages1.documentname","DocumentLastPublished":"2023-01-01T00:00:00","DocumentModifiedWhen":"2023-01-01T00:00:00","DocumentCreatedWhen":"2023-01-01T00:00:00","DocumentPublishFrom":"2023-01-01T00:00:00","DocumentPublishTo":"2026-01-01T00:00:00","DocumentGUID":"945aaabc-940b-42f6-bf99-3fcd6ffab03b","DocumentCreatedByUserGuid":"6415b8ce-8072-4bcd-8e48-9d7178b826b7","DocumentModifiedByUserGuid":"6415b8ce-8072-4bcd-8e48-9d7178b826b7","NodeIsPage":true,"Perex":"Testing perex"},{"$type":"TreeNode","NodeClassGuid":"adeaf5ce-13cb-4457-a0be-efe29e23f513","NodeOwnerGuid":"6415b8ce-8072-4bcd-8e48-9d7178b826b7","NodeParentGuid":"dcbde667-ac3f-4ef1-b092-61d7c3912e2c","NodeGUID":"bd089033-a00e-40f1-aff3-00992293df10","NodeAlias":"umt.test.nestedpages2.nodealias","NodeName":"umt.test.nestedpages2.ndoename","NodeOrder":null,"DocumentCulture":"en-US","DocumentName":"umt.test.nestedpages2.documentname","DocumentLastPublished":"2023-01-01T00:00:00","DocumentModifiedWhen":"2023-01-01T00:00:00","DocumentCreatedWhen":"2023-01-01T00:00:00","DocumentPublishFrom":"2023-01-01T00:00:00","DocumentPublishTo":"2026-01-01T00:00:00","DocumentGUID":"03f3cddf-b8aa-41a3-bc5d-7fd6d9909fd2","DocumentCreatedByUserGuid":"6415b8ce-8072-4bcd-8e48-9d7178b826b7","DocumentModifiedByUserGuid":"6415b8ce-8072-4bcd-8e48-9d7178b826b7","NodeIsPage":true,"Perex":"Testing perex"}]""");
//         return Task.CompletedTask;
//     }
//
//     [Fact]
//     public void SerializationTest()
//     {
//         var provider = KenticoFixture.GetUmtServiceProvider();
//         var modelService = provider.GetRequiredService<UmtModelService>();
//         
//         string? sample = """
// [{
//         "$type": "TreeNode",
//         "NodeClassGuid": "3727aac3-1adb-4937-8b84-008024d9c0a0",
//         "NodeOwnerGuid": "6415b8ce-8072-4bcd-8e48-9d7178b826b7",
//         "NodeParentGuid": "51a96a18-bf48-49ff-91c3-4bf2faed9ddb",
//         "NodeGUID": "d605d2fb-9b36-46bd-aadb-a85b88d5bb59",
//         "NodeAlias": "news-content-page---demo-mw",
//         "NodeName": "news-content-page---demo-mw",    
//         "DocumentCulture": "en-US",
//         "DocumentName": "News content page - DEMO MW",
//         "DocumentLastPublished": "2023-01-01T00:00:00",
//         "DocumentModifiedWhen": "2023-01-01T00:00:00",
//         "DocumentCreatedWhen": "2023-01-01T00:00:00",
//         "DocumentPublishFrom": "2023-01-01T00:00:00",
//         "DocumentPublishTo": "2026-01-01T00:00:00",
//         "DocumentGUID": "d605d2fb-9b36-46bd-aadb-a85b88d5bb59",
//         "DocumentCreatedByUserGuid": "6415b8ce-8072-4bcd-8e48-9d7178b826b7",
//         "DocumentModifiedByUserGuid": "6415b8ce-8072-4bcd-8e48-9d7178b826b7",    
//         "SampleNewsDate": "2023-02-23T00:00:00",
//         "SampleNewsTitle": "News content page - DEMO MW ",
//         "SampleNewsSubTitle": "This press release was done during a DEMO",
//         "SampleNewsText": ""
//     }]
// """;
//         
//         var converter = new UmtModelStjConverter(modelService.GetAll());
//
//         async IAsyncEnumerable<UmtModel> DeserializeModel()
//         {
//             var stream = new MemoryStream(Encoding.UTF8.GetBytes(sample));
//             var actual = JsonSerializer.DeserializeAsyncEnumerable<UmtModel>(stream, new JsonSerializerOptions
//             {
//                 Converters = { converter }
//             });
//             await foreach (var umtModel in actual)
//             {
//                 yield return umtModel ?? throw new Exception("Null UMT model is unexpected");
//             }
//         }
//
//         var action = () => DeserializeModel().ToListAsync();
//
//         action.Should().NotThrow();
//     }
//     
//     [Fact]
//     public void SerializationTest2()
//     {
//         var provider = KenticoFixture.GetUmtServiceProvider();
//         var modelService = provider.GetRequiredService<UmtModelService>();
//         
//         string? sample = """
// [
//   {
//     "$type": "DataClass",
//
//     "ClassGUID": "3727aac3-1adb-4937-8b84-008024d9c0a0",
//     "ClassResourceID": null,
//     "ClassDisplayName": "UMT Sample - News",
//     "ClassName": "UMT.SampleNews",
//     "ClassIsDocumentType": true,
//     "ClassIsCoupledClass": true,
//     "ClassNodeNameSource": "",
//     "ClassTableName": "UMT_SampleNews",
//     "ClassShowAsSystemTable": false,
//     "ClassUsePublishFromTo": null,
//     "ClassShowTemplateSelection": null,
//     "ClassNodeAliasSource": null,
//     "ClassLastModified": null,
//     "ClassShowColumns": null,
//     "ClassInheritsFromClassGUID": null,
//     "ClassContactMapping": null,
//     "ClassContactOverwriteEnabled": null,
//     "ClassConnectionString": null,
//     "ClassDefaultObjectType": null,
//     "ClassIsForm": false,
//     "ClassCustomizedColumns": null,
//     "ClassCodeGenerationSettings": null,
//     "ClassIconClass": null,
//     "ClassURLPattern": null,
//     "ClassUsesPageBuilder": true,
//     "ClassHasURL": true,
//     "ClassHasMetadata": false,
//     "ClassIsPage": true,
//     "ClassHasUnmanagedDbSchema": false,
//
//     "Fields": [
//       {
//         "ColumnType": "datetime",
//         "Column": "SampleNewsDate",
//         "AllowEmpty": true,
//         "Enabled": true,
//         "Visible": true,
//         "Guid": "023d0460-18e5-4d67-9671-fbf3c7cfc4f5",
//         "Properties": {
//           "FieldCaption": "News date"
//         },
//         "Settings": {
//           "ControlName": "Kentico.Administration.DateTimeInput"
//         }
//       },
//       {
//         "ColumnType": "text",
//         "Column": "SampleNewsTitle",
//         "AllowEmpty": true,
//         "ColumnSize": 200,
//         "Enabled": true,
//         "Visible": true,
//         "Guid": "5b7e23e1-15e3-467a-a669-99982e9f1d17",
//         "Properties": {
//           "FieldCaption": "News title"
//         },
//         "Settings": {
//           "ControlName": "Kentico.Administration.TextArea"
//         }
//       },
//       {
//         "ColumnType": "text",
//         "Column": "SampleNewsSubTitle",
//         "AllowEmpty": true,
//         "ColumnSize": 200,
//         "Enabled": true,
//         "Visible": true,
//         "Guid": "7fe0ccc9-26b7-4cfd-bfb7-6176de0a8191",
//         "Properties": {
//           "FieldCaption": "News sub title"
//         },
//         "Settings": {
//           "ControlName": "Kentico.Administration.TextArea"
//         }
//       },
//       {
//         "ColumnType": "longtext",
//         "Column": "SampleNewsText",
//         "AllowEmpty": true,
//         "Enabled": true,
//         "Visible": true,
//         "Guid": "d0f8d32b-abbe-4f33-b649-8fc3df399075",
//         "Properties": {
//           "FieldCaption": "Text"
//         },
//         "Settings": {
//           "ControlName": "Kentico.Administration.TextArea"
//         }
//       }
//     ]
//   },
//   {
//     "$type": "TreeNode",
//     "NodeClassGuid": "8FA3E50A-B5EF-48F1-B506-FAD8F3F9E50A",
//     "NodeOwnerGuid": "6415b8ce-8072-4bcd-8e48-9d7178b826b7",
//     "NodeParentGuid": "acdd2058-bde0-4c9d-8332-45f417220571",
//     "NodeGUID": "51a96a18-bf48-49ff-91c3-4bf2faed9ddb",
//     "NodeAlias": "News",
//     "NodeName": "news",
//     "NodeOrder": null,
//     "DocumentCulture": "en-US",
//     "DocumentName": "News",
//     "DocumentLastPublished": "2023-01-01T00:00:00",
//     "DocumentModifiedWhen": "2023-01-01T00:00:00",
//     "DocumentCreatedWhen": "2023-01-01T00:00:00",
//     "DocumentPublishFrom": "2023-01-01T00:00:00",
//     "DocumentPublishTo": "2026-01-01T00:00:00",
//     "DocumentGUID": "51a96a18-bf48-49ff-91c3-4bf2faed9ddb",
//     "DocumentCreatedByUserGuid": "6415b8ce-8072-4bcd-8e48-9d7178b826b7",
//     "DocumentModifiedByUserGuid": "6415b8ce-8072-4bcd-8e48-9d7178b826b7",
//     "NodeIsPage": true
//   },
//   {
//     "$type": "TreeNode",
//     "NodeClassGuid": "3727aac3-1adb-4937-8b84-008024d9c0a0",
//     "NodeOwnerGuid": "6415b8ce-8072-4bcd-8e48-9d7178b826b7",
//     "NodeParentGuid": "51a96a18-bf48-49ff-91c3-4bf2faed9ddb",
//     "NodeGUID": "302b0569-f877-45cd-b558-4027dc0d1e60",
//     "NodeAlias": "biffa-birthday-boy",
//     "NodeName": "biffa-birthday-boy",
//     "NodeOrder": null,
//     "DocumentCulture": "en-US",
//     "DocumentName": "Biffa Birthday Boy ",
//     "DocumentLastPublished": "2023-01-01T00:00:00",
//     "DocumentModifiedWhen": "2023-01-01T00:00:00",
//     "DocumentCreatedWhen": "2023-01-01T00:00:00",
//     "DocumentPublishFrom": "2023-01-01T00:00:00",
//     "DocumentPublishTo": "2026-01-01T00:00:00",
//     "DocumentGUID": "8f80d48e-648a-4bd0-afab-8eddfb3bff5a",
//     "DocumentCreatedByUserGuid": "6415b8ce-8072-4bcd-8e48-9d7178b826b7",
//     "DocumentModifiedByUserGuid": "6415b8ce-8072-4bcd-8e48-9d7178b826b7",
//     "NodeIsPage": true,
//     "SampleNewsDate": "2023-02-23T00:00:00",
//     "SampleNewsTitle": "Let us invite you to our summer event",
//     "SampleNewsSubTitle": "Biffa helps birthday boys’ dream come true by surprising him with a visit from our local crew and a goody bag of Biffa merchandise.",
//     "SampleNewsText": "When little ‘Biffa Bill’s’ birthday dreams came true\n\nThis is the heart-melting moment Biffa-mad William Brinkley’s birthday dreams came true.\n\nThe little Sittingbourne boy fell in love with all things Biffa during lockdown when he started waving at his local bin crew every Thursday morning.\n\nSo when his fourth birthday came around last week, his family decided to try and arrange something extra special.\n\nThey posted on Facebook asking how to get a refuse truck to visit him on his big day. A friend whose uncle works for Biffa saw the post, and it snowballed from there.\n\nOn the day, the borough’s shiny new electric Biffa refuse truck parked up outside, with refuse collector [name here] and operations manager Jenna Hammon on board.\n\nWilliam’s mum Caitlyn Crayford said: “They knocked the door and asked for the birthday boy. He just kept saying ‘For me? For me?’ He couldn’t believe it was for him.\n\n“They gave him lots of little Biffa presents which are now all next to his bed, and a little high-vis Biffa top with his name on which he now wears everywhere. They showed him around the truck and how it works, and he got to speak to the bin man which he absolutely loved.\n\n“His favourite part was sitting in front of the truck. He touched all the buttons and beeped the horn.\n\n“They made him feel very very special. He went to bed with a big smile on his face – and he couldn’t stop talking about it the next day either.\n\n“I cried. I was very emotional. Even talking about it now and looking back through pictures it’s just something I never thought we’d be able to get for him.\n\n“Biffa have been absolute legends. To make this happen for William on his fourth birthday is just a dream. Their gifts, their kindness and their love have made some beautiful memories for all of us.”\n\nWilliam also lives with dad Bill and sisters Tillianna Rose, 7, and Priscilla May, 6.\n\nThe whole family is already big on recycling and litter picking, and William has already said he wants to be a refuse collector when he’s older.\n\nCaitlyn added: “We call him little Biffa Bill now. He even makes his dad take him to the tip so he can sit in the car and watch what goes on.”\n\nJenna Hammon, Biffa’s operations manager in Swale, said: “We’re a big part of the community here, so when you get the call to send a refuse truck to make a little boy’s birthday, you do!\n\n“I’m so glad we were able to make it a really special day for a special little boy.”"
//   },
//   {
//     "$type": "TreeNode",
//     "NodeClassGuid": "3727aac3-1adb-4937-8b84-008024d9c0a0",
//     "NodeOwnerGuid": "6415b8ce-8072-4bcd-8e48-9d7178b826b7",
//     "NodeParentGuid": "51a96a18-bf48-49ff-91c3-4bf2faed9ddb",
//     "NodeGUID": "d605d2fb-9b36-46bd-aadb-a85b88d5bb59",
//     "NodeAlias": "news-content-page---demo-mw",
//     "NodeName": "news-content-page---demo-mw",    
//     "DocumentCulture": "en-US",
//     "DocumentName": "News content page - DEMO MW",
//     "DocumentLastPublished": "2023-01-01T00:00:00",
//     "DocumentModifiedWhen": "2023-01-01T00:00:00",
//     "DocumentCreatedWhen": "2023-01-01T00:00:00",
//     "DocumentPublishFrom": "2023-01-01T00:00:00",
//     "DocumentPublishTo": "2026-01-01T00:00:00",
//     "DocumentGUID": cumentPublishTo": "2026-01-01T00:00:00",
//     "DocumentGUID": "d605d2fb-9b36-46bd-aadb-a85b88d5bb59",
//     "DocumentCreatedByUserGuid": "6415b8ce-8072-4bcd-8e48-9d7178b826b7",
//     "DocumentModifiedByUserGuid": "6415b8ce-8072-4bcd-8e48-9d7178b826b7",    
//     "SampleNewsDate": "2023-02-23T00:00:00",
//     "SampleNewsTitle": "News content page - DEMO MW ",
//     "SampleNewsSubTitle": "This press release was done during a DEMO",
//     "SampleNewsText": ""
//   },
//   {
//     "$type": "TreeNode",
//     "NodeClassGuid": "3727aac3-1adb-4937-8b84-008024d9c0a0",
//     "NodeOwnerGuid": "6415b8ce-8072-4bcd-8e48-9d7178b826b7",
//     "NodeParentGuid": "51a96a18-bf48-49ff-91c3-4bf2faed9ddb",
//     "NodeGUID": "fd47d173-dccd-474b-bcad-e6c1a6db5362",
//     "NodeAlias": "biffa-unlocks-1bn-for-green-infrastructure-investment-ahead-of-plans",
//     "NodeName": "biffa-unlocks-1bn-for-green-infrastructure-investment-ahead-of-plans",
//     "DocumentCulture": "en-US",
//     "DocumentName": "Biffa unlocks £1bn for green infrastructure investment, ahead of plans",
//     "DocumentLastPublished": "2023-01-01T00:00:00",
//     "DocumentModifiedWhen": "2023-01-01T00:00:00",
//     "DocumentCreatedWhen": "2023-01-01T00:00:00",
//     "DocumentPublishFrom": "2023-01-01T00:00:00",
//     "DocumentPublishTo": "2026-01-01T00:00:00",
//     "DocumentGUID": "fd47d173-dccd-474b-bcad-e6c1a6db5362",
//     "DocumentCreatedByUserGuid": "6415b8ce-8072-4bcd-8e48-9d7178b826b7",
//     "DocumentModifiedByUserGuid": "6415b8ce-8072-4bcd-8e48-9d7178b826b7",
//     "SampleNewsDate": "2021-06-21T00:00:00",
//     "SampleNewsTitle": "Biffa unlocks £1bn for green infrastructure investment, ahead of plans",
//     "SampleNewsSubTitle": "In its inaugural sustainability report, Biffa has confirmed today that it has already unlocked £1bn worth of investment in vital UK green infrastructure, well ahead of its targets. The update comes as the business publishes its first sustainability report following the launch of its sustainability strategy ‘Resourceful, Responsible” in March 2020.",
//     "SampleNewsText": "<div class=\"copy__text\">\n                    <p style=\"text-align: right;\">21 June 2021</p>\n<p>&nbsp;</p>\n<p style=\"text-align: center;\"><strong><span style=\"text-decoration: underline;\">Biffa unlocks £1bn for green infrastructure investment, ahead of plans</span></strong></p>\n<p style=\"text-align: justify;\">In its inaugural sustainability report, Biffa has confirmed today that it has already unlocked £1bn worth of investment in vital UK green infrastructure, well ahead of its targets. The update comes as the business publishes its first sustainability report following the launch of its sustainability strategy ‘Resourceful, Responsible” in March 2020.</p>\n<p style=\"text-align: justify;\"><span class=\"normaltextrun\" style=\"background: white; color: black;\">Biffa has accelerated its investment plans over the course of the last year, focusing on four key areas – Reduce, Recycle, Recover, and Collect, aligned to the waste hierarchy. The Group has an overall ambition to unlock £1.25bn investment by 2030.</span></p>\n<p style=\"text-align: justify;\">The report shows the company has made further progress against ambitious targets despite the challenges of the Covid-19 pandemic. As part of the investment programme the Group has doubled its plastics recycling capacity this year to more than 120,000 tonnes at its state-of-the-art facilities in the North East as well as establishing an industry leading position in waste reduction through the acquisition of Company Shop Group and making further acquisitions to expand its low carbon collections service.</p>\n<p style=\"text-align: justify;\">Biffa has also announced further progress against its commitment to reduce emissions, outlining a roadmap to reach net zero no later than 2050. <span class=\"normaltextrun\" style=\"background: white; color: black;\">Since 2002 Biffa has reduced its CO<sub>2 </sub>emission</span>s by 70% and is targeting a further 50% reduction by 2030. </p>\n<p style=\"text-align: justify;\"><strong>Commenting on the report, Michael Topham, CEO of Biffa, said:</strong><em> </em><em><span style=\"color: black;\">“We have accelerated our sustainability programme despite the challenges posed by Covid-19, with meaningful delivery across a range of areas. The waste industry plays a critical role in shaping a better future for our communities and the environment. As part of our commitment to delivering on our ambitious plans Biffa has committed to unlocking £1.25bn investment in vital UK green infrastructure and I’m delighted to have already realised £1bn of that commitment, well ahead of plan. </span></em></p>\n<p style=\"text-align: justify;\"><em><span style=\"color: black;\">“Biffa has a defining and important role to play in delivering more sustainable solutions to help combat the UK’s waste challenge. I’m proud of this progress but we cannot be complacent and remain fully focussed on <span class=\"dh\">strengthening our commitment to delivering more circular solutions for our customers and wider society.”</span></span></em></p>\n<p style=\"text-align: justify;\">The three pillars of Biffa’s sustainability strategy are: Building a circular economy, Tackling climate change, and Caring for our people, supporting our communities. </p>\n<p style=\"text-align: justify;\">Key highlights since March 2021 include:</p>\n<p style=\"text-align: justify;\"><strong>Building a circular economy</strong></p>\n<ul style=\"list-style-type: disc;\">\n    <li><span>We’ve doubled the Group’s plastics recycling capacity with investments in facilities in the North East.</span></li>\n    <li><span>We entered the world of UK surplus redistribution through our acquisition of Company Shop Group, enabling us to deliver a unique circular economy proposition.</span></li>\n</ul>\n<p style=\"text-align: justify;\"><strong>Tackling climate change</strong></p>\n<ul style=\"list-style-type: disc;\">\n    <li>We’re on track to reduce greenhouse gas emissions by 50% by 2030. This year-on-year reduction in CO<sub>2</sub> emissions means that since our peak emissions in 2002, we have reduced emissions by 70%. We also set out our path to net zero emissions by no later than 2050.</li>\n    <li>Our programme of acquisitions over recent years has helped to improve collection efficiencies and route densities. This year we welcomed Ward and Simply Waste into the Biffa family, as well as announcing an agreement to purchase Viridor’s collections business. Acquisitions help to significantly reduce CO<sub>2</sub> emissions per tonne of waste collected.</li>\n    <li>We’ve also taken thousands of truck journeys off the road by expanding our rail network.</li>\n</ul>\n<p style=\"text-align: justify;\"><strong>Caring for our people, supporting our communities</strong></p>\n<ul style=\"list-style-type: disc;\">\n    <li>We remained committed to investing in our communities and protecting the planet for future generations. Since 2019, we have allocated £13.9m of Landfill Tax receipts to local community projects, through the Biffa Award fund, which include important biodiversity initiatives to help protect endangered wildlife species in the UK.</li>\n    <li><span>We made further improvement in employee engagement despite the challenges of the pandemic, with our engagement score growing to 59%</span><span>, which is 3% above the UK average.</span></li>\n    <li>We continued our successful Diversity and Inclusion programme, launching our first Women in Waste group to look at how we can better attract, support, and develop women at Biffa.</li>\n</ul>\n<p style=\"text-align: justify;\"><span class=\"dh\" style=\"color: black;\">You can read the full 2021 sustainability report </span><a href=\"http://www.biffa.co.uk/sustainability/reports-and-performance/sustainabilityreport-2021\"><span>here</span></a><span class=\"dh\" style=\"color: black;\">.</span></p>\n<p style=\"text-align: center;\"><strong>-ENDS-</strong></p>\n<p style=\"text-align: justify;\"><strong><span>Notes to Editors</span></strong></p>\n<p class=\"paragraph\" style=\"margin: 0cm;\"><span clparagraph\" style=\"margin: 0cm;\"><span class=\"normaltextrun\"><strong><span>For enquiries, please contact:</span></strong></span><span class=\"eop\"></span></p>\n<p class=\"paragraph\" style=\"margin: 0cm;\"><span class=\"normaltextrun\"><strong><span style=\"color: black;\">Houston</span></strong></span><span class=\"eop\" style=\"color: black;\"></span></p>\n<p class=\"paragraph\" style=\"margin: 0cm;\"><a rel=\"noopener noreferrer\" href=\"mailto:biffa@houston.co.uk\" target=\"_blank\"><span class=\"normaltextrun\" style=\"color: #0563c1;\">biffa@houston.co.uk</span></a><span class=\"normaltextrun\" style=\"color: #0b4cb4;\"></span><span class=\"normaltextrun\" style=\"color: black;\">/ +44 (0)204 529 0549</span><span class=\"eop\" style=\"color: black;\"></span></p>\n<p style=\"text-align: justify;\"><strong><span>&nbsp;</span></strong></p>\n<p class=\"paragraph\" style=\"margin: 0cm;\"><span class=\"normaltextrun\"><strong><span>About Biffa</span></strong></span></p>\n<p class=\"paragraph\" style=\"margin: 0cm;\"><span class=\"normaltextrun\">With a history of leading the UK’s waste management industry for over 100 years, today Biffa is an established enabler of the UK circular economy.</span><span class=\"eop\"></span></p>\n<p class=\"paragraph\" style=\"margin: 0cm;\"><span class=\"eop\">&nbsp;</span></p>\n<p class=\"paragraph\" style=\"margin: 0cm; text-align: justify;\"><span class=\"normaltextrun\">Our team of more than 9,000 colleagues carry out essential operations every day to support the UK circular economy including collection, surplus redistribution, recycling, treatment, disposal and energy generation.&nbsp;</span><span class=\"eop\"></span></p>\n<p class=\"paragraph\" style=\"margin: 0cm; text-align: justify;\"><span class=\"eop\">&nbsp;</span></p>\n<p class=\"paragraph\" style=\"margin: 0cm; text-align: justify;\"><span class=\"normaltextrun\">Our purpose is ‘to change the way people think about waste’ and sustainability has been at the heart of our business strategy for many years. We have already made huge strides in our sustainability journey by investing in plastic recycling and energy from waste infrastructure, surplus redistribution and low carbon collections, leading to a 70% reduction in our carbon emissions since 2002. Our sustainability strategy ‘Resourceful, Responsible’ will see us unlock £1.25bn of investment in vital green economy infrastructure by 2030, while further reducing our carbon emissions by 50% by 2030. We aim&nbsp;to have net zero emissions no later than 2050.&nbsp;</span><span class=\"eop\"></span></p>\n<p class=\"paragraph\" style=\"margin: 0cm; text-align: justify;\"><span class=\"eop\">&nbsp;</span></p>\n<p class=\"paragraph\" style=\"margin: 0cm; text-align: justify;\"><span class=\"normaltextrun\">We understand that we must lead by example and are committed to further improving health, safety and wellbeing in our sector. We are proud to have been awarded a&nbsp;5 star&nbsp;grading by the British Safety Council. We have also made strong progress in making sure Biffa is an inclusive place to work where diversity is championed and our&nbsp;&gt;9,000 strong workforce feel valued and understand the&nbsp;positive&nbsp;contribution they make to enabling the UK circular economy.</span><span class=\"eop\"></span></p>\n<p class=\"paragraph\" style=\"margin: 0cm; text-align: justify;\"><span class=\"eop\">&nbsp;</span></p>\n<p class=\"paragraph\" style=\"margin: 0cm; text-align: justify;\"><span class=\"normaltextrun\">Our long-standing Biffa Award programme supports sustainable projects across the UK which deliver environmental benefits while making a valuable contribution to local communities. Our partnership with&nbsp;WasteAid&nbsp;helps countries in the developing world with managing their waste more sustainably.</span></p>\n<p style=\"text-align: center;\">&nbsp;</p>\n<p>\n</p>\n                </div>"
//   }
// ]                                                                                                                                                             
// """;
//         
//         var converter = new UmtModelStjConverter(modelService.GetAll());
//
//         async IAsyncEnumerable<UmtModel> DeserializeModel()
//         {
//             var stream = new MemoryStream(Encoding.UTF8.GetBytes(sample));
//             var actual = JsonSerializer.DeserializeAsyncEnumerable<UmtModel>(stream, new JsonSerializerOptions
//             {
//                 Converters = { converter }
//             });
//             await foreach (var umtModel in actual)
//             {
//                 yield return umtModel ?? throw new Exception("Null UMT model is unexpected");
//             }
//         }
//
//         var action = () => DeserializeModel().ToListAsync();
//
//         action.Should().NotThrow();
//     }
// }
