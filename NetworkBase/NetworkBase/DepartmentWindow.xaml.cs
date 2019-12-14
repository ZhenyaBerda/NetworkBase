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

namespace NetworkBase
{
    /// <summary>
    /// Логика взаимодействия для DepartmentWindow.xaml
    /// </summary>
    public partial class DepartmentWindow : Window
    {
		NetworkBaseEntities entities;

		public DepartmentWindow(NetworkBaseEntities db)
        {
			entities = db;

			InitializeComponent();
        }

		private void InsertButton_Click(object sender, RoutedEventArgs e)
		{
			Departments department = new Departments();

			if (CheckInput())
			{
				try
				{
					department.departmentID = Int32.Parse(departmentID.Text);
					department.departmentName = departmentName.Text;

					entities.Departments.Add(department);
					entities.SaveChanges();

					this.Close();
				}
				catch
				{
					MessageBox.Show("Ошибка добалвения данных в базу.");
				}
			}
			else
				MessageBox.Show("Заполните все поля!");
		}

		private bool CheckInput()
		{
			if (departmentID.Text.Length > 0 && departmentName.Text.Length > 0)
				return true;
			else
				return false;
		}

		private void DepartmentID_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
		}
	}
}
