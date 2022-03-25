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
            return new List<Item>();
            //Items private collection has 6 Operational and 4 Pretest Items.
            //Randomize the order of these items as per the requirement(with TDD)
            //The assignment will be reviewed on the basis of – Tests written first, Correct
            //logic, Well structured &clean readable code.
        }
    }
}
