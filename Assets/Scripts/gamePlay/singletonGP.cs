using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class singletonGP : MonoBehaviour
{
    private static singletonGP _instance = null;
	public monsterManager monster;
    public playerManager player;
    public hudManager hud;
    public playerData jogador;
    public touchEff touch;
    public Text debugText;
    public bool clickDMG,zeraPlayer;
    public decimal gold;
    public float cameraFloat;
	   
        public static singletonGP Instance
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
            if (Singleton.Instance) jogador=Singleton.Instance.jogador;
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
		
        if (Singleton.Instance) {
            if (zeraPlayer){
                jogador = new playerData();
                Singleton.Instance.jogador.gold=0;
            }
            resumeGame(jogador);
            
        }
        else {
            hud.gold=0;
            monster.newGame();
            player.newPlayer();
        }
        
    }

    public void resumeGame(playerData p){
            monster.resumeGame(p);
            hud.gold=p.gold;
            hud.setHud();
            player.resumePlayer(p);
    }

    public void saveData(){
        if (Singleton.Instance){
            jogador.baseDMG = player.baseDmg;
            jogador.gold=hud.gold;
            jogador.bonusDMG=player.bonus;
            jogador.goldM = monster.goldM;
            jogador.monsterLvl=monster.level;
            jogador.monsterSubLvl=monster.sublevel;
        }
    }

	
    // Update is called once per frame
    void Update()
    {
		
    }

    public void debugMsg(string msg){
        debugText.text = msg;
        Invoke("disableDebug",3);
    }

    public void disableDebug(){
        debugText.text = "";
    }

    public void nextMonster(decimal g){
        gold+=g;
        hud.addGold(g);
        player.verificaGold();
    }

    public void cameraTest(){
               
    }

}