﻿using Models.DisplayBoard;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DisplayBoardService : IDisplayBoardService
    {
        private readonly ConfigSettingService configSettingService;
        private const string GROUPNAME = "DisplayBoardFileGenerator";
        public DisplayBoardService(ConfigSettingService _configSettingService)
        {
            configSettingService = _configSettingService;
        }
        public void CreateTemplate(Template template)
        {
            Models.Post.ConfigSetting config = new Models.Post.ConfigSetting
            {
                GroupName = GROUPNAME,
                ContentName = $"Template_{Guid.NewGuid().ToString()}",
                ContentValue = Newtonsoft.Json.JsonConvert.SerializeObject(template)
            };
            configSettingService.CreateConfigSetting(config);
        }

        public IEnumerable<Template> GetAllTemplates()
        {
            throw new NotImplementedException();
        }
    }
}
