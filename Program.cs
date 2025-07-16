using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;
using System.IO;
using System.Net;
namespace Studentpro
{
    class Mainprogram
    {
        
        
        static void Main(string[] args)
        {
            //
            int Choosemenulist;
            string Editstudent = "";
            int StorageM = 0;
            string Deletestudent = "";
            //
            List<string> menuclass = new List<string> { ". M101", ". M102", ". M103" };
            List<string> menulist = new List<string> { ". Add Student", ". Show All Student", ". Edit Student", ". Delete Student", ". Exit" };
            List<StorageStudentInfo> studentM101 = new List<StorageStudentInfo> { };
            List<StorageStudentInfo> studentM102 = new List<StorageStudentInfo> { };
            List<StorageStudentInfo> studentM103 = new List<StorageStudentInfo> { };
         
            
            
                List<string> save101student = new List<string>();
            List<string> save102student = new List<string>();
            List<string> save103student = new List<string>();
            //
            
            
            
            if (File.Exists("save101student.txt"))
            {
                string[] countsave101 = File.ReadAllLines("save101student.txt");
                foreach (var x in countsave101)
                {
                    string[] line = x.Split('|');
                    if (line.Length != 3) { continue; }
                    string name = line[0];
                    string age = line[1];
                    string room = line[2];
                    StorageStudentInfo objsave = new StorageStudentInfo { Name = name, Age = age, Room = room };
                    if (room == "M101" || room == "1")
                    {

                        save101student.Add(objsave.Room);
                        save101student.Add(objsave.Name);
                        save101student.Add(objsave.Age);
                    }
                }
            }
            else if (File.Exists("save102student.txt"))
            {
                string[] countsave102 = File.ReadAllLines("save102student.txt");
                foreach (var i in countsave102)
                {
                    string[] line102 = i.Split('|');
                    if (line102.Length != 3) { continue; }
                    string name102 = line102[0];
                    string age102 = line102[1];
                    string room102 = line102[2];
                    StorageStudentInfo objsave102 = new StorageStudentInfo { Name = name102, Age = age102, Room = room102 };
                    if (room102 == "M102" || room102 == "2")
                    {
                        save102student.Add(objsave102.Room);
                        save102student.Add(objsave102.Name);
                        save102student.Add(objsave102.Age);
                    }
                }
            }
            else if (File.Exists("save103student.txt"))
            {
                string[] countsave103 = File.ReadAllLines("save103student.txt");
                foreach (var o in countsave103)
                {
                    string[] line103 = o.Split('|');
                    if (line103.Length != 3) { continue; }
                    string name103 = line103[0];
                    string age103 = line103[1];
                    string room103 = line103[2];
                    StorageStudentInfo objsave103 = new StorageStudentInfo { Name = name103, Age = age103, Room = room103 };
                    if (room103 == "M103" || room103 == "3")
                    {
                        save103student.Add(objsave103.Room);
                        save103student.Add(objsave103.Name);
                        save103student.Add(objsave103.Age);
                    }
                }
            }
           
                //
                string Back = "";
            do
            {
                int selectstudentedit;
                Console.WriteLine("----------StudentInfo----------");
                for (int x = 0; x < menulist.Count; x++)
                {
                    Console.WriteLine(x + 1 + menulist[x]);
                }
                Console.Write("Choose : ");
                Choosemenulist = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("-------------------------------");
                //1
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
                        S.Age = Console.ReadLine();

                        for (int i = 0; i < menuclass.Count; i++)
                        {
                            Console.WriteLine(i + 1 + menuclass[i]);
                        }
                        Console.Write("Choose Room (Enter Only | M101 | M102 | M103 | ): ");
                        S.Room = Console.ReadLine();
                        if (S.Room == "M101" || S.Room == "1")
                        {
                            studentM101.Add(S);
                          
                                save101student.Add($"{S.Name}|{S.Age}|M101");
                            File.WriteAllLines("student101.text", save101student);
                            StorageM += 1;
                        }
                        else if (S.Room == "M102" || S.Room == "2")
                        {
                            studentM102.Add(S);
                            save102student.Add($"{S.Name}|{S.Age}|M102");
                            File.WriteAllLines("student102.text", save102student);
                            StorageM += 1;
                        }
                        else if (S.Room == "M103" || S.Room == "3")
                        {
                            studentM103.Add(S);
                            save103student.Add($"{S.Name}|{S.Age}|M103");
                            File.WriteAllLines("student103.text", save103student);
                            StorageM += 1;
                        }
                        else
                        {
                            Console.WriteLine("----------Error----------");
                            Err = true;
                        }
                        if (Err == true)
                        {
                            Console.WriteLine("Try Again ? (y/n)");
                        }
                        else if (Err == false)
                        {
                           
                            
                           
                            Console.WriteLine("Success!!");
                            Console.WriteLine("Add more ? (y/n)");
                        }

                        Addstudentagain = Console.ReadLine();
                    } while (Addstudentagain.ToUpper() == "Y");
                }
                //2
                else if (Choosemenulist == 2)
                {

                    int ChooseRoom;
                    if (StorageM == 0)
                    {
                        Console.WriteLine("No Student in This List");
                        Console.WriteLine("-------------------------------");
                    }
                    else if (StorageM > 0)
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
                            else if (studentM102.Count > 0)
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
                            else if (studentM103.Count > 0)
                            {
                                for (int r1 = 0; r1 < studentM103.Count; r1++)
                                {
                                    Console.WriteLine(r1 + 1 + ". " + studentM103[r1].Name + "                      AGE   " + studentM103[r1].Age);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("----------Error----------");
                        }

                    }
                }
                //3

                else if (Choosemenulist == 3)
                {
                    Console.WriteLine("------Choose Room to Edit------");
                    for (int x = 0; x < menuclass.Count; x++)
                    {
                        Console.WriteLine(x + 1 + menuclass[x]);
                    }
                    Console.Write("Choose Class to Edit : ");
                    Editstudent = Console.ReadLine();
                    if (Editstudent == "M101" || Editstudent == "1")
                    {
                        for (int x = 0; x < studentM101.Count; x++)
                        {
                            Console.WriteLine(x + 1 + ". " + studentM101[x].Name + "                    " + studentM101[x].Age);
                        }
                        Console.Write("Select Student to Edit : ");
                        selectstudentedit = Convert.ToInt32(Console.ReadLine());
                        if (selectstudentedit <= studentM101.Count)
                        {
                            Console.WriteLine($"----------Edit {studentM101[selectstudentedit - 1].Name}---------- ");
                            Console.Write("Edit Name : ");
                            studentM101[selectstudentedit - 1].Name = Console.ReadLine();
                         
                            Console.Write("Edit Age  : ");
                            studentM101[selectstudentedit - 1].Age = Console.ReadLine();
                            
                                File.WriteAllLines("save101student",save101student);
                            
                            Console.WriteLine("Edit Success!");
                        }
                        else
                        {
                            Console.WriteLine("----------Error----------");
                        }
                    }
                    else if (Editstudent == "M102" || Editstudent == "2")
                    {
                        for (int x = 0; x < studentM102.Count; x++)
                        {
                            Console.WriteLine(x + 1 + ". " + studentM102[x].Name + "                    " + studentM102[x].Age);
                        }
                        Console.Write("Select Student to Edit : ");
                        selectstudentedit = Convert.ToInt32(Console.ReadLine());
                        if (selectstudentedit <= studentM102.Count)
                        {
                            Console.WriteLine($"----------Edit {studentM102[selectstudentedit - 1].Name}---------- ");
                            Console.Write("Edit Name : ");
                            studentM102[selectstudentedit - 1].Name = Console.ReadLine();
                            Console.Write("Edit Age  : ");
                            studentM102[selectstudentedit - 1].Age = Console.ReadLine();
                           
                                File.WriteAllLines("save102student", save102student);
                            
                            Console.WriteLine("Edit Success!");
                        }
                        else
                        {
                            Console.WriteLine("----------Error----------");
                        }
                    }
                    else if (Editstudent == "M103" || Editstudent == "3")
                    {

                        for (int x = 0; x < studentM103.Count; x++)
                        {
                            Console.WriteLine(x + 1 + ". " + studentM103[x].Name + "                    " + studentM103[x].Age);
                        }
                        Console.Write("Select Student to Edit : ");
                        selectstudentedit = Convert.ToInt32(Console.ReadLine());
                        if (selectstudentedit <= studentM103.Count)
                        {
                            Console.WriteLine($"----------Edit {studentM103[selectstudentedit - 1].Name}---------- ");
                            Console.Write("Edit Name : ");
                            studentM103[selectstudentedit - 1].Name = Console.ReadLine();
                            Console.Write("Edit Age  : ");
                            studentM103[selectstudentedit - 1].Age = Console.ReadLine();
                            
                                File.WriteAllLines("save103student", save103student);
                            
                            Console.WriteLine("Edit Success!");
                        }
                        else
                        {
                            Console.WriteLine("----------Error----------");
                        }
                        //
                    }
                }
                //4
                else if (Choosemenulist == 4)
                {
                    if (StorageM >= 1)
                    {
                        Console.WriteLine("----------Delete Student----------");
                        for (int x = 0; x < menuclass.Count; x++)
                        {
                            Console.WriteLine(x + 1 + menuclass[x]);
                        }
                        Console.Write("Choose Room : ");
                        Deletestudent = Console.ReadLine();
                        if (Deletestudent == "M101" || Deletestudent == "1" && studentM101.Count > 0)
                        {
                            for (int i = 0; i < studentM101.Count; i++)
                            {
                                Console.WriteLine(i + 1 + ". " + studentM101[i].Name + "                    " + studentM101[i].Age);
                            }
                            Console.Write("Choose student to delete : ");
                            int deleteindex = Convert.ToInt32(Console.ReadLine()) - 1;
                            if (deleteindex >= 0 && deleteindex <= studentM101.Count)
                            {
                                studentM101.RemoveAt(deleteindex);
                                StorageM -= 1;
                                foreach (var x in studentM101)
                                {
                                    File.WriteAllLines("save101student", save101student);
                                }
                                Console.WriteLine("Delete Success!!");
                            }
                            else
                            {
                                Console.WriteLine("Delete fail!!");
                            }

                        }
                        else if (Deletestudent == "M102" || Deletestudent == "2" && studentM102.Count > 0)
                        {
                            for (int i = 0; i < studentM102.Count; i++)
                            {
                                Console.WriteLine(i + 1 + ". " + studentM102[i].Name + "                    " + studentM102[i].Age);
                            }
                            Console.Write("Choose student to delete : ");
                            int deleteindex = Convert.ToInt32(Console.ReadLine()) - 1;
                            if (deleteindex >= 0 && deleteindex <= studentM102.Count)
                            {
                                studentM102.RemoveAt(deleteindex);
                                StorageM -= 1;
                                foreach (var x in studentM102)
                                {
                                    File.WriteAllLines("save102student", save102student);
                                }
                                Console.WriteLine("Delete Success!!");
                            }
                            else
                            {
                                Console.WriteLine("Delete fail!!");
                            }
                        }
                        else if (Deletestudent == "M103" || Deletestudent == "3" && studentM103.Count > 0)
                        {
                            for (int i = 0; i < studentM103.Count; i++)
                            {
                                Console.WriteLine(i + 1 + ". " + studentM103[i].Name + "                    " + studentM103[i].Age);
                            }
                            Console.Write("Choose student to delete : ");
                            int deleteindex = Convert.ToInt32(Console.ReadLine()) - 1;

                            if (deleteindex >= 0 && deleteindex <= studentM103.Count)
                            {
                                studentM103.RemoveAt(deleteindex);
                                StorageM -= 1;
                                foreach (var x in studentM103)
                                {
                                    File.WriteAllLines("save103student", save103student);
                                }
                                Console.WriteLine("Delete Success!!");
                            }
                            else
                            {
                                Console.WriteLine("Delete fail!!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("----------Error----------");
                        }
                    }
                    else if (StorageM < 1)
                    {
                        Console.WriteLine("No student to delete!!");
                    }
                }
                else if (Choosemenulist == 5)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("----------Error----------");
                }
                Console.WriteLine("Do you want Back ? (y/n)");
                Back = Console.ReadLine();
                
            } while (Back.ToUpper() == "Y");
            
            Console.WriteLine("----------End----------");
        }
    }
}
