namespace dotnetproj
{
    public delegate void SearchPerformedEventHandler(object sender, EventArgs e);

    public class SearchService
    {
        public event SearchPerformedEventHandler SearchPerformed;

        public void PerformSearch(string searchTerm)
        {
            SearchPerformed?.Invoke(this, EventArgs.Empty);
        }
    }
}