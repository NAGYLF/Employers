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
        public static List<Employee> Employes = new List<Employee>();
        static void Main(string[] args)
        {
            
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

        static void TizEv_hugdijig()
        {
            Console.WriteLine("akinek 10 ev van a nyugdijig");
            for (int i = 0; i < Employes.Count; i++)
            {
                if (Employes[i].Kor>=55)
                {
                    Console.WriteLine(Employes[i].Name);
                }
            }
        }
        static void felett_keresnek()
        {
            int szam = 0;
            for (int i = 0; i < Employes.Count; i++)
            {
                if (Employes[i].Fizetes>50000)
                {
                    szam++;
                }
            }
            Console.WriteLine("50.000 folott keresok szama: "+szam);
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
