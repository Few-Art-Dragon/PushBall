using UnityEngine;
using UnityEngine.Events;
using TMPro;

abstract public class Enemy : MonoBehaviour
{
    public static UnityEvent OnNextTurnEvent = new UnityEvent();

    protected GameObject enemyGameObject;
    protected TMP_Text textHp;

    [SerializeField]
    protected int health;
    [SerializeField]
    protected int minHealth;
    [SerializeField]
    protected int maxHealth;

    protected virtual void MinusHealth()
    {
        health--;
    }

    protected virtual void SetHealth(int min, int max, int hp)
    {
        if (min == 0 || max == 0)
        {
            health = hp;
        }
        else
        {
            SetRandomHealth(min, max);
        }
    }

    protected virtual void SetRandomHealth(int min, int max) { health = Random.Range(min, max); }

    protected virtual void MoveUpEnemy()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

        if (transform.position.y >= 0)
        {
            GameManager.OnGameOverEvent.Invoke();
        }
    }
    protected virtual void CheckHealth()
    {
        if (health <= 0)
        {
            SetHealth(1, 3, 1);
            Score.OnAddScoreEvent.Invoke();
            DestroyEnemy();
        }
    }
    protected void SetTextHealth()
    {
        textHp = gameObject.GetComponentInChildren<TMP_Text>();
    }

    protected void UpdateTextHealth()
    {
        textHp.text = health.ToString();
    }

    protected virtual void DestroyEnemy()
    {
        SpawnEnemy.OnSpawnEnemyEvent.Invoke(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out ControllerPlayer _))
        {
            MinusHealth();
            CheckHealth();
            UpdateTextHealth();
        }
    }

}

