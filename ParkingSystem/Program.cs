using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParkingSystem.Model;
using ParkingSystem.Repo;

namespace ParkingSystem
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ());*/

            VehicleRepo vehicleRepo = new VehicleRepo();
            foreach (Vehicle vehicle in vehicleRepo.getAll())
            {
                Debug.WriteLine(vehicle.ToString());
            }
        }
    }
}