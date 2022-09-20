using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy_Square : Enemy
{
    [SerializeField] private float _speedRotate;
    [SerializeField] private int _minHp, _maxHp;
    [SerializeField] private new int _hp;

    private void Start()
    {
        _enemyGameObject = gameObject;
        NextTurnEvent.AddListener(MoveUp);
        SetTextHp();
        SetHp(_minHp, _maxHp, _hp);
        OutputHp();
    }
    private void Update()
    {
        RotateEnemy(_speedRotate);
    }
    
}
