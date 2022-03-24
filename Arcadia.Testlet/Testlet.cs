namespace Arcadia.Testlet
{
    public class Testlet
    {
        private List<Item> Items;

        public Testlet(string testletId, List<Item> items)
        {
            TestletId = testletId;
            Items = items;
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
