using GiftShopService.CoverModels;
using GiftShopService.Interfaces;
using System;
using System.Web.Http;

namespace GiftShopRestApi.Controllers
{
    public class GiftController : ApiController
    {
        private readonly IGiftService _service;

        public GiftController(IGiftService service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = _service.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = _service.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }

        [HttpPost]
        public void AddElement(GiftCoverModel model)
        {
            _service.AddElement(model);
        }

        [HttpPost]
        public void UpdElement(GiftCoverModel model)
        {
            _service.UpdElement(model);
        }

        [HttpPost]
        public void DelElement(GiftCoverModel model)
        {
            _service.DelElement(model.Id);
        }
    }
}
