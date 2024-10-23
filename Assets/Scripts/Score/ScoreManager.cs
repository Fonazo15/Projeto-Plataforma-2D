using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public float multiplyValue = 1f;
    public TextMeshProUGUI textMeshPro;

    float _score;
    int _collectableTotal;
    float _scoreTotal;
    bool _hasGameEnded;

    [Header("Events")]
    public UnityEvent onFinishGameEvnt;

    public void IncreaseScore()
    {
        _score += multiplyValue;
    }

    public void AddCollectable()
    {
        _collectableTotal++;
        _scoreTotal = _collectableTotal * multiplyValue;
    }
    public void SetText(float value)
    {
        textMeshPro.text = "Score: " + value.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetText(_score);

        if (_score == _scoreTotal && !_hasGameEnded)
        {
            _hasGameEnded = true;
            onFinishGameEvnt.Invoke();
        }
    }
}
