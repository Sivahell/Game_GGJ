using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndFade : MonoBehaviour
{
    public static EndFade instance;
    public static EndType _endType;
    public Image img;
    public CanvasGroup cg;
    bool ended = false;
    private void Awake()
    {
        instance = this;
    }
    public void End(EndType endType)
    {
        if (ended)
            return;
        ended = true;
        _endType = endType;
        switch (endType)
        {
            case EndType.Win:
                img.color = Color.white;
               
                break;
            case EndType.Lose:
                img.color = Color.red;
                break;
        }
        LeanTween.value(0, 1, 2).setOnUpdate((float val) => cg.alpha = val).setOnComplete(() => UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene")) ;
        //LoadScene
    }


}
public enum EndType { Win, Lose }
