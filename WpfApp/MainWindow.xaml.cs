
using ComicLibrary;
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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int maxNum = 0;
        private int currentNum = 0;
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeComicClient();
            nextImageButton.IsEnabled = false;
        }

        private async Task LoadImage(int imageNumber = 0)
        {
            var comic = await ComicProcessor.LoadComic(imageNumber);

            if(imageNumber ==0)
            {
                maxNum = comic.Num;
            }

            currentNum = comic.Num;

            var urisource = new Uri(comic.Img, UriKind.Absolute);

            comicImage.Source = new BitmapImage(urisource);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadImage();
        }


        private async void previousImageButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentNum >1)
            {
                currentNum -= 1;
                nextImageButton.IsEnabled = true;
                await LoadImage(currentNum);


                if(currentNum == 1)
                {
                    previousImageButton.IsEnabled = false;
                }
            }
        }

        private async void nextImageButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentNum < maxNum)
            {
                currentNum += 1;
                previousImageButton.IsEnabled = true;
                await LoadImage(currentNum);

                if(currentNum == maxNum)
                {
                    nextImageButton.IsEnabled = false;
                }
            }
        }
     
    }
}
