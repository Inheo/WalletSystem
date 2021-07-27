namespace Wallet.Handler
{
    public interface IDataHandler
    {
        WalletData Load(string name);

        void Save(string name, WalletData data);
    }
}
