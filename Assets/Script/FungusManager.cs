using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Fungus;

public class FungusManager : MonoBehaviour
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

    public void KaiwaSceneFlag()
    {
        if (PlayerPrefs.GetInt("Tyouchin") == 1)
        {
            flowchart.SetBooleanVariable("Kappa_clear",true);
            
        }else
        {
            flowchart.SetBooleanVariable("Kappa_clear", false);
        }

        if (PlayerPrefs.GetInt("Tsumu") == 1)
        {
            flowchart.SetBooleanVariable("Zashikiwarashi_clear", true);

        }
        else
        {
            flowchart.SetBooleanVariable("Zashikiwarashi_clear", false);
        }

        if (PlayerPrefs.GetInt("RoratePuzzle") == 1)
        {
            flowchart.SetBooleanVariable("Tengu_clear", true);

        }
        else
        {
            flowchart.SetBooleanVariable("Tengu_clear", false);
        }
    }

}
