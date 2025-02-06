using TestAfterMigration.Helpers;

namespace TestAfterMigration.Extensions
{
    public static class PageTreeItemExtensions
    {
        public static IEnumerable<PageTreeItem> Family(this PageTreeItem item) => [item, .. item.Children.SelectManyRecursive(x => x.Children)];
    }
}
