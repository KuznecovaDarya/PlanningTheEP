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
using Word = Microsoft.Office.Interop.Word;

namespace PlanningTheEP
{
    public partial class Plan1 : Page
    {
        public Plan1(string id_plan)
        {
            InitializeComponent();
            id.Text = id_plan;
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            int idPlan = Convert.ToInt32(id.Text);

            string name = "";
            PlanningTheEPEntities context = new PlanningTheEPEntities();//выводим заголовком название плана
            var fullplan = context.FullPlan;
            foreach (FullPlan fullPlan in fullplan.Where(c => c.Id_Plan == idPlan))
            {
                name = fullPlan.NamePlan;
            }
            MessageBox.Show($"Будет составлен документ для печати для {name}");

            PlanningTheEPEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            var PLans = PlanningTheEPEntities.GetContext().FullAndFirst.Where((u) => (u.FirstPlan.Id_Grade == 10 || u.FirstPlan.Id_Grade == 11) && u.Id_Plan == idPlan).ToList();
            var application = new Word.Application();

            Word.Document document = application.Documents.Add();
            Word.Paragraph paragraph = document.Paragraphs.Add();
            Word.Range range = paragraph.Range;
            range.Text = name;

            paragraph.set_Style("Заголовок");
            paragraph.Range.Font.Name = "Times New Roman";
            range.InsertParagraphAfter();//создаем новый параграф для таблицы


            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table PLansTable = document.Tables.Add(tableRange, PLans.Count() + 1, 4);//строки и столбцы
            PLansTable.Borders.InsideLineStyle = PLansTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;//значение границ внутр и внеш
            PLansTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;//выравнивание по центру

            Word.Range cellRange;
            //заголовки
            cellRange = PLansTable.Cell(1, 1).Range;
            cellRange.Text = "Предметная область";
            cellRange = PLansTable.Cell(1, 2).Range;
            cellRange.Text = "Предмет";
            cellRange = PLansTable.Cell(1, 3).Range;
            cellRange.Text = "Класс";
            cellRange = PLansTable.Cell(1, 4).Range;
            cellRange.Text = "Кол.часов";
            //форматирование заголовков
            PLansTable.Rows[1].Range.Bold = 1;//жирный текст
            PLansTable.Range.Font.Name = "Times New Roman";
            PLansTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;//выравнивание по центру

            Word.Paragraph sumParagraph = document.Paragraphs.Add();//парагараф для суммы часов 
            Word.Range sumRange = sumParagraph.Range;
            sumParagraph.Range.Font.Name = "Times New Roman";
            foreach (var pLan in PLans)
            {
                double sum10 = 0;
                double sum11 = 0;
                for (int i = 0; i < PLans.Count(); i++)
                {
                    var currentPlan = PLans[i];
                    if (currentPlan.FirstPlan.Grade.Name == "10 класс")
                    {
                        sum10 = sum10 + currentPlan.FirstPlan.NumberOfHours;
                    }
                    else if (currentPlan.FirstPlan.Grade.Name == "11 класс")
                    {
                        sum11 = sum11 + currentPlan.FirstPlan.NumberOfHours;
                    }
                    cellRange = PLansTable.Cell(i + 2, 1).Range;
                    cellRange.Text = currentPlan.FirstPlan.SubjectArea.Name + "";
                    cellRange = PLansTable.Cell(i + 2, 2).Range;
                    cellRange.Text = currentPlan.FirstPlan.Subject.Name + "";
                    cellRange = PLansTable.Cell(i + 2, 3).Range;
                    cellRange.Text = currentPlan.FirstPlan.Grade.Name + "";
                    cellRange = PLansTable.Cell(i + 2, 4).Range;
                    cellRange.Text = currentPlan.FirstPlan.NumberOfHours + "";
                }

                sumRange.Text = $"Итого объем аудиторной нагрузки при 5 - дневной учебной неделе для 10 класса= { sum10} час.\n" +
                    $"Итого объем аудиторной нагрузки при 5 - дневной учебной неделе для 11 класса= { sum11} час.";
                sumRange.Font.Color = Word.WdColor.wdColorDarkRed;//цвет суммы

            }

            application.Visible = true;//отображение приложения

            //document.SaveAs2($@"C:\Users\User\Desktop\{name}.docx");
            //document.SaveAs2($@"C:\Users\User\Desktop\{name}.pdf", Word.WdExportFormat.wdExportFormatPDF);
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            int idPlan = Convert.ToInt32(id.Text);
            if (Visibility == Visibility.Visible)
            {
                PlanningTheEPEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGPlan.ItemsSource = PlanningTheEPEntities.GetContext().FullAndFirst.Where((u) => (u.FirstPlan.Id_Grade == 10 || u.FirstPlan.Id_Grade == 11) && u.Id_Plan == idPlan).ToList();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditPlan((sender as Button).DataContext as FullAndFirst));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            int idPlan = Convert.ToInt32(id.Text);
            var orderForRemoving = DGPlan.SelectedItems.Cast<FullAndFirst>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {orderForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PlanningTheEPEntities.GetContext().FullAndFirst.RemoveRange(orderForRemoving);
                    PlanningTheEPEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGPlan.ItemsSource = PlanningTheEPEntities.GetContext().FullAndFirst.Where((u) => (u.FirstPlan.Id_Grade == 10 || u.FirstPlan.Id_Grade == 11) && u.Id_Plan == idPlan).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddPlan(id.Text));
        }
    }
}
