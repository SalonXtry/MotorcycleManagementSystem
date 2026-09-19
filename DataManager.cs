using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace MotorcycleManagementSystem
{
    public static class DataManager
    {
        private static string customerFile = "customers.json";

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
    }
}