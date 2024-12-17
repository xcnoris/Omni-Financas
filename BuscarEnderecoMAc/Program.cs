
using System.Net.Mail;
using System.Net.NetworkInformation;


static string GetMacAddressVM()
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

static string GetMacAddress()
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

try
{
    Console.WriteLine("A maquina atual é uma maquina virtual(VM)? - SIM = 1 | NÂO = 2");
    string VM = Console.ReadLine();
    if (VM == "1")
    {
        string macAddressVM = GetMacAddressVM();
        Console.WriteLine("Endereço MAC: " + macAddressVM);
        Console.ReadLine();
    }
    else if (VM == "2")
    {
        string macAddress = GetMacAddress();

        Console.WriteLine("Endereço MAC: " + macAddress);
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine("Valor Invalido!");
        Console.ReadLine();
    }

  
    Console.ReadLine();
}
catch (Exception ex) 
{
    Console.WriteLine("ERROR: " + ex.Message);
    Console.ReadLine();
}
