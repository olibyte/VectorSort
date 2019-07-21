﻿using System;
using System.Collections.Generic;

namespace Vector
{

    public class AscendingIntComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return A - B;
        }
    }

    public class DescendingIntComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return B - A;
        }
    }

    public class EvenNumberFirstComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return A % 2 - B % 2;
        }
    }

    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return Id + "[" + Name + "]";
        }
        //compares this (current) element to another element and returns an integer value that is
        //less than zero, when the current instance precedes the object specified by the CompareTo method in the sort order;
        //zero, when this current instance occurs in the same position in the sort order as the object specified by CompareTo method;
        //greater than zero, when this current instance follows the object specified by the CompareTo method in the sort order.
        public int CompareTo(Student otherStudent)
        {
        // A null value means that this object is greater.
        if (otherStudent == null) return 1;
        else if ( this.Id == otherStudent.Id) return 0;
        else if ( this.Id > otherStudent.Id) return 1;
        else return -1;

        //This else block could be used in place of lines 48-50.
        // else  return this.Id.CompareTo(otherStudent.Id);

        //These blocks sorts the Students alphabetically. 
        //      string A = Name;
        //      string B = otherStudent.Name;
        //      int count = 0;
        //      if (A == B)
        //      {
        //          return 0;
        //      }
        //      //determine how number of characters in each name. The longest name will be the Count used for iteration
        //      if (A.Length > B.Length)
        //      {
        //          count = A.Length;
        //      }
        //      else
        //      {
        //          count = B.Length;
        //      }
        //      for (int i = 0; i < count; i++)
        //      {
        //          //current instance precedes the object specified by the CompareTo method in the sort order.
        //          //Consider A = 'Andy', B = 'Bob'
        //          //i.e. If the 'A' in Andy occurs alphabetically before the 'B' in Bob, return -1.
        //          if (A[i] < B[i])
        //          {
        //              return -1;
        //          }
        //          //current instance occurs in the same position in the sort order as the object specified
        //        //by the CompareTo method;
        //        //Consider A = 'Andy', B = 'Alice'
        //        //i.e. If the 'A' in Andy occurs in the same position in the alphabet as the 'A' in Alice, return 0.
        //        //Note: Since both names start with A, the next occurence (character) of each name will be used for comparison.
        //        else if (A[i] == B[i])
        //        {
        //            return 0;
        //        }
        //        //current instance FOLLOWS the object specified by the CompareTo method in the sort order.
        //        //Consider A = 'Chris', B = 'Bob'
        //        //i.e. If the 'C' in Chris follows the 'B' in Bob in the alphabet, so return 1.
        //        else
        //        {
        //            return 1;
        //        }
        //    }
        //    return 0;
        

        }
        //sorts a vector of students in ascending order of IDs
        public class AscendingIDComparer : IComparer<Student>
        {
            public int Compare(Student A, Student B)
            {
                return A.Id - B.Id;
            }
        }
        //sorts a vector of students in descending order of names (compareTo),
        //breaking ties by descending order of ids.
        public class DescendingNameDescendingIdComparer : IComparer<Student>
        {
            public int Compare(Student A, Student B)
            {
                if (A.Name.Equals(B.Name))
                {
                    return B.Id - A.Id;
                }
                return B.Name.CompareTo(A.Name);
            }
        }

        class Tester
        {
            private static bool CheckIntSequence(int[] certificate, Vector<int> vector)
            {
                if (certificate.Length != vector.Count) return false;
                for (int i = 0; i < certificate.Length; i++)
                {
                    if (certificate[i] != vector[i]) return false;
                }
                return true;
            }

            static void Main(string[] args)
            {
                Vector<int> vector = null;
                string result = "";

                // test 1
                try
                {
                    Console.WriteLine("\nTest A: Run a sequence of operations: ");
                    Console.WriteLine("Create a new vector by calling 'Vector<int> vector = new Vector<int>(50);'");
                    vector = new Vector<int>(50);
                    Console.WriteLine("Add a sequence of numbers 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9");
                    vector.Add(2); vector.Add(6); vector.Add(8); vector.Add(5); vector.Add(5); vector.Add(1); vector.Add(8); vector.Add(5);
                    vector.Add(3); vector.Add(5); vector.Add(7); vector.Add(1); vector.Add(4); vector.Add(9);
                    if (!CheckIntSequence(new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 }, vector)) throw new Exception("Vector stores an incorrect sequence of integers after adding new elements");
                    Console.WriteLine("Sort the integers in the default order defined by the native CompareTo() method");
                    vector.Sort();
                    int[] array = new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 };
                    Array.Sort(array, 0, 14);
                    Console.WriteLine("Resulting order: " + vector.ToString());
                    if (!CheckIntSequence(array, vector)) throw new Exception("Vector stores an incorrect sequence of integers after sorting them");
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "A";
                }
                catch (Exception exception)
                {
                    Console.WriteLine(" :: FAIL");
                    Console.WriteLine(exception.ToString());
                    result = result + "-";
                }

                // test 2
                try
                {
                    Console.WriteLine("\nTest B: Run a sequence of operations: ");
                    Console.WriteLine("Create a new vector by calling 'Vector<int> vector = new Vector<int>(50);'");
                    vector = new Vector<int>(50);
                    Console.WriteLine("Add a sequence of numbers 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9");
                    vector.Add(2); vector.Add(6); vector.Add(8); vector.Add(5); vector.Add(5); vector.Add(1); vector.Add(8);
                    vector.Add(5); vector.Add(3); vector.Add(5); vector.Add(7); vector.Add(1); vector.Add(4); vector.Add(9);
                    if (!CheckIntSequence(new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 }, vector)) throw new Exception("Vector stores an incorrect sequence of integers after adding new elements");
                    Console.WriteLine("Sort the integers in the order defined by the AscendingIntComparer class");
                    vector.Sort(new AscendingIntComparer());
                    int[] array = new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 };
                    Array.Sort(array, 0, 14, new AscendingIntComparer());
                    Console.WriteLine("Resulting order: " + vector.ToString());
                    if (!CheckIntSequence(array, vector)) throw new Exception("Vector stores an incorrect sequence of integers after sorting them");
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "B";
                }
                catch (Exception exception)
                {
                    Console.WriteLine(" :: FAIL");
                    Console.WriteLine(exception.ToString());
                    result = result + "-";
                }

                // test 3
                try
                {
                    Console.WriteLine("\nTest C: Run a sequence of operations: ");
                    Console.WriteLine("Create a new vector by calling 'Vector<int> vector = new Vector<int>(50);'");
                    vector = new Vector<int>(50);
                    Console.WriteLine("Add a sequence of numbers 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9");
                    vector.Add(2); vector.Add(6); vector.Add(8); vector.Add(5); vector.Add(5); vector.Add(1); vector.Add(8);
                    vector.Add(5); vector.Add(3); vector.Add(5); vector.Add(7); vector.Add(1); vector.Add(4); vector.Add(9);
                    if (!CheckIntSequence(new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 }, vector)) throw new Exception("Vector stores an incorrect sequence of integers after adding new elements");
                    Console.WriteLine("Sort the integers in the order defined by the DescendingIntComparer class");
                    vector.Sort(new DescendingIntComparer());
                    int[] array = new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 };
                    Array.Sort(array, 0, 14, new DescendingIntComparer());
                    Console.WriteLine("Resulting order: " + vector.ToString());
                    if (!CheckIntSequence(array, vector)) throw new Exception("Vector stores an incorrect sequence of integers after sorting them");
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "C";
                }
                catch (Exception exception)
                {
                    Console.WriteLine(" :: FAIL");
                    Console.WriteLine(exception.ToString());
                    result = result + "-";
                }

                // test 4
                try
                {
                    Console.WriteLine("\nTest D: Run a sequence of operations: ");
                    Console.WriteLine("Create a new vector by calling 'Vector<int> vector = new Vector<int>(50);'");
                    vector = new Vector<int>(50);
                    Console.WriteLine("Add a sequence of numbers 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9");
                    vector.Add(2); vector.Add(6); vector.Add(8); vector.Add(5); vector.Add(5); vector.Add(1); vector.Add(8);
                    vector.Add(5); vector.Add(3); vector.Add(5); vector.Add(7); vector.Add(1); vector.Add(4); vector.Add(9);
                    if (!CheckIntSequence(new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 }, vector)) throw new Exception("Vector stores an incorrect sequence of integers after adding new elements");
                    Console.WriteLine("Sort the integers in the order defined by the EvenNumberFirstComparer class");
                    vector.Sort(new EvenNumberFirstComparer());
                    int[] array = new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 };
                    Array.Sort(array, 0, 14, new EvenNumberFirstComparer());
                    Console.WriteLine("Resulting order: " + vector.ToString());
                    if (!CheckIntSequence(array, vector)) throw new Exception("Vector stores an incorrect sequence of integers after sorting them");
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "D";
                }
                catch (Exception exception)
                {
                    Console.WriteLine(" :: FAIL");
                    Console.WriteLine(exception.ToString());
                    result = result + "-";
                }

                // test 5
                try
                {
                    string[] names = new string[] { "Kelly", "Cindy", "John", "Andrew", "Richard", "Michael", "Guy", "Elicia", "Tom", "Iman", "Simon", "Vicky" };
                    Random random = new Random(100);
                    Console.WriteLine("\nTest E: Run a sequence of operations: ");
                    Console.WriteLine("Create a new vector of Student objects by calling 'Vector<Student> students = new Vector<Student>();'");
                    Vector<Student> students = new Vector<Student>();
                    for (int i = 0; i < 14; i++)
                    {
                        Student student = new Student() { Name = names[random.Next(0, names.Length)], Id = i };
                        Console.WriteLine("Add student with record: " + student.ToString());
                        students.Add(student);
                    }
                    Console.WriteLine("Sort the students in the default order defined by the native CompareTo() method");
                    students.Sort();
                    Console.WriteLine("Print the vector of students via students.ToString();");
                    Console.WriteLine(students.ToString());

                    Console.WriteLine(" :: SUCCESS");
                    result = result + "E";
                }
                catch (Exception exception)
                {
                    Console.WriteLine(" :: FAIL");
                    Console.WriteLine(exception.ToString());
                    result = result + "-";
                }

                // test 6
                try
                {
                    string[] names = new string[] { "Kelly", "Cindy", "John", "Andrew", "Richard", "Michael", "Guy", "Elicia", "Tom", "Iman", "Simon", "Vicky" };
                    Random random = new Random(100);
                    Console.WriteLine("\nTest F: Run a sequence of operations: ");
                    Console.WriteLine("Create a new vector of Student objects by calling 'Vector<Student> students = new Vector<Student>();'");
                    Vector<Student> students = new Vector<Student>();
                    for (int i = 0; i < 14; i++)
                    {
                        Student student = new Student() { Name = names[random.Next(0, names.Length)], Id = i };
                        Console.WriteLine("Add student with record: " + student.ToString());
                        students.Add(student);
                    }
                    Console.WriteLine("Sort the students in the order defined by the AscendingIDComparer class");
                    students.Sort(new AscendingIDComparer());
                    Console.WriteLine("Print the vector of students via students.ToString();");
                    Console.WriteLine(students.ToString());

                    Console.WriteLine(" :: SUCCESS");
                    result = result + "F";
                }
                catch (Exception exception)
                {
                    Console.WriteLine(" :: FAIL");
                    Console.WriteLine(exception.ToString());
                    result = result + "-";
                }

                // test 7
                try
                {
                    string[] names = new string[] { "Kelly", "Cindy", "John", "Andrew", "Richard", "Michael", "Guy", "Elicia", "Tom", "Iman", "Simon", "Vicky" };
                    Random random = new Random(100);
                    Console.WriteLine("\nTest G: Run a sequence of operations: ");
                    Console.WriteLine("Create a new vector of Student objects by calling 'Vector<Student> students = new Vector<Student>();'");
                    Vector<Student> students = new Vector<Student>();
                    for (int i = 0; i < 14; i++)
                    {
                        Student student = new Student() { Name = names[random.Next(0, names.Length)], Id = i };
                        Console.WriteLine("Add student with record: " + student.ToString());
                        students.Add(student);
                    }
                    Console.WriteLine("Sort the students in the order defined by the DescendingNameDescendingIdComparer class");
                    students.Sort(new DescendingNameDescendingIdComparer());
                    Console.WriteLine("Print the vector of students via students.ToString();");
                    Console.WriteLine(students.ToString());

                    Console.WriteLine(" :: SUCCESS");
                    result = result + "G";
                }
                catch (Exception exception)
                {
                    Console.WriteLine(" :: FAIL");
                    Console.WriteLine(exception.ToString());
                    result = result + "-";
                }

                Console.WriteLine("\n\n ------------------- SUMMARY ------------------- ");
                Console.WriteLine("Tests passed: " + result);
                Console.ReadKey();
            }
        }
    }
}
