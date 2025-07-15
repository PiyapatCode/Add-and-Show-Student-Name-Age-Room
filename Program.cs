using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;
namespace Studentpro{
    class Mainprogram {
        static void Main(string[] args) {
            //
            int Choosemenulist;
            //
            List<string> menuclass = new List<string> {". M101",". M102",". M103" };
            List<string> menulist = new List<string> {". Add Student",". Show All Student",". Exit" };
            List<StorageStudentInfo> studentM101 = new List<StorageStudentInfo> { };
            List<StorageStudentInfo> studentM102 = new List<StorageStudentInfo> { };
            List<StorageStudentInfo> studentM103 = new List<StorageStudentInfo> { };
            List<StorageStudentInfo> StorageM = new List<StorageStudentInfo> { };
            string Back = "";
            do
            {
                Console.WriteLine("----------StudentInfo----------");
                for (int x = 0; x < menulist.Count; x++)
                {
                    Console.WriteLine(x + 1 + menulist[x]);
                }
                Console.Write("Choose : ");
                Choosemenulist = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("-------------------------------");

                if (Choosemenulist == 1)
                {
                    string Addstudentagain = "";
                    do
                    {
                        bool Err = false;
                        StorageStudentInfo S = new StorageStudentInfo();
                        Console.WriteLine("----------StudentAdd----------");
                        Console.Write("Enter his/her Name : ");
                        S.Name = Console.ReadLine();
                        Console.Write("Enter his/her Age : ");
                        S.Age = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("----------Choose Room----------");
                        for (int i = 0; i < menuclass.Count; i++)
                        {
                            Console.WriteLine(i + 1 + menuclass[i]);
                        }
                        Console.Write("Choose Room (Enter Only | M101 | M102 | M103 | ): ");
                        S.Room = Console.ReadLine();
                        if (S.Room == "M101" || S.Room == "1")
                        {
                            studentM101.Add(S);
                            StorageM.Add(S);
                        }
                        else if (S.Room == "M102" || S.Room == "2")
                        {
                            studentM102.Add(S);
                            StorageM.Add(S);
                        }
                        else if (S.Room == "M103" || S.Room == "3")
                        {
                            studentM103.Add(S);
                            StorageM.Add(S);
                        }
                        else {
                            Console.WriteLine("----------Error----------");
                            Err = true;
                        }
                        if (Err == true)
                        {
                            Console.WriteLine("Try Again ? (y/n)");
                        }
                        else if (Err == false) {
                            Console.WriteLine("Success!!");
                            Console.WriteLine("Add more ? (y/n)");
                        }
                           
                        Addstudentagain = Console.ReadLine();
                    } while (Addstudentagain.ToUpper() == "Y");
                }
                else if (Choosemenulist == 2)
                {

                    int ChooseRoom;
                    if (StorageM.Count == 0)
                    {
                        Console.WriteLine("No Student in This List");
                        Console.WriteLine("-------------------------------");
                    }
                    else if (StorageM.Count > 0)
                    {
                        Console.WriteLine("----------Choose Room----------");
                        for (int i = 0; i < menuclass.Count; i++)
                        {
                            Console.WriteLine(i + 1 + menuclass[i]);
                        }
                        Console.Write("Choose Room : ");
                        ChooseRoom = Convert.ToInt32(Console.ReadLine());
                        if (ChooseRoom == 1)
                        {
                            if (studentM101.Count <= 0)
                            {
                                Console.WriteLine("===!!!No Student in here!!!===");
                            }
                            else if (studentM101.Count > 0)
                            {
                                for (int r1 = 0; r1 < studentM101.Count; r1++)
                                {
                                    Console.WriteLine(r1 + 1 + ". " + studentM101[r1].Name + "                      AGE   " + studentM101[r1].Age);
                                }
                            }
                        }
                        else if (ChooseRoom == 2)
                        {
                            if (studentM102.Count <= 0)
                            {
                                Console.WriteLine("===!!!No Student in here!!!===");
                            }
                            else if (studentM101.Count > 0)
                            {
                                for (int r1 = 0; r1 < studentM102.Count; r1++)
                                {
                                    Console.WriteLine(r1 + 1 + ". " + studentM102[r1].Name + "                      AGE   " + studentM102[r1].Age);
                                }
                            }
                        }
                        else if (ChooseRoom == 3)
                        {
                            if (studentM103.Count <= 0)
                            {
                                Console.WriteLine("===!!!No Student in here!!!===");
                            }
                            else if (studentM101.Count > 0)
                            {
                                for (int r1 = 0; r1 < studentM103.Count; r1++)
                                {
                                    Console.WriteLine(r1 + 1 + ". " + studentM103[r1].Name + "                      AGE   " + studentM103[r1].Age);
                                }
                            }
                        }
                        else {
                            Console.WriteLine("----------Error----------");
                        }

                    }
                }
                else {
                    Console.WriteLine("----------Error----------");
                }
                    Console.WriteLine("Do you want Back ? (y/n)");
                Back = Console.ReadLine();
            } while (Back.ToUpper() == "Y");
            if (Choosemenulist == 3)
            {
                Console.WriteLine("----------End----------");
            }
            Console.WriteLine("----------End----------");
        }
    }
}