using API.Repository.IRepository;
using AutoMapper;
using Packages;

namespace API.Controllers
{
    public class Packer
    {
        private readonly IMapper _mapper;
        private readonly IItems _itemsRepo;
        public Packer(IMapper mapper, IItems items)
        {
            _mapper = mapper;
            _itemsRepo = items;
        }

        public  class Item
        {
            public int Index { get; set; }
            public double Weight { get; set; }
            public double Cost { get; set; }

            public Item(int index, double weight, double cost)
            {
                Index = index;
                Weight = weight;
                Cost = cost;
            }
        }
        static void Main(string[] args)
        {
    
        string filename = args[0];

            foreach (string line in File.ReadLines(filename))
            {
                string[] parts = line.Split(':');
                int limit = int.Parse(parts[0].Trim());

                List<Items> items = new List<Items>();
                foreach (string itemPart in parts[1].Trim().Split(' '))
                {
                    string[] itemParts = itemPart.Trim('(', ')').Split(',');       
                    int index = int.Parse(itemParts[0]);
                    double weight = double.Parse(itemParts[1]);
                    double cost = double.Parse(itemParts[2].Substring(1));
                    
                }

                int[,] table = new int[items.Count + 1, limit + 1];

                for (int i = 1; i <= items.Count; i++)
                {
                    for (int w = 1; w <= limit; w++)
                    {
                        if (items[i - 1].Weight <= w)
                        {
                            table[i, w] = Math.Max((int)items[i - 1].Cost + table[i - 1, (int)(w - items[i - 1].Weight)], table[i - 1, w]);
                        }
                        else
                        {
                            table[i, w] = table[i - 1, w];
                        }
                    }
                }

                Console.WriteLine("Maximum cost for limit " + limit + ": " + table[items.Count, limit]);

                Console.WriteLine("Items in the package:");
                int j = limit;
                List<Items> packageItems = new List<Items>();
                for (int i = items.Count; i > 0 && table[i, j] != 0; i--)
                {
                    if (table[i, j] != table[i - 1, j])
                    {
                        packageItems.Add(items[i - 1]);
                        j -= (int)items[i - 1].Weight;
                    }
                }
                packageItems.Sort((a, b) => a.Index.CompareTo(b.Index));

                foreach (Items item in packageItems)
                {
                    Console.WriteLine("- Item #" + item.Index + ": weight = " + item.Weight + ", cost = €" + item.Cost);
                }
            }
        }

        
    }
}
