using Microsoft.Extensions.Logging;
using MyProject.Currency;
using MyProject.Repository;
using Newtonsoft.Json;
using Services.CronoJobServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject.Tools
{
    public class UpdateFileCron : CronJobService
    {
        private readonly ILogger<UpdateFileCron> _logger;
        public List<CurrencyDTO> _listOfValue = new List<CurrencyDTO>();
        public List<CurrencyDTO> _helpListOfValue = new List<CurrencyDTO>();

        public UpdateFileCron(IScheduleConfig<UpdateFileCron> config, ILogger<UpdateFileCron> logger)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronJob  starts.");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _listOfValue.Clear();
            _helpListOfValue.Clear();

            string path = @"Data/ValueOfCurrencyToday.json";
            path = Path.GetFullPath(path);

            string fileData = File.ReadAllText(path);

            _listOfValue = JsonConvert.DeserializeObject<List<CurrencyDTO>>(fileData);

            path = @"Data/ValueOfCurrency.json";
            path = Path.GetFullPath(path);
            fileData = File.ReadAllText(path);
            if (fileData != "")
            {
                _helpListOfValue = JsonConvert.DeserializeObject<List<CurrencyDTO>>(fileData);

                foreach (CurrencyDTO item in _helpListOfValue)
                {
                    _listOfValue.Add(item);

                    //if (DateTime.Compare(DateTime.Now.AddDays(-100), DateTime.Parse(item.Data)) == 1)
                    //{
                    //    break;
                    //}
                }
            }

            string jsonString = JsonConvert.SerializeObject(_listOfValue, Formatting.Indented);

            File.WriteAllText(path, jsonString);
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronJob  is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}

