using EldenRing_API_Client.Modles;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Attribute = EldenRing_API_Client.Modles.Attribute;

namespace EldenRing_API_Client
{
	public partial class MainWindow : Window
	{
		ObservableCollection<Weapon> weaponlist;
		HttpClient client = new HttpClient();

		public MainWindow()
		{
			InitializeComponent();


			weaponlist = getWeaponData("http://localhost:8080/weapons");
			getWeaponList.ItemsSource = weaponlist;
			FilterBy.ItemsSource = new string[] { "Name", "Category", "Weight" };
		}

		public Predicate<object> GetFilter()
		{
			switch (FilterBy.SelectedItem as string)
			{
				case "Name":
					FilterBasicSettings();
					return NameFilter;
				case "Category":
					FilterBasicSettings();
					return CategoryFilter;
				case "Weight":
					FilterBasicSettings();
					return WeightFilter;
			}

			return NameFilter; //Default Filter
		}


		public void FilterBasicSettings()
		{
			FilterText.Visibility = Visibility.Visible;
			FilterText.IsEnabled = true;
			FilterText_Scaling_Name.Visibility = Visibility.Hidden;
			FilterText_Scaling_scaling.Visibility = Visibility.Hidden;
			FilterText_Scaling_Name.IsEnabled = false;
			FilterText_Scaling_scaling.IsEnabled = false;
			FilterText_Attribute_Name.Visibility = Visibility.Hidden;
			FilterText_Attribute_Amount.Visibility = Visibility.Hidden;
			FilterText_Attribute_Name.IsEnabled = false;
			FilterText_Attribute_Amount.IsEnabled = false;
		}

		public bool NameFilter(object obj)
		{
			Weapon filterobject = obj as Weapon;
			return filterobject.name.Contains(FilterText.Text);
		}

		public bool CategoryFilter(object obj)
		{
			Weapon filterobject = obj as Weapon;
			return filterobject.category.Contains(FilterText.Text);
		}

		public bool WeightFilter(object obj)
		{
			Weapon filterobject = obj as Weapon;
			return filterobject.weight.ToString().Contains(FilterText.Text);
		}

		public ObservableCollection<Weapon> getWeaponData(string link)
		{
			WebClient client = new WebClient();

			string responseBody = client.DownloadString(link);
			Console.WriteLine(responseBody);

			ObservableCollection<Weapon> weaponlist = JsonConvert.DeserializeObject<ObservableCollection<Weapon>>(responseBody);

			return weaponlist;
		}

		private void FilterText_TextChanged(object sender, RoutedEventArgs e)
		{
			if (FilterText.Text == null)
			{
				getWeaponList.Items.Filter = null;
			}
			else
			{
				getWeaponList.Items.Filter = GetFilter();
				//getWeaponList.Items.Filter = new Predicate<object>(x=>ScalingFilterName(x) || ScalingFilterTier(x));
			}

		}

		private void FilterBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			getWeaponList.Items.Filter = GetFilter();
		}

		private void getWeaponList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (getWeaponList.SelectedItem != null)
			{
				PopUpWindow popUpWindow = new PopUpWindow(getWeaponList.SelectedItem, getWeaponList, weaponlist);
				popUpWindow.Show();
			}

		}



		private void PostButton_Click(object sender, RoutedEventArgs e)
		{

			Weapon weapon = new Weapon()
			{
				name = txtName.Text,
				image = txtImage.Text,
				attack = new List<Attribute>
				{
					new Attribute(name: "physical", amount: int.Parse(txtAttacks_Phy.Text)),
					new Attribute(name: "magic", amount: int.Parse(txtAttacks_Magic.Text)),
					new Attribute(name: "fire", amount: int.Parse(txtAttacks_Fire.Text)),
					new Attribute(name: "lightning", amount: int.Parse(txtAttacks_Ltng.Text)),
					new Attribute(name: "holy", amount: int.Parse(txtAttacks_Holy.Text)),
					new Attribute(name: "crit", amount: int.Parse(txtAttacks_Crit.Text)),
				},
				defence = new List<Attribute>
				{
					new Attribute(name: "physical", amount: int.Parse(txtDefence_Phy.Text)),
					new Attribute(name: "magic", amount: int.Parse(txtDefence_Magic.Text)),
					new Attribute(name: "fire", amount: int.Parse(txtDefence_Fire.Text)),
					new Attribute(name: "lightning", amount: int.Parse(txtDefence_Ltng.Text)),
					new Attribute(name: "holy", amount: int.Parse(txtDefence_Holy.Text)),
					new Attribute(name: "crit", amount: int.Parse(txtDefence_Boost.Text)),
				},

				requiredAttributes = new List<Attribute>
				{
					new Attribute(name: "physical", amount: int.Parse(txtRequiredAttribute_Str.Text)),
					new Attribute(name: "magic", amount: int.Parse(txtRequiredAttributes_Dex.Text)),
					new Attribute(name: "fire", amount: int.Parse(txtRequiredAttributes_Int.Text)),
					new Attribute(name: "lightning", amount: int.Parse(txtRequiredAttributes_Faith.Text)),
					new Attribute(name: "holy", amount: int.Parse(txtRequiredAttributes_Arc.Text)),
				},

				scalesWith = new List<Scaling>
				{
					new Scaling(name: "strength", scaling: txtSclaesWith_Str.Text),
					new Scaling(name: "dex", scaling: txtSclaesWith_Dex.Text),
					new Scaling(name: "intelligence", scaling: txtSclaesWith_Int.Text),
					new Scaling(name: "faith", scaling: txtSclaesWith_Faith.Text),
					new Scaling(name: "arcane", scaling: txtSclaesWith_Arc.Text),
				},
				description = txtDescription.Text,
				weight = float.Parse(txtWeight.Text),
				category = txtCategory.Text,

			};


			client.BaseAddress = new Uri("http://localhost:8080/");
			string json = JsonConvert.SerializeObject(weapon);
			Console.WriteLine(json);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = client.PostAsync("addWeapon", content).Result;
		}
	}
}
