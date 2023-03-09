using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using ProjectWork.Models.Core.Authentication;
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
                await UtilityToolkit.CreateToast(e.Message);
                throw;
            }
        }
    }

}