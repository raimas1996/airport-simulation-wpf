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
    /// Interação lógica para MainPage.xam
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            LoadTestPilots();
            
        }
        public void ButtonLogsWindowClick(object sender, RoutedEventArgs e)
        {
            LogsPage homePage = new();
            this.NavigationService.Navigate(homePage);
        }

        public void LoadTestPilots()
        {
            StartProgram startProgram = StartProgram.Instance;
            pilots_data.Items.Clear();
            int numPilots = 5;

            GRI gri = new()
            {
                NumPilots = numPilots
            };

            Track track = new()
            {
                Gri = gri,
                NumPilots = numPilots
            };

            Hangar hangar = new()
            {
                Gri = gri,
                NumPilots = numPilots
            };

            Sky sky = new()
            {
                Gri = gri,
                NumPilots = numPilots
            };

            for (int i = 0; i < startProgram.PilotsArray.Length; i++)
            {
                Pilot pilot = new()
                {
                    Gri = gri,
                    PilotId = i,
                    Code = startProgram.airplaneNames[i],
                    NumFlightsLeft = new Random().Next(10),
                    Distance = new Random().Next(startProgram.max_distance) + 1,
                    HangarClass = hangar,
                    SkyClass = sky,
                    TrackClass = track
                };
                pilots_data.Items.Add(pilot);
            }
        }
    }
}
