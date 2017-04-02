using UnityEngine;
using UnityEngine.EventSystems;


public class controleTouch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public enum eTouchPlace
    {   //direcoes
        monster, heroDMG, heroBonus, heroBonus2
    }

    //ponteiro para as funcoes da mao
  
    public eTouchPlace placeTouch;
    public bool turbo;

    bool _pressed,_released = false;
    //eventos sobrescritos, eles q vao capturar o press e release
    public void OnPointerDown(PointerEventData eventData)
    {
        _pressed = true;
       Debug.Log(eventData.pressPosition) ;
       //singletonGP.Instance.touch.makeEffect(eventData.pressPosition);
       singletonGP.Instance.touch.makeEffect(eventData.pressPosition);
    }

    //eventos sobrescritos, eles q vao capturar o press e release
    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
        _released = true;
    }

    void Update()
    {
        if (!_pressed)	//agora é soh ver se ta pressionado...
            return;

        switch (placeTouch)	// e chamar a funcao propria.
        {
            case eTouchPlace.monster:
            if (singletonGP.Instance.clickDMG)
              if (!turbo){
                _pressed=false;
                singletonGP.Instance.player.doDMG();
              }else {
                singletonGP.Instance.player.doDMG();
              }
            break;
            case eTouchPlace.heroDMG:
              _pressed=false;
              singletonGP.Instance.player.levelPlus();
            break;
            case eTouchPlace.heroBonus:
              _pressed=false;
              singletonGP.Instance.player.bonusPlus();
            break;
            case eTouchPlace.heroBonus2:
              _pressed=false;
              singletonGP.Instance.player.bonus2Plus();
            break;
        }
    }
}

