using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace MotorcycleManagementSystem
{
    public static class DataManager
    {
        private static string customerFile = "customers.json";
        private static string motorcycleFile = "motorcycles.json";

        public static void SaveCustomers(List<Customer> customers)
        {
            string json = JsonSerializer.Serialize(customers);
            File.WriteAllText(customerFile, json);
        }

        public static List<Customer> LoadCustomers()
        {
            if (!File.Exists(customerFile))
            {
                return new List<Customer>();
            }

            string json = File.ReadAllText(customerFile);

            return JsonSerializer.Deserialize<List<Customer>>(json)
                   ?? new List<Customer>();
        }

        public static void SaveMotorcycles(List<Motorcycle> motorcycles)
        {
            string json = JsonSerializer.Serialize(motorcycles);
            File.WriteAllText(motorcycleFile, json);
        }

        public static List<Motorcycle> LoadMotorcycles()
        {
            if (!File.Exists(motorcycleFile))
            {
                return new List<Motorcycle>();
            }

            string json = File.ReadAllText(motorcycleFile);

            return JsonSerializer.Deserialize<List<Motorcycle>>(json)
                   ?? new List<Motorcycle>();
        }
    }
}