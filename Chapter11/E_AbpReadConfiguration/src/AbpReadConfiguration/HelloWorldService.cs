using System;
using AbpReadConfiguration.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Json;

namespace AbpReadConfiguration
{
    public class HelloWorldService : ITransientDependency
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<HelloWorldService> _logger;
        private readonly IJsonSerializer _jsonSerializer;

        public HelloWorldService(IConfiguration configuration,
            ILogger<HelloWorldService> logger,
            IJsonSerializer jsonSerializer)
        {
            _configuration = configuration;
            _logger = logger;
            _jsonSerializer = jsonSerializer;
        }
        public void SayHello()
        {
            var mapSetting = _configuration.GetSection("MapSettings")
                .Get<MapSetting>();
            _logger.LogInformation(_jsonSerializer.Serialize(mapSetting, false,true));
            var jobSetting = _configuration.GetSection("JobSettings")
                .Get<JobSetting>();
            _logger.LogInformation(_jsonSerializer.Serialize(jobSetting,false,true));
        }
    }
    
}
