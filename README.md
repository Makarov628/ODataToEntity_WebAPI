# ODataToEntity_WebAPI

```json
POST https://localhost:5001/odata/DictAreas

{
    "Code": null,
    "Name": "123123 Test"
}
```

```
System.InvalidOperationException: Not found table for clr type ODataToEntity_WebAPI.DB.DictCity
         at OdataToEntity.Linq2Db.OeLinq2DbDataContext.UpdateIdentities(OeLinq2DbTable table, Int32 lastIndex)
         at OdataToEntity.Linq2Db.OeLinq2DbDataContext.SaveChanges(DataConnection dataConnection)
         at OdataToEntity.Linq2Db.OeLinq2DbDataAdapter`1.SaveChangesAsync(Object dataContext, CancellationToken cancellationToken)
         at OdataToEntity.AspNetCore.OeBatchFilterAttributeAttribute.OnActionExecuted(ActionExecutedContext context)
         at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
         at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeNextActionFilterAsync()
      --- End of stack trace from previous location ---
```
