using GrapheneApp.Models;
using GrapheneApp.Views;

namespace GrapheneApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Clinician doctor = new Clinician("Smith");

            // -----------------------------------------
            // PATIENT 1 – Henry Burbridge
            // -----------------------------------------
            Patient henry = new Patient("P01", "Henry Burbridge");
            henry.CsvFiles.Add(@"C:\Users\disha\OneDrive\Desktop\GTLB-Data\1c0fd777_20251011.csv");
            henry.CsvFiles.Add(@"C:\Users\disha\OneDrive\Desktop\GTLB-Data\1c0fd777_20251012.csv");
            henry.CsvFiles.Add(@"C:\Users\disha\OneDrive\Desktop\GTLB-Data\1c0fd777_20251013.csv");

            // -----------------------------------------
            // PATIENT 2 – Noor Aisha
            // -----------------------------------------
            Patient noor = new Patient("P02", "Noor Aisha");
            noor.CsvFiles.Add(@"C:\Users\disha\OneDrive\Desktop\GTLB-Data\71e66ab3_20251011.csv");
            noor.CsvFiles.Add(@"C:\Users\disha\OneDrive\Desktop\GTLB-Data\71e66ab3_20251012.csv");
            noor.CsvFiles.Add(@"C:\Users\disha\OneDrive\Desktop\GTLB-Data\71e66ab3_20251013.csv");

            // -----------------------------------------
            // PATIENT 3 – ID: 543d4676
            // -----------------------------------------
            Patient patient3 = new Patient("P03", "Patient 543d4676");
            patient3.CsvFiles.Add(@"C:\Users\disha\OneDrive\Desktop\GTLB-Data\543d4676_20251011.csv");
            patient3.CsvFiles.Add(@"C:\Users\disha\OneDrive\Desktop\GTLB-Data\543d4676_20251012.csv");
            patient3.CsvFiles.Add(@"C:\Users\disha\OneDrive\Desktop\GTLB-Data\543d4676_20251013.csv");

            // -----------------------------------------
            // PATIENT 4 – ID: d13043b3
            // -----------------------------------------
            Patient patient4 = new Patient("P04", "Patient d13043b3");
            patient4.CsvFiles.Add(@"C:\Users\disha\OneDrive\Desktop\GTLB-Data\d13043b3_20251011.csv");
            patient4.CsvFiles.Add(@"C:\Users\disha\OneDrive\Desktop\GTLB-Data\d13043b3_20251012.csv");
            patient4.CsvFiles.Add(@"C:\Users\disha\OneDrive\Desktop\GTLB-Data\d13043b3_20251013.csv");

            // -----------------------------------------
            // PATIENT 5 – ID: de0e9b2c
            // -----------------------------------------
            Patient patient5 = new Patient("P05", "Patient de0e9b2c");
            patient5.CsvFiles.Add(@"C:\Users\disha\OneDrive\Desktop\GTLB-Data\de0e9b2c_20251011.csv");
            patient5.CsvFiles.Add(@"C:\Users\disha\OneDrive\Desktop\GTLB-Data\de0e9b2c_20251012.csv");
            patient5.CsvFiles.Add(@"C:\Users\disha\OneDrive\Desktop\GTLB-Data\de0e9b2c_20251013.csv");

            // Add all patients to clinician
            doctor.Patients.Add(henry);
            doctor.Patients.Add(noor);
            doctor.Patients.Add(patient3);
            doctor.Patients.Add(patient4);
            doctor.Patients.Add(patient5);

            // Start dashboard loop
            while (true)
            {
                ClinicianDashboard.ShowDashboard(doctor);
            }
        }
    }
}
