using System.Security.Cryptography;

namespace Switchfully.DotNetToolkit.Authentication
{
    public static class KeyGenerator
    {
        public static Dictionary<string, string> GenerateASymmetricKey()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            using (RSA rsa = RSA.Create())
            {
                result.Add("PrivateKey", Convert.ToBase64String(rsa.ExportRSAPrivateKey()));
                result.Add("PublicKey", Convert.ToBase64String(rsa.ExportRSAPublicKey()));
            }

            return result;
        }
    }
}
