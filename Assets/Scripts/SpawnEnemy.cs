using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class SpawnEnemy : MonoBehaviour
{
    private Vector3 BoundsSpawnCollider;
    public static UnityEvent<GameObject> SpawnEnemyEvent = new UnityEvent<GameObject>();

    [SerializeField] private GameObject[] _enemies;

    private void Start()
    {
        SetStandartParam();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out ControllerPlayer _))
        {
            Enemy.NextTurnEvent.Invoke();
            ControllerPlayer.RestartGameEvent.Invoke();
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawCube(b1.center, b1.size);
    //    Gizmos.DrawCube(b2.center, b2.size);
    //}

    private void SetStandartParam()
    {
        BoundsSpawnCollider = gameObject.GetComponent<Collider2D>().bounds.center;
        SpawnEnemyEvent.AddListener(ResetPositionEnemy);
    }

    //private Bounds b1;
    //private Bounds b2;

    private void ResetPositionEnemy(GameObject gameObject)
    {
        var spawnPoint = new Vector3(Random.Range(-1.3f, 1.3f), BoundsSpawnCollider.y + Random.Range(-2f, 1f), 0);
        gameObject.transform.position = spawnPoint;
        var spawnBouds = new Bounds(spawnPoint, gameObject.GetComponent<Collider2D>().bounds.size);
        for (int i = 0; i < _enemies.Length; i++)
        {
            if (gameObject.name != _enemies[i].name)
            {
                //b1 = spawnBouds;
                //b2 = _enemies[i].GetComponent<Collider2D>().bounds;

                if (spawnBouds.Intersects(_enemies[i].GetComponent<Collider2D>().bounds))
                {
                    ResetPositionEnemy(gameObject);
                    break;
                }
            } 
        }
    }


}
