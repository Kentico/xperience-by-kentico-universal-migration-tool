# Kentico.UMT.Services.IImportService


## Methods
### SerializeToJson
`Kentico.UMT.Services.IImportService.SerializeToJson(Kentico.UMT.Model.UmtModel, System.Text.Json.JsonSerializerOptions?)`  
Serializes umt model to JSON  
Parameters
|Name|Type|Summary|
|---|---|---|
|model|Kentico.UMT.Model.UmtModel|
|options|System.Text.Json.JsonSerializerOptions?|
### FromJsonStream
`Kentico.UMT.Services.IImportService.FromJsonStream(System.IO.Stream)`  
Reads json from stream and returns enumerable of UmtModel  
Parameters
|Name|Type|Summary|
|---|---|---|
|jsonStream|System.IO.Stream|Stream of data, content must be valid JSON array of UMT model
### StartImport
`Kentico.UMT.Services.IImportService.StartImport(System.Collections.Generic.IEnumerable<Kentico.UMT.Model.UmtModel>, Kentico.UMT.Services.ImporterContext, Kentico.UMT.Services.ImportStateObserver)`  
Starts import  
Parameters
|Name|Type|Summary|
|---|---|---|
|importedObjects|System.Collections.Generic.IEnumerable<Kentico.UMT.Model.UmtModel>|UMT model, imported objects
|context|Kentico.UMT.Services.ImporterContext|Import context, information that remains same whole import process lifetime
|importObserver|Kentico.UMT.Services.ImportStateObserver|Import state observer, stores current information about import with events
### StartImportAsync
`Kentico.UMT.Services.IImportService.StartImportAsync(System.Collections.Generic.IAsyncEnumerable<Kentico.UMT.Model.UmtModel>, Kentico.UMT.Services.ImporterContext, Kentico.UMT.Services.ImportStateObserver)`  
Starts import  
Parameters
|Name|Type|Summary|
|---|---|---|
|importedObjects|System.Collections.Generic.IAsyncEnumerable<Kentico.UMT.Model.UmtModel>|UMT model, imported objects
|context|Kentico.UMT.Services.ImporterContext|Import context, information that remains same whole import process lifetime
|importObserver|Kentico.UMT.Services.ImportStateObserver|Import state observer, stores current information about import with events


