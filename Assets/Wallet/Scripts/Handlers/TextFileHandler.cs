using System.IO;
using UnityEngine;

namespace Wallet.Handler
{
    public class TextFileHandler : IDataHandler
    {
        public WalletData Load(string name)
        {
            string filePath = Path.Combine(Application.dataPath, "Wallet/" + name + "Text");

            if (!File.Exists(filePath))
            {
                return new WalletData();
            }

            using (StreamReader stream = new StreamReader(filePath))
            {
                return JsonUtility.FromJson<WalletData>(stream.ReadToEnd());
            }
        }

        public void Save(string name, WalletData data)
        {
            string filePath = Path.Combine(Application.dataPath, "Wallet/" + name + "Text");

            using (StreamWriter stream = new StreamWriter(filePath))
            {
                stream.Write(JsonUtility.ToJson(data));
            }
        }
    }
}
