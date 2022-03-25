using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Arcadia.Testlet.Test
{
    public class Tests
    {
        [Test]
        public void TestValidItemsCount()
        {
            Assert.Catch<ArgumentException>(() => CreateTestlet(0));
            Assert.Catch<ArgumentException>(() => CreateTestlet(Testlet.ItemsCountInTestlet - 1));
            Assert.Catch<ArgumentException>(() => CreateTestlet(Testlet.ItemsCountInTestlet + 1));

            Assert.DoesNotThrow(() => CreateTestlet(Testlet.ItemsCountInTestlet));

            Testlet CreateTestlet(int itemsCount)
            {
                return new Testlet("id", Enumerable.Range(0, itemsCount).Select(_ => new Item("", 0)).ToList());
            }
        }

        [Test]
        public void TestRandomize()
        {
            var items = new List<Item>
            {
                new Item("0pretest", ItemTypeEnum.Pretest),
                new Item("1pretest", ItemTypeEnum.Pretest),
                new Item("2pretest", ItemTypeEnum.Pretest),
                new Item("3pretest", ItemTypeEnum.Pretest),

                new Item("4operational", ItemTypeEnum.Operational),
                new Item("5operational", ItemTypeEnum.Operational),
                new Item("6operational", ItemTypeEnum.Operational),
                new Item("7operational", ItemTypeEnum.Operational),
                new Item("8operational", ItemTypeEnum.Operational),
                new Item("9operational", ItemTypeEnum.Operational)
            };

            var randomizeResult = CreateTestlet().Randomize();

            //Test count
            Assert.AreEqual(Testlet.ItemsCountInTestlet, randomizeResult.Count);

            //Test uniqueness
            Assert.AreEqual(randomizeResult.Count, new HashSet<Item>(randomizeResult).Count);

            //Test types - first should be preset items
            Assert.IsTrue(randomizeResult
                .Take(Testlet.MandatoryFirstPretestItemsCount)
                .All(item => item.ItemType == ItemTypeEnum.Pretest));

            //Test order with seed
            const int randomSeed = 0;
            var randomizeWithSeedResult = CreateTestlet(randomSeed).Randomize();

            int[] expectedOrder = new[] { 3, 0, 1, 7, 8, 5, 9, 2, 4, 6 };

            for (int index = 0; index < items.Count; index++)
            {
                Assert.AreEqual(items[expectedOrder[index]], randomizeWithSeedResult[index]);
            }


            Testlet CreateTestlet(int? seed = null)
            {
                return seed.HasValue
                    ? new Testlet("id", items, new Random(seed.Value))
                    : new Testlet("id", items);
            }
        }
    }
}