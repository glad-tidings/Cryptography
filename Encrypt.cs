using System.Security.Cryptography;
using System.Text;
using static System.Text.Encoding;

namespace ParsElecom.Cryptography
{

    public class Encrypt
    {

        public enum EncodingType : int
        {
            HEX = 0,
            BASE_64 = 1
        }

        public enum Algorithm : int
        {
            SHA1 = 0,
            SHA256 = 1,
            SHA384 = 2,
            Rijndael = 3,
            TripleDES = 4,
            RSA = 5,
            RC2 = 6,
            DES = 7,
            DSA = 8,
            MD5 = 9,
            RNG = 10,
            Base64 = 11,
            SHA512 = 12
        }

        private static TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
        private static MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
        private static string Key = "TripleDESCrypto@MD5Crypto";

        public static string Base64EnCode(string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return "";
            ASCIIEncoding EnCode = new ASCIIEncoding();
            byte[] Buffer = EnCode.GetBytes(Text);
            string BS64 = System.Convert.ToBase64String(Buffer).Replace("/", "-").Replace(@"\", "-");
            return BS64;
        }

        public static string Base64DeCode(string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return "";
            string BS64 = Text.Replace("/", "-").Replace(@"\", "-");
            ASCIIEncoding EnCode = new ASCIIEncoding();
            byte[] Buffer = System.Convert.FromBase64String(BS64);
            return EnCode.GetString(Buffer);
        }

        public static string GenerateHash(string Content, EncodingType EnType, Algorithm Alg)
        {
            HashAlgorithm HashAlg = new SHA1CryptoServiceProvider();
            switch (Alg)
            {
                case Algorithm.SHA1:
                    {
                        HashAlg = new SHA1CryptoServiceProvider();
                        break;
                    }
                case Algorithm.SHA256:
                    {
                        HashAlg = new SHA256Managed();
                        break;
                    }
                case Algorithm.SHA384:
                    {
                        HashAlg = new SHA384Managed();
                        break;
                    }
                case Algorithm.SHA512:
                    {
                        HashAlg = new SHA512Managed();
                        break;
                    }
                case Algorithm.MD5:
                    {
                        HashAlg = new MD5CryptoServiceProvider();
                        break;
                    }
            }
            byte[] hash = ComputeHash(HashAlg, Content);
            if (EnType == EncodingType.HEX)
                return BytesToHex(hash);
            else
                return System.Convert.ToBase64String(hash);
        }

        private static byte[] ComputeHash(HashAlgorithm Provider, string plainText)
        {
            byte[] hash = Provider.ComputeHash(UTF8.GetBytes(plainText));
            Provider.Clear();
            return hash;
        }

        private static string BytesToHex(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder();
            for (int n = 0, loopTo = bytes.Length - 1; n <= loopTo; n++)
                hex.AppendFormat("{0:X2}", bytes[n]);
            return hex.ToString();
        }

        public static string TripleEnCode(string Text)
        {
            DES.Key = MD5Hash(Key);
            DES.Mode = CipherMode.ECB;
            byte[] Buffer = ASCII.GetBytes(Text);
            return System.Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));
        }

        public static string TripleDeCode(string Text)
        {
            try
            {
                DES.Key = MD5Hash(Key);
                DES.Mode = CipherMode.ECB;
                byte[] Buffer = System.Convert.FromBase64String(Text);
                return ASCII.GetString(DES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch
            {
                return "";
            }
        }

        public static byte[] MD5Hash(string value)
        {
            return MD5.ComputeHash(ASCII.GetBytes(value));
        }

    }
}