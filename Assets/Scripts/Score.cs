using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    public static UnityEvent AddScoreEvent = new UnityEvent();

    private TMP_Text _textScore;
    private int _score;

    private void Start()
    {
        SetStandartParam();
    }

    private void SetStandartParam()
    {
        AddScoreEvent.AddListener(AddScore);
        _textScore = GetComponent<TMP_Text>();
        _score = 0;
    }

    private void Output()
    {
        _textScore.text = _score.ToString();
    }

    private void AddScore()
    {
        _score++;
        Output();
    }

}
