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
        setStartAudioManager();
        AudioManager.GetInstance().PlayBGM(0);
    }

    public void OnChangedBGMSlider() {
        PlayerPrefs.SetFloat("BGM", bgmSlider.value);
        PlayerPrefs.Save();
        AudioManager.GetInstance().BGMVolume = bgmSlider.value;
        bgmVolumeText.text = string.Format("{0:0}", bgmSlider.value*100);
    }

    public void OnChangedSESlider() {
        PlayerPrefs.SetFloat("SE", seSlider.value);
        PlayerPrefs.Save();
        AudioManager.GetInstance().SEVolume = seSlider.value;
        seVolumeText.text = string.Format("{0:0}", seSlider.value*100);
    }

    public void OnPush() {
        AudioManager.GetInstance().PlaySound(0); // テスト
    }

    public void setStartAudioManager()
    {
        
        bgmSlider.value = PlayerPrefs.GetFloat("BGM");
        seSlider.value = PlayerPrefs.GetFloat("SE");
        
        
    }
    
}