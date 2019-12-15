using System;
using System.Data.Entity.Migrations;
using System.Windows;
using System.Windows.Input;


namespace NetworkBase
{
    /// <summary>
    /// Логика взаимодействия для DepartmentWindow.xaml
    /// </summary>
    public partial class DepartmentWindow : Window
    {
		NetworkBaseEntities entities;
		Departments udepartment;

		public DepartmentWindow(NetworkBaseEntities db)
        {
			InitializeComponent();

			entities = db;
			InsertButton.IsEnabled = true;
			updateButton.IsEnabled = false;
		}

		public DepartmentWindow(NetworkBaseEntities db, Departments department)
		{
			InitializeComponent();

			entities = db;
			udepartment = department;
			InsertButton.IsEnabled = false;
			updateButton.IsEnabled = true;
			departmentID.IsReadOnly = true;
			ShowData();
		}

		private void ShowData()
		{
			departmentID.Text = udepartment.departmentID.ToString();
			departmentName.Text = udepartment.departmentName;

		}

		private void InsertButton_Click(object sender, RoutedEventArgs e)
		{
			if (CheckInput())
			{
				try
				{
					Departments department = new Departments();

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

		private void UpdateButton_Click(object sender, RoutedEventArgs e)
		{
			if (CheckInput())
			{
				try
				{ 			
					udepartment.departmentName = departmentName.Text;

					entities.Departments.AddOrUpdate(udepartment);
					entities.SaveChanges();

					this.Close();
				}
				catch
				{
					MessageBox.Show("Не удалось изменить данные в базе.");
				}
			}
		}
	}
}
