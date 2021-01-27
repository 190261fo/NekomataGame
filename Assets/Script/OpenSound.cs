using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.GetInstance().CheckBGMIsPlaying();
    }

    // Update is called once per frame
    
}
