using GiftShopService.CoverModels;
using GiftShopService.Interfaces;
using System;
using System.Web.Http;

namespace GiftShopRestApi.Controllers
{
    public class ElementController : ApiController
    {
        private readonly IElementService _service;

        public ElementController(IElementService service)
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
        public void AddElement(ElementCoverModel model)
        {
            _service.AddElement(model);
        }

        [HttpPost]
        public void UpdElement(ElementCoverModel model)
        {
            _service.UpdElement(model);
        }

        [HttpPost]
        public void DelElement(ElementCoverModel model)
        {
            _service.DelElement(model.Id);
        }
    }
}
