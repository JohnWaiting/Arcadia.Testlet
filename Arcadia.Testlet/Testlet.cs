namespace Arcadia.Testlet
{
    public class Testlet
    {
        internal const int ItemsCountInTestlet = 10;
        internal const int MandatoryFirstPretestItemsCount = 2;

        private readonly List<Item> _items;
        private readonly Random _random;

        internal Testlet(string testletId, List<Item> items, Random random)
        {
            if (items.Count != ItemsCountInTestlet)
            {
                throw new ArgumentException(
                    $"Invalid testlet items count. Should be {ItemsCountInTestlet}.",
                    nameof(items));
            }

            TestletId = testletId;
            _items = items;
            _random = random;
        }

        public Testlet(string testletId, List<Item> items) : this(testletId, items, new Random())
        {
        }

        public string TestletId { get; }


        public List<Item> Randomize()
        {
            return GetRandomizedItems().ToList();
        }

        private IEnumerable<Item> GetRandomizedItems()
        {
            List<Item> mandatoryPretestItems = _items
                .Where(item => item.ItemType == ItemTypeEnum.Pretest)
                .OrderBy(item => _random.Next())
                .Take(MandatoryFirstPretestItemsCount)
                .ToList();

            return mandatoryPretestItems
                .Concat(_items
                    .Except(mandatoryPretestItems)
                    .OrderBy(x => _random.Next()));
        }
    }
}
