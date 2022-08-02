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
    /// Логика взаимодействия для List.xaml
    /// </summary>
    public partial class List : Page
    {
        public List()
        {
            InitializeComponent();
        }

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            FullPlan n = (FullPlan)DGPlansList.Items[DGPlansList.SelectedIndex];
            if (n.Id_Type + "" == "1")
            {
                Manager.MainFrame.Navigate(new Plan1(n.Id_Plan + ""));
            }
            else if (n.Id_Type + "" == "2")
            {
                Manager.MainFrame.Navigate(new Plan2(n.Id_Plan + ""));
            }
            else if (n.Id_Type + "" == "3")
            {
                Manager.MainFrame.Navigate(new Plan3(n.Id_Plan + ""));
            }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PlanningTheEPEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGPlansList.ItemsSource = PlanningTheEPEntities.GetContext().FullPlan.ToList();
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = TxtSearch.Text;

            var Plans = PlanningTheEPEntities.GetContext().FullPlan.ToList();
            DGPlansList.ItemsSource = Plans.Where(c => c.NamePlan.Contains(search));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddFullPlan());
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var orderForRemoving = DGPlansList.SelectedItems.Cast<FullPlan>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {orderForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PlanningTheEPEntities.GetContext().FullPlan.RemoveRange(orderForRemoving);
                    PlanningTheEPEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGPlansList.ItemsSource = PlanningTheEPEntities.GetContext().FullPlan.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void TxtSearch_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TxtSearch.Clear();
        }
    }
}
