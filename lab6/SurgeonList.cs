using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace lab6
{
    class SurgeonList
    {
        public SurgeonList()
        {
            performOperation += delegate (int id, string title)
            {
                Random rnd = new Random();

                int result = 0;
                int number = 0;

                number = rnd.Next(1, 101);

                if (number <= (int)(surgeonList[id].GetOperationPercentage(title) * 100 + 1))
                {
                    Console.Clear();
                    for (int i = 0; i < 20; ++i)
                    {
                        displayMessage?.Invoke(".");
                        System.Threading.Thread.Sleep(200);
                    }

                    surgeonList[id].AddStatisticOperation(title, true);

                    result = 1;
                }

                else
                {
                    Console.Clear();
                    for (int i = 0; i < 20; ++i)
                    {
                        displayMessage?.Invoke(".");
                        System.Threading.Thread.Sleep(200);
                    }

                    surgeonList[id].AddStatisticOperation(title, false);

                    result = 0;
                }

                return result;
            };
        }

        public delegate void displayMes(string mes);
        public delegate int performOp(int id, string title);

        public event displayMes displayMessage;
        public event performOp performOperation;
        
        public void SetDisplayMessageInSurgeon(Surgeon.displayMes del)
        {
            for (int i = 0; i < surgeonList.Count; ++i)
            {
                surgeonList[i].displayMessage += del;
            }
        }

        public void SortOpByLength()
        {
            for(int i = 0; i < surgeonList.Count; ++i)
            {
                surgeonList[i].SortOperationsByLength();
            }
        }

        public void SortOpByName()
        {
            for (int i = 0; i < surgeonList.Count; ++i)
            {
                surgeonList[i].SortOperationsByName();
            }
        }

        public void InitSurgeons()
        {
            string[] fileInput = File.ReadAllLines("surgeons.txt");


            for (int i = 0; fileInput[i] != "eof";)
            {
                string name = fileInput[i++];
                int age = Int32.Parse(fileInput[i++]);
                int workExperience = Int32.Parse(fileInput[i++]);
                string qualification = fileInput[i++];
                string scienceDegree = fileInput[i++];

                Surgeon surgeon = new Surgeon(name, age, workExperience, qualification, scienceDegree);


                List<Days> daysOfWork = new List<Days>();

                while(fileInput[i] != "///////////////")
                {

                    string day = fileInput[i];
                    
                    switch(day)
                    {
                        case "Monday":
                            daysOfWork.Add(Days.Monday);
                            break;
                        case "Tuesday":
                            daysOfWork.Add(Days.Tuesday);
                            break;
                        case "Wednesday":
                            daysOfWork.Add(Days.Wednesday);
                            break;
                        case "Thursday":
                            daysOfWork.Add(Days.Thursday);
                            break;
                        case "Friday":
                            daysOfWork.Add(Days.Friday);
                            break;
                        case "Saturday":
                            daysOfWork.Add(Days.Saturday);
                            break;
                        case "Sunday":
                            daysOfWork.Add(Days.Sunday);
                            break;
                        default:
                            break;
                    }

                    ++i;
                }

                if (daysOfWork.Count != 0)
                {
                    surgeon.schedule = new DaySchedule(daysOfWork);
                }



                while (fileInput[i++] == "///////////////")
                {
                    string title = fileInput[i++];
                    string difficulty = fileInput[i++];
                    int successedOp = Int32.Parse(fileInput[i++]);
                    int complicatedOp = Int32.Parse(fileInput[i++]);

                    Operation op = new Operation(title, difficulty, successedOp, complicatedOp);
                    surgeon.AddOperation(op);
                }

                surgeonList.Add(surgeon);

            }
        }

        public void ShowAllInfo(int id)
        {
            try
            {
                displayMessage?.Invoke("#" + (surgeonList[id].Id + 1) + "      NAME: " + surgeonList[id].Name + "\t\tAGE: " + surgeonList[id].Age + "\n\tWORK EXPERIENCE: " + surgeonList[id].WorkExperience + "\tQUALIFICATION: " + surgeonList[id].Qualification);
                displayMessage?.Invoke("\n");
                displayMessage?.Invoke("Days of work: ");
                surgeonList[id].schedule.ShowDaysOfWork();
                displayMessage?.Invoke("\n\t" + surgeonList[id].Name + "'s operations:\n");
                surgeonList[id].ShowAllOperations();
            }
            catch(System.ArgumentOutOfRangeException)
            {
                displayMessage?.Invoke("no surgeons with that index");
            }
        }

        public string GetName(int id)
        {
            return surgeonList[id].Name;
        }

        public int FindBestSurgeon(string title)
        {
            int id = -1;
            double currentPercentage = -1;
            double maxPercentage = -1;

            for (int i = 0; i < surgeonList.Count; ++i)
            {
                currentPercentage = surgeonList[i].GetOperationPercentage(title);

                if (currentPercentage > maxPercentage)
                {
                    maxPercentage = currentPercentage;
                    id = i;
                }
            }

            return id;
        }

        public int PerformOperation()
        {
            int result = -1;
            Random rnd = new Random();


            displayMessage?.Invoke("What operation do u need to perform? ");
            string title = Console.ReadLine();

            displayMessage?.Invoke("Which doctor you want to choose? ");

            int id = 0;
            try
            {
                id = Int32.Parse(Console.ReadLine()) - 1;
            }

            catch(System.FormatException)
            {
                displayMessage?.Invoke("wrong input");
            }

            try
            {
                if (surgeonList[id].GetOperationPercentage(title) != -1)
                {
                    displayMessage?.Invoke("\nWhat day you want to choose?");
                    string day = Console.ReadLine();

                    if (surgeonList[id].schedule.CheckAvailibility(day))
                    {
                        displayMessage?.Invoke("The doctor " + surgeonList[id].Name + " has " + surgeonList[id].GetOperationPercentage(title) * 100 + " % on success.\nDo u want to perform the operation?(1 - yes, 2 - no)  ");
                        int choice = 0;

                        try
                        {
                            choice = Int32.Parse(Console.ReadLine());
                        }

                        catch (System.FormatException)
                        {
                            displayMessage?.Invoke("wrong input");
                        }

                        if (choice == 1)
                        {
                            result = performOperation(id, title); // calling event to perform operation.
                        }

                        else if (choice == 0)
                        {
                            result = -1;
                        }

                        else
                        {
                            Console.WriteLine("wrong input");
                            result = -1;
                        }

                        return result;
                    }
                    else
                    {
                        displayMessage?.Invoke($"{surgeonList[id].Name} rests on that day");
                        return -3;
                    }
                }

                else
                {
                    displayMessage?.Invoke($"{surgeonList[id].Name} doesnt perform such operations");
                    return -2;
                }
            }
            catch(System.ArgumentOutOfRangeException)
            {
                displayMessage?.Invoke("no doctors with that id");
                return -2;
            }
            
        }

        private List <Surgeon> surgeonList = new List <Surgeon>();
    }
}