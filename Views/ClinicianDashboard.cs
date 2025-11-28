using System;
using GrapheneApp.Models;
using GrapheneApp.Services;
using GrapheneApp.Views;

namespace GrapheneApp.Views
{
    public static class ClinicianDashboard
    {
        public static void ShowDashboard(Clinician clinician)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine($"   Clinician Dashboard - Dr. {clinician.Name}");
                Console.WriteLine("========================================\n");

                Console.WriteLine("Select a patient:\n");

                for (int i = 0; i < clinician.Patients.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {clinician.Patients[i].Name} (ID: {clinician.Patients[i].ID})");
                }

                Console.WriteLine("\n0. Exit System");
                Console.Write("\nEnter patient number: ");

                if (!int.TryParse(Console.ReadLine(), out int patientChoice))
                {
                    Console.WriteLine("Invalid choice. Press ENTER to try again.");
                    Console.ReadLine();
                    continue;
                }

                if (patientChoice == 0)
                {
                    Console.WriteLine("\nExiting system... Goodbye!");
                    Environment.Exit(0);
                }

                if (patientChoice < 1 || patientChoice > clinician.Patients.Count)
                {
                    Console.WriteLine("Invalid choice. Press ENTER to try again.");
                    Console.ReadLine();
                    continue;
                }

                Patient selectedPatient = clinician.Patients[patientChoice - 1];
                ShowPatientData(selectedPatient);
            }
        }

        private static void ShowPatientData(Patient patient)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine($"   Patient: {patient.Name} (ID: {patient.ID})");
                Console.WriteLine("========================================\n");

                Console.WriteLine("Available recordings:\n");

                for (int i = 0; i < patient.CsvFiles.Count; i++)
                {
                    string file = patient.CsvFiles[i];
                    string date = ExtractDateFromFile(file);
                    Console.WriteLine($"{i + 1}. Recording from {date}");
                }

                Console.WriteLine("\n0. Back to Patients");
                Console.Write("\nSelect recording number: ");

                if (!int.TryParse(Console.ReadLine(), out int fileChoice))
                {
                    Console.WriteLine("Invalid choice. Press ENTER to try again.");
                    Console.ReadLine();
                    continue;
                }

                if (fileChoice == 0)
                    return;

                if (fileChoice < 1 || fileChoice > patient.CsvFiles.Count)
                {
                    Console.WriteLine("Invalid choice. Press ENTER to try again.");
                    Console.ReadLine();
                    continue;
                }

                string selectedFile = patient.CsvFiles[fileChoice - 1];

                Console.Clear();
                Console.WriteLine($"Loading data from: {ExtractDateFromFile(selectedFile)}...\n");

                try
                {
                    int[,] grid = CsvReader.ReadPressureData(selectedFile);
                    int peak = DataAnalyzer.CalculatePeakPressure(grid);
                    double contact = DataAnalyzer.CalculateContactArea(grid);

                    Console.WriteLine($"Patient: {patient.Name}");
                    Console.WriteLine($"Recording Date: {ExtractDateFromFile(selectedFile)}\n");
                    Console.WriteLine($"Peak Pressure Index: {peak}");
                    Console.WriteLine($"Contact Area: {contact:F2}%");

                    // 🔥 ADDING THE HEATMAP BACK
                    Console.WriteLine("\nHeatmap:\n");
                    HeatMap.Print(grid);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading CSV file:");
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("\nPress ENTER to return...");
                Console.ReadLine();
                return;
            }
        }

        private static string ExtractDateFromFile(string path)
        {
            string fileName = System.IO.Path.GetFileNameWithoutExtension(path);
            string[] parts = fileName.Split('_');

            if (parts.Length >= 2)
            {
                string raw = parts[1];
                return $"{raw.Substring(6, 2)}-{raw.Substring(4, 2)}-{raw.Substring(0, 4)}";
            }

            return "Unknown Date";
        }
    }
}
