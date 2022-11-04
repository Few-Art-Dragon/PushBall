using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class SpawnEnemy : MonoBehaviour
{
    public static UnityEvent<GameObject> OnSpawnEnemyEvent = new UnityEvent<GameObject>();

    [SerializeField]
    private GameObject[] _listEnemies;
    private Vector3 _boundsSpawnCollider;
    
    private void ResetPositionEnemy(GameObject gameObject)
    {
        var spawnPoint = new Vector3(Random.Range(-1.3f, 1.3f), _boundsSpawnCollider.y + Random.Range(-2f, 1f), 0);
        gameObject.transform.position = spawnPoint;
        var spawnBouds = new Bounds(spawnPoint, gameObject.GetComponent<Collider2D>().bounds.size);
        for (int i = 0; i < _listEnemies.Length; i++)
        {
            if (gameObject.name != _listEnemies[i].name)
            {
                if (spawnBouds.Intersects(_listEnemies[i].GetComponent<Collider2D>().bounds))
                {
                    ResetPositionEnemy(gameObject);
                    break;
                }
            } 
        }
    }

    private void OnEnable()
    {
        OnSpawnEnemyEvent.AddListener(ResetPositionEnemy);
    }

    private void Start()
    {
        _boundsSpawnCollider = gameObject.GetComponent<Collider2D>().bounds.center;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out ControllerPlayer _))
        {
            Enemy.OnNextTurnEvent.Invoke();
            ControllerPlayer.RestartGameEvent.Invoke();
        }
    }

    private void OnDisable()
    {
        OnSpawnEnemyEvent.RemoveListener(ResetPositionEnemy);
    }
}
