using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba5
{
    public class BKController : Bookkeeping
    {
        public void PriceByName(string productName)
        {
            int price = 0;

            foreach (dynamic item in list)
            {
                if (item is Program.Receqipt && item.ProductName == productName)
                {
                    price += item.Price;
                }
            }

            Console.WriteLine($"Общая стоимость товаров {productName} равна {price}");
        }

        public void ChequeCount()
        {
            int count = 0;

            foreach (dynamic item in list)
            {
                if (item is Program.Cheque)
                {
                    count++;
                }
            }

            Console.WriteLine($"Общая количество чеков равно {count}");
        }

        public void GetByDate(DateTime date)
        {
            Console.WriteLine($"\nВывод документов до {date}");
            foreach (dynamic item in list)
            {

                if (item.Date < date)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine($"-------------\n");
        }
    }
    abstract public class Bookkeeping
    {
        public List<dynamic> list = new List<dynamic>();
        public void Set(dynamic item)
        {
            list.Add(item);
        }
        public int Get()
        {
            return list.Count;
        }
        public bool Remove(dynamic item)
        {
            Console.WriteLine($"элемент {item.ProductName} был удален");
            return list.Remove(item);

        }
        public void Print()
        {
            foreach (dynamic item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
