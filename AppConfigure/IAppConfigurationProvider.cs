using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using static AppConfigure.Model;

namespace AppConfigure
{
    internal interface IAppConfigurationProvider
    {
        bool TryReadXML(out DaikinAppConfigure daikinAppConfigure, out string error, string filePath = "CONFIG\\CONFIG.xml");
        void Save(AppConfiguration configuration, string filePath = "CONFIG\\CONFIG.xml");
        ArgsCooperationModel GetCooperationArguments(DaikinAppConfigure konfiguraceAplikace, string[] argumentyPole);
        void ParseArguments(string[] argumentyPole, ref Argumenty argumenty);
    }
}
