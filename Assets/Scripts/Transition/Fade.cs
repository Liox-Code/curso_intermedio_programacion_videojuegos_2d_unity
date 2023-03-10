using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fade : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    [ContextMenu("FadeIn")]
    public void FadeIn()
    {
        spriteRenderer.DOFade(1,2).OnComplete(() => {
            Debug.Log("FadeIn Completo");
        });
    }


    [ContextMenu("FadeOut")]
    public void FadeOut()
    {
        spriteRenderer.DOFade(0, 2).OnComplete(() => {
            Debug.Log("FadeOut Completo");
        }).OnStart(() => { Debug.Log("FadeOut Iniciado"); });
    }

    private void Start()
    {
        FadeOut();
        GameManager.OnPlayerDeath += FadeIn;
        GameManager.OnPlayAgain += FadeOut;
    }
}
