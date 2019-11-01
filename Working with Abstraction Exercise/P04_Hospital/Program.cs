using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

            string command;
            while ((command = Console.ReadLine()) != "Output")
            {
                string[] tokens = command.Split();
                var departament = tokens[0];
                var patient = tokens[3];
                var fullName = tokens[1] + tokens[2];
                InitializeDoctorAndDepartment(doctors, departments, departament, fullName);

                bool isDepartmentNotFull = departments[departament].SelectMany(x => x).Count() < 60;
                if (isDepartmentNotFull)
                {
                    AddPatient(doctors, departments, departament, patient, fullName);
                }
            }

            while ((command = Console.ReadLine()) != "End")
            {
                string[] args = command.Split();
                PrintResult(doctors, departments, args);
            }
        }

        private static void AddPatient(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string departament, string patient, string fullName)
        {
            int room = 0;
            doctors[fullName].Add(patient);
            for (int currentRoom = 0; currentRoom < departments[departament].Count; currentRoom++)
            {
                if (departments[departament][currentRoom].Count < 3)
                {
                    room = currentRoom;
                    break;
                }
            }
            departments[departament][room].Add(patient);
        }

        private static void PrintResult(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string[] args)
        {
            if (args.Length == 1)
            {
                Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
            }
            else if (args.Length == 2 && int.TryParse(args[1], out int staq))
            {
                Console.WriteLine(string.Join("\n", departments[args[0]][staq - 1].OrderBy(x => x)));
            }
            else
            {
                Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
            }
        }

        private static void InitializeDoctorAndDepartment(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string departament, string fullName)
        {
            if (!doctors.ContainsKey(fullName))
            {
                doctors[fullName] = new List<string>();
            }
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();
                for (int room = 0; room < 20; room++)
                {
                    departments[departament].Add(new List<string>());
                }
            }
        }
    }
}
