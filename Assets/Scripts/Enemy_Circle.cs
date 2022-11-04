using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Enemy_Circle : Enemy
{
    private void OnEnable()
    {
        OnNextTurnEvent.AddListener(MoveUpEnemy);
    }

    private void Start()
    {
        enemyGameObject = gameObject;

        SetTextHealth();
        SetHealth(minHealth, maxHealth, health);
        UpdateTextHealth();
    }

    private void OnDisable()
    {
        OnNextTurnEvent.RemoveListener(MoveUpEnemy);
    }





}
