using System.Windows;

namespace dotnetproj
{
    public partial class MainWindow : Window
    {
        private MovieRepository _movieRepository;
        private SearchService _searchService;

        public MainWindow()
        {
            InitializeComponent();

            _movieRepository = new MovieRepository();
            _searchService = new SearchService();
            _searchService.SearchPerformed += OnSearchPerformed;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = SearchTextBox.Text;
            _searchService.PerformSearch(searchTerm);
        }

        private void OnSearchPerformed(object sender, EventArgs e)
        {
            string searchTerm = SearchTextBox.Text;
            var results = _movieRepository.SearchMovies(searchTerm);
            if (results.Any())
            {
                ResultsListBox.ItemsSource = results.OrderBy(m => m.Title);
                NoResultsMessage.Visibility = Visibility.Collapsed;
            }
            else
            {
                ResultsListBox.ItemsSource = null;
                NoResultsMessage.Visibility = Visibility.Visible;
            }
        }

        private void ResultsListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ResultsListBox.SelectedItem is Movie selectedMovie)
            {
                TitleTextBlock.Text = $"Title: {selectedMovie.Title}";
                DirectorTextBlock.Text = $"Director: {selectedMovie.Director}";
                YearTextBlock.Text = $"Year: {selectedMovie.Year}";
            }
            else
            {
                TitleTextBlock.Text = "Title:";
                DirectorTextBlock.Text = "Director:";
                YearTextBlock.Text = "Year:";
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Clear();
            ResultsListBox.ItemsSource = null;
            NoResultsMessage.Visibility = Visibility.Collapsed;

            TitleTextBlock.Text = "Title:";
            DirectorTextBlock.Text = "Director:";
            YearTextBlock.Text = "Year:";
        }
    }
}
