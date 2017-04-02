using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{
    private static Singleton _instance = null;
    public string SceneDestName;
    public GameObject loadPrefab, loadMB;
    public saveManager save;
    public playerData jogador;
    public bool debug;
    public Text loadTxt;
    private AsyncOperation async = null;
    public static Singleton Instance
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
            DontDestroyOnLoad(gameObject);  //objeto se mantem entre cenas
            _instance = this;
            Screen.SetResolution(360, 640, false);  //configs d android
            /*Screen.autorotateToLandscapeLeft = true;
            Screen.autorotateToLandscapeRight = true;
            Screen.autorotateToPortrait = false;*/

            save = gameObject.AddComponent<saveManager>();  //carregar dados do jogador
            string temp = save.carrega("dados");
            if (temp != "")
            {
                jogador = playerData.restauraDados(temp);
            }
            else
                jogador = new playerData();

                if (jogador.jogadas==null){
                    jogador.jogadas = new ArrayList();
                  
                }else {
                    //jogador.jogadas = new ArrayList();
                   
                    if (debug)
                    foreach(jogadaResultado jogada in jogador.jogadas){
                    Debug.Log(jogada.toString());
                    }
                    
                }
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
        SceneDestName="Menu";
        sceneAsync();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void sceneAsync()
    {
        loadMB = Instantiate(loadPrefab, this.transform);
        async = SceneManager.LoadSceneAsync(SceneDestName);
        async.allowSceneActivation = false;
        StartCoroutine(LoadSceneCoroutine());
    }


        void OnApplicationQuit()
    {

        save.salva("dados", jogador.salvaDados());
    }
void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus == true)
        {
            
            save.salva("dados", jogador.salvaDados());
        }
    }

    IEnumerator LoadSceneCoroutine()
    {
        float percentage = 0;
        loadTxt = GameObject.Find("textPerc").GetComponent<Text>();
        while (!async.isDone)
        {
            if (async.progress < 0.90f)
            {
                //progressBar.fillAmount = async.progress / 0.9f;
                if (loadTxt)
                {
                    percentage = async.progress * 100;
                    loadTxt.text = (int)percentage + "%";
                }
                //img.fillAmount= async.progress / 0.9f;
            }
            else
            {
                //img.fillAmount = async.progress / 0.9f;
                if (loadTxt)
                {
                    percentage = (async.progress / 0.9f) * 100;
                    loadTxt.text = (int)percentage + "%";
                }
                async.allowSceneActivation = true;

            }


            yield return null;
        }

        if (loadTxt) Destroy(loadMB);
        yield break;

    }

    public IEnumerator Flash(float countFloat)
    {
        while (countFloat > 0f)
        {
            countFloat -= Time.deltaTime;
            //Debug.Log(" count: " + countF);
            yield return new WaitForEndOfFrame();

        }
        yield break;
    }
}
