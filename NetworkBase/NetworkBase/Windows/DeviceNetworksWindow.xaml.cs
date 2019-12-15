using System;
using System.Data.Entity.Migrations;
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
	/// Логика взаимодействия для DeviceNetworksWindow.xaml
	/// </summary>
	public partial class DeviceNetworksWindow : Window
	{
		NetworkBaseEntities entities;
		DeviceNetworks uNetwork;

		public DeviceNetworksWindow(NetworkBaseEntities db)
		{
			InitializeComponent();
			entities = db;
			insertButton.IsEnabled = true;
			updateButton.IsEnabled = false;
		}

		public DeviceNetworksWindow(NetworkBaseEntities db, DeviceNetworks deviceNetworks)
		{
			InitializeComponent();

			uNetwork = deviceNetworks;
			entities = db;
			insertButton.IsEnabled = false;
			updateButton.IsEnabled = true;
			numberBox.IsReadOnly = true;
			ShowData();
		}

		private void ShowData()
		{
			networkID.Text = uNetwork.networkID.ToString();
			deviceID.Text = uNetwork.deviceID.ToString();
		}

		private void DeviceID_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
		}

		private void NetworkID_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
		}

		private bool CheckInput()
		{
			if (deviceID.Text.Length > 0 && networkID.Text.Length > 0)
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
					DeviceNetworks network = new DeviceNetworks();

					network.Number = Int32.Parse(numberBox.Text);
					network.deviceID = Int32.Parse(deviceID.Text);
					network.networkID = Int32.Parse(networkID.Text);

					entities.DeviceNetworks.Add(network);
					entities.SaveChanges();

					this.Close();
				}
				catch
				{
					MessageBox.Show("Ошибка добавления данных в базу.");
				}
			}

		}

		private void UpdateButton_Click(object sender, RoutedEventArgs e)
		{
			if (CheckInput())
			{
				try
				{
					uNetwork.deviceID = Int32.Parse(deviceID.Text);
					uNetwork.networkID = Int32.Parse(networkID.Text);					

					entities.DeviceNetworks.AddOrUpdate(uNetwork);
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
