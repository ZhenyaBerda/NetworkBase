using System;
using System.Linq;
using System.Data.Entity;
using System.Windows;
using System.Data.SqlClient;
using System.Security.Principal;


namespace NetworkBase
{
	/// <summary>
	/// Логика взаимодействия для login.xaml
	/// </summary>
	public partial class login : Window
	{

		NetworkBaseEntities db = new NetworkBaseEntities();
		bool enter=false;


		public login()
		{
			InitializeComponent();
			
		}

		private void EnterButton_Click(object sender, RoutedEventArgs e)
		{

			errorLabel.Content = "";

			

			if (loginBox.Text.Length > 0) //проверка ввода логина
			{
				if (passwordBox.Password.Length > 0) //проверка ввода пароля
				{
					/*
					string connectionString = 
					SqlConnection sqlConnection = new SqlConnection();
					*/

				}
				else
					errorLabel.Content = "Введите пароль!";
			}
			else
				errorLabel.Content = "Введите логин!";
				

		}

	

		private void LoginWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (enter == false)
				Application.Current.Shutdown();
		}
	}
}
