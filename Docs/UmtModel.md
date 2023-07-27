## Discriminator

Discriminator is specified for all model roots, it describes which model will be picked for deserialization.

For example in JSON structure with property `$type`:
```json
{
    "$type": "DataClass"    
}
```

## UniqueId

unique id is `System.Guid` that uniquely identifies entity. This ID will be persisted to target instance and can be used for back reference. It is preferable to ensure any external entity has it before starting conversion and import for data migration checks and fast data search.