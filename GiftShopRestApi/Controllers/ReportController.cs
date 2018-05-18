using GiftShopService.CoverModels;
using GiftShopService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GiftShopRestApi.Controllers
{
    public class ReportController : ApiController
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult GetStorageLoad()
        {
            var list = _service.GetStorageLoad();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpPost]
        public IHttpActionResult GetCustomerCustoms(ReportCoverModel model)
        {
            var list = _service.GetCustomerCustoms(model);
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpPost]
        public void SaveGiftPrice(ReportCoverModel model)
        {
            _service.SaveGiftPrice(model);
        }

        [HttpPost]
        public void SaveStorageLoad(ReportCoverModel model)
        {
            _service.SaveStorageLoad(model);
        }

        [HttpPost]
        public void SaveCustomerCustoms(ReportCoverModel model)
        {
            _service.SaveCustomerCustoms(model);
        }
    }
}
