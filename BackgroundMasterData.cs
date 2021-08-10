using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CentralSpecAPI
{
    public class BackgroundMasterData : IHostedService, IDisposable
    {
        private readonly ILogger<BackgroundMasterData> _logger;
        private int secondsToGetData = 5;
        private Timer timer;
        public BackgroundMasterData(ILogger<BackgroundMasterData> logger)
        {
            this._logger = logger;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //var logMessage = $"Getting master data | {DateTime.Now.ToString()}";
            //timer = new Timer(o => _logger.LogInformation(logMessage)
            //,null,TimeSpan.Zero,TimeSpan.FromSeconds(secondsToGetData));

            
            timer = new Timer(o => GetMasterData()
            , null, TimeSpan.Zero, TimeSpan.FromSeconds(secondsToGetData));


            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stop getting master data");
            return Task.CompletedTask;
        }

        private void GetMasterData()
        {
            var logMessage = $"Getting master data | {DateTime.Now.ToString()}";
            //TODO: Get and update data
            _logger.LogInformation(logMessage);
        }
    }
}
