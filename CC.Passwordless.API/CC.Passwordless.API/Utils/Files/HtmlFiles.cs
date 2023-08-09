namespace CC.Passwordless.Utils.Files
{
    public static class HtmlFiles
    {
        public static string LoadHtmlFromFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"The File {filePath} it was not found.");
                }

                string htmlContent;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    htmlContent = reader.ReadToEnd();
                }

                return htmlContent;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
