using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    [SerializeField] private GameObject musicPlayer; 

    private void Awake()
    {
        string index = SceneManager.GetActiveScene().name;
        if (index == "Main_Menu" )
        {
            DontDestroyOnLoad(transform.gameObject);
            
            music = GetComponent<AudioSource>();
        }
        if (index == "HexGrid")
        {
           musicPlayer.SetActive(false);
            music.Stop();
        }
    }

    private void PlayMusic()
    {
        if (music.isPlaying)
        {
            return;
        }
        else music.Play();
    }
}
