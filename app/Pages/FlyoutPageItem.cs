namespace app.Pages
{
    public class FlyoutPageItem
    {
        public required string Title { get; set; }
        public required Type TargetType { get; set; }

        public Page? page { get; set; } = null;
    }
}
