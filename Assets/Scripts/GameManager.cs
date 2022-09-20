using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public static UnityEvent GameOverEvent = new UnityEvent();
    [SerializeField] private GameObject _gameOverPanel;

    private void Start()
    {
        SetStandartParam();
    }

    private void SetStandartParam()
    {
        GameOverEvent.AddListener(ShowPanel);
        _gameOverPanel.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void ShowPanel()
    {
        _gameOverPanel.SetActive(true);
    }
}
