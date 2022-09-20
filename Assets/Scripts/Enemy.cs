using UnityEngine;
using UnityEngine.Events;
using TMPro;

abstract public class Enemy : MonoBehaviour
{
    protected GameObject _enemyGameObject;
    protected TMP_Text _textHp;

    public static UnityEvent NextTurnEvent = new UnityEvent();


    protected int _hp { get; set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out ControllerPlayer _))
        {
            MinusHp();
            CheckHp();
            OutputHp();
        }
    }

    protected virtual void RotateEnemy(float speed)
    {
        _enemyGameObject.transform.Rotate(0, 0, speed * Time.deltaTime);
    }

    protected virtual void MinusHp()
    {
        _hp--;
    }

    protected virtual void SetHp(int min, int max, int hp)
    {
        if (min == 0 || max == 0)
        {
            _hp = hp;
        }
        else
        {
            RandomHp(min, max);
        }
    }

    protected virtual void RandomHp(int min, int max) { _hp = Random.Range(min, max); }

    protected virtual void MoveUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

        if (transform.position.y >= 0)
        {
            GameManager.GameOverEvent.Invoke();
        }
    }
    protected virtual void CheckHp()
    {
        if (_hp <= 0)
        {
            SetHp(1, 3, 1);
            Score.AddScoreEvent.Invoke();
            DestroyEnemy();
        }
    }
    protected void SetTextHp()
    {
        _textHp = gameObject.GetComponentInChildren<TMP_Text>();
    }

    protected void OutputHp()
    {
        _textHp.text = _hp.ToString();
    }

    protected virtual void DestroyEnemy()
    {
        SpawnEnemy.SpawnEnemyEvent.Invoke(gameObject);
    }
}
