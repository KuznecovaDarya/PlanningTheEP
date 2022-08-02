using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для AddPlan.xaml
    /// </summary>
    public partial class AddPlan : Page
    {
        private FirstPlan _currentPlan = new FirstPlan();

        public AddPlan(string id_plan)
        {
            InitializeComponent();
            Id_Plan.Text = id_plan;


            DataContext = _currentPlan;
            SArea.ItemsSource = PlanningTheEPEntities.GetContext().SubjectArea.ToList();
            Subject.ItemsSource = PlanningTheEPEntities.GetContext().Subject.ToList();
            Grades.ItemsSource = PlanningTheEPEntities.GetContext().Grade.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            int countRight = 0;
            if (SArea.SelectedItem == null) MessageBox.Show("Выберите предметную область!");
            else countRight++;
            if (Subject.SelectedItem == null) MessageBox.Show("Выберите предмет!");
            else countRight++;
            if (NOH.Text == "") MessageBox.Show("Введите корректное кол. часов!");
            else
            {
                int error = 0;
                string[] hour = NOH.Text.Split('.');

                for (int g = 0; g < hour.Length; g++)
                {
                    for (int i = 0; i < hour[g].Length; i++)
                    {
                        if (Convert.ToChar(hour[g][i]) < 48 || 57 < Convert.ToChar(hour[g][i]))
                        {
                            error++;
                        }
                    }
                }
                if (error == 0)
                {
                    countRight++;
                }
                else
                {
                    MessageBox.Show("Некорректно введена Рекомендованная цена!");
                }
            }
            if (Grades.SelectedItem == null) MessageBox.Show("Выберите класс!");
            else countRight++;
            if (countRight == 4) 
            {
                string IdFirstPlan = "";
                PlanningTheEPEntities.GetContext().FirstPlan.Add(_currentPlan);
                PlanningTheEPEntities.GetContext().SaveChanges();

                string table = "FirstPlan"; //Имя таблицы
                string ssql = $"SELECT  * FROM {table} "; //Запрос 
                string connectionString = @"Data Source=.\MSSQLSERVER1;Initial Catalog=PlanningTheEP;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
                conn.Open();// Открытие Соединения

                SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов
                SqlDataReader reader = command.ExecuteReader(); // Выаолнение запроса вывод информации
                while (reader.Read())
                {
                    IdFirstPlan = reader[0] + "";
                }

                int IdPlan = Convert.ToInt32(Id_Plan.Text);


                string sql = string.Format("Insert Into FullAndFirst (Id_Plan,Id_FPlan) Values(@Id_Plan,@Id_FPlan)");
                string connectionString1 = @"Data Source=.\MSSQLSERVER1;Initial Catalog=PlanningTheEP;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString1);
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    // Добавить параметры
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_Plan", IdPlan);
                    cmd.Parameters.AddWithValue("@Id_FPlan", IdFirstPlan);

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Информация сохранена!");
                //Manager.MainFrame.GoBack();
            }
        }
    }
}
