using Microsoft.Extensions.Logging;
using MyProject.Currency;

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
        public ValueOfCurrency myWalute = new ValueOfCurrency();
        public List<ValueOfCurrency> _listOfValue = new List<ValueOfCurrency>();
        GetApiContiouns getApiContiouns = new GetApiContiouns();
        public List<ValueOfCurrency> _helpListOfValue = new List<ValueOfCurrency>();



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

            _listOfValue = JsonConvert.DeserializeObject<List<ValueOfCurrency>>(fileData);

            path = @"Data/ValueOfCurrency.json";
            path = Path.GetFullPath(path);
            fileData = File.ReadAllText(path);
            if (fileData != "")
            {
                _helpListOfValue = JsonConvert.DeserializeObject<List<ValueOfCurrency>>(fileData);

                foreach (ValueOfCurrency item in _helpListOfValue)
                {
                    _listOfValue.Add(item);

                    if (DateTime.Compare(DateTime.Parse(item.AcctualPriceData), DateTime.Now.AddDays(-100))==-1)
                    {
                        break;
                    }

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

