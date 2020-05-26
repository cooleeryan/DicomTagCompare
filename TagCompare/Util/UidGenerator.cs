using System;
using System.Collections;
using System.Net;
using System.Text;

namespace TagCompare.Util
{
    public class UidGenerator
    {
        public static string Ip { get; }
        private static readonly Hashtable Ht = new Hashtable {{"ClassUID", "1.2.40.1.6.8.168"}, {"VersionName", "DicomTags_Demo"}};

        static UidGenerator()
        {
            try
            {
                var hostEntry = Dns.GetHostEntry(Dns.GetHostName());
                var addressList = hostEntry.AddressList;
                foreach (var address in addressList)
                {
                    if (address.AddressFamily.ToString().ToUpper().Trim() == "INTERNETWORK")
                    {
                        Ip = address.ToString();
                    }
                }
            }
            catch (Exception)
            {
                Ip = "127.0.0.1";
            }
        }

        public virtual string CreateUid()
        {
            return CreateUid((string) Ht["ClassUID"]);
        }

        public virtual string CreateUid(string root)
        {
            var strBuilder = new StringBuilder(64).Append(root).Append('.').Append(Ip.Replace(".", ""));
            var value = DateTime.Now.ToString("yyyyMMddHHmmssffffff");
            strBuilder.Append(value);
            return strBuilder.ToString();
        }
    }
}
