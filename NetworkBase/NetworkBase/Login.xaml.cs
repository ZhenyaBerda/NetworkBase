using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
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

			var users = db.baseUsers;

			if (loginBox.Text.Length > 0) //проверка ввода логина
			{
				if (passwordBox.Password.Length > 0) //проверка ввода пароля
				{
					var query = from user in users
								where user.login == loginBox.Text.ToString() && user.password == passwordBox.Password.ToString()
								select new { user.login };

					if (query.ToList().Count > 0)
					{						
						enter = true;
						this.Close();
					}
					else
						errorLabel.Content ="Некорректные данные";

				}
				else
					errorLabel.Content = "Введите пароль!";
			}
			else
				errorLabel.Content = "Введите логин!";
		}

		private void RegButton_Click(object sender, RoutedEventArgs e)
		{
			Registration_window regWindow = new Registration_window();
			regWindow.Owner = this;

			regWindow.ShowDialog();
		}

		private void LoginWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (enter == false)
				Application.Current.Shutdown();
		}
	}
}
