using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using AirFishLab.ScrollingList;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void DelayRestartGame(float time)
    {
        Invoke("RestartGame", time);
    }
    void RestartGame()
    {
        SceneManager.LoadScene("Title");
    }
}