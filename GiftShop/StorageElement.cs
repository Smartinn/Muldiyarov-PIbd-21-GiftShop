
namespace GiftShopModel
{
    public class StorageElement
    {
        public int Id { get; set; }

        public int StorageId { get; set; }

        public int ElementId { get; set; }

        public int Count { get; set; }

        public virtual Storage Storage { get; set; }

        public virtual Element Element { get; set; }
    }
}
