using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SwEngHomework.Commissions
{
    public class CommissionCalculator : ICommissionCalculator
    {
        /// <summary>
        /// This solution reads the json string and deserializes it as it steps through the string.
        /// This means only having to iterate through the advisors / accounts once.
        /// It does rely on the advisors being set in the file before the accounts.
        /// </summary>
        /// <param name="jsonInput"></param>
        /// <returns></returns>
        public Dictionary<string, double> CalculateCommissionsByAdvisor(string jsonInput)
        {
            var advisors = new Dictionary<string, string>();
            var commissionReport = new Dictionary<string, double>();

            using (var inputStream = jsonInput.ToStream())
            using (var reader = new StreamReader(inputStream))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var inAdvisors = false;
                var inAccounts = false;
                while(jsonReader.Read())
                {
                    if(jsonReader.TokenType == JsonToken.PropertyName && jsonReader.Value.Equals("advisors"))
                    {
                        inAdvisors = true;
                        inAccounts = false;
                    }

                    if (jsonReader.TokenType == JsonToken.PropertyName && jsonReader.Value.Equals("accounts"))
                    {
                        inAdvisors = false;
                        inAccounts = true;
                    }

                    if (inAdvisors && jsonReader.TokenType == JsonToken.StartObject)
                    {
                        var serializer = new JsonSerializer();
                        var advisor = serializer.Deserialize<Advisor>(jsonReader);
                        advisors.Add(advisor.Name, advisor.Level);
                        commissionReport.Add(advisor.Name, 0);
                    }

                    if(inAccounts && jsonReader.TokenType == JsonToken.StartObject)
                    {
                        var serializer = new JsonSerializer();
                        var account = serializer.Deserialize<Account>(jsonReader);

                        if(advisors.ContainsKey(account.Advisor) && commissionReport.ContainsKey(account.Advisor))
                        {
                            var level = advisors[account.Advisor];
                            var currentCommission = commissionReport[account.Advisor];
                            var commission = CalculateCommission(level, account.PresentValue);
                            commissionReport[account.Advisor] = currentCommission + commission;
                        }                        
                    }
                }
            }

            return commissionReport;
        }

        private double CalculateCommission(string level, double presentValue)
        {
            var commissionPercent = CalculateCommisionPercent(level);
            var basisPoints = CalculateBasisPoints(presentValue);

            return commissionPercent > 0 && basisPoints > 0
                ? Math.Round(presentValue * basisPoints * commissionPercent / 10000, 2, MidpointRounding.AwayFromZero)
                : 0;
        }

        private double CalculateCommisionPercent(string level)
        {
            switch (level)
            {
                case "Senior":
                    return 1;                    
                case "Experienced":
                    return .5;                    
                case "Junior":
                    return .25;                    
                default:
                    return 0;
            }
        }

        private int CalculateBasisPoints(double presentValue)
        {
            return presentValue < 50000 
                ? 5 
                : presentValue >= 100000 
                    ? 7 
                    : 6;
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
