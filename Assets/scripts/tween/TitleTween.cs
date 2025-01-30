using UnityEngine;
using DG.Tweening;
public class TitleTween : MonoBehaviour
{
    public int duration;
    GameObject Cavern;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.DOMoveX(-565, duration).SetEase(Ease.InQuint).OnComplete(MoveNext);
      
    }

    void MoveNext() 
    { 
        Cavern.transform.DOMoveX(-178,duration).SetEase(Ease.InQuint);
    }

}

    
