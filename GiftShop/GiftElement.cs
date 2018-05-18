
namespace GiftShopModel
{
    public class GiftElement
    {
        public int Id { get; set; }

        public int GiftId { get; set; }

        public int ElementId { get; set; }

        public int Count { get; set; }

        public virtual Gift Gift { get; set; }

        public virtual Element Element { get; set; }
    }
}
