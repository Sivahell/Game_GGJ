using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEnding : MonoBehaviour
{
    public Image image;
    public CanvasGroup cg;
    bool win;
    private void Awake()
    {
        switch (EndFade._endType)
        {
            case EndType.Win:
                image.color = Color.white;
                win = true;
                break;
            case EndType.Lose:
                image.color = Color.red;
                win = false;
                break;
        }

        EndAniCtr.instance.ShowAni(win);
    }
    private void Start()
    {
        LeanTween.value(1, 0, 1.5f).setOnUpdate((float val) => cg.alpha = val);
    }
}
