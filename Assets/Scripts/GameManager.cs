using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public static UnityEvent OnGameOverEvent = new UnityEvent();

    [SerializeField]
    private GameObject _gameOverPanel;

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void ShowGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
    }

    private void Start()
    {
        OnGameOverEvent.AddListener(ShowGameOverPanel);
        _gameOverPanel.SetActive(false);
    }
}
