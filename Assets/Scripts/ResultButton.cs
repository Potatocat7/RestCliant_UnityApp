using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using System.Text;
using System.Net.Http;
using MiniJSON;
using System.IO;

[DataContract]
//[System.Serializable]
public class Answer
{
    // JSONのフィールド名とプロパティ名は合わせなければいけません。
    [DataMember]
    public string id;
    [DataMember]
    public string name;
    //[DataMember]
    //public int value;
}
//[DataContract]
[System.Serializable]
public class JsonData
{
    public Answer[] answer;
}
public class ResultButton : MonoBehaviour
{
    [SerializeField]
    private Text _inputText;
    [SerializeField]
    private GameObject _fade;
    [SerializeField]
    private Image _fadeImage;
    [SerializeField]
    private fadeInScript _fadeData;
    private JsonData _jsonData = new JsonData();
    private Answer _answer = new Answer();
    private List<Answer> playData;// = new JsonData();

    private SaveDataScript _saveData;
    private string _responseData;
    // Start is called before the first frame update
    void Start()
    {
        _fade.SetActive(false);
        _saveData = SaveDataScript.Instance;
    }
    async UniTask FadeOut()
    {
        while (_fadeData.aysncFade)
        {
            await UniTask.Delay((int)(1));
        }
    }
    async UniTask SendData()
    {
        var comment = _inputText.text.ToString(); ;
        var content = new StringContent(comment, Encoding.UTF8);

        HttpClient client = new HttpClient();

        var answer = new JsonData();
        var httpResponse_cnt = client.PostAsync("http://localhost:8080/b", content).Result;
        var responseContent_cnt = await httpResponse_cnt.Content.ReadAsStringAsync();
        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseContent_cnt)))
        {
            var ser = new DataContractJsonSerializer(answer.GetType());
            answer = ser.ReadObject(ms) as JsonData;
            _saveData.SetStrData(answer.answer[0].name);
        }
        await UniTask.Delay((int)(1));


    }
    async UniTask SaveSetData()
    {
        await UniTask.Delay((int)(1));
    }

    async UniTask ComunicationData()
    {
        await SendData();
        await SaveSetData();
    }
    public async void PushResultbutton()
    {
        _fade.SetActive(true);
        _fadeData.fadeIn();
        await UniTask.WhenAll( FadeOut(),ComunicationData());        //DontDestroyOnLoad(_saveData);
        //追加要素
        //文字が記入されてなかったらポップウィンドウ表示
        SceneManager.LoadScene("ResultScene");
    }

}
