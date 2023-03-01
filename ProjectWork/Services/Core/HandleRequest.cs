using ProjectWork.Utilities;

namespace ProjectWork.Services.Core
{
    public class HandleRequest
    {
        public static async Task<T> Requested<T>(Task<T> task)
        {
            try
            {
                return await task;
            }
            catch (Exception e)
            {
                await UtilyToolkit.CreateToast(e.Message);
                return default;
            }
        }
    }
}