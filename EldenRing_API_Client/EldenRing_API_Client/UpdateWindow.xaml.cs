using EldenRing_API_Client.Modles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Attribute = EldenRing_API_Client.Modles.Attribute;

namespace EldenRing_API_Client
{
    /// <summary>
    /// Interaktionslogik für UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        List<Weapon> weapons = new List<Weapon>();
        Weapon weapon;
		HttpClient client = new HttpClient();

		public UpdateWindow(object selectedWeapon)
        {
            InitializeComponent();
            weapon = selectedWeapon as Weapon;
			DataContext = selectedWeapon;

           
			weapons.Add(selectedWeapon as Weapon);
			AttackDataGrid.ItemsSource = weapons;
            DefenceDataGrid.ItemsSource = weapons;
            RequiredAttributeDataGrid.ItemsSource = weapons;
            ScalingDataGrid.ItemsSource = weapons;
		}


		private void UpdateButton_Click_1(object sender, RoutedEventArgs e)
		{
            var a = weapons[0];
            UpdateCall();

		}

        private void UpdateCall()
        {
			client.BaseAddress = new Uri("http://localhost:8080/");
			string json = JsonConvert.SerializeObject(weapon);
			Console.WriteLine(json);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = client.PostAsync("updateWeapon/" + weapon.name, content).Result;
		}
	}
}
