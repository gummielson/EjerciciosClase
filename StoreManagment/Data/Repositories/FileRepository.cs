using System.Collections.Generic;
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

        public async Task WriteData<T>(T objects)
        {
            if ((await ReadJsonFile<IEnumerable<T>>()).Count() < 1)
            {
                string jsonFileWithInputData = JsonConvert.SerializeObject(objects);

                using (StreamWriter writer = new StreamWriter(_localFile))
                {
                    await writer.WriteAsync(jsonFileWithInputData);
                }
            }
        }

        public async Task<T> ReadJsonFile<T>()
        {
            string jsonFile;
            using (StreamReader reader = new StreamReader(_localFile))
            {
                jsonFile = await reader.ReadToEndAsync();
            }

            return JsonConvert.DeserializeObject<T>(jsonFile) ?? default(T);
        }
    }
}
