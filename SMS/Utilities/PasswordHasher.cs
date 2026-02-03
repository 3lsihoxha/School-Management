using System.Security.Cryptography;
using System.Text;

namespace SMS.Utilities
{
    public static class PasswordHasher
    {
        public static string Sha256(string input)
        {
            if (input == null) input = string.Empty;

            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(bytes.Length * 2);
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}