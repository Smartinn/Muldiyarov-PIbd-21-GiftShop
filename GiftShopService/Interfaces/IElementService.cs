using GiftShopService.ViewModels;
using GiftShopService.CoverModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiftShopRestApi.Attributies;

namespace GiftShopService.Interfaces
{

    [CustomInterface("Интерфейс для работы с компонентами")]
    public interface IElementService
    {
        [CustomMethod("Метод получения списка компонентов")]
        List<ElementViewModel> GetList();

        [CustomMethod("Метод получения компонента по id")]
        ElementViewModel GetElement(int id);

        [CustomMethod("Метод добавления компонента")]
        void AddElement(ElementCoverModel model);

        [CustomMethod("Метод обновления информации по компоненту")]
        void UpdElement(ElementCoverModel model);

        [CustomMethod("Метод удаления компонента")]
        void DelElement(int id);
    }
}
