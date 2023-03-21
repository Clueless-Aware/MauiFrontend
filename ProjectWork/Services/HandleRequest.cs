namespace ProjectWork.Services.Core
{
    public class HandleRequest
    {
        public static async Task<T> Requested<T>(Task<T> task)
        {
            return await task;
        }
    }

}