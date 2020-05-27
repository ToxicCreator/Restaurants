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
using Newtonsoft;

namespace Restorans
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    OpenData openData;
        FoodPlace[] foodPlaces;
    public MainWindow()
    {
      InitializeComponent();
      openData = new OpenData("OpenData1.json");
      foodPlaces = openData.GetFoodPlaces();
      FillCollection(foodPlaces);
    }

    private void Check_Click(object sender, RoutedEventArgs e)
    {
            var foodPlaces = CheckTags(openData.FindFoodPlaces(SearchTextBox.Text));

            if(foodPlaces.Length < 1)
                foodPlaces = openData.FindFoodPlaces(SearchTextBox.Text);

            FillCollection(foodPlaces);
    }

        private FoodPlace[] CheckTags(FoodPlace[] foodPlaces)
        {
            if (RestoransCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindFoodPlacesOnTypeObject("Ресторан")).ToArray();
            }
            if (RestoransCheck.IsChecked != true)
            {
                foodPlaces = foodPlaces.Except(openData.FindFoodPlacesOnTypeObject("Ресторан")).ToArray();
            }
            if (BarCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindFoodPlacesOnTypeObject("Бар")).ToArray();
            }
            if (BarCheck.IsChecked != true)
            {
                foodPlaces = foodPlaces.Except(openData.FindFoodPlacesOnTypeObject("Бар")).ToArray();
            }
            if (CafeCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindFoodPlacesOnTypeObject("Кафе")).ToArray();
            }
            if (CafeCheck.IsChecked != true)
            {
                foodPlaces = foodPlaces.Except(openData.FindFoodPlacesOnTypeObject("Кафе")).ToArray();
            }
            if (CafeteriaCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindFoodPlacesOnTypeObject("Кафетерий")).ToArray();
            }
            if (CafeteriaCheck.IsChecked != true)
            {
                foodPlaces = foodPlaces.Except(openData.FindFoodPlacesOnTypeObject("Кафетерий")).ToArray();
            }
            if (CanteenCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindFoodPlacesOnTypeObject("Столовая")).ToArray();
            }
            if (CanteenCheck.IsChecked != true)
            {
                foodPlaces = foodPlaces.Except(openData.FindFoodPlacesOnTypeObject("Столовая")).ToArray();
            }
            if (FastFoodCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindFoodPlacesOnTypeObject("Предприятие быстрого обслуживания")).ToArray();
            }
            if (FastFoodCheck.IsChecked != true)
            {
                foodPlaces = foodPlaces.Except(openData.FindFoodPlacesOnTypeObject("Предприятие быстрого обслуживания")).ToArray();
            }
            if (BuffetCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindFoodPlacesOnTypeObject("Буфет")).ToArray();
            }
            if (BuffetCheck.IsChecked != true)
            {
                foodPlaces = foodPlaces.Except(openData.FindFoodPlacesOnTypeObject("Буфет")).ToArray();
            }
            if (DinerCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindFoodPlacesOnTypeObject("Закусочная")).ToArray();
            }
            if (DinerCheck.IsChecked != true)
            {
                foodPlaces = foodPlaces.Except(openData.FindFoodPlacesOnTypeObject("Закусочная")).ToArray();
            }
            if (ShopCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindFoodPlacesOnTypeObject("магазин (отдел кулинарии)")).ToArray();
            }
            if (ShopCheck.IsChecked != true)
            {
                foodPlaces = foodPlaces.Except(openData.FindFoodPlacesOnTypeObject("магазин (отдел кулинарии)")).ToArray();
            }
            //if (SearchTextBox.Text.Length > 0)
            //{
            //    this.foodPlaces = openData.FindFoodPlaces(SearchTextBox.Text, foodPlaces);
            //}
            return foodPlaces;
        }

    public void FillCollection(FoodPlace[] collection)
    {
      MainLB.ItemsSource = collection;
    }

    private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
            //this.foodPlaces = openData.FindFoodPlaces(SearchTextBox.Text, this.foodPlaces);
            var foodPlaces = openData.FindFoodPlaces(SearchTextBox.Text);
            FillCollection(foodPlaces);
    }
  } 
}
