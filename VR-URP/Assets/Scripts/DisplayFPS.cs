using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class DisplayFPS : MonoBehaviour
{
    public float updateDelay = 0.1f;
    public float targetFPS = 72f;
    public float lowFPS = 50f;

    private float _currentFPS = 72.0f;
    private float _deltaTime = 0f;

    private TextMeshProUGUI _textFPS;

    // Start is called before the first frame update
    void Awake()
    {
        _textFPS = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {
        StartCoroutine(DisplayFramesPerSecond());
    }

    // Update is called once per frame
    void Update()
    {
        CalculateFramesPerSecond();
    }

    private void CalculateFramesPerSecond()
    {
        _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * .1f;
        _currentFPS = 1.0f / _deltaTime;
    }

    private IEnumerator DisplayFramesPerSecond()
    {
        while (true)
        {
            _textFPS.text = $"FPS: {_currentFPS:0}";
            yield return null;
        }
    }
}
