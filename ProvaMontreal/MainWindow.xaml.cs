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
using LibModelControl;

namespace ProvaMontreal
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private int lastPage = 0;
    private int PageNumber = 0;
    public MainWindow()
    {
      InitializeComponent();
      ApiHelper.InitializeClient();
      nextMovieButton.IsEnabled = false;
    }
    private async Task LoadMovie(int page = 0)
    {
      MovieModel movie = await MovieProcessor.LoadMovie(page);

      if (page == 0)
      {
        lastPage = 100;
      }

      PageNumber = movie.Id;

      titleText.Text = movie.Title;
      idText.Text = movie.Id.ToString();
      homePageText.Text = movie.Homepage;
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
      await LoadMovie();
    }

    private async void previousMovieButton_Click(object sender, RoutedEventArgs e)
    {
      if (PageNumber > 1)
      {
        PageNumber -= 1;
        nextMovieButton.IsEnabled = true;
        await LoadMovie(PageNumber);

        if (PageNumber == 1)
        {
          previousMovieButton.IsEnabled = false;
        }
      }
    }

    private async void nextMovieButton_Click(object sender, RoutedEventArgs e)
    {
      if (PageNumber < lastPage)
      {
        PageNumber += 1;
        previousMovieButton.IsEnabled = true;
        await LoadMovie(PageNumber);

        if (PageNumber == lastPage)
        {
          nextMovieButton.IsEnabled = false;
        }
      }
    }

    private void movieInformationButton_Click(object sender, RoutedEventArgs e)
    {
      MovieInfo movieInfo = new MovieInfo();

      movieInfo.Show();
    }
  }
}
