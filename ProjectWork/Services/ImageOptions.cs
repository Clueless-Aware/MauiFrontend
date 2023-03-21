namespace ProjectWork.Services.Core
{
    public class ImageOptions
    {
        public long FileMaxSize { get; set; } = long.MaxValue;

        public string FileName { get; set; } = "image_url";
    }
}