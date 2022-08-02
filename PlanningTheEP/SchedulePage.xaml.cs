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
    /// Логика взаимодействия для SchedulePage.xaml
    /// </summary>
    public partial class SchedulePage : Page
    {
        private Schedule _currentSchedule = new Schedule();
        public SchedulePage()
        {
            InitializeComponent();
            CBGrade.ItemsSource = PlanningTheEPEntities.GetContext().Grade.ToList();
            CBDay.ItemsSource = PlanningTheEPEntities.GetContext().Day.ToList();
            CBSubject.ItemsSource = PlanningTheEPEntities.GetContext().Subject.ToList();
        }

        //private void BtnSchedule_Click(object sender, RoutedEventArgs e)
        //{
        //    Manager.MainFrame.Navigate(new AddEditSchedulePage((sender as Button).DataContext as Schedule));
        //}

        //private void Add_Click(object sender, RoutedEventArgs e)
        //{
        //    Manager.MainFrame.Navigate(new AddEditSchedulePage(null));
        //}

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (CBGrade.Text != "" && CBDay.Text != "")
            {
                int grade = Convert.ToInt32(CBGrade.SelectedValue);
                int day = Convert.ToInt32(CBDay.SelectedValue);
                if (Visibility == Visibility.Visible)
                {
                    PlanningTheEPEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    DGSchedule.ItemsSource = PlanningTheEPEntities.GetContext().Schedule.Where(u => u.Id_Grade == grade && u.Id_Day == day).ToList();
                }
            }
            else MessageBox.Show("Выберите класс и день недели для формирования расписания!");
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var ScheduleForRemoving = DGSchedule.SelectedItems.Cast<Schedule>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {ScheduleForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PlanningTheEPEntities.GetContext().Schedule.RemoveRange(ScheduleForRemoving);
                    PlanningTheEPEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    //DGSchedule.ItemsSource = PlanningTheEPEntities.GetContext().ScheduleAndSubject.ToList();
                    DGSchedule.ItemsSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

            Search_Click(sender, e);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int grade = Convert.ToInt32(CBGrade.SelectedValue);
            int day = Convert.ToInt32(CBDay.SelectedValue);

            for (int i = 0; i < DGSchedule.Items.Count - 1; i++)
            {
                Schedule n = (Schedule)DGSchedule.Items[i];
                _currentSchedule = n;

                DataContext = _currentSchedule;
                _currentSchedule.Id_Grade = grade;
                _currentSchedule.Id_Day = day;

                if (_currentSchedule.Id_Schedule == 0)
                {
                    PlanningTheEPEntities.GetContext().Schedule.Add(_currentSchedule);
                }
                try
                {
                    PlanningTheEPEntities.GetContext().SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                CBGrade.SelectedValue = grade;
                CBDay.SelectedValue = day;
            }
            Search_Click(sender, e);
        }
    }
}
