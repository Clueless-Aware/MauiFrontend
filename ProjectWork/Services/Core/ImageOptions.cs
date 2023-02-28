namespace ProjectWork.Services.Core
{
    public class ImageOptions
    {
		private long fileMaxSize = long.MaxValue;

		public long FileMaxSize
		{
			get { return fileMaxSize; }
			set { fileMaxSize = value; }
		}

		private string fileName = "image_url";

		public string FileName
		{
			get { return fileName; }
			set { fileName = value; }
		}


	}
}