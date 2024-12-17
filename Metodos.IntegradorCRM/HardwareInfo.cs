
using System.Net.NetworkInformation;

namespace Metodos.IntegradorCRM
{
    public class HardwareInfo
    {
        public static string GetMacAddress()
        {
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            var macAddress = networkInterfaces
                .Where(nic =>
                    nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                    nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) // Apenas adaptadores físicos (Wi-Fi/Ethernet)
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up) // Apenas adaptadores ativos
                .Where(nic => !nic.Description.Contains("Virtual", StringComparison.OrdinalIgnoreCase) && // Ignora adaptadores virtuais
                              !nic.Description.Contains("Pseudo", StringComparison.OrdinalIgnoreCase) &&
                              !nic.Description.Contains("VPN", StringComparison.OrdinalIgnoreCase)) // Ignora adaptadores VPN
                .Select(nic => nic.GetPhysicalAddress().ToString())
                .FirstOrDefault();

            return macAddress ?? string.Empty;
        }

        public static string GetMacAddressVM()
        {
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            var macAddress = networkInterfaces
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up) // Apenas adaptadores ativos
                .Select(nic => new
                {
                    MAC = nic.GetPhysicalAddress().ToString(),
                    Description = nic.Description
                })
                .FirstOrDefault(nic => !string.IsNullOrEmpty(nic.MAC))?.MAC;

            return macAddress ?? string.Empty;
        }
    }
}
