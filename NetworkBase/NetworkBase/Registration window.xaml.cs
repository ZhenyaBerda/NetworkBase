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
	/// Логика взаимодействия для Registration_window.xaml
	/// </summary>
	public partial class Registration_window : Window
	{
		public Registration_window()
		{
			InitializeComponent();
		}

		//Регистрация пользователя
		private void regisButton_Click(object sender, RoutedEventArgs e)
		{
			statusLabel.Content = "";


			if (loginBox.Text.Length > 0) //проверка ввода логина
			{
				if (passwordBox.Password.Length > 0) //проверка ввода пароля
				{
					if (passwordRepeat.Password.Length > 0) //проверка повторного ввода пароля
					{
						if (passwordRepeat.Password == passwordBox.Password) //проверка совпадения паролей
						{
							statusLabel.Foreground = Brushes.LightGreen;
							statusLabel.Content = "Молодец, возьми с полки пирожок!";
						}
						else
							statusLabel.Content = "Пароли не совпадают";
					}
					else
					statusLabel.Content = "Повторите пароль";
				}
				else
					statusLabel.Content = "Введите пароль";
			}
			else
				statusLabel.Content = "Введите логин";
		}

		//Добавление данных нового пользователя в бд
		private void AddUser()
		{
			//добавление пользователя в бд
		}
	}
}
