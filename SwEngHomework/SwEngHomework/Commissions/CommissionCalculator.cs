using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SwEngHomework.Commissions
{
    public class CommissionCalculator : ICommissionCalculator
    {
        public IDictionary<string, double> CalculateCommissionsByAdvisor(string jsonInput)
        {
            var serializer = new JsonSerializer();

            using (var inputStream = jsonInput.ToStream())
            using (var reader = new StreamReader(inputStream))
            using (var jsonReader = new JsonTextReader(reader))
            {
                while(jsonReader.Read())
                {
                    if(jsonReader.TokenType == JsonToken.StartArray)
                    {

                    }
                }
            }

            //var commisionCalculatorInput = JsonConvert.DeserializeObject<CommisionCalculatorInput>(jsonInput);

            //var advisors = new Dictionary<string, string>();

            //commisionCalculatorInput.Advisors.Select(i => advisors.Add(i.Name, i.Level));
            // TODO: your implementation
            throw new NotImplementedException();
        }
    }

    public static class StringExtensions
    {
        public static Stream ToStream(this string str)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
