using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace doctor
{
    class Program
    {
        static void Main()
        {
            SurgeonList surgeonList = new SurgeonList();

            surgeonList.InitSurgeons();

            while (true)
            {
                int id;

                Console.WriteLine("-------------------------------\n|  #1 Show info of surgeon    |\n|  #2 Find appropriate doctor |\n|  #3 Make an operation       |\n|  #4 Exit\t\t      |\n-------------------------------");
                int choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {

                    case 1:

                        Console.Clear();

                        Console.Write("Enter id of surgeon ");
                        id = Int32.Parse(Console.ReadLine()) - 1;

                        Console.Clear();

                        surgeonList.ShowAllInfo(id);
                        Console.WriteLine("\n");

                        Console.ReadLine();
                        Console.Clear();

                        break;


                    case 2:

                        Console.Clear();

                        string title;
                        Console.Write("What operation do u need to perform? ");
                        title = Console.ReadLine();

                        id = surgeonList.FindBestSurgeon(title);

                        if (id != -1)
                        {
                            Console.WriteLine("The best surgeon compared to others would be #" + (id + 1) + "  " + surgeonList.GetName(id));
                        }

                        else
                        {
                            Console.WriteLine("Noone performs such operation");
                        }

                        Console.ReadLine();
                        Console.Clear();

                        break;


                    case 3:

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


                    case 4:

                        Environment.Exit(1);
                        break;
                }
            }
        }
    }
}
