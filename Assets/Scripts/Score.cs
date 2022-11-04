using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    public static UnityEvent OnAddScoreEvent = new UnityEvent();

    private TMP_Text _textScore;
    private int _score;

    private void UpdateScoreText()
    {
        _textScore.text = _score.ToString();
    }

    private void AddScore()
    {
        _score++;
        UpdateScoreText();
    }

    private void OnEnable()
    {
        OnAddScoreEvent.AddListener(AddScore);
    }

    private void Start()
    {
        _textScore = GetComponent<TMP_Text>();
        _score = 0;
    }

    private void OnDisable()
    {
        OnAddScoreEvent.RemoveListener(AddScore);
    }

}
