using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class SliderValueToText : MonoBehaviour
{
  
    public Slider g_SliderUI;
    private TextMeshProUGUI m_TextSliderValue;


   public enum SliderOption
    {
        ROUGHNESS,
        PERSISTENCE,
        MINVALUE
    };

    public SliderOption m_SliderOption;

    void Start()
    {
        m_TextSliderValue = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        ShowSliderValue();
    }


    public void ShowSliderValue()
    {

        switch (m_SliderOption)
        {
            case SliderOption.ROUGHNESS:
                 string sliderMessage = "Roughness " + g_SliderUI.value.ToString("F2");
                 m_TextSliderValue.text = sliderMessage;
                break;
            case SliderOption.PERSISTENCE:
                 sliderMessage = "Persistence " + g_SliderUI.value.ToString("F2");
                m_TextSliderValue.text = sliderMessage;
                break;
            case SliderOption.MINVALUE:
                 sliderMessage = "Min Value " + g_SliderUI.value.ToString("F2");
                m_TextSliderValue.text = sliderMessage;
                break;
            default:
                 sliderMessage = "Slider value = " + g_SliderUI.value.ToString("F2");
                m_TextSliderValue.text = sliderMessage;
                break;
        }
    }

}
