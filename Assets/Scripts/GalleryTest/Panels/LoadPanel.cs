using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadPanel : MonoBehaviour
{
    public Slider LoadSlider;
    public TextMeshProUGUI LoadProgressText;

    void Start()
    {
        StartCoroutine(LoadProcess());
    }

    IEnumerator LoadProcess()
    {
        float timer = LoadSlider.maxValue,
              currentTime = 0;

        while (currentTime < timer)
        {
            currentTime += Time.deltaTime;
            LoadSlider.value = currentTime;
            LoadProgressText.text = $"{(int)((currentTime / timer) * 100)} %";
            yield return Time.deltaTime;
        }
        Destroy(gameObject);
    }
}
