using UnityEngine;
using UnityEngine.UI;
using Wallet;

public class Game : MonoBehaviour
{
    [SerializeField] private string _name = "Storage";

    [SerializeField] private Text _rubleText;
    [SerializeField] private Text _dollarText;
    [SerializeField] private Text _euroText;
    [Header("Handler Settings")]
    [SerializeField] private HandlerType _handlerType;

    private Storage _storage;
    private WalletData _data;

    private void Awake()
    {
        _storage = new Storage(_handlerType);
        _data = _storage.Load(_name);
    }

    private void Start()
    {
        UpdateUI();
    }

    #region Increment

    public void IncrementRuble()
    {
        _data.Ruble++;
        _rubleText.text = _data.Ruble.ToString();
    }
    public void IncrementDollar()
    {
        _data.Dollar++;
        _dollarText.text = _data.Dollar.ToString();
    }
    public void IncrementEuro()
    {
        _data.Euro++;
        _euroText.text = _data.Euro.ToString();
    }
    #endregion

    #region Reset
    public void ResetRuble()
    {
        _data.Ruble = 0;
        _rubleText.text = _data.Ruble.ToString();
    }

    public void ResetDollar()
    {
        _data.Dollar = 0;
        _dollarText.text = _data.Dollar.ToString();
    }


    public void ResetEuro()
    {
        _data.Euro = 0;
        _euroText.text = _data.Euro.ToString();
    }

    #endregion

    private void UpdateUI()
    {
        _rubleText.text = _data.Ruble.ToString();
        _dollarText.text = _data.Dollar.ToString();
        _euroText.text = _data.Euro.ToString();
    }

    private void OnApplicationQuit()
    {
        _storage.Save(_name, _data);
    }
}
