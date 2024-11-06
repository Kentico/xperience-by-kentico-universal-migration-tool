# Kentico.Xperience.UMT.Services.IImportService


## Methods
### SerializeToJson
`Kentico.Xperience.UMT.Services.IImportService.SerializeToJson(Kentico.Xperience.UMT.Model.UmtModel, System.Text.Json.JsonSerializerOptions?)`  
Serializes umt model to JSON  
Parameters
|Name|Type|Summary|
|---|---|---|
|model|Kentico.Xperience.UMT.Model.UmtModel|
|options|System.Text.Json.JsonSerializerOptions?|
### SerializeToJson
`Kentico.Xperience.UMT.Services.IImportService.SerializeToJson(System.Collections.Generic.IEnumerable<Kentico.Xperience.UMT.Model.UmtModel>, System.Text.Json.JsonSerializerOptions?)`  
Serializes umt model to JSON  
Parameters
|Name|Type|Summary|
|---|---|---|
|model|System.Collections.Generic.IEnumerable<Kentico.Xperience.UMT.Model.UmtModel>|
|options|System.Text.Json.JsonSerializerOptions?|
### FromJsonStream
`Kentico.Xperience.UMT.Services.IImportService.FromJsonStream(System.IO.Stream)`  
Reads json from stream and returns enumerable of UmtModel  
Parameters
|Name|Type|Summary|
|---|---|---|
|jsonStream|System.IO.Stream|Stream of data, content must be valid JSON array of UMT model
### FromJsonString
`Kentico.Xperience.UMT.Services.IImportService.FromJsonString(string)`  
Reads model from json string and returns enumerable of UmtModel  
Parameters
|Name|Type|Summary|
|---|---|---|
|jsonString|string|String that contains valid JSON UMT model
### StartImport
`Kentico.Xperience.UMT.Services.IImportService.StartImport(System.Collections.Generic.IEnumerable<Kentico.Xperience.UMT.Model.IUmtModel>, Kentico.Xperience.UMT.Services.ImportStateObserver?)`  
Starts import  
Parameters
|Name|Type|Summary|
|---|---|---|
|importedObjects|System.Collections.Generic.IEnumerable<Kentico.Xperience.UMT.Model.IUmtModel>|UMT model, imported objects
|importObserver|Kentico.Xperience.UMT.Services.ImportStateObserver?|Import state observer, stores current information about import with events
### StartImportAsync
`Kentico.Xperience.UMT.Services.IImportService.StartImportAsync(System.Collections.Generic.IAsyncEnumerable<Kentico.Xperience.UMT.Model.IUmtModel>, Kentico.Xperience.UMT.Services.ImportStateObserver?)`  
Starts import  
Parameters
|Name|Type|Summary|
|---|---|---|
|importedObjects|System.Collections.Generic.IAsyncEnumerable<Kentico.Xperience.UMT.Model.IUmtModel>|UMT model, imported objects
|importObserver|Kentico.Xperience.UMT.Services.ImportStateObserver?|Import state observer, stores current information about import with events


