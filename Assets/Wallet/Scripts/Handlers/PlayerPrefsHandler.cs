using UnityEngine;
namespace Wallet.Handler
{
    public class PlayerPrefsHandler : IDataHandler
    {
        public WalletData Load(string key)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                return JsonUtility.FromJson<WalletData>(JsonUtility.ToJson(new WalletData()));
            }
            else
            {
                return JsonUtility.FromJson<WalletData>(PlayerPrefs.GetString(key));
            }
        }

        public void Save(string key, WalletData data)
        {
            string json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(key, json);
        }
    }
}
