using Kbank.Web.Components;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using Kentico.Xperience.UMT.Example.Target.Sections;

[assembly: RegisterSection(ComponentIdentifiers.SINGLE_COLUMN_SECTION, "1 column section", typeof(SingleColumnSectionProperties), "~/Sections/_SingleColumnSection.cshtml", Description = "Single-column section with one full-width zone.", IconClass = "icon-square")]

[assembly: RegisterPageTemplate(ComponentIdentifiers.PAGE_WITH_WIDGETS_DEFAULT_TEMPLATE, "Page with widgets - default", null, customViewName: "~/Views/PageTemplates/PageWithWidgets.cshtml", ContentTypeNames = ["UMT.PageWithWidgets", "DancingGoatCore.StoreSection"])]
[assembly: RegisterPageTemplate(ComponentIdentifiers.ARTICLE_PAGE_DEFAULT_TEMPLATE, "Article page - default", null, customViewName: "~/Views/PageTemplates/ArticlePage.cshtml", ContentTypeNames = ["UMT.Article"])]
