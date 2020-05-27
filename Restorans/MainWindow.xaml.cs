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
    public MainWindow()
    {
      InitializeComponent();
      openData = new OpenData("OpenData1.json");
      FillCollection(openData.GetFoodPlaces());
    }

    public void FillCollection(FoodPlace[] collection)
    {
      MainLB.ItemsSource = collection;
    }

    private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
            FillCollection(openData.FindFoodPlaces(SearchTextBox.Text));
    }
  } 
}
