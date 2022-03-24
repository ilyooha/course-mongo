using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Data.Products.Models;

namespace Data.Products
{
    public class ProductGenerator : CollectionGenerator
    {
        private readonly Random _random = new();
        private readonly Fixture _fixture = new();

        private readonly string[] _adjectives =
        {
            "Chocolate",
            "Vanilla",
            "Banana",
            "Strawberry",
            "Blueberry",
            "Grand",
            "Delicious",
            "Amazing",
            "Best",
            "Berry",
            "Protein"
        };

        private readonly string[] _objectives =
        {
            "Cookie",
            "Bar",
            "Ice Cream",
            "Donut",
            "Brownie",
            "Cake",
            "Cheesecake"
        };

        private readonly int[] _volumes = { 250, 330, 500, 1000 };

        private readonly string[] _manufacturers =
        {
            "Mom & co.",
            "Best bite",
            "All Stars",
            "Tasty",
            "Delicious but Healthy",
            "Unforgettable",
            "Nice Butter",
            "Brothers & Carbs"
        };

        private ProductType[] _productTypes =
        {
            ProductType.Donut,
            ProductType.ChocolateBar,
            ProductType.Cookie,
            ProductType.SodaDrink,
            ProductType.Cake,
            ProductType.Pancake
        };

        public override async Task Generate(int count, Stream output, CancellationToken ct = default)
        {
            var documents = Enumerable.Range(0, count)
                .Select(i => GetRandomProduct());

            await WriteToFile(documents, output, ct);
        }

        private Product GetRandomProduct()
        {
            var type = _productTypes[_random.Next(0, _productTypes.Length)];

            return type switch
            {
                ProductType.Donut => GetRandomDonut(),
                ProductType.Cake => GetRandomCake(),
                ProductType.Cookie => GerRandomCookie(),
                ProductType.Pancake => GetRandomPancake(),
                ProductType.ChocolateBar => GetRandomChocolateBar(),
                ProductType.SodaDrink => GetRandomSodaDrink(),
                _ => throw new NotSupportedException(type.ToString())
            };
        }

        private SodaDrink GetRandomSodaDrink()
        {
            return new SodaDrink
            {
                Id = GetRandomId(),
                Name = GetRandomName(),
                Manufacturer = GetRandomManufacturer(),
                NutritionFacts = GetRandomNutritionFacts(),
                VolumeMl = GetRandomVolumeMl()
            };
        }

        private ChocolateBar GetRandomChocolateBar()
        {
            return new ChocolateBar
            {
                Id = GetRandomId(),
                Name = GetRandomName(),
                Manufacturer = GetRandomManufacturer(),
                NutritionFacts = GetRandomNutritionFacts(),
            };
        }

        private Cookie GerRandomCookie()
        {
            return new Cookie
            {
                Id = GetRandomId(),
                Name = GetRandomName(),
                Manufacturer = GetRandomManufacturer(),
                NutritionFacts = GetRandomNutritionFacts(),
            };
        }

        private Pancake GetRandomPancake()
        {
            return new Pancake
            {
                Id = GetRandomId(),
                Name = GetRandomName(),
                Manufacturer = GetRandomManufacturer(),
                NutritionFacts = GetRandomNutritionFacts(),
            };
        }

        private Cake GetRandomCake()
        {
            return new Cake
            {
                Id = GetRandomId(),
                Name = GetRandomName(),
                Manufacturer = GetRandomManufacturer(),
                NutritionFacts = GetRandomNutritionFacts(),
            };
        }

        private Donut GetRandomDonut()
        {
            return new Donut
            {
                Id = GetRandomId(),
                Name = GetRandomName(),
                Manufacturer = GetRandomManufacturer(),
                NutritionFacts = GetRandomNutritionFacts(),
                Shell = _fixture.Create<bool>()
            };
        }

        private NutritionFacts GetRandomNutritionFacts()
        {
            var protein = GetRandomProtein();
            var carbs = GetRandomCarbs();
            var fat = GetRandomFat();
            var energy = Math.Round(CalcEnergy(protein, carbs, fat), 2);

            return new NutritionFacts
            {
                Protein = protein,
                Carbs = carbs,
                Fat = fat,
                Energy = energy
            };
        }

        private string GetRandomName()
        {
            var adjective = _adjectives[_random.Next(0, _adjectives.Length)];
            var objective = _objectives[_random.Next(0, _objectives.Length)];

            return $"{adjective} {objective}";
        }

        private string GetRandomManufacturer()
        {
            return _manufacturers[_random.Next(0, _manufacturers.Length)];
        }

        private Oid GetRandomId()
        {
            return new Oid
            {
                Value = _fixture.Create<Guid>().ToString("N")[..24]
            };
        }

        private double GetRandomFat()
        {
            double one = _random.Next(1, 40);
            double two = _random.Next(0, 100);

            return one + two / 100;
        }

        private double GetRandomCarbs()
        {
            double one = _random.Next(10, 70);
            double two = _random.Next(0, 100);

            return one + two / 100;
        }

        private int GetRandomVolumeMl()
        {
            var volume = _volumes[_random.Next(0, _volumes.Length)];
            return volume;
        }

        private double GetRandomProtein()
        {
            double one = _random.Next(2, 30);
            double two = _random.Next(0, 100);

            return one + two / 100;
        }

        private double CalcEnergy(double protein, double carbs, double fat)
        {
            return protein * 4 + carbs * 4 + fat * 9;
        }
    }
}