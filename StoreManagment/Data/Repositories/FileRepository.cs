using Newtonsoft.Json;

namespace Data.Repositories
{
    public class FileRepository
    {
        private readonly string _localFile;

        public FileRepository(string entity)
        {
            _localFile = Path.Combine(Directory.GetCurrentDirectory(), "LocalFiles", $"{entity}.json");
        }

        public async Task WriteData<T>(IEnumerable<T> objects)
        {
            if (!(await ReadJsonFile<T>()).Any())
            {
                string jsonFileWithInputData = JsonConvert.SerializeObject(objects);

                using (StreamWriter writer = new StreamWriter(_localFile))
                {
                    await writer.WriteAsync(jsonFileWithInputData);
                }
            }
        }

        public async Task<IEnumerable<T>> ReadJsonFile<T>()
        {
            string jsonFile;
            using (StreamReader reader = new StreamReader(_localFile))
            {
                jsonFile = await reader.ReadToEndAsync();
            }
            var aa = JsonConvert.DeserializeObject<IEnumerable<T>>(jsonFile);
            return aa;
        }
    }
}
