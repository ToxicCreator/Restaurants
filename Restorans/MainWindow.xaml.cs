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
            foodPlaces = CheckTags(openData.GetFoodPlaces());

            if (foodPlaces.Length < 1)
                foodPlaces = openData.GetFoodPlaces();

            FillCollection(openData.FindFoodPlaces(SearchTextBox.Text, foodPlaces));
    }

        private FoodPlace[] CheckTags(FoodPlace[] foodPlaces)
        {
            if (RestoransCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindOnType("Ресторан")).ToArray();
            }
            else
            {
                foodPlaces = foodPlaces.Except(openData.FindOnType("Ресторан")).ToArray();
            }

            if (BarCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindOnType("Бар")).ToArray();
            } 
            else
            {
                foodPlaces = foodPlaces.Except(openData.FindOnType("Бар")).ToArray();
            }

            if (CafeCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindOnType("Кафе")).ToArray();
            }
            else
            {
                foodPlaces = foodPlaces.Except(openData.FindOnType("Кафе")).ToArray();
            }

            if (CafeteriaCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindOnType("Кафетерий")).ToArray();
            }
            else
            {
                foodPlaces = foodPlaces.Except(openData.FindOnType("Кафетерий")).ToArray();
            }

            if (CanteenCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindOnType("Столовая")).ToArray();
            }
            else
            {
                foodPlaces = foodPlaces.Except(openData.FindOnType("Столовая")).ToArray();
            }

            if (FastFoodCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindOnType("Предприятие быстрого обслуживания")).ToArray();
            }
            else
            {
                foodPlaces = foodPlaces.Except(openData.FindOnType("Предприятие быстрого обслуживания")).ToArray();
            }

            if (BuffetCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindOnType("Буфет")).ToArray();
            }
            else
            {
                foodPlaces = foodPlaces.Except(openData.FindOnType("Буфет")).ToArray();
            }

            if (DinerCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindOnType("Закусочная")).ToArray();
            }
            else
            {
                foodPlaces = foodPlaces.Except(openData.FindOnType("Закусочная")).ToArray();
            }

            if (ShopCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindOnType("магазин (отдел кулинарии)")).ToArray();
            }
            else
            {
                foodPlaces = foodPlaces.Except(openData.FindOnType("магазин (отдел кулинарии)")).ToArray();
            }

            return foodPlaces;
        }

    public void FillCollection(FoodPlace[] collection)
    {
      MainLB.ItemsSource = collection;
    }

    private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
            
            FillCollection(openData.FindFoodPlaces(SearchTextBox.Text, foodPlaces));
    }

    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
      RestoransCheck.IsChecked = false;
      BarCheck.IsChecked = false;
      CafeCheck.IsChecked = false;
      CafeteriaCheck.IsChecked = false;
      CanteenCheck.IsChecked = false;
      FastFoodCheck.IsChecked = false;
      BuffetCheck.IsChecked = false;
      DinerCheck.IsChecked = false;
      ShopCheck.IsChecked = false;
    }
  } 
}
