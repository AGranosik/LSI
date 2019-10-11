using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LSI.Configuration.Automapper
{
    public class DIMapper : Mapper
    {
        public DIMapper(IConfigurationProvider configurationProvider) : base(configurationProvider)
        {
        }
    }
}