using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class btControl : MonoBehaviour {
    public Button btPedra,btPapel,btTesoura;
    private Color initColor;
    public bool Jogador;
    public controlaJogo controle;
    public enum jogadas {
        pedra,papel,tesoura
    }
   

    void Awake()
    {
        
    }

    
    void Start()
    {
        initColor = btPapel.gameObject.GetComponent<Image>().color;
        if (Jogador){
        btPedra.onClick.AddListener(btPedraAct);
        btPapel.onClick.AddListener(btPapelAct);
        btTesoura.onClick.AddListener(btTesouraAct);
        }
    }

    void Update()
    {
        
    }

    public void reset(){
        btPapel.gameObject.GetComponent<Image>().color=initColor;
        btPedra.gameObject.GetComponent<Image>().color=initColor;
        btTesoura.gameObject.GetComponent<Image>().color=initColor;
    }

    public void btPapelAct(){
        controle.jogadaPlayer(jogadas.papel);
    }

    public void btPedraAct(){
        controle.jogadaPlayer(jogadas.pedra);
    }

    public void btTesouraAct(){
        controle.jogadaPlayer(jogadas.tesoura);
    }

    public void interact(bool inter){
        btPedra.interactable=inter;
        btPapel.interactable=inter;
        btTesoura.interactable=inter;
    }

    public int jogaRandom(){
        int rnd =(int)( Random.value*3);
        Debug.Log(rnd);
        switch(rnd){
            case 0:
            makeJogada(jogadas.pedra);
            break;
            case 1:
            makeJogada(jogadas.papel);
            break;
            case 2:
            makeJogada(jogadas.tesoura);
            break;
        }

        return rnd;

    }

    public void makeJogada(jogadas j){
        switch (j){
            case jogadas.pedra: //pedra
                btPedra.gameObject.GetComponent<Image>().color=new Color32(255,255,255,255);
            break;
            case jogadas.papel: //papel
                btPapel.gameObject.GetComponent<Image>().color=new Color32(255,255,255,255);
            break;
            case jogadas.tesoura: //tesoura
                btTesoura.gameObject.GetComponent<Image>().color=new Color32(255,255,255,255);
            break;
        }
        Invoke("reset",2);

    }

    


}