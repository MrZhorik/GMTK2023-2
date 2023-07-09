using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
    public AudioSource MyFX;
    public AudioClip Clip;
    public AudioClip clickClip;
    public void Hover()
    {
        MyFX.PlayOneShot(Clip);
    }
    public void StartGame()
    {
        Invoke("PlayGame", 2f);
    }
    public void Click()
    {
        MyFX.PlayOneShot(clickClip);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    
}
