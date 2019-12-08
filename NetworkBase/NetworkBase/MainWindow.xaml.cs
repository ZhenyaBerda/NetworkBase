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

namespace NetworkBase
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Table table;

		public MainWindow()
		{
			InitializeComponent();
			//OpenLogin();
		}

		void OpenLogin()
		{
			login login = new login();
			login.ShowDialog();
		}

		

		private void ShowButton_Click(object sender, RoutedEventArgs e)
		{
			if (tablesBox.SelectedIndex == 0)
			{
				table = Table.device;
			}
		}
	}
}
