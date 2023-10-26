using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using Ebac.core.Singleton;

public class EffectsManager : Singleton<EffectsManager>
{
    public PostProcessVolume processVolume;
    [SerializeField] private Vignette _vignette;

    public float duration = 1.0f;

    [NaughtyAttributes.Button]
    public void ChangeVignette()
    {
        
        StartCoroutine(FlashColorVignette());
    }

    IEnumerator FlashColorVignette()
    {
        Vignette tmp;
        if (processVolume.profile.TryGetSettings<Vignette>(out tmp))
        {
            _vignette = tmp;
        }

        ColorParameter color = new ColorParameter();

        float time = 0;

        while(time < duration)
        {
            color.value = Color.Lerp(Color.black, Color.red, time / duration);
            time += Time.deltaTime;
            _vignette.color.Override(color);
            yield return new WaitForEndOfFrame();
        }
        
        time = 0;

        while(time < duration)
        {
            color.value = Color.Lerp(Color.red, Color.black, time / duration);
            time += Time.deltaTime;
            _vignette.color.Override(color);
            yield return new WaitForEndOfFrame();
        }

        //color.value = Color.red;

    }
}
