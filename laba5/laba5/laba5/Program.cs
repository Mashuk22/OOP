using System;
using System.Diagnostics;


namespace laba5
{
    public class Program
    {
        enum Days:byte
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
        public struct Time
        {
            public int hours;
            public int minutes;
            public int seconds;

            public Time(int h, int m, int s)
            {
                hours = h;
                minutes = m;
                seconds = s;
            }

            public void GetTime()
            {
                Console.WriteLine($"hours: {hours}  minutes: {minutes}  seconds: {seconds}");
            }
        }
        
        public class Organization
        {
            public string OrgName {get; set;}

            public Organization()
            {
                OrgName = "NoName";
            }
            public void PrintOrgName()
            {
                Console.WriteLine(OrgName);
            }

            public override string ToString()
            {
                return ($"Org Name: {OrgName}");
            }
        }

        public abstract class Document: Organization, IDate
        {
            public DateTime Date {get; set;}

            private string productName = "No Name";
            public string ProductName
            {
                get
                {
                    return productName;
                }
                set 
                {
                    Debug.Assert(value != "");

                    try
                    {
                        if (value == null)
                        {
                            throw new Exceptions.NoProductNameException("\n---ERROR---\nУ продукта должно быть именя!");
                        }
                        else if (value == "")
                        {
                            throw new Exceptions.NoProductNameException("\n---ERROR---\nУ продукта должно быть имя!");
                        }
                        else productName = value;
                    }
                    catch (Exceptions.NoProductNameException ex)
                    {
                        Console.WriteLine(ex.Message); 
                    }

                }
            }

            private int price = 0;
            public int Price
            {
                get
                {
                    return price;
                }
                set
                {
                    
                    
                    try
                    {
                        if (value < 0)
                        {
                            throw new Exceptions.NegativeNumberException("\n---ERROR---\nЦена продукта меньше нуля!");
                        }
                        else if (value == 0)
                        {
                            throw new Exceptions.WrongDataException("\n---ERROR---\nЦена продукта равна нулю!");
                        }
                        else price = value;
                    }
                    catch (Exceptions.NegativeNumberException ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                    catch (Exceptions.WrongDataException ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                }
            }
            public virtual void PrintDate()
            {
                Console.WriteLine(Date.ToString());
            }

            
            public override string ToString()
            {
                return ($"\n{base.ToString()}\nDate: {Date}");
            }
        }

        public class Receqipt : Document
        {
            public static string name = "Receqipt";
            public Receqipt()
            {
                Date = new DateTime(2021, 10, 6);
            }

            public override string ToString()
            {
                 return ($"{base.ToString()}\nDoc Name: {name}\nProduct Name: {ProductName}\nPrice: {Price}");
            }
        }

        public class Waybill : Document
        {
            public static string name = "Waybill";

            public Waybill()
            {
                Date = new DateTime(2021, 10, 6);
            }

            public override void PrintDate()
            {
                Console.WriteLine(Date.DayOfWeek);
            }

            public override string ToString()
            {
                 return ($"{base.ToString()}\nDoc Name: {name}\nProduct Name: {ProductName}\nPrice: {Price}");
            }
        }

        interface IDate
        {
            DateTime Date { get; set; }
            void PrintDate();
        }

        public sealed class Cheque : Document, IDate
        {

            public static string name = "Cheque";

            new public DateTime Date {get; set;}
            
            public override void PrintDate()
            {
                Console.WriteLine("PrintDate() - Abstract");
            }
             void IDate.PrintDate()
            {
                Console.WriteLine("PrintDate() - Interface");
            }

            public override string ToString()
            {
                 return ($"{base.ToString()}\nDoc Name: {name}\nProduct Name: {ProductName}\nPrice: {Price}");
            }
            
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер лабы 5 или 7");
            string symb = Console.ReadLine();
            Console.Clear();
            switch (symb)
            {
                case "5":
                    {
                        Receqipt receqipt = new Receqipt();
                        receqipt.PrintDate();
                        receqipt.PrintOrgName();

                        Waybill waybill = new Waybill();
                        waybill.PrintDate();
                        waybill.OrgName = "Apple";
                        waybill.PrintOrgName();

                        Cheque cheque = new Cheque();
                        cheque.PrintDate();
                        ((IDate)cheque).PrintDate();

                        Console.WriteLine($"\n-----\n{waybill as Waybill}\n-----\n");

                        if (waybill is Waybill)
                        {
                            Console.WriteLine("is - True");
                        }
                        else
                        {
                            Console.WriteLine("is - False");
                        }

                        Waybill document = null;
                        Organization org = document as Organization;

                        if (org != null)
                        {
                            Console.WriteLine($"as convert \n");
                        }
                        else { Console.WriteLine($"as don't convert \n"); }



                        Printer printer = new Printer();

                        dynamic[] array = new dynamic[] { receqipt, waybill, cheque, printer };
                        for (int i = 0; i < array.Length; i++)
                        {
                            printer.IAmPrinting(array[i]);
                        }

                        Console.WriteLine($"\n---Struct test---");
                        Time time = new Time(8, 39, 13);
                        time.GetTime();


                        Console.WriteLine($"\n---Enum test---");
                        Console.WriteLine(Days.Friday);

                        Console.WriteLine($"\n---List test---");
                        BKController bkController = new BKController();

                        Receqipt rec1 = new Receqipt();
                        rec1.ProductName = "Telephone";
                        rec1.Price = 10;
                        rec1.Date = new DateTime(21, 01, 20);

                        Receqipt rec2 = new Receqipt();
                        rec2.ProductName = "Telephone";
                        rec2.Price = 10;
                        rec2.Date = new DateTime(21, 01, 19);

                        Receqipt rec3 = new Receqipt();
                        rec3.ProductName = "TV";
                        rec3.Price = 10;
                        rec3.Date = new DateTime(21, 01, 18);


                        Cheque cq1 = new Cheque();
                        cq1.Date = new DateTime(21, 01, 17);

                        Cheque cq2 = new Cheque();
                        cq2.Date = new DateTime(21, 01, 16);


                        Waybill wb1 = new Waybill();
                        wb1.ProductName = "Telephone";
                        wb1.Price = 10;
                        wb1.Date = new DateTime(21, 01, 15);

                        Waybill wb2 = new Waybill();
                        wb2.ProductName = "Telephone";
                        wb2.Price = 10;
                        wb2.Date = new DateTime(21, 01, 14);

                        bkController.Set(rec1);
                        bkController.Set(rec2);
                        bkController.Set(rec3);
                        bkController.Set(cq1);
                        bkController.Set(cq2);
                        bkController.Set(wb1);
                        bkController.Set(wb2);

                        Console.WriteLine($"Длина списка равна {bkController.Get()}");

                        DateTime date = new DateTime(21, 01, 18);
                        bkController.GetByDate(date);

                        bkController.PriceByName("Telephone");

                        bkController.Remove(rec1);
                        Console.WriteLine($"Длина списка равна {bkController.Get()}");

                        bkController.PriceByName("Telephone");

                        bkController.ChequeCount();
                        bkController.Print();
                        break;
                    }
                case "7":
                    {
                        
                        Laba7();
                        break;
                    }
                default:
                    Console.WriteLine("Вы нажали неизвестную букву");
                    break;
            }

            void Laba7()
            {
                //1
                Waybill waybill = new Waybill();
                try
                {
                    waybill.ProductName = "Watch";
                    waybill.Price = 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Описание ошибки:");
                    Console.WriteLine(ex.TargetSite);
                    Console.WriteLine(ex.Source);
                    Console.WriteLine(ex.StackTrace);
                }
                Console.WriteLine(waybill.ToString());
                Console.ReadLine();

                //2
                Receqipt receqipt = new Receqipt();
                try
                {
                    receqipt.ProductName = "";
                    receqipt.Price = 50;
                }
                catch (Exceptions.WrongDataException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine(receqipt.ToString());
                Console.ReadLine();

                //3
                Receqipt receqipt2 = new Receqipt();
                try
                {
                    receqipt2.ProductName = "TV";
                    receqipt2.Price = 150;
                    receqipt2.Price = -150;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Возникла непредвиденная ошибка, описание ошибки:");
                    Console.WriteLine(ex.TargetSite);
                    Console.WriteLine(ex.Source);
                    Console.WriteLine(ex.StackTrace);
                }
                finally
                {
                    Console.WriteLine("Обработка ошибок завершена -Блок finally-");
                }
                Console.WriteLine(receqipt2.ToString());
                Console.ReadLine();

                //4
                try
                {
                    receqipt2.ProductName = null;
                    receqipt2.Price = 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Возникла непредвиденная ошибка, описание ошибки:");
                    Console.WriteLine(ex.TargetSite);
                    Console.WriteLine(ex.Source);
                    Console.WriteLine(ex.StackTrace);
                }
                Console.WriteLine(receqipt2.ToString());
                Console.ReadLine();

                //5
                try
                {
                    receqipt2.ProductName = null;
                    object prod = "Mouse";
                    int test = (int)prod;
                }
                catch (Exceptions.WrongDataException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                } 
                finally
                {
                    Console.WriteLine("Обработка ошибок завершена -Блок finally-");
                }
                Console.WriteLine(receqipt2.ToString());

            }

            Console.WriteLine("\n----EOF----");
            Console.ReadLine();
            
        
        }

    }
}
