using System;

namespace laba3
{

    partial class Product
    {
        static Product()
        {
            Console.WriteLine("Создан первый продукт");
        }

    }
    partial class Product
    {

        private Product()
        {
            this.id = Guid.NewGuid();
            objectCount++;
        }
        public Product(float price) : this()
        {
            this.price = price;
        }

        public Product(float price, int count) : this()
        {
            this.price = price;
            this.count = count;
            Console.WriteLine(this.id);
        }
        public Product(string name, int price = 1, int count = 1) : this()
        {
            this.name = name;
            this.price = price;
            this.count = count;
        }

        private static int objectCount = 0;
        const int shopNumber = 22;
        public readonly Guid id;
        public string name;

        private int UPC { get; }
        private int manufacturer { get; set; }
        public float price { get; private set; }
        private DateTime shelfLife { get; set; }
        public int count { get; set; }


        public static int getObjectCount()
        {
            return objectCount;
        }
        public void getSum()
        {
            Console.WriteLine($"Общая сумма продукта равна {Math.Round(count * price, 2)}");

        }

        public void getPriceRef(ref float price)
        {
            price++;
        }

        public void getPriceOut(out float price)
        {
            price = this.price;
        }

        public static void getInfo()
        {
            Console.WriteLine($"id\nname\nUPC\nmanufacturer\nprice\nshelfLife\ncount\n");
        }

        public override bool Equals(object obj)
        {
            Product product;
            if (obj == null || (product = obj as Product) == null)
            {
                return false;
            }
            return this.name == product.name;
        }

        public bool Equals(Product obj)
        {
            if (obj == null)
            {
                return false;
            }
            return this.name == obj.name;
        }

        public override int GetHashCode()
        {
            return UPC;
        }

        public override string ToString()
        {
            return ($"\nid {this.id}\nname {this.name}\nUPC {this.UPC}\nmanufacturer {this.manufacturer}\nprice {this.price}\nshelfLife {this.shelfLife}\ncount {this.count}\n");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var pr1 = new Product(price: 10.12f);
            pr1.count = 10;
            pr1.getSum();

            var pr2 = new Product(price: 12.99f, count: 10);
            pr2.getSum();

            var pr3 = new Product(name: "MacBook");
            pr3.getSum();

            float priceRef = 5;
            pr3.getPriceRef(ref priceRef);
            Console.WriteLine($"Use ref {priceRef}");

            pr3.getPriceOut(out float priceOut);
            Console.WriteLine($"Use out {priceOut}");
            Product.getInfo();


            Console.WriteLine($"Общее количество элемнетов {Product.getObjectCount()}");


            Console.WriteLine(pr2.Equals(pr3));
            pr2.name = "MacBook";
            Console.WriteLine(pr2.Equals(pr3));

            Console.WriteLine(pr2.GetHashCode());

            Console.WriteLine(pr2.ToString());

            Console.WriteLine(pr2.GetType());

            Product[] productArr = { pr1, pr2, pr3 };
            int count = 0;
            foreach (var item in productArr)
            {
                count++;
                if (item.name == "MacBook")
                {
                    Console.WriteLine($"product {count}\n{item.ToString()}");
                }
                if (item.price < 11)
                {
                    Console.WriteLine(item.GetHashCode());
                }


            }

            var pr4 = new { name = "pr4", price = 100, count = 2 };
            Console.WriteLine(pr4.GetType());


        }
    }

}
