using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace lab6
{
    class Program
    {

        static void Main()
        {
            SurgeonList surgeonList = new SurgeonList();

            surgeonList.InitSurgeons();
            surgeonList.displayMessage += (mes) => Console.WriteLine(mes); // setting lambda to surgeonList for displaying information

            surgeonList.SetDisplayMessageInSurgeon((mes) => Console.WriteLine(mes)); // passing lambda to surgeonList, that sets this lambda to event
                                                                                     // in every object of Surgeon class ( surgeonList contains surgeons )

            while (true)
            {
                int id = 0;
                   
                
                Console.WriteLine("---------------------------------\n|  #1 Show info of surgeon      |\n|  #2 Sort operations by length |\n|  #3 Sort operations by name   |\n|  #4 Find appropriate doctor   |\n|  #5 Make an operation         |\n|  #6 Exit\t\t        |\n---------------------------------");
                int choice = 0;
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                    if (choice > 6 || choice < 1)
                        throw new Exception();
                }
                catch
                {
                    Console.WriteLine("wrong input");
                    Console.ReadLine();
                    Console.Clear();
                }

                switch (choice)
                {

                    case 1:

                        Console.Clear();

                        Console.Write("Enter id of surgeon ");

                        try
                        {
                            id = Int32.Parse(Console.ReadLine()) - 1;
                        }

                        catch (System.FormatException)
                        {
                            Console.WriteLine("wrong input");
                            Console.ReadLine();
                            Console.Clear();

                            break;
                        }

                        Console.Clear();

                        surgeonList.ShowAllInfo(id);
                        Console.WriteLine("\n");

                        Console.ReadLine();
                        Console.Clear();

                        break;

                    case 2:

                        Console.Clear();
                        surgeonList.SortOpByLength();
                        Console.Write("Operations have been sorted !\n\n");
                        
                        break;

                    case 3:

                        Console.Clear();
                        surgeonList.SortOpByName();
                        Console.Write("Operations have been sorted !\n\n");

                        break;

                    case 4:

                        Console.Clear();

                        string title;
                        Console.Write("What operation do u need to perform? ");
                        title = Console.ReadLine();

                        id = surgeonList.FindBestSurgeon(title);

                        if (id != -1)
                        {
                            Console.WriteLine("The best surgeon compared to others would be #" + (id + 1) + "  " + surgeonList.GetName(id));
                        }

                        else if (id != -2)
                        {
                            Console.WriteLine("Noone performs such operation");
                        }

                        
                        Console.ReadLine();
                        Console.Clear();

                        break;


                    case 5:

                        Console.Clear();

                        int result = surgeonList.PerformOperation();

                        if (result == 1)
                        {
                            Console.WriteLine("The operation was successful!\n");
                        }

                        else if (result == 0)
                        {
                            Console.WriteLine("Unfortuntaly, there were some problems with operation\n");
                        }

                        else if (result == -1)
                        {
                            Console.WriteLine("Operation was delayed..\n");
                        }


                        break;


                    case 6:

                        Environment.Exit(1);
                        break;
                }
            }
        }
    }
}
