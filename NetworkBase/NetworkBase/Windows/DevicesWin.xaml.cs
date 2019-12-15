using System;
using System.Windows;
using System.Windows.Input;
using System.Data.Entity.Migrations;


namespace NetworkBase
{
    /// <summary>
    /// Логика взаимодействия для DevicesWin.xaml
    /// </summary>
    public partial class DevicesWin : Window
    {

		NetworkBaseEntities entities;
		Devices udevice;

        public DevicesWin(NetworkBaseEntities db)
        {
			
			InitializeComponent();
			Button.IsEnabled = true;
			updateButton.IsEnabled = false;
			entities = db;
		}

		public DevicesWin(NetworkBaseEntities db, Devices device)
		{
			InitializeComponent();

			entities = db;
			udevice = device;
			Button.IsEnabled = false;
			updateButton.IsEnabled = true;
			deviceID.IsReadOnly = true;
			ShowData();
		}

		private void ShowData()
		{
			deviceID.Text = udevice.deviceID.ToString();
			deviceName.Text = udevice.deviceName;
			deviceType.Text = udevice.deviceType;
			deviceOS.Text = udevice.deviceOS;
			deviceSNumber.Text = udevice.deviceSNumber;
			departmentID.Text = udevice.departmentID.ToString();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (CheckInput())
			{

				try
				{
					Devices device = new Devices();

					device.deviceID = Int32.Parse(deviceID.Text);
					device.deviceName = deviceName.Text;
					device.deviceType = deviceType.Text;
					device.deviceOS = deviceOS.Text;
					device.deviceSNumber = deviceSNumber.Text;
					device.departmentID = Int32.Parse(departmentID.Text);

					entities.Devices.Add(device);
					entities.SaveChanges();

					this.Close();
				}
				catch {
					MessageBox.Show("Ошибка добавления данных в базу.");
				}


			}
			else
				MessageBox.Show("Не все поля заполнены");



		}

		private bool CheckInput()
		{
			if (deviceID.Text.Length > 0 && deviceName.Text.Length > 0 && deviceType.Text.Length > 0
				&& deviceOS.Text.Length > 0 && deviceSNumber.Text.Length > 0 && departmentID.Text.Length > 0)
				return true;
			else
				return false;
		}

		private void DeviceID_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
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
					udevice.deviceName = deviceName.Text;
					udevice.deviceType = deviceType.Text;
					udevice.deviceOS = deviceOS.Text;
					udevice.deviceSNumber = deviceSNumber.Text;
					udevice.departmentID = Int32.Parse(departmentID.Text);

					entities.Devices.AddOrUpdate(udevice);
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
