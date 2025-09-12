using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using NaughtyAttributes;
using Core.Singleton;

public class EffectsManager : Singleton<EffectsManager>
{
    public PostProcessVolume postProcessVolume;
    public float duration = 0.1f;
    [SerializeField] private Vignette _vignette;

    /*[Button]
    public void ChangeVignette()
    {
        StartCoroutine(nameof(FlashColorVignette));
    }*/
    [Button]
    public void ChangeVignette()
    {
        Vignette temporaryVignette;
        if (postProcessVolume.profile.TryGetSettings<Vignette>(out temporaryVignette))
        {
            _vignette = temporaryVignette;
        }
        ColorParameter colorParameter = new ColorParameter();
        /*float time = 0;
        while (time < duration)
        {
            colorParameter.value = Color.Lerp(Color.black,Color.red,time/duration);
            time += Time.deltaTime;
            _vignette.color.Override(colorParameter);
            yield return new WaitForEndOfFrame();
        }
        time = 0;
        while (time < duration)
        {
            colorParameter.value = Color.Lerp(Color.red,Color.black,time/duration);
            time += Time.deltaTime;
            _vignette.color.Override(colorParameter);
            yield return new WaitForEndOfFrame();
        }*/
        StartCoroutine(FlashColorVignette(colorParameter,Color.black,Color.red));
        StartCoroutine(FlashColorVignette(colorParameter,Color.red,Color.black));
    }

    private IEnumerator FlashColorVignette(ColorParameter colorParameter, Color colorInitial, Color colorChange)
    {
        float time = 0;
        while (time < duration)
        {
            colorParameter.value = Color.Lerp(colorInitial,colorChange,time/duration);
            time += Time.deltaTime;
            _vignette.color.Override(colorParameter);
            yield return new WaitForEndOfFrame();
        }
    }
}
