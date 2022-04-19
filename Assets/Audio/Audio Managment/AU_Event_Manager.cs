using System;
using UnityEngine;

public class AU_Event_Manager : MonoBehaviour
{
    private static AU_Event_Manager _instance;
    public static AU_Event_Manager Instance { get { return _instance; } }
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

    //Event for managing the loading of banks
    public event Action<string> onLoadBank;
    public void LoadBank(string bankName)
    {
        if (onLoadBank != null)
        {
            onLoadBank(bankName);
        }
    }

    //Event for managing the unloading of banks
    public event Action<string> onUnloadBank;
    public void UnloadBank(string bankName)
    {
        if (onUnloadBank != null)
        {
            onUnloadBank(bankName);
        }
    }
}
