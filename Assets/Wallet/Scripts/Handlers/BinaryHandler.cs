using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Wallet.Handler
{
    public class BinaryHandler : IDataHandler
    {
        private BinaryFormatter _formatter;

        public BinaryHandler()
        {
            _formatter = new BinaryFormatter();
        }

        public WalletData Load(string name)
        {
            string filePath = Path.Combine(Application.dataPath, "Wallet/" + name + "Binary");

            if (!File.Exists(filePath))
            {
                return new WalletData();
            }

            var file = File.Open(filePath, FileMode.Open);
            WalletData data = (WalletData)_formatter.Deserialize(file);
            file.Close();

            return data;
        }

        public void Save(string name, WalletData data)
        {
            string filePath = Path.Combine(Application.dataPath, "Wallet/" + name + "Binary");

            var file = File.Create(filePath);
            _formatter.Serialize(file, data);
            file.Close();
        }
    }
}
