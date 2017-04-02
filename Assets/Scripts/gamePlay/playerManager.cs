using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerManager : MonoBehaviour
{
    public decimal totalDmg, baseDmg, bonus, bonus2;
    public float danoBase, multLevelUp, multBonusUp, multBonus2UP;
    public monsterManager monstro;
    public Button heroUp, BonusUp, Bonus2Up;
    public bool haveUp, haveBonus, haveBonus2;
    public decimal nextUp, nextBonus, nextBonus2;
    public Text txtNextUp, txtNextBonus, txtNextBonus2;
    public Text txtDMG, txtBonusDmg;

    // Use this for initialization
    void Start()
    {
        monstro = singletonGP.Instance.monster;

    }

    public void resumePlayer(playerData player)
    {

        bonus = player.bonusDMG;

        bonus2 = player.bonusDMG2;
        if (player.bonusDMG == 0)
        {
            bonus = 1;
            bonus2 = 1;
            baseDmg = 1;
        }

        haveBonus = false;
        haveUp = false;
        haveBonus2 = false;
        setaLevel();
        verificaGold();
    }

    public void newPlayer()
    {
        bonus = 1;
        bonus2 = 1;
        baseDmg = (decimal)danoBase;
        haveBonus = false;
        haveUp = false;
        haveBonus2 = false;
        setaLevel();
        verificaGold();
    }

    // Update is called once per frame
    void Update()
    {
        heroUp.interactable = haveUp;
        BonusUp.interactable = haveBonus;
        Bonus2Up.interactable = haveBonus2;
    }

    public void doDMG()
    {

        totalDmg = baseDmg * bonus;
        //Debug.Log(totalDmg);
        monstro.getDMG(totalDmg);
    }




    public void verificaGold()
    {
        //multLevelUp,multBonusUp,multBonus2UP;
        nextUp = baseDmg * (decimal)multLevelUp;    //custo level up
        txtNextUp.text = nextUp.ToString("0");
        nextBonus = bonus * (decimal)multBonusUp;
        txtNextBonus.text = nextBonus.ToString("0");
        nextBonus2 = bonus2 * (decimal)multBonus2UP;
        txtNextBonus2.text = nextBonus2.ToString("0");

        if (singletonGP.Instance.hud.gold > (nextBonus))
            haveBonus = true;
        else haveBonus = false;
        if (singletonGP.Instance.hud.gold > (nextBonus2))
            haveBonus2 = true;
        else haveBonus2 = false;
        if (singletonGP.Instance.hud.gold >= (nextUp))
            haveUp = true;
        else haveUp = false;
    }

    public void setaLevel()
    {
        txtDMG.text = (baseDmg * bonus * bonus2).ToString("0");
        txtBonusDmg.text = (bonus * bonus2).ToString("0");

    }

    public void levelPlus()
    {
        if (singletonGP.Instance.hud.gold >= (nextUp))
        {
            singletonGP.Instance.hud.addGold(-nextUp);
            baseDmg++;


        }

        setaLevel();
        verificaGold();
        singletonGP.Instance.saveData();
    }

    public void bonusPlus()
    {
        if (singletonGP.Instance.hud.gold >= (nextBonus))
        {
            bonus++;
            singletonGP.Instance.hud.addGold(-nextBonus);
        }
        setaLevel();
        verificaGold();
        singletonGP.Instance.saveData();
    }
    public void bonus2Plus()
    {
        if (singletonGP.Instance.hud.gold >= (nextBonus2))
        {
            bonus2++;
            singletonGP.Instance.hud.addGold(-nextBonus2);
        }
        setaLevel();
        verificaGold();
        singletonGP.Instance.saveData();
    }
}
