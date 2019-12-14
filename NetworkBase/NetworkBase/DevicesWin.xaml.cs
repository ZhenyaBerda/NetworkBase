using System;
using System.Windows;
using System.Windows.Input;


namespace NetworkBase
{
    /// <summary>
    /// Логика взаимодействия для DevicesWin.xaml
    /// </summary>
    public partial class DevicesWin : Window
    {

		NetworkBaseEntities entities;

        public DevicesWin(NetworkBaseEntities db)
        {
			entities = db;

			InitializeComponent();
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Devices device = new Devices();

			if (CheckInput())
			{

				try
				{
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
	}
}
