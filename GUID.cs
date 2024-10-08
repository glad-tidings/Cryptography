namespace ParsElecom.Cryptography
{

    public class GUID
    {

        public static string RandomHex()
        {
            string TMP = "";
            byte[] random = new byte[513];
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(random);
            for (int i = 0, loopTo = random.Length - 1; i <= loopTo; i++)
            {
                switch (random[i])
                {
                    case var @case when (byte)48 <= @case && @case <= (byte)57:
                    case var case1 when (byte)65 <= case1 && case1 <= (byte)70:
                    case var case2 when (byte)97 <= case2 && case2 <= (byte)102:
                        {
                            TMP += ((char)random[i]).ToString().ToLower();
                            break;
                        }
                }
            }
            return TMP;
        }

        public static string RandomHex(int Len)
        {
            string TMP = "";
            byte[] random = new byte[513];
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(random);
            for (int i = 0, loopTo = random.Length - 1; i <= loopTo; i++)
            {
                switch (random[i])
                {
                    case var @case when (byte)48 <= @case && @case <= (byte)57:
                    case var case1 when (byte)65 <= case1 && case1 <= (byte)70:
                    case var case2 when (byte)97 <= case2 && case2 <= (byte)102:
                        {
                            TMP += ((char)random[i]).ToString().ToLower();
                            break;
                        }
                }
            }
            return TMP.Substring(0, Len);
        }

    }
}