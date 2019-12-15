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
	/// Логика взаимодействия для NetworksWindow.xaml
	/// </summary>
	public partial class NetworksWindow : Window
	{
		NetworkBaseEntities entities;

		public NetworksWindow(NetworkBaseEntities db)
		{
			entities = db;

			InitializeComponent();
		}

		private void NetworkID_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
		}

		private bool CheckInput()
		{
			if (networkID.Text.Length > 0 && networkName.Text.Length > 0 && networkIP.Text.Length > 0)
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
					Networks network = new Networks();

					network.networkID = Int32.Parse(networkID.Text);
					network.networkName = networkName.Text;
					network.networkPassword = networkPassword.Text;
					network.networkIP = networkIP.Text;

					entities.Networks.Add(network);
					entities.SaveChanges();

					this.Close();
				}
				catch
				{
					MessageBox.Show("Ошибка добавления данных в базу.");
				}
			}
			else
				MessageBox.Show("Не все поля заполнены.");
		}
	}
}
