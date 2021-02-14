using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundPresenter : MonoBehaviour {
    
    [SerializeField] Text bgmVolumeText;
    [SerializeField] Slider bgmSlider;

    [SerializeField] Text seVolumeText;
    [SerializeField] Slider seSlider;



    void Start() {
        setStartSound();
        AudioManager.GetInstance().PlayBGM(0);
    }

    public void OnChangedBGMSlider() {
        PlayerPrefs.SetInt("defaultBGM", 1);
        PlayerPrefs.SetFloat("BGM", bgmSlider.value);
        PlayerPrefs.Save();
        AudioManager.GetInstance().BGMVolume = bgmSlider.value;
        bgmVolumeText.text = string.Format("{0:0}", bgmSlider.value*100);
    }

    public void OnChangedSESlider() {
        PlayerPrefs.SetInt("defaultSE", 1);
        PlayerPrefs.SetFloat("SE", seSlider.value);
        PlayerPrefs.Save();
        AudioManager.GetInstance().SEVolume = seSlider.value;
        seVolumeText.text = string.Format("{0:0}", seSlider.value*100);
    }

    public void OnPush() {
        AudioManager.GetInstance().PlaySound(0); // テスト
    }

    public void setStartSound()
    {
        //if (PlayerPrefs.GetInt("defaultBGM") == 0)
        //{
        //    bgmSlider.value = 0.2f;
        //}
        //else
        //{
        //    bgmSlider.value = PlayerPrefs.GetFloat("BGM");
        //}

        //if (PlayerPrefs.GetInt("defaultSE") == 0)
        //{
        //    seSlider.value = 0.2f;
        //}
        //else
        //{
        //    seSlider.value = PlayerPrefs.GetFloat("SE");
        //}
        bgmSlider.value = PlayerPrefs.GetFloat("BGM");
        seSlider.value = PlayerPrefs.GetFloat("SE");
    }

    

}