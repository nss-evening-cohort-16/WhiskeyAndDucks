using WhiskeyAndDucks.Models;

namespace WhiskeyAndDucks.DataAccess
{
    public class WhiskeyRepository
    {
        private static List<Whiskey> _whiskeys = new List<Whiskey>()
        {
            new Whiskey()
            {
                Id = 1,
                Name = "Jack Daniels",
                Price = 30.99,
                Proof = 80,
                StockQuantity = 100
            },
            new Whiskey()
            {
                Id = 2,
                Name = "Woodford Reserve",
                Price = 100.35,
                Proof = 80,
                StockQuantity = 15
            },
            new Whiskey()
            {
                Id = 3,
                Name = "Dickel",
                Price = 60.99,
                Proof = 80,
                StockQuantity = 50
            },
            new Whiskey()
            {
                Id = 4,
                Name = "Pappy VanWinkle",
                Price = 999.99,
                Proof = 80,
                StockQuantity = 2
            },
        };

        internal object GetByName(string name)
        {
            var match = _whiskeys.FirstOrDefault(x => x.Name == name);
            return match;
        }

        internal List<Whiskey> GetAll()
        {
            return _whiskeys;
        }
    }
}
