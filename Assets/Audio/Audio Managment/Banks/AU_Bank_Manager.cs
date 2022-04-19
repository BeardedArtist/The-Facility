using UnityEngine;
using FMODUnity;
using FMOD.Studio;


public class AU_Bank_Manager : MonoBehaviour
{
    private static AU_Bank_Manager _instance;
    public static AU_Bank_Manager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        //Loads the master bank (essential to be loaded at all times)
        if (!RuntimeManager.HasBankLoaded("Master"))
        {
            RuntimeManager.LoadBank("Master");
        }
        //Subscribes to bank loading events
        AU_Event_Manager.Instance.onLoadBank += LoadBank;
        AU_Event_Manager.Instance.onUnloadBank += UnloadBank;
    }

    public void LoadBank(string bankName)
    {
        //Checks if the bank is loaded, and loads if not
        if (!RuntimeManager.HasBankLoaded(bankName))
        {
            RuntimeManager.LoadBank(bankName);
        }
        else
        {
            Debug.LogError($"Audio Error: Bank '{bankName}' already loaded");
        }
    }

    public void UnloadBank(string bankName)
    {
        //Checks if the bank is loaded and unloads if so
        if (RuntimeManager.HasBankLoaded(bankName))
        {
            RuntimeManager.UnloadBank(bankName);
        }
        else
        {
            Debug.LogError($"Audio Error: Bank '{bankName}' not loaded, and thus cannot be unloaded.");
        }
    }
}