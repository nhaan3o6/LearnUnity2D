using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    [SerializeField]
    private Slider bgmSlider;
    [SerializeField]
    private Slider seSlider;

    private float bgmValue;
    private float seValue;

    private void OnEnable()
    {
        if(AudioManager.HasInstance)
        {
            bgmValue = AudioManager.Instance.AttachBGMSource.volume;
            seValue = AudioManager.Instance.AttachSESource.volume;
            bgmSlider.value = bgmValue;
            seSlider.value = seValue;
        }
    }
    public void OnSliderChangeBGMValue(float value)
    {
        bgmValue = value;
    }
    public void OnSliderChangeSEValue(float value)
    {
        seValue = value;
    }
    public void OnCancelButtonClick()
    {
        if(UIManager.HasInstance)
        {
            UIManager.Instance.ActiveSettingPanel(false);
        }
    }
    public void OnApplyButtonClick()
    {
        if(AudioManager.HasInstance)
        {
            AudioManager.Instance.ChangeBGMVolume(bgmValue);
            AudioManager.Instance.ChangeSEVolume(seValue);
        }
        if(UIManager.HasInstance)
        {
            UIManager.Instance.ActiveSettingPanel(false);
        }
        SettingPanelCallBack();
    }
    private void SettingPanelCallBack()
    {
        if(GameManager.HasInstance)
        {
            if(!GameManager.Instance.IsPlaying && !UIManager.Instance.MenuPanel.gameObject.activeSelf)
            {
                UIManager.Instance.ActivePausePanel(true);
            }
        }
    }
}
