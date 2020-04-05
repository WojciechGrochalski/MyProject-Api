using Microsoft.Extensions.Logging;
using MyProject.Currency;
using MyProject.Repository;
using Newtonsoft.Json;
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
    public class MyCronJob : CronJobService
    {
        private readonly ILogger<MyCronJob> _logger;
        readonly WebClient webClient = new WebClient();
        readonly CultureInfo kultura1 = new CultureInfo("Pl-pl");
        public ValueOfCurrency myWalute = new ValueOfCurrency();
        public List<ValueOfCurrency> _listOfValue = new List<ValueOfCurrency>();
        GetApiContiouns getApiContiouns = new GetApiContiouns();
        public string[] isoArray;
        

        public MyCronJob(IScheduleConfig<MyCronJob> config, ILogger<MyCronJob> logger)
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
         
            string path = @"Data/iso.json";
            path = Path.GetFullPath(path);
            string fileData = File.ReadAllText(path);
            isoArray = JsonConvert.DeserializeObject<string[]>(fileData);
            foreach (string iso in isoArray)
            {
                string url = "http://api.nbp.pl/api/exchangerates/rates/c/" + iso + "/?today/?format=json";
                _listOfValue.Add( getApiContiouns.GetApiToFile(url));
            }

            string jsonString = JsonConvert.SerializeObject(_listOfValue,Formatting.Indented);
            path = @"Data/ValueOfCurrencyToday.json";
            path = Path.GetFullPath(path);
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
