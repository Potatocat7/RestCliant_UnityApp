using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTextScript : MonoBehaviour
{
    [SerializeField]
    private Text _resultText;
    private SaveDataScript _saveData;
    private string _responseText;
    // Start is called before the first frame update
    void Start()
    {
        _saveData = SaveDataScript.Instance;
        if (_saveData.GetStrData() == "0")
        {
            _responseText = "あなたが送った文字列は初めてです。";
        }
        else
        {
            //_responseText = "あなたが送った文字列は過去に" + _saveData.GetStrData() + "回送られています。";
            _responseText = _saveData.GetStrData();

        }
        _resultText.text = _responseText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
