using AutoMapper;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NT.Integration.Medicus
{
    public class ApiHelper
    {
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        public static T JsonDeserializer<T>(string fileName)
        {
            try
            {
                //get credentials from json file
                string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string jsonFile = Path.Combine(assemblyFolder, fileName);
               T deserializedObject = JsonConvert.DeserializeObject<T>(File.ReadAllText(jsonFile));
                return deserializedObject;
            }
            catch (Exception e)
            {
                logger.Fatal(e.Message);
                throw;
            }

        }
        //auto maping configuration
        public static List<D> CreateMap<S, D>(List<S> Source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<S, D>();
            });
            IMapper mapper = config.CreateMapper();
            List<D> mapped = mapper.Map<List<S>, List<D>>(Source);
            return mapped;
        }

    }
}
