using System.Collections.Generic;

namespace ADS.Wizard.Models
{
    public class DeploymentConfig
    {
        public string ComputerName { get; set; }
        public string OsVersion { get; set; }
        public string ImagePath { get; set; }
        public int ImageIndex { get; set; }
        public int TargetDisk { get; set; }
        public string Platform { get; set; }
        public string DriverPackPath { get; set; }
        public string UnattendTemplatePath { get; set; }
        public string OdjBlobPath { get; set; }
        public List<string> Packages { get; set; } = new List<string>();
        public List<string> SoftwareInstallers { get; set; } = new List<string>();
        public bool FormatAdditionalDisks { get; set; }
        public bool UseStaticIp { get; set; }
        public string StaticIpAddress { get; set; }
        public string StaticSubnetMask { get; set; }
        public string StaticGateway { get; set; }
        public List<string> StaticDnsServers { get; set; } = new List<string>();
    }
}
