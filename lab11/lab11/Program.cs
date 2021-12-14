using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months =
            {
                "January", "February", "March", "April", "May", "June", "July",
                "August", "September", "October", "November", "December"
            };

            Console.WriteLine("Введите n (длина строки месяцев): ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Месяцы состоящие из {n} букв: ");
            var MonthsByLength = from m in months
                                   where m.Length == n
                                   select m;

           foreach (string s in MonthsByLength)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();


            string[] SummerAndWinterMonths =
             {
                "January", "February", "June", "July",
                "August", "December"
            };
            Console.WriteLine("Только летние и зимние месяцы: ");
            var MonthsBySummerAndWinterMonths = from m in months
                                                  where SummerAndWinterMonths.Contains(m)
                                                  select m;
            foreach (string s in MonthsBySummerAndWinterMonths)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();


            Console.WriteLine("Месяца в алфавитном порядке: ");

            var MonthsByAlphabet = from m in months
                                   orderby m
                                   select m;
            foreach (string s in MonthsByAlphabet)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            Console.WriteLine("Месяцы содержащие букву «u» и длиной имени не менее 4-х: ");
            var MonthsByU = from m in months
                            where m.ToUpper().Contains('U') && 
                            m.Length >= 4
                            select m;

            foreach (string s in MonthsByU)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            //2
           

            Product prod1 = new Product("Pants", 10, 5, "Nike");
            Product prod2 = new Product("Boots", 50, 2, "Adidas"); 
            Product prod3 = new Product("Hat", 100, 1, "Gucci");
            Product prod4 = new Product("Boots", 20, 50, "Abibas");
            Product prod5 = new Product("T-Shirt", 25, 10, "Lacost");
            Product prod6 = new Product("T-Shirt", 10, 25, "Abibas");
            Product prod7 = new Product("Pants", 20, 10, "Lacost");
            Product prod8 = new Product("Jacket", 250, 1, "The North Face");
            Product prod9 = new Product("Flip flops", 80, 7, "Gucci");
            Product prod10 = new Product("T-Shirt", 110, 3, "Louis Vuitton");

            List<Product> productList = new List<Product>() 
            {prod1, prod2, prod3, prod4, prod5, prod6, prod7, prod8, prod9, prod10
            };
            
            Console.WriteLine("Товары с именем Boots: ");
            var ProductsByName = from p in productList
                                where p.name == "Boots"
                                select p;

            foreach (var s in ProductsByName)
            {
                s.getInfo();
            }
            Console.WriteLine();

            Console.WriteLine("Товары с именем T-Shirt и ценой меньше 50: ");
            var ProductsByNameAndPrice = from p in productList
                                         where p.name == "Boots" &&
                                         p.price < 50
                                         select p;

            foreach (var s in ProductsByNameAndPrice)
            {
                s.getInfo();
            }
            Console.WriteLine();

            Console.WriteLine("Число товаров с ценой больше 100: ");
            int ProductsCountByPrice = productList.Where(p => p.price> 100).Count();
            Console.WriteLine(ProductsCountByPrice);
            Console.WriteLine();

            Console.WriteLine("Товар с наибольшей ценой: ");
            int MaxPrice = (from p in productList select p.price).Max();
            var ProductWithMaxPrice = from p in productList where p.price == MaxPrice select p;
            foreach (var s in ProductWithMaxPrice)
            {
                s.getInfo();
            }
            Console.WriteLine();

            Console.WriteLine("Сортировка по производителю: ");
            var SortedByManufacturer = from p in productList 
                                       orderby p.manufacturer 
                                       select p;
            foreach (var s in SortedByManufacturer)
            {
                s.getInfo();
            }
            Console.WriteLine();

            Console.WriteLine("Сортировка по количеству: ");
            var SortedByCount = from p in productList
                                       orderby p.count
                                       select p;
            foreach (var s in SortedByCount)
            {
                s.getInfo();
            }
            Console.WriteLine();


            Console.WriteLine("Собственная сортировка: ");
            string[] TrandBrand = { "Gucci", "Louis Vuitton", "Lacost" };
            var ProductsByTrand = from p in productList
                                  where p.price > 50
                                  orderby p.price descending
                                  where TrandBrand.Contains(p.manufacturer) &&
                                  p.name == "T-Shirt" || p.name == "Flip flops"
                                  select p;
            foreach (var s in ProductsByTrand)
            {
                s.getInfo();
            }
            Console.WriteLine();


            //4 Join
            List<Manufacturer> manufacturers = new List<Manufacturer>() { 
                new Manufacturer {Name = "Gucci", Country = "Italy"},
                new Manufacturer {Name = "Abibas", Country = "China"}
            };

            var join = from p in productList
                       join m in manufacturers on p.manufacturer
                       equals m.Name
                       select new { Name = p.name, Manufacturer = p.manufacturer, Country = m.Country };

            foreach (var item in join)
            {
                Console.WriteLine($"{item.Name} - {item.Manufacturer} ({item.Country})");
            }
        }
    }
}
