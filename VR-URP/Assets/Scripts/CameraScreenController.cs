using System.Collections;
using UnityEngine;

public class CameraScreenController : MonoBehaviour
{
    [SerializeField] bool fadeOnStart = true;
    [SerializeField] float defaultFadeDuration = 3.0f;
    [SerializeField] float fastFadeDuration = 0.5f;
    public Color color;
    public AnimationCurve fadeCurve;
    [SerializeField] string colorPropertyName = "_BaseColor";

    Renderer _renderer;
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.enabled = false;

        if (fadeOnStart)
            FadeIn();
    }

    public void FadeIn() => Fade(1, 0, defaultFadeDuration);
    public void FadeOut() => Fade(0, 1, defaultFadeDuration);
    public void FastFadeIn() => Fade(1, 0, fastFadeDuration);
    public void FastFadeOut() => Fade(0, 1, fastFadeDuration);

    public void Fade(float startAlpha, float endAlpha, float? fadeDuration = null)
    {
        if (fadeDuration is null)
            fadeDuration = defaultFadeDuration;

        StartCoroutine(Fader(startAlpha, endAlpha, (float)fadeDuration));
    }

    private IEnumerator Fader(float startAlpha, float endAlpha, float fadeDuration)
    {
        _renderer.enabled = true;

        float timer = 0;
        while(timer < fadeDuration)
        {
            Color newColor = color;

            newColor.a = Mathf.Lerp(startAlpha, endAlpha, fadeCurve.Evaluate(timer / fadeDuration));
            _renderer.material.SetColor(colorPropertyName, newColor);

            timer += Time.deltaTime;
            yield return null;
        }


        //If the alpha is completely transparent turn off the renderer
        if(endAlpha == 0)
            _renderer.enabled = false;
    }
}
