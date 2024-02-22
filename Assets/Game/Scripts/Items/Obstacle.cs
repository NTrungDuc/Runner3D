using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAmount;
    [SerializeField] private float duration = 1f;
    [SerializeField] private LoopType loopType;

    void Start()
    {
        transform.DORotate(rotationAmount, duration)
            .SetLoops(-1, loopType) 
            .SetEase(Ease.Linear);
    }
}
