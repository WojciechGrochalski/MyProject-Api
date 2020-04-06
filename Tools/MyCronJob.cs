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
    public class MyCronJob : CronJobService
    {
        private readonly ILogger<MyCronJob> _logger;
        ApiTools apiServices = new ApiTools();
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
            apiServices.GetApi();
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronJob  is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}
