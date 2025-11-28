using System.Collections.Generic;

namespace GrapheneApp.Models
{
    public class Clinician
    {
        public string Name { get; set; }
        public List<Patient> Patients { get; set; } = new();

        public Clinician(string name)
        {
            Name = name;
        }
    }
}
