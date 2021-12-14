using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Concurrent;


namespace lab10
{
    public class Game
    {
        public string Name { set; get; }
        public int Price { set; get; }

        public Game(string name, int price)
        {
            Name = name;
            Price = price;
        }

    }

    public class GameList : IEnumerable<Game>
    {
        List<Game> list = new List<Game>();

        public void Print()
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Name}");
            }
        }
        public void Add(Game item)
        {
            list.Add(item);
        }
        public void Clear()
        {
            list.Clear();
        }
        public bool Remove(Game item)
        {
            return list.Remove(item);
        }
        public int Search(Game item)
        {
            int key = 1;
            foreach (Game x in list)
            {

                if (x == item)
                {
                    return key;
                }
                key++;
            }
            return -1;
        }

        public IEnumerator<Game> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
    public class IntBlockingCollection
    {
        public BlockingCollection<int> list { set; get; }

        public IntBlockingCollection()
        {
            list = new BlockingCollection<int>(4);
 
        }

        public void Print()
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine();
        }

        public void Add(int item)
        {
            list.Add(item);
        }
        public void TryAdd(int item)
        {
            list.TryAdd(item);
        }

        public void Delete(int value)
        {
            for (int i=0; i<value; i++)
            {
                list.TryTake(out i);
            }
        }
    }


}
