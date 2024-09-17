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
            beolvasas();

            nevek_kiiratasa();
            legtobbet_kereseok();
            TizEv_hugdijig();
            OtvenEzer_felett_keresnek();
            Console.Read();

        }
        static void beolvasas()
        {
            StreamReader sr = new StreamReader("tulajdonsagok_100sor.txt");
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');
                Employes.Add(new Employee(int.Parse(sor[0]), sor[1], int.Parse(sor[2]), int.Parse(sor[3])));

            }
            sr.Close();
        }
        static void nevek_kiiratasa()
        {
            for (int i = 0; i < Employes.Count; i++)
            {
                Console.WriteLine(Employes[i].Name);
            }
        }
        static void legtobbet_kereseok()
        {
            List<Employee> employee = new List<Employee>();
            employee.Add(Employes[0]);
            for (int i = 0; i < Employes.Count; i++)
            {

                if (employee[0].Fizetes == Employes[i].Fizetes)
                {
                    employee.Add(Employes[i]);
                }
                else if (employee[0].Fizetes < Employes[i].Fizetes)
                {
                    employee.Clear();
                    employee.Add(Employes[i]);
                }
            }
            Console.WriteLine();
            Console.WriteLine("legtobbet keresok:");
            foreach (Employee item in employee)
            {
                Console.WriteLine(item.Id+" "+item.Name);
            }
        }

        static void TizEv_hugdijig()
        {
            Console.WriteLine();
            Console.WriteLine("akinek 10 ev van a nyugdijig");
            for (int i = 0; i < Employes.Count; i++)
            {
                if (Employes[i].Kor>=55)
                {
                    Console.WriteLine(Employes[i].Name);
                }
            }
        }
        static void OtvenEzer_felett_keresnek()
        {
            int szam = 0;
            for (int i = 0; i < Employes.Count; i++)
            {
                if (Employes[i].Fizetes>50000)
                {
                    szam++;
                }
            }
            Console.WriteLine();
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
