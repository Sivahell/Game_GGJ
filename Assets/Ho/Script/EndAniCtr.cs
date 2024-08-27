using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAniCtr : MonoBehaviour
{
    public static EndAniCtr instance;


  public CanvasGroup  cg;
    public Animator ani;


    private void Awake()
    {
        instance = this;
    }
    public void ShowAni(bool win)
    {

        ani.SetBool("Win", win);
        ani.SetTrigger("Play");
    }

    public void ShowBtn()
    {
        LeanTween.value(0, 1, 2).setOnUpdate((float val) => cg.alpha = val).setOnComplete(() => cg.interactable = true);
    }
}
