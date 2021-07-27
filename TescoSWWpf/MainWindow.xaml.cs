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
using TescoSWLibrary.Xml;
using TescoSWLibrary.DB;
using TescoSWLibrary.Xml.Models;

namespace TescoSWWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dgMain.ItemsSource = null;
            dgWeekend.ItemsSource = null;
        }
        private void LoadTable(CarRootModel Data)
        {
            dgMain.ItemsSource = new CarRootModelExtended(Data).CarsExtended;
            dgWeekend.ItemsSource = new CarRootModelExtended(Data).GetWeekendSoldCars();
        }
        private void LoadTable(CarRootModelExtended Data)
        {
            dgMain.ItemsSource = Data.CarsExtended;
            dgWeekend.ItemsSource = Data.GetWeekendSoldCars();
        }
        private void Button_Click_LoadXml(object sender, RoutedEventArgs e)
        {
            LoadTable(FileXml.LoadFromDisk());
        }

        private void Button_Click_LoadExampleData(object sender, RoutedEventArgs e)
        {
            LoadTable(CarTestData.GetExampleData());
        }
        private void Button_Click_CleanTable(object sender, RoutedEventArgs e)
        {
            dgMain.ItemsSource = null;
            dgWeekend.ItemsSource = null;
        }

        private async void Button_Click_SaveToDbAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgMain.ItemsSource != null)
                {
                    foreach (CarModelExtended item in dgMain.ItemsSource)
                    {
                        await CarControl.SaveAsync((CarDbModel)item);
                    }
                    string Message = "The data from the table was successfully written to the sqlite database.";
                    MessageBox.Show($"{Message}", "DB Control");
                }
                else
                {
                    string Message = "there is no data in the table, nothing can be saved to the database.";
                    MessageBox.Show($"{Message}", "DB Control");
                }
            }
            catch (Exception ef)
            {
                string Message = "Unexpected error.";
                MessageBox.Show($"{Message}\n\n\nRaw Error:\n{ef}", "Error");
            }
        }

        private void Button_Click_LoadFromDb(object sender, RoutedEventArgs e)
        {
            try
            {
                var DbData = CarControl.GetAll();
                List<CarModelExtended> tableData = DbData.Select(a => (CarModelExtended)a).ToList();
                dgMain.ItemsSource = tableData;
                LoadTable(new CarRootModelExtended { CarsExtended = tableData });
                string Message = "data was read from sqlite and loaded into the table.";
                MessageBox.Show($"{Message}", "DB Control");
            }
            catch (Exception ef)
            {
                string Message = "Unexpected error.";
                MessageBox.Show($"{Message}\n\n\nRaw Error:\n{ef}", "Error");
            }
        }
        private async void Button_Click_RemoveDb(object sender, RoutedEventArgs e)
        {
            try
            {
                await CarControl.DeleteAllAsync();
                string Message = "All records inside the sqlite database have been successfully deleted.";
                MessageBox.Show($"{Message}", "DB Control");
            }
            catch (Exception ef)
            {
                string Message = "Unexpected error.";
                MessageBox.Show($"{Message}\n\n\nRaw Error:\n{ef}", "Error");
            }
        }
    }
}
