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
using System.Windows.Shapes;
using LibModelControl;

namespace ProvaMontreal
{
  /// <summary>
  /// Interaction logic for MovieInfo.xaml
  /// </summary>
  public partial class MovieInfo : Window
  {
    public MovieInfo()
    {
      InitializeComponent();
    }
    private async void LoadMovieInfo_Click(object sender, RoutedEventArgs e)
    {
      var movieInfo = await MovieProcessor.LoadSunInformation();

      adultoText.Text = $"Adulto { movieInfo.Adult}";
      homePageText.Text = $"HomePage { movieInfo.Homepage}";
      titleText.Text = $"HomePage { movieInfo.Title}";
      originalTitleText.Text = $"HomePage { movieInfo.OriginalTitle}";
      overviewText.Text = $"HomePage { movieInfo.Overview}";
      idText.Text = $"HomePage { movieInfo.Id}";
      popularityText.Text = $"HomePage { movieInfo.Popularity}";
      releaseDateText.Text = $"HomePage { movieInfo.ReleaseDate}";
      statusText.Text = $"HomePage { movieInfo.Status}";
    }
  }
}
