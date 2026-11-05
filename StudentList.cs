

using System;

namespace Cse111Task1;

public class StudentList
{
    public Student? First;
    public Student? Last;
    public int Count;

    public void AddFront(int id)
    {
        Student node = new Student(id);
        node.Next = First;
        First = node;

        if (Last == null)
            Last = node;

        Count++;
    }

    public void AddEnd(int id)
    {
        Student node = new Student(id);

        if (Last == null)
        {
            First = node;
            Last = node;
        }
        else
        {
            Last.Next = node;
            Last = node;
        }

        Count++;
    }

    public bool Remove(int id)
    {
        Student? previous = null;
        Student? current = First;

        while (current != null)
        {
            if (current.Id == id)
            {
                if (previous == null)
                    First = current.Next;
                else
                    previous.Next = current.Next;

                if (current == Last)
                    Last = previous;

                Count--;
                return true;
            }

            previous = current;
            current = current.Next;
        }

        return false;
    }

    public void Reverse()
    {
        Student? previous = null;
        Student? current = First;
        Last = First;

        while (current != null)
        {
            Student? next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;
        }

        First = previous;
    }

    public void Print()
    {
        Student? current = First;
        while (current != null)
        {
            Console.Write(current.Id);
            if (current.Next != null)
                Console.Write(" ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}

internal static class Program
{
    private static void Show(StudentList students)
    {
        Console.Write("Line: ");
        students.Print();
        Console.WriteLine($"First: {students.First?.Id.ToString() ?? "null"}, " +
                          $"Last: {students.Last?.Id.ToString() ?? "null"}, " +
                          $"Count: {students.Count}");
    }

    private static void Main()
    {
        StudentList students = new StudentList();
        Show(students);

        students.AddFront(20);
        Show(students);

        students.AddFront(10);
        Show(students);

        students.AddEnd(30);
        Show(students);

        students.AddEnd(40);
        Show(students);

        students.Reverse();
        Show(students);

        students.Remove(20);
        Show(students);
    }
}
