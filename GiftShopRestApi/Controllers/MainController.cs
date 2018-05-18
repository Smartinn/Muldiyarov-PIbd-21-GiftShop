using GiftShopService.CoverModels;
using GiftShopService.Interfaces;
using System;
using System.Web.Http;

namespace GiftShopRestApi.Controllers
{
    public class MainController : ApiController
    {
        private readonly IMainService _service;

        public MainController(IMainService service)
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

        [HttpPost]
        public void CreateCustom(CustomCoverModel model)
        {
            _service.CreateCustom(model);
        }

        [HttpPost]
        public void TakeCustom(CustomCoverModel model)
        {
            _service.TakeCustom(model);
        }

        [HttpPost]
        public void FinishCustom(CustomCoverModel model)
        {
            _service.FinishCustom(model.Id);
        }

        [HttpPost]
        public void PayCustom(CustomCoverModel model)
        {
            _service.PayCustom(model.Id);
        }

        [HttpPost]
        public void PutElementInStorage(StorageElementCoverModel model)
        {
            _service.PutElementInStorage(model);
        }
    }
}
