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
	/// Логика взаимодействия для Login.xaml
	/// </summary>
	public partial class Login : Window
	{
		NetworkBaseEntities db = new NetworkBaseEntities();

		public Login()
		{
			InitializeComponent();
		}

		//Проверка подлинности
		private void EnterButton_Click(object sender, RoutedEventArgs e)
		{
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
						MessageBox.Show("Добро пожаловать!");
						this.Close();
					}
					else
					{
						MessageBox.Show("Некорректные данные");
							
					}
				}
				else
				MessageBox.Show("Введите пароль!");
			}
			else
			MessageBox.Show("Введите логин!");
		}

		private void RegBurron_Click(object sender, RoutedEventArgs e)
		{
			Registration_window regWindow = new Registration_window();
			regWindow.Owner = this;

			regWindow.ShowDialog();

		}
	}
}
