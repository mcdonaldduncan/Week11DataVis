using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using static DataVisWeek11.Constants;

namespace DataVisWeek11
{
    internal class Services
    {
        public List<Error> errors = new List<Error>();
        List<Log> logs = new List<Log>();

        public async Task<List<DataModel>> GetRequest(string requestName)
        {
            List<DataModel> dataModels = new List<DataModel>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7222/Monster/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.GetAsync(requestName).Result;
                    dataModels = JsonConvert.DeserializeObject<List<DataModel>>(await response.Content.ReadAsStringAsync());

                    logs.Add(new Log(requestName, response.RequestMessage?.ToString(), response.StatusCode.ToString(), DateTime.Now));
                }

            }
            catch (Exception e)
            {
                errors.Add(new Error(e.Message, e.Source));
            }

            return dataModels;
        }

        public void GenerateLogFile()
        {
            string writePath = Path.Combine(directoryPath, "logs.txt");

            try
            {
                if (File.Exists(writePath))
                {
                    File.Delete(writePath);
                }

                using (StreamWriter sw = new StreamWriter(writePath, true))
                {
                    sw.WriteLine($"Processed at: {DateTime.Now}");
                    sw.WriteLine();

                    foreach (var log in logs)
                    {
                        sw.WriteLine(log.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                errors.Add(new Error(e.Message, e.Source));
            }
        }

        public void ReportErrors()
        {
            string writePath = Path.Combine(directoryPath, "errors.txt");

            try
            {
                if (File.Exists(writePath))
                {
                    File.Delete(writePath);
                }

                using (StreamWriter sw = new StreamWriter(writePath, true))
                {
                    sw.WriteLine($"Processed at: {DateTime.Now}");
                    sw.WriteLine();

                    foreach (var error in errors)
                    {
                        sw.WriteLine(error.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                errors.Add(new Error(e.Message, e.Source));
            }
        }

        public void ReportFinalErrors()
        {
            foreach (var error in errors)
            {
                Console.WriteLine($"Error: {error.ErrorMessage} Source: {error.Source}");
            }
        }

    }
}
