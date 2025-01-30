using UnityEngine;
using DG.Tweening;
public class TitleTween1 : MonoBehaviour
{
    public int duration;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.DOMoveX(-178, duration).SetEase(Ease.InQuint).From();

    }

}

    
