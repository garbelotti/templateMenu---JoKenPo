using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class singletonMenu : MonoBehaviour
{
    private static singletonMenu _instance = null;
    public Button btPlay;



    public static singletonMenu Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;

        }
    }


    // Use this for initialization
    void Start()
    {
        btPlay.onClick.AddListener(playGame);
    }

    public void playGame()
    {
        Singleton.Instance.SceneDestName = "gp1";
        Singleton.Instance.sceneAsync();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void webRanking()
    {
        //a implementar
    }

    public void webAchiev()
    {
        //a implementar
    }

    public void muteAudio()
    {
        //a implementar
    }

    public void changeLanguage()
    {
        //a implementar
    }


}