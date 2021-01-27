using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Fungus;

public class FungusManeger : MonoBehaviour
{
    public Fungus.Flowchart flowchart = null;
    public string message = "";
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (flowchart && collision.gameObject.tag == "Player")
        {
            flowchart.SendFungusMessage(message);
        }
    }

    private void OnCollisionEnter2D(Trigger2D trigger)
    {
        if (flowchart && trigger.gameObject.tag == "Player")
        {
            flowchart.SendFungusMessage(message);
        }
    }

    public void  KaiwaSceneFlag()
    {
        if (PlayerPrefs.GetInt("Tyouchin") == 1)
        {
            flowchart.SetBooleanVariable("Kappai_clear",true);
            
        }

        if (PlayerPrefs.GetInt("Tsumu") == 1)
        {
            flowchart.SetBooleanVariable("Zashikiwarashi_clear", true);

        }

        if (PlayerPrefs.GetInt("RoratePuzzle") == 1)
        {
            flowchart.SetBooleanVariable("Tengu_clear", true);

        }
    }

}
