using System;
using System.Data.Entity.Migrations;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace NetworkBase
{
	/// <summary>
	/// Логика взаимодействия для UsersWindow.xaml
	/// </summary>
	public partial class UsersWindow : Window
	{
		NetworkBaseEntities entities;
		
		Users uUser;

		public UsersWindow(NetworkBaseEntities db)
		{
			InitializeComponent();

			entities = db;		
			insertButton.IsEnabled = true;
			updateButton.IsEnabled = false;
		}

		public UsersWindow(NetworkBaseEntities db, Users users)
		{
			InitializeComponent();

			entities = db;
			uUser = users;
			insertButton.IsEnabled = false;
			updateButton.IsEnabled = true;
			userID.IsReadOnly = true;
			ShowData();
		}

		private void ShowData()
		{
			userID.Text = uUser.userID.ToString();
			userLogin.Text = uUser.userLogin;
			userPassword.Text = uUser.userPassword;
			userAccount.Text = uUser.userAccount;
			deviceID.Text = uUser.deviceID.ToString();
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

		private void UpdateButton_Click(object sender, RoutedEventArgs e)
		{
			if (CheckInput())
			{
				try
				{
					uUser.userLogin = userLogin.Text;
					uUser.userPassword = userPassword.Text;
					uUser.userAccount = userAccount.Text;
					uUser.deviceID = Int32.Parse(deviceID.Text);


					entities.Users.AddOrUpdate(uUser);
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
