<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## WorkspaceModel
Model represents XbyK WorkspaceInfo

Model [discriminator](../UmtModel.md#discriminator): `Workspace`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|WorkspaceGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|WorkspaceDisplayName\*||string?||
|WorkspaceName\*||string?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### Workspace sample

```json
{
  "$type": "Workspace",
  "WorkspaceGUID": "018fe300-d522-4cc8-9888-b7248e922077",
  "WorkspaceDisplayName": "Sample Workspace",
  "WorkspaceName": "SampleWorkspace"
}
```

### Reusable content item sample in non-default workspace
This sample describes how to import reusable content item into non-default workspace
```json
{
  "$type": "ContentItemSimplified",
  "ContentItemGUID": "2867f7b2-2db4-429a-b1b7-7596a502b089",
  "ContentItemWorkspaceGUID": "018fe300-d522-4cc8-9888-b7248e922077",
  "IsSecured": false,
  "ContentTypeName": "UMT.Event",
  "Name": "EventInSampleWorkspace",
  "IsReusable": true,
  "LanguageData": [
    {
      "LanguageName": "en-US",
      "DisplayName": "Sample workspace Event - en-US",
      "VersionStatus": 2,
      "IsLatest": true,
      "UserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
      "ContentItemData": {
        "EventTitle": "en-US Sample workspace Event",
        "EventText": "en-US Sample workspace Event (reusable)",
        "EventDate": "2024-01-01T00:00:00Z",
        "EventRecurrentYearly": true,
        "EventTeaser": {
          "$assetType": "AssetData",
          "Data": "iVBORw0KGgoAAAANSUhEUgAAARsAAABlCAYAAAB9ckckAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAABAESURBVHhe7d0JkBxVHQbw/xw7u5sN4b4hXEFABQRBQBOSgAYLVOQMkOIyaFQKTdDiUCCJHBZggaCoIVYlqOG\u002BFBFEQxLuMwY5lAgkHJEjkSvJXnM53\u002Bx7tZ2X1zPdMz1vjv1\u002BVZ3t1zPztnuy75vXr4\u002BJ5QuEiKjG4uonEVFNMWyIyAmGDRE5wbAhIicYNkTkBMOGiJxg2BCREwwbInKCYUNETjBsiMgJhg0ROcGwISInGDZE5ERLXfWdfWWJZJe/INk3/yO5d5dL7n9vS371\u002B5LvWSOSSRe2Ni6xVIfEhm8osY02l/hm20l8m10kMXJ3SYzaW\u002BKbbK1qIqKoNXXY5D9aJelnHpDMkoWSefExyff1qEcqk9h2lCT3HCPJfQ\u002BV5KcOUkuJKApNGTbpxQ9K\u002BqHbJf30X9WS6MW32F7aRh8lqXHHS3xT9niIqtVUYZN\u002B5C7pu29OYVfpRbXEjdQhJ0j74ZMlvvXOagkRhdUUYZN5bpH03vkLyb7yD7WkPtoPP0Paj50qsfZOtYSIgmrosMHAbu\u002B8y6R/wS1qSf3FN9lKOk48V9o\u002B/zW1hIiCaNiwwaBvz5yLJLdqhVrSWLBr1fmNiwvvIM8eIAqiIcOm755Z0nvzFarUuBI77ymdU66UxHa7qiVE5KfhwqZn7nTp/9sfVKnxxbo2lGFnXSvJPUerJURk01Bh0/2rsyX96B9VqbkMm/ZradtvgioRkalhBhyaOWig\u002B\u002BrvSGbxfFUiIlNDhE3P3Bk1DZr45tsVp1pbe82Zkl26WJWIyKvuu1F9f75eem\u002B6XJWilTr4GOmcsu5Ac9\u002Bd10r/Q3dIbuVbakm0EGrDZ9xevPaKiAbVtWdTPFmvRkHjp/3o7xVDqFYQYt2zz1MlItLqFjb53rXSM2e6KrmV2ONzaq42cI5Q393XqRIRQd3CBmcG51a\u002BqUpu4dYStdZ721WSfe2fqkREdQmbzPMPS/\u002BDN6tS48LuVscx31el8Hpv\u002BZmaI6K6hE3vndequfDQ\u002BDHVctwF9OAyxngqDZzMC49K\u002BpG7VYloaHMeNulH/1TR4WEc5em6YF6x8WNCEGzw80U1OaRtHsWqZlAZl14QUR3Cpu/\u002BOWounM4pl0tyjwNVaUAxgH48L9LAMYNGQ\u002BBUIvvWUul/\u002BC5VIhq6nIYNjtJUMmiKxm8GjRZl4PgFDaD\u002BSn9H//x5ao5o6HJ6Ul/3tWdJ\u002Bsm/qFJwaOS2no0Xzm9Ze\u002BmkdU7W8wsPPGf11LGqNKBU0GgfTdpFzYU3fPptkvjEvqoUjblz58qiRYtUacDYsWPltNNOU6V1LV\u002B\u002BXGbOnKlK65o\u002BfbrsuOOOqtT8Tj/9dFm4cGFxm7Bt48aNU49QvTgLm/yaD\u002BXjKZ9VpfAqCZzkHgdI1wU3Fue9zLAJEjRrLzlJMv96UpXCS004RTpPjfa8IjQoBI4XGtaMGTNUaV3jx48vNkDTggULWqox2t6XZcuWtVSYNiNnu1H4FoRqICB6Zp1baPBPqCXrQyBhl0pDOOjg8Uo/fKeaGwikckHTM\u002BucqoIGMjW8OXsQCCBb0DTLpz7W3Zxs0HszgwYQQFRfzsIG4zXVCho46Klo6Ong\u002BXjtwOvPkd47rlGPDowHlYLn41qqauU\u002BeLduF2miYdp2nxAyfr2gRoL1R6/MO91www3qUWoW7sLmxcfUXHWCBo6G56\u002B9ZFJxtwmTGRze55qiChot89Ljas4dfNKjcZqwS4Hdp1aD7bLtLmEsi\u002BrLSdhkl70g\u002Be7VqlS9coGTeck/iEx\u002BdUQdNJBZ\u002Bqyac8dv92HOnMpOQWgG5hhUqXEscsdN2NTge578Age3kAgzvoI6UJdXLYIGssueV3Nu\u002BI3TtNqAsEn32nDsAxODpjE4ORrV\u002B/uLpe/\u002B9QftooDdIAzy4icCwgyOIKKoI6gNfvmYxDfeUpWqU\u002BpolB7nMAX9lPcOtOLwOsp6F6XU4XXA68xD8qeeeuo6Y0S6TsByrJe5\u002B4Pnvv7668XnmaGJ55q9F/162\u002B\u002B31a/pbdW/y7teUOq1JqwnJtSFn6gL9eD1O\u002BywQ/F9C1pXq3ESNmuvPEMyS\u002BozPoAAwYBxbLNtJb9qRXEXq9ojS9XouvAmSe4ezS0u/MIGf9A77bSTWjIIf/RBxmnQyP3Ox9HQYBAgtuCyrRd22xAA5nLNVh/C0gwZP97emu33\u002B/Xmqt1WL9vvtcF7USqsW5WTsFlz/hGSfePfqhRMrHO4JD/9BZFS3z7ZvVrSzxU\u002BwbIZtWBdfufZoPeC3S2/Hozu6QThd3jdz7Azr47sC\u002B78wgaN2tYTwLkm5YRp4IBGY47/2NYLv1/3GPzgOahLh0KtwybstuL1trDGdqGuctvnhfctTI\u002BpFTgJm4/PPEjyH76nSuUld99fhk37jcSGb6SW\u002BMt/uFK6r5u63qAwAgMXavpB2HgPgWu4wjvMdVB\u002B9fjpOPlCaf9yNJ9qYRq13ye7l\u002B1THvXhUx0/dYiZ9Zt1B/2Et/GGVy3DBo/jeWHZwjVsaGkIm3K9pVbi5tB37xo1E0z7sdMCBQ3gXr8dJ5yjSoO859rYIFAQSF7ozYS94BK7Z6H0rlUztWELGvxRlwsaNBYzaPAa9IbQIHQjQ6M1P42DNlq8TteBdbLxrj\u002Beg\u002Bfbnot1w2N6MtepHNs6ow78Lqwf6rS9Z2ao4L2xBY1eP12Xbf3wfofpDTU7J2GTz6TVXACJtkKjDzemkdhl78KWJFRpQJBbf8aNoDDDpxZCvRcRwQlw5f6obQ0GjcSERoOejhfqLvfJjtchuBBaaIhopLb6veuJ5\u002Bnnm1AfHtOTrTH7sfW69PphvfTvtYWEua3mQDTowNLrjp9\u002Bl0uUe99aiZueTYjvw451duHfgUJQaMC5rCoMyK0M/x3hlRyFyoYdbI7X9i3HH7YJDQRd/VJw9MSERonGZ06255ZjBhTYQqRcKEbBLyBMCAfdM/FO3tAwwwKP4T2ywWtNtnVpVU7CJlZqkNeUy6mZ4NKL/67mBpULAQSLeVQqt2pFqMDBc8OejxNLdai52sDhVdsfNRpxqd0d2ycsuvm2ydYzCNKzMdmW1Yst\u002BADriAD3Tnq9bcFYapvqFa6Nwk3YdI1Qc\u002BXluz8uXkeUe/u18tN/X5X\u002BhbdKz\u002BwfqVcPKne\u002BDAZ2TXg\u002BrqXCa73XU9kmvB7PDQvfDV5raBC2T2rdU7Gp9R99IwVLVNsaRT1DKWzcnGfzk4mSefkZVXILF1rqE/a0am8XUY2uH86W5D6HqFJ1bEddEDIIFPwR43FbNx89H/NT1nZExRZYflCfrtO2XtgdsX2yx2Lr7zKbf5JYL3M3EIFq68FBud8fZv3KMdcfdaAuG/yfmOc/lXp\u002Bq3HTs3Ew8OoHlx6gB4KAwYWYuAFWPU/qizn4GhnQoWLSIWR\u002Botp6HmgIepym3FRJQ61GNT0C7Gqa/K4ix7Yh6LyTN5TN9w2P\u002Ba2bGXAwlC4QdRI2ia13VnPRQ68F59NsOO/V4g3RbUeUsNtT6uQ7nFuD12NCT6iWR6US29TuvTCVCxwv2x99qQaI13unahp/JUo16nJswYj6sF1eWIYxKvz0Tt6AsdVlBhKgbtQ1lLkJmx32UHPRwrk0OENYhwPu4hf2fsTmSXzFOiO\u002BibqWGLl74Z\u002BkKrnhN36DxuBtXGg0ZsPBJzG6/fipn4\u002BGpAeJ9YRGb\u002BsZRQXrZasf66YnMyhKQX14X7ywDdgu1IVtxO4RfpqwHt51wXtrrhvqwmv1uqEuW9BgPcKsd7NzEzY4DyZiCAXbja8QEkEvNYC2MUeruUGooxaBkxj1GTXnFhqWGSSgP7UBDaZUL0iHjPmJDWHGdqKG9cMUlt86oy7bNmrme4T3zXZYH0qtG143VMZqNDdjNiM2LfRuPqlK1fMLGs0MibZ9D5X2o86S9q9OkcSu\u002B6ilA/wCpRaBE9UFmGH5BQl4d4HwPNsndSmVDqyGhd8TZr3KQV1\u002BJ9r58dtW9E7w/gatC3X4/X\u002B0MidhA8m9xqi56pQLGvBeJ9V5\u002Bk9k2A\u002Bul45jpxYvaxg\u002B43ZJjTtePTpwiNxP1IGT3HO0mnMPDcGv5\u002BLdXUDDQaMq11vB42isLoIG9PqHCYdyUJfe1lL14nEcISu1reg96jOk/erS2\u002BAqoBuNk0PfkF36rKyZOdjIKxEkaLw3vopvO0o2uGL9G41nX1kia6YPXDuFIKnka2LCwhXsXef/TpWah94VwKQbUb0bil4f0OtUKiyCMrdVT5XC7hjqwvsVxfo1O2dhA6vPOUxyK15RpXAQCqWu4gbzDnttBx4hw86ynLz33puyetpgg3EROJ2TL5XUISeoEtHQ42w3ClKjv67mwkOvppRqbuWJAAlyE3XsUlUClyi0jT5SlYiGJrdhM25ioeWFvMhSKXUrhyjuGRwkcHKrKuvVtI2fWAicENeHEbUgp2ETG7GJtE84RZXC8buzXhRBo5UKHDyGr4SpRPuEk9Uc0dDlNGwgdfhkNRcOGrv3mywhyqDRdOB4L9TEvPnd4EGlvjhJ4lutfz9goqHG6QCx1nvbVdJ393WqFA7O\u002BMWJeAiAckETdIDYD8ZpbL2pwJJtssHVCyW\u002ByVZqAdHQ5bxnAx3HTJX4lutfDBcE7verbwNRa1UFTUHHcWczaIiUuoQN7lbXceJ5qhBetSHgAm7a3v6Vb6kSEdUnbAra9p8gqcPs15REJfdu\u002BNtXRqXjlIvUHBFB3cIGOgsNMrnbfqoUPXzHeP/8m1RpUHyL7dVcbXSecVmk14IRtYK6DBB75d57o3gnv9wHwb9XKqzkXgcXr7jGF99JYXPzH62Uvnt/qx6NVvsR35SOkyrfRSRqVXUPG8i8/LSsveyUwky/WtKcUmOOls5vX6lKRORV190oLbnb/tJ19qziwHGzwmF2Bg2Rv4Zp3cm9D5auc\u002BcO7Oo0GfRobOfzENGghtiN8souf1G6r5tW/JqWZoDD2x0nnqtKROSn4cIG8N1RPbPPl/RT96slDSgWk87Jl0lqfHX36CEaKhoybDQcMeq98aeq1DjwXeQ4jyYxsjY3cidqRQ0dNpB9c6n03XqlpBc/qJbUUVu7dBw3rXh4m4jCafiw0dJP3Sd998yS7GvPqyVupb50srQf\u002BV2Jb7yFWkJEYTRN2GjpJ\u002B6V/vk3rnNT81qJdXRJavzEYtDEtxyplhJRJZoubDRcipB\u002B/B5JP/1A8SzkKOGM47YDDpcUbuWZTKmlRFSNpg0bLwRP5qXHi9/ggN2s3PvvqEcCiCeK39iJyxnwvU74upVY14bqQSKKSkuEjSm/\u002BoPiFd8Infzq9yXfs0Ykky5sbVwk1VEIkxES32jz4s2x4jX8HnIiGtSSYUNEjad5L0YioqbCsCEiJxg2ROQEw4aInGDYEJETDBsicoJhQ0ROMGyIyAmGDRE5wbAhIicYNkTkBMOGiJxg2BCREwwbInKCYUNETsTefmsF72dDRDUXu0v6GTZN5P3E2/JO2zLpj/WoJUTNgbtRTYRBQ81L5P9tTCaxUJPzFgAAAABJRU5ErkJggg==",
          "ContentItemGuid": "2867f7b2-2db4-429a-b1b7-7596a502b089",
          "Identifier": "57c26660-ef2f-4288-8f30-886135c2c8fb",
          "Name": "byteArraySample.jpg",
          "Extension": ".jpg"
        }
      }
    }
  ]
}
```