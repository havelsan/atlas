using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Infrastructure.Helpers
{
    public class ComputerNameHelper
    {
        public string GetClientComputerName(string IP)
        {
            IPAddress myIP = IPAddress.Parse(IP);
            IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
            List<string> compName = GetIPHost.HostName.ToString().Split('.').ToList();
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US");
            return compName.First().ToUpper(cultureInfo);
        }
    }
}