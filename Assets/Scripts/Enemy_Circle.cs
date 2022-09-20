using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Enemy_Circle : Enemy
{
    [SerializeField] private int _minHp, _maxHp;
    [SerializeField] private new int _hp;

    private void Start()
    {
        NextTurnEvent.AddListener(MoveUp);
        SetTextHp();
        SetHp(_minHp, _maxHp, _hp);
        OutputHp();
    }

    

    

    
}
