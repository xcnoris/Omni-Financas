
using System.Security.Cryptography;
using System.Text;

namespace Metodos.IntegradorCRM
{
    public class LicenseManager
    {
        private static readonly string SecretKey = "casadainformaticacdisoftware2005123654789JeovaDeusPorTodaEternizada@#$%";

        public static bool ValidateToken(string token, string macAddress, string macAddressVM)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(SecretKey));
            
            var tokenBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(macAddress));
            var tokenBytesVM = hmac.ComputeHash(Encoding.UTF8.GetBytes(macAddressVM));

            var generatedToken = Convert.ToBase64String(tokenBytes);
            var generatedTokenVM = Convert.ToBase64String(tokenBytesVM);

            return token == generatedToken || token == generatedTokenVM;
        }
    }
}
