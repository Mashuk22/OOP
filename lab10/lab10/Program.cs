using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Game GTA = new Game("GTA", 20);
            Game CS = new Game("CS", 5);
            Game DOTA = new Game("DOTA", 0);
            Game LOL = new Game("LOL", 10);

            GameList GameLib = new GameList();
            GameLib.Add(GTA);
            GameLib.Add(CS);
            GameLib.Add(DOTA);
            GameLib.Add(LOL);

            Console.WriteLine("Библиотека игр: ");
            GameLib.Print();

            if (GameLib.Search(LOL) != -1)
                Console.WriteLine($"Игра LOL есть в библиотеке под номером {GameLib.Search(LOL)}\n");
            
            //2
            IntBlockingCollection bc = new IntBlockingCollection();

            bc.Add(0);
            for (int i = 1; i< 8; i++)
            { 
                bc.TryAdd(i);
            }
            bc.list.CompleteAdding();
            Console.WriteLine("Print");
            bc.Print();
            Console.WriteLine("Deleting");
            bc.Delete(2);
            Console.WriteLine("Deleting");

            Console.WriteLine("Print");
            bc.Print();

            //2d Another Collection

            Dictionary<int, int> GenericDictionary = new Dictionary<int, int>();
            for (int i = 0; i < 10; i++)
            {
                GenericDictionary.Add(i, i);
            }

            Console.WriteLine("<-- Обобщенный словарь -->");
            Console.WriteLine("Коллекция int в словаре: ");
            foreach (var item in GenericDictionary)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.WriteLine("Удаление элементов: ");
            for (int i = 0; i < 5; i++)
            {
                GenericDictionary.Remove(i);
            }
            foreach (var item in GenericDictionary)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.WriteLine("Преобразование словаря в список: ");
            List<int> DictionaryInList = GenericDictionary.Values.ToList();
            foreach (var item in DictionaryInList)
            {
                Console.WriteLine($"{item}");
            }

            int count = DictionaryInList.Count;
            Console.Write($"\nИщем 3 элемент из {count} имеющихся: ");
            int search = 6;
            int thereIs = 0;

            Console.WriteLine($"Поиск элемента {search} в списке");
            foreach (var item in DictionaryInList)
            {
                if (item == search)
                {
                    Console.WriteLine("Такой элемент есть!");
                    continue;
                }
                thereIs++;
                if (thereIs == count)
                {
                    Console.WriteLine("Такого элемента нет!");
                }
            }


            //3

            ObservableCollection<Game> obsGames = new ObservableCollection<Game>
            {
                new Game("Sims", 15),
                new Game("Tarkov", 25),
                new Game("Mario", 10)
            };

            Console.WriteLine("\nСобытия Observable коллекции: ");
            obsGames.CollectionChanged += GamesCollectionChanged;

            obsGames.Add(new Game("Sonic", 40));
            obsGames.RemoveAt(1);
            obsGames[0] = new Game("Assasin's Creed", 19);

            Console.WriteLine("\nСписок игр: ");
            foreach (var item in obsGames)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();


            static void GamesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add: 
                        Game newGame = e.NewItems[0] as Game;
                        Console.WriteLine($"Добавлен новый объект: {newGame.Name}");
                        break;
                    case NotifyCollectionChangedAction.Remove: 
                        Game oldGame = e.OldItems[0] as Game;
                        Console.WriteLine($"Удален объект: {oldGame.Name}");
                        break;
                    case NotifyCollectionChangedAction.Replace: 
                        Game replacedGame = e.OldItems[0] as Game;
                        Game replacingGame = e.NewItems[0] as Game;
                        Console.WriteLine($"Объект {replacedGame.Name} заменен объектом {replacingGame.Name}");
                        break;
                }
            }
        }
    }
}
