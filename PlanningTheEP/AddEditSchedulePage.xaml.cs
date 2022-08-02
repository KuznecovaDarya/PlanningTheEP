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

namespace PlanningTheEP
{
    /// <summary>
    /// Логика взаимодействия для AddEditSchedulePage.xaml
    /// </summary>
    public partial class AddEditSchedulePage : Page
    {
        private Schedule _currentSchedule = new Schedule();
        public AddEditSchedulePage(Schedule selectedSchedule)
        {
            InitializeComponent();
            if (selectedSchedule != null)
                _currentSchedule = selectedSchedule;

            DataContext = _currentSchedule;
            CBDay.ItemsSource = PlanningTheEPEntities.GetContext().Day.ToList();
            CBGrade.ItemsSource = PlanningTheEPEntities.GetContext().Grade.ToList();
            CBSubject.ItemsSource = PlanningTheEPEntities.GetContext().Subject.ToList();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CBGrade.SelectedItem == null) MessageBox.Show("Введите класс!");
            else if (CBDay.SelectedItem == null) MessageBox.Show("Введите день недели!");
            else if (CBSubject.SelectedItem == null) MessageBox.Show("Введите предмет!");
            else
            {

                if (_currentSchedule.Id_Schedule == 0)
                {
                    PlanningTheEPEntities.GetContext().Schedule.Add(_currentSchedule);
                }

                try
                {
                    PlanningTheEPEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена!");
                    Manager.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }

        }
    }
}