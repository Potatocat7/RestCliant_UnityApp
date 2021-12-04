using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeOutScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _fade;
    [SerializeField]
    private Image _fadeImage;
    [SerializeField]
    private Color _fadeColor;
    private bool _isFadeOut = true;
    void Start()
    {
        _fadeColor = _fadeImage.color;
        _fade.SetActive(true);

    }

    void Update()
    {
        if (_isFadeOut)
        {
            _fadeColor.a -= Time.deltaTime * 0.5f;
            _fadeImage.color = _fadeColor;
            if (_fadeImage.color.a <= 0.0f)
            {
                _isFadeOut = false;
                _fade.SetActive(false);
            }
        }
    }

    public void fadeOut()
    {
        _isFadeOut = true;
    }

}
