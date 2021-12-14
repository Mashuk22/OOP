using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
 
    public class Product
    {
        public readonly Guid id;
        public string name;
        private int UPC { get; }
        public string manufacturer { get; set; }
        public int price { get; private set; }
        private DateTime shelfLife { get; set; }
        public int count { get; set; }
 
        public Product(string name, int price , int count, string manufacturer)
        {
            id = Guid.NewGuid();
            shelfLife = DateTime.Now;
            UPC = new Random().Next(100000);
            this.name = name;
            this.price = price;
            this.count = count;
            this.manufacturer = manufacturer;
        }

        public void getSum()
        {
            Console.WriteLine($"Общая сумма продукта равна {count * price}");

        }

        public void getPriceRef(ref float price)
        {
            price++;
        }

        public void getPriceOut(out float price)
        {
            price = this.price;
        }

        public void getInfo()
        {
            Console.WriteLine("Info about product:");
            Console.WriteLine($"id: {id}\nname: {name}\nUPC: {UPC}\nmanufacturer: {manufacturer}\nprice: {price}\nshelfLife: {shelfLife}\ncount: {count}\n");
        }


    }
}
