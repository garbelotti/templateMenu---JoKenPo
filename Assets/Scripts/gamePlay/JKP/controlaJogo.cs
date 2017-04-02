using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class controlaJogo : MonoBehaviour {
	public GameObject jogador,casa;
	public Text uiText;
	public bool venceu=false;
	public bool empate=true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void reset(){
		venceu=false;
		empate=true;
		uiText.text="Selecione";
		jogador.GetComponent<btControl>().interact(true);
	}

	public void jogadaPlayer(btControl.jogadas a){
		
		int jogadaCasa = casa.GetComponent<btControl>().jogaRandom();
		switch (a){
			case btControl.jogadas.pedra:
			if (jogadaCasa==2) {
				empate=false;
				venceu=true;
			}
			if (jogadaCasa==1) {
				empate=false;
			}

			break;
			case btControl.jogadas.papel:
			if (jogadaCasa==0) {
				empate=false;
				venceu=true;
			}
			if (jogadaCasa==2) {
				empate=false;
			}
			break;
			case btControl.jogadas.tesoura:
			if (jogadaCasa==1) {
				empate=false;
				venceu=true;
			}
			if (jogadaCasa==0) {
				empate=false;
			}
			break;
		}
		if (venceu) {
			uiText.text = "Vitoria";
		}else if (empate){
			uiText.text = "Empate";
		}else {
			uiText.text = "Derrota";
		}
		Invoke("reset",2);

		if (Singleton.Instance) {
			jogadaResultado j = new jogadaResultado();
			j.jogada = a;
			j.venceu=venceu;
			j.empatou=empate;
			Singleton.Instance.jogador.jogadas.Add(j);
		}

		jogador.GetComponent<btControl>().interact(false);
	}
}
