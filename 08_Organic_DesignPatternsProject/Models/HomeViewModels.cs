namespace _08_Organic_DesignPatternsProject.Models
{
    public class BannerViewModel
    {
        public string SubTitle { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ButtonText { get; set; } = string.Empty;
        public string ButtonUrl { get; set; } = string.Empty;
        public string BackgroundImageUrl { get; set; } = string.Empty;
    }

    public class ServiceItem
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AnimationDuration { get; set; }
    }

    public class TrendItem
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string AnimationEffect { get; set; } = "fade-up";
        public int AnimationDuration { get; set; } = 1500;
    }

    public class QualityItem
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PositionClass { get; set; } = string.Empty;
        public string AnimationEffect { get; set; } = "fade-left";
        public int AnimationDuration { get; set; } = 1000;
        public bool ImageFirst { get; set; } = false;
    }

    public class SaleBannerViewModel
    {
        public string SubTitle { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string HighlightedWord { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ButtonText { get; set; } = string.Empty;
        public string ButtonUrl { get; set; } = string.Empty;
        public string BackgroundImageUrl { get; set; } = string.Empty;
        public bool ShowCountdown { get; set; } = false;
        public string CountdownDate { get; set; } = string.Empty;
        public bool ShowProductImage { get; set; } = false;
        public string ProductImageUrl { get; set; } = string.Empty;
    }

    public class BlogPost
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public int CommentCount { get; set; }
        public string Url { get; set; } = "#";
    }

    public class TestimonialItem
    {
        public string Comment { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorTitle { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }

    public class InstagramItem
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Url { get; set; } = "#";
    }
}
