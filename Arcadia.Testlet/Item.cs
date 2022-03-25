namespace Arcadia.Testlet
{
    public class Item
    {
        public Item(string itemId, ItemTypeEnum itemType)
        {
            ItemId = itemId;
            ItemType = itemType;
        }

        public string ItemId { get; }

        public ItemTypeEnum ItemType { get; }
    }
}
