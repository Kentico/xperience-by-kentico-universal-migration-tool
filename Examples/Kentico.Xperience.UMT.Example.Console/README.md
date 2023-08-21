# Console sample

to run console sample, you need to change connection string to target instance:

1. fill connection to target instance

   ```csharp
   root[ConfigurationPath.Combine("ConnectionStrings", "CMSConnectionString")]
       // TODO: change connection string to target XbyK instance
       = "";
   ```

2. fill context - target site name and culture code of target site

   ```csharp
   // fill context
   var context = new ImporterContext(
       // TODO: change site name
       "Boilerplate",
       // TODO: change culture if needed
       "en-US"
   );
   ```

3. change `TreeNodeSamples.SiteRootNodeGuid` to NodeGuid of root node in Your site (root node of Your site) [Root node guid](../../Docs/References.md#root-node)
4. run sample
