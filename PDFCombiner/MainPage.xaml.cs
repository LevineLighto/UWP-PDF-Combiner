using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PDFCombiner
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string[] DisplayName = new string[10];
        private string[] CancelHash = new string[10];
        private string[] PDFLocation = new string[10];
        private int counter = 1;
        public MainPage()
        {
            this.InitializeComponent();
            CreateAddButton();
        }

        private void CreateAddButton()
        {
            Thickness Margin = new Thickness(25);

            StackPanel AddButtonContainer = new StackPanel();
            AddButtonContainer.Margin = Margin;
            AddButtonContainer.Name = "AddButton";

            Image AddButtonImage = new Image();
            AddButtonImage.Name = "AddButtonImage";
            AddButtonImage.Height = 125;
            AddButtonImage.Width = 120;
            AddButtonImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/BTN Plus Idle.png"));

            AddButtonContainer.PointerEntered += (object sender, PointerRoutedEventArgs e) => { AddButtonImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/BTN Plus Hover.png")); };

            AddButtonContainer.PointerExited += (object sender, PointerRoutedEventArgs e) => { AddButtonImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/BTN Plus Idle.png")); };

            AddButtonContainer.Tapped += (object sender, TappedRoutedEventArgs e) =>
            {
                Container.Items.Remove((UIElement)FindName("AddButton"));
                AddPDFList();
                
            };

            AddButtonContainer.Children.Add(AddButtonImage);
            Container.Items.Add(AddButtonContainer);
        }

        private void AddPDFList()
        {
            Thickness Margin = new Thickness(25);

            Grid PDFContainer = new Grid();
            PDFContainer.Name = "PDF " + counter.ToString();
            PDFContainer.Width = 170;
            PDFContainer.Height = 175;

            Image PDFImage = new Image();
            PDFImage.Name = "PDF " + counter.ToString() + " Image";
            PDFImage.Width = 120;
            PDFImage.Height = 125;
            PDFImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PDF Inserted.png"));

            Image RemoveButton = new Image();
            RemoveButton.Name = "Remove PDF " + counter.ToString();
            RemoveButton.Width = 25;
            RemoveButton.Height = 25;
            RemoveButton.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/BTN Remove.png"));
            RemoveButton.VerticalAlignment = 0;
            RemoveButton.HorizontalAlignment = (HorizontalAlignment)2;
            RemoveButton.Margin = Margin;

            PDFContainer.Children.Add(PDFImage);
            PDFContainer.Children.Add(RemoveButton);

            Container.Items.Add(PDFContainer);

            if(counter == 10)
            {
                return;
            }
            counter++;
            CreateAddButton();
        }
    }
}
