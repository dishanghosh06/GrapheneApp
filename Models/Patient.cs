using System.Collections.Generic;

namespace GrapheneApp.Models
{
    public class Patient
    {
        public string ID { get; set; }
        public string Name { get; set; }

        // List of CSV files for multiple days
        public List<string> CsvFiles { get; set; } = new List<string>();

        public Patient(string id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
