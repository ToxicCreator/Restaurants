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
        openData = new OpenData("OpenData.json");
            foodPlaces = openData.GetFoodPlaces();
    }

    private void Check_Click(object sender, RoutedEventArgs e)
    {
           CheckBox checkBox = (CheckBox)e.Source;
            switch(checkBox.Name)
            {
                case "RestoransCheck":
                    if (checkBox.IsChecked == true)
                    {
                        FillCollection(foodPlaces.Union(openData.FindFoodPlacesOnTypeObject("Ресторан")).ToArray());
                    }
                    if(checkBox.IsChecked == false)
                    {
                        FillCollection(foodPlaces.Except(openData.FindFoodPlacesOnTypeObject("Ресторан")).ToArray());
                    }
                    break;
                case "BarCheck":
                    if (checkBox.IsChecked == true)
                    {
                        FillCollection(foodPlaces.Union(openData.FindFoodPlacesOnTypeObject("Бар")).ToArray());
                    }
                    if (checkBox.IsChecked == false)
                    {
                        FillCollection(foodPlaces.Except(openData.FindFoodPlacesOnTypeObject("Бар")).ToArray());
                    }
                    break;
                case "CafeCheck":
                    if (checkBox.IsChecked == true)
                    {
                        FillCollection(foodPlaces.Union(openData.FindFoodPlacesOnTypeObject("Кафе")).ToArray());
                    }
                    if (checkBox.IsChecked == false)
                    {
                        FillCollection(foodPlaces.Except(openData.FindFoodPlacesOnTypeObject("Кафе")).ToArray());
                    }
                    break;
                case "CafeteriaCheck":
                    if (checkBox.IsChecked == true)
                    {
                        FillCollection(foodPlaces.Union(openData.FindFoodPlacesOnTypeObject("Кафетерий")).ToArray());
                    }
                    if (checkBox.IsChecked == false)
                    {
                        FillCollection(foodPlaces.Except(openData.FindFoodPlacesOnTypeObject("Кафетерий")).ToArray());
                    }
                    
                    break;
                case "CanteenCheck":
                    if (checkBox.IsChecked == true)
                    {
                        FillCollection(foodPlaces.Union(openData.FindFoodPlacesOnTypeObject("Столовая")).ToArray());
                    }
                    if (checkBox.IsChecked == false)
                    {
                        FillCollection(foodPlaces.Except(openData.FindFoodPlacesOnTypeObject("Столовая")).ToArray());
                    }
                    
                    break;
                case "FastFoodCheck":
                    if (checkBox.IsChecked == true)
                    {
                        FillCollection(foodPlaces.Union(openData.FindFoodPlacesOnTypeObject("Ресторан быстрого питания")).ToArray());
                    }
                    if (checkBox.IsChecked == false)
                    {
                        FillCollection(foodPlaces.Except(openData.FindFoodPlacesOnTypeObject("Ресторан быстрого питания")).ToArray());
                    }
                    
                    break;
                case "BuffetCheck":
                    if (checkBox.IsChecked == true)
                    {
                        FillCollection(foodPlaces.Union(openData.FindFoodPlacesOnTypeObject("Буфет")).ToArray());
                    }
                    if (checkBox.IsChecked == false)
                    {
                        FillCollection(foodPlaces.Except(openData.FindFoodPlacesOnTypeObject("Буфет")).ToArray());
                    }
                    
                    break;
                case "DinerCheck":
                    if (checkBox.IsChecked == true)
                    {
                        FillCollection(foodPlaces.Union(openData.FindFoodPlacesOnTypeObject("Закусочная")).ToArray());
                    }
                    if (checkBox.IsChecked == false)
                    {
                        FillCollection(foodPlaces.Except(openData.FindFoodPlacesOnTypeObject("Закусочная")).ToArray());
                    }
                    
                    break;
                case "ShopCheck":
                    if (checkBox.IsChecked == true)
                    {
                        FillCollection(foodPlaces.Union(openData.FindFoodPlacesOnTypeObject("магазин (отдел кулинарии)")).ToArray());
                    }
                    if (checkBox.IsChecked == false)
                    {
                        FillCollection(foodPlaces.Except(openData.FindFoodPlacesOnTypeObject("магазин (отдел кулинарии)")).ToArray());
                    }
                    break;
            }
    }

    public void FillCollection(FoodPlace[] collection)
    {

    }
  } 
}
