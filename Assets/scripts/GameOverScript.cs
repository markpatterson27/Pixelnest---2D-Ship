using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Start or quit the game
/// </summary>
public class GameOverScript : MonoBehaviour
{
    private Button[] buttons;
    private Text[] gameOverTexts;

    void Awake()
    {
        // Get the buttons
        buttons = GetComponentsInChildren<Button>();

        // Get text objects
        gameOverTexts = GetComponentsInChildren<Text>();

        // Disable them
        HideItems();
    }

    public void HideButtons()
    {
        ///depreciated. use:
        HideItems();
    }

    public void ShowButtons()
    {
        ///depreciated. use:
        ShowItems();
    }
    
    public void HideItems()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(false);
        }
        foreach (var t in gameOverTexts)
        {
            t.gameObject.SetActive(false);
        }
    }

    public void ShowItems()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(true);
        }
        foreach (var t in gameOverTexts)
        {
            t.gameObject.SetActive(true);
        }
    }

    public void ExitToMenu()
    {
        // Reload the level
        //depreciated: Application.LoadLevel("Menu");
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        // Reload the level
        //depreciated: Application.LoadLevel("Stage1");
        SceneManager.LoadScene("Stage1");
    }
}
