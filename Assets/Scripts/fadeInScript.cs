using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeInScript : MonoBehaviour
{
    [SerializeField]
    private Image _fadeImage;
    [SerializeField]
    private Color _fadeColor;
    private bool _isFadeIn = false;
    [SerializeField]
    public bool aysncFade;
    void Start()
    {
        _fadeColor = _fadeImage.color;
        aysncFade = true;

    }

    void Update()
    {
        if (_isFadeIn)
        {
            _fadeColor.a += Time.deltaTime * 0.5f;
            _fadeImage.color = _fadeColor;
            if (_fadeImage.color.a >= 1.0f)
            {
                _isFadeIn = false;
                aysncFade = false;
            }
        }
    }

    public void fadeIn()
    {
        _isFadeIn = true;
    }
}
