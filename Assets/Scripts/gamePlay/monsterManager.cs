using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class monsterManager : MonoBehaviour {

	public monster atual;
	public int level,sublevel;

	
	public string tempLvl,tempLife;
	public decimal monsterLife,maxLife,goldM,loweGold;
	public float percent;

	public float levelMultiplier, subleveMultiplier;	

	public float multGold, multGoldBoss, multGoldSubboss;

	public Text txtLevel,txtLife;
	public Image lifeBar;

	// Use this for initialization
	void Start () {
	//	level=sublevel=0;
		loweGold=0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void newGame(){
		level++;
		sublevel++;
		goldM=2;
		atual=new monster(level,sublevel);
		setNewMonster(atual);
		
	}

	public void resumeGame(playerData player){
		level=player.monsterLvl;
		sublevel=player.monsterSubLvl;
		goldM=player.goldM;
		if (level==0){
			level=1;
			sublevel=1;
			goldM=2;
		}
		atual=new monster(level,sublevel);
		setNewMonster(atual);
	
	}

	

	public void setNewMonster(monster rooar){

		singletonGP.Instance.clickDMG=true;
		/*
		levelMultiplier, subleveMultiplier;
		 */
		monsterLife = (decimal) levelMultiplier * (rooar.level-1) + (decimal)subleveMultiplier * rooar.sublevel;
		if (rooar.subBoss) monsterLife=monsterLife * 1.2m;
		if (rooar.boss) monsterLife=monsterLife * 1.5m;
		
		//monsterLife+= 10 * (rooar.level-1) + 2m * rooar.sublevel;

		maxLife=monsterLife;
		setLife();
		setMonster(rooar);
	}

	public void setMonster(monster rooar){
		 tempLvl =  rooar.level.ToString("00")+"/"+rooar.sublevel.ToString("00");
		 txtLevel.text=tempLvl;
	}

	public void setLife(){
		percent=(float) (monsterLife/maxLife);
		lifeBar.fillAmount=percent;
		txtLife.text = monsterLife.ToString("0") + "/" + maxLife.ToString("0");
	}

	public void getDMG(decimal qty){
		monsterLife-=qty;
		if (monsterLife<=0){
			monsterLife=0;
			nextLvl();
		}
		
		setLife();
	}

	public void nextLvl(){
		//multGold, multGoldBoss, multGoldSubboss;
		if (atual.boss) {

			    loweGold=goldM;
				goldM*=(decimal)multGoldBoss;
				loweGold=goldM-loweGold;

			}else if (atual.subBoss){
				loweGold=goldM;
				goldM*=(decimal)multGoldSubboss;
				loweGold=goldM-loweGold;
			}else if (loweGold>0){
				goldM-=(loweGold*0.5m);
				loweGold=0;
			}
			goldM*=(decimal)multGold;
			singletonGP.Instance.nextMonster(goldM);
			

		if (sublevel==10) {
			level++;
			sublevel=1;
		}else {
			sublevel++;
		}
			atual=new monster(level,sublevel);
			setNewMonster(atual);
			singletonGP.Instance.saveData();
	}

}
