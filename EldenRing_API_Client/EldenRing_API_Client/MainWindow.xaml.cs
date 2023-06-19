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
		string baseaddres = "http://localhost:8080/";
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

		private void OpenPostMenuButton_Click(object sender, RoutedEventArgs e)
		{
			PostPage postPage = new PostPage();
			postPage.ShowDialog();
			weaponlist.Add(postPage.weapon);
		}
	}
}
