using System.IO;
using System;
using ColorsManagment.Domain.Entities;
using ColorsManagment.Domain.RepositoriesContracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using ColorsManagment.Infrastructure.Data.DataEntity;

namespace ColorsManagment.Infrastructure.Data.Repositories
{
    public class ColorRepository : IColorRepository
    {
        private readonly string _localDbFullPath;

        public ColorRepository()
        {
            _localDbFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LocalFiles", "ColorsJSON.json");
        }

        public void Insert(ColorEntity color)
        {
            string jsonFile;
            using (StreamReader reader = new StreamReader(_localDbFullPath))
            {
                //string jsonFile = File.ReadAllText(_localDbFullPath);
                jsonFile = reader.ReadToEnd();
            }

            List<ColorDataEntity> jsonList = JsonConvert.DeserializeObject<List<ColorDataEntity>>(jsonFile);

            jsonList.Add(GenerateDataEntity(color));

            string jsonFileWithInputData = JsonConvert.SerializeObject(jsonList);

            using (StreamWriter writer = new StreamWriter(_localDbFullPath))
            {
                //string jsonFile = File.ReadAllText(_localDbFullPath);
                writer.Write(jsonFileWithInputData);
            }
            //File.WriteAllText(_localDbFullPath, jsonFileWithInputData);
        }

        private ColorDataEntity GenerateDataEntity(ColorEntity color) 
        {
            return new ColorDataEntity
            {
                Color = color.Color,
                CurrentDate = DateTime.UtcNow,
                DefaultValue = color.DefaultValue,
                NumericValue = color.NumericValue
            };
        }
    }
}
