using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.OData.Edm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using OdataToEntity.Query;
using OdataToEntity.AspNetCore;
using ODataToEntity_WebAPI.DB;

namespace ODataToEntity_WebAPI.Controllers
{
    [Route("odata/[controller]")]
    public class DictAreasController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DictAreasController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task Get(string table)
        {
            var edmModel = (IEdmModel)_httpContextAccessor.HttpContext.RequestServices.GetService(typeof(IEdmModel));
            OeModelBoundProvider modelBoundProvider = OeAspHelper.CreateModelBoundProvider(edmModel, 50, false);
            await OeAspQueryParser.Get(_httpContextAccessor.HttpContext, modelBoundProvider).ConfigureAwait(false);
        }

        [HttpPost]
        public void Post(OeDataContext dataContext, DictArea obj)
        {
            dataContext.Update(obj);
        }

        [HttpPatch]
         public void Post(OeDataContext dataContext, IDictionary<String, Object> obj)
        {
            dataContext.Update(obj);
        }
    }
}