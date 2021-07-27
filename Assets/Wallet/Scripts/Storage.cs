using Wallet.Handler;

namespace Wallet
{
    public class Storage
    {
        private IDataHandler[] _dataHandlers = new IDataHandler[]
        {
            new PlayerPrefsHandler(),
            new TextFileHandler(),
            new BinaryHandler()
        };

        private IDataHandler _currentHandler;

        public Storage(HandlerType handlerType)
        {
            _currentHandler = _dataHandlers[(int)handlerType];
        }

        public WalletData Load(string key)
        {
            return _currentHandler.Load(key);
        }
        public void Save(string key, WalletData data)
        {
            for (int i = 0; i < _dataHandlers.Length; i++)
            {
                _dataHandlers[i].Save(key, data);
            }
        }
    }
}
public enum HandlerType
{
    PlayerPrefs,
    TextFile,
    Binary
}
