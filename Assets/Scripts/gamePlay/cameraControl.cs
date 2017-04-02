using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraControl : MonoBehaviour {
	public Button btPlayer, btVoltar,btCompanion;
	public Canvas player, companion;
	public Animator anima;
	// Use this for initialization
	void Start () {
		btPlayer.onClick.AddListener(panelPlayer);
		btVoltar.onClick.AddListener(panelGame);
		btCompanion.onClick.AddListener(panelComp);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void panelPlayer(){
		anima.SetTrigger("toPlayer");
		anima.ResetTrigger("toGame");
		player.sortingOrder=1;
		companion.sortingOrder=0;
		
	}

	public void panelGame(){
		anima.SetTrigger("toGame");
		anima.ResetTrigger("toPlayer");
	}
	public void panelComp(){
		anima.SetTrigger("toPlayer");
		anima.ResetTrigger("toGame");
		player.sortingOrder=0;
		companion.sortingOrder=1;
	}
}
