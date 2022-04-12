using System;
using System.Collections.Generic;

namespace Lahiye_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> StudentsList = new List<Student>();
            List<Student> ObshiStuList = new List<Student>(); 
            List<Group> GroupsList = new List<Group>();
            AddGroup(GroupsList);
            AddStudent(StudentsList, ObshiStuList, GroupsList);
            ShowInfo(GroupsList , StudentsList);
        }

        static void AddGroup(List<Group> grouplist)
        {
            int OnlineCheck = 0;
            Console.Write("Yaratmaq istediyiniz qruplarin sayini yazin : ");
            int say = int.Parse(Console.ReadLine());
            Group[] Groups = new Group[say];
            for (int i = 0; i < say; i++)
            {
                Groups[i] = new Group();
                do
                {
                    Console.WriteLine("Dersin ne formatda olacagini sechin : ");
                    Console.WriteLine("1.Online.");
                    Console.WriteLine("2.Offline.");
                    Console.Write("Sechiminiz : ");
                    OnlineCheck = int.Parse(Console.ReadLine());
                    switch (OnlineCheck)
                    {
                        case 1:
                            Groups[i].IsOnline = true;
                            break;
                        case 2:
                            Groups[i].IsOnline = false;
                            break;
                        default:
                            Console.WriteLine("Bele opsiya yoxdur! Yeniden sechim edin : ");
                            break;
                    }
                } while (OnlineCheck != 1 && OnlineCheck != 2);
                if (Groups[i].IsOnline)
                {
                    Groups[i].Limit = 15;
                }
                else
                {
                    Groups[i].Limit = 10;
                }
                grouplist.Add(Groups[i]);
            }
        }

        static void ShowInfo(List<Group> GroupsList, List<Student> StudentsList)
        {
            foreach (var item in GroupsList)
            {
                Console.WriteLine($"No : {item.No}\nOnline : {item.IsOnline}\nStudents number : {StudentsList.Count}");
            }
        }

        static void AddStudent(List<Student> StudentsList , List<Student> ObshiStuList , List<Group> GroupsList)
        {
            int typecheck = 0;
            Console.Write("Yaratmaq istediyiniz studentlerin sayini daxil edin : ");
            int count = int.Parse(Console.ReadLine());
            StudentsList = new List<Student>();
            Student[] Students = new Student[count];
            for (int i = 0; i < count; i++)
            {
                Students[i] = new Student();
                Console.Write("Full name : ");
                Students[i].Fullname = Console.ReadLine();
                while (Students[i].Fullname == "" || Students[i].Fullname == " ")
                {
                    Console.WriteLine("Sevh format yeniden elave et");
                    Console.Write("Full name : ");
                    Students[i].Fullname = Console.ReadLine();
                }
                do
                {
                    Console.WriteLine("Studentin qarantili olub olmamsini secin : ");
                    Console.WriteLine("1.Qarantili");
                    Console.WriteLine("2.Qarantisiz");
                    Console.Write("Sechiminiz : ");
                    typecheck = int.Parse(Console.ReadLine());
                    switch (typecheck)
                    {
                        case 1:
                            Students[i].Type = true;
                            break;
                        case 2:
                            Students[i].Type = false;
                            break;
                        default:
                            Console.WriteLine("Bele opsiya yoxdur! Yeniden sechin edin : ");
                            break;
                    }
                } while (typecheck != 1 && typecheck != 2);
                ObshiStuList.Add(Students[i]);
                Console.WriteLine("Studente qrup secin :");
                int a = 0;
                foreach (var item in GroupsList)
                {
                    a++;
                    Console.WriteLine($"{a}.{item.No}");
                }
                Console.Write("Sechiminiz :");
                string selectgroup = Console.ReadLine();
                foreach (var item in GroupsList)
                {
                    if (selectgroup.ToUpper() == item.No)
                    {
                        Students[i].GroupNo = item.No;
                        StudentsList.Add(Students[i]);
                    }
                }
            }
        }
    }
}
