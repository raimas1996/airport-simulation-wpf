using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirportSimulation
{
    /// <summary>
    /// Interação lógica para LogsPage.xaml
    /// </summary>
    public partial class LogsPage : Page
    {

        public LogsPage()
        {
            InitializeComponent();
            LoadTestLogs();
        }
        private void ButtonMainWindowClick(object sender, RoutedEventArgs e)
        {
            MainPage homePage = new();
            this.NavigationService.Navigate(homePage);
        }
        private void LoadTestLogs()
        {
            //StartProgram startInstance = new();

            logs_data.Items.Clear();

            string[] _logsStrings = {
                "Flight 350 is scheduled to depart.",
                "Flight 777 is scheduled to depart.",
                "Airbus 350 is scheduled to depart.",
                "Boeing 737 is scheduled to depart.",
                "Flight 350 is departing.",
                "Airbus 500 is scheduled to depart.",
                "Flight 350 has departed.",
                "Flight 777 is departing.",
                "Flight 777 has departed.",
                "Airbus 350 is departing.",
                "Airbus 350 has departed.",
                "Flight 350 is scheduled to land.",
                "Flight 777 is scheduled to land.",
                "Flight 350 is landing.",
                "Flight 350 has landed.",
                "Flight 777 is landing.",
                "Airbus 350 is scheduled to land.",
                "Flight 777 has landed.",
                "Airbus 350 is landing.",
                "Airbus 350 has landed.",
                "Boeing 737 is departing.",
                "Boeing 737 has departed.",
                "Airbus 500 is departing.",
                "Airbus 500 las departed.",
                "Boeing 737 is scheduled to land.",
                "Boeing 737 is landing.",
                "Boeing 737 has landed.",
                "Airbus 500 is scheduled to land.",
                "Airbus 500 is landing.",
                "Airbus 500 las landed."
            };

            for (int i = 0; i < _logsStrings.Length; i++)
            {
                Logs log = new Logs();
                log.LogText = _logsStrings[i];

                logs_data.Items.Add(log);
            }
        }
    }
}
