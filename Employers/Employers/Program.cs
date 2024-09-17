using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Employers
{
    internal class Program
    {
        static List<Employee> Employes;
        static void Main(string[] args)
        {
            Employes = new List<Employee>();
            StreamReader sr = new StreamReader("tulajdonsagok_100sor.txt");
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');
                Employes.Add(new Employee(int.Parse(sor[0]), sor[1], int.Parse(sor[2]), int.Parse(sor[3])));

            }
            sr.Close();

            for (int i = 0; i < Employes.Count; i++)
            {
                Console.WriteLine(Employes[i].Name);
            }



            Employee employee = Employes[0];

            for (int i = 0; i < Employes.Count; i++)
            {

                if (employee.Fizetes < Employes[i].Fizetes)
                {
                    employee.Fizetes = Employes[i].Fizetes;
                    employee.Name = Employes[i].Name;
                }
            }
            Console.WriteLine("a legtobbet kereso: "+employee.Name+"osszeg: "+employee.Fizetes);
        }
    }

    class Employee
    {
        public int Id;
        public string Name;
        public int Kor;
        public int Fizetes;

        public Employee(int id,string name, int kor, int fizetes)
        {
            Id = id;
            Name = name;
            Kor = kor;
            Fizetes = fizetes;

        }
    }
}
