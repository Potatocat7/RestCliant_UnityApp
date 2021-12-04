using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataScript : MonoBehaviour
{
    [SerializeField]
    private string _strData;
    private static SaveDataScript mInstance;
    public static SaveDataScript Instance
    {
        get
        {
            return mInstance;
        }
    }
    public void SetStrData(string data)
    {
        _strData = data;
    }
    public string GetStrData()
    {
        return _strData;
    }

    void Awake()
    {
        //transform.parent = null;
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        mInstance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
