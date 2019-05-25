using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour
{
    private GameObject logo;
    private GameObject credits;

    void Start()
    {
        logo = GameObject.Find("Logo");
        credits = GameObject.Find("CreditsPanel");
        credits.SetActive(false);
    }

    public void StartGame()
    {
        // "Stage1" is the name of the first scene we created.
        Application.LoadLevel("Stage1");
    }

    public void ShowCredits()
    {
        // enable/disable logo/credits panel
        logo.SetActive(!logo.activeSelf);
        credits.SetActive(!credits.activeSelf);
    }
}
