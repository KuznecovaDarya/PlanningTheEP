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
using System.Windows.Shapes;

namespace PlanningTheEP
{
    /// <summary>
    /// Логика взаимодействия для SelectionWindow.xaml
    /// </summary>
    public partial class SelectionWindow : Window
    {
        public SelectionWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Schedules_Click(object sender, RoutedEventArgs e)
        {
            ScheduleWindow main = new ScheduleWindow();
            main.Show();
            this.Close();
        }

        private void Plans_Click(object sender, RoutedEventArgs e)
        {
            WindowAdmin main = new WindowAdmin();
            main.Show();
            this.Close();
        }
    }
}
