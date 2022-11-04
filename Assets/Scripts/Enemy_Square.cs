using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class Enemy_Square : Enemy, IRotateObject
{
    private IRotateObject _iRotateObject;

    [SerializeField]
    private float _speedRotate;

    void IRotateObject.RotateObject(float speed)
    {
        enemyGameObject.transform.Rotate(0, 0, _speedRotate * Time.deltaTime);
    }

    private void OnEnable()
    {
        OnNextTurnEvent.AddListener(MoveUpEnemy);
    }

    private void Start()
    {

        _iRotateObject = GetComponent<IRotateObject>();
        enemyGameObject = gameObject;
        SetTextHealth();
        SetHealth(minHealth, maxHealth, health);
        UpdateTextHealth();
    }

    private void Update()
    {
        _iRotateObject.RotateObject(_speedRotate);
    }

    private void OnDisable()
    {
        OnNextTurnEvent.RemoveListener(MoveUpEnemy);
    }
}
