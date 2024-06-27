using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleColourchange : MonoBehaviour
{
    public TextMeshProUGUI title;
    public void OnClicked()
    {
        title.color = Color.red;
        Invoke("NextScreen", 0.6f);
    }
    public void PlayGame()
    {
        
        SceneManager.LoadScene("HexGrid");
    }

    void NextScreen()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Quitter()
    {
        Application.Quit();
    }
}
