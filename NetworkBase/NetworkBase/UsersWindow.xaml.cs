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
	/// Логика взаимодействия для UsersWindow.xaml
	/// </summary>
	public partial class UsersWindow : Window
	{
		NetworkBaseEntities entities;

		public UsersWindow(NetworkBaseEntities db)
		{
			entities = db;
			InitializeComponent();
		}

		private void UserID_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
		}

		private void DeviceID_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
		}

		private bool CheckInput()
		{
			if (userID.Text.Length > 0 && userLogin.Text.Length > 0 && userPassword.Text.Length > 0
				&& userAccount.Text .Length > 0 && deviceID.Text.Length > 0)
				return true;
			else
				return false;
		}

		private void InsertButton_Click(object sender, RoutedEventArgs e)
		{
			if (CheckInput())
			{
				try
				{
					Users user = new Users();

					user.userID = Int32.Parse(userID.Text);
					user.userLogin = userLogin.Text;
					user.userPassword = userPassword.Text;
					user.userAccount = userAccount.Text;
					user.deviceID = Int32.Parse(deviceID.Text);

					entities.Users.Add(user);
					entities.SaveChanges();

					this.Close();
				}
				catch
				{
					MessageBox.Show("Ошибка добавления данных в базу.");
				}
			}
			else
				MessageBox.Show("Заполните все поля");
		}
	}
}
