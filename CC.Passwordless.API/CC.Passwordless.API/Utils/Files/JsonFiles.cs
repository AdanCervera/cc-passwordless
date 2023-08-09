using CC.Passwordless.API.Models;
using Newtonsoft.Json;

namespace CC.Passwordless.Utils.Files
{
    public class JsonFiles
    {
        public async Task<EmailData> ReadFileToObject(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path), "The path cannot be empty or null");
            }

            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string json = await reader.ReadToEndAsync();
                        EmailData objectReturn = JsonConvert.DeserializeObject<EmailData>(json);
                        return objectReturn;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in the JSON file: " + ex.Message, ex);
            }
        }
    }
}
