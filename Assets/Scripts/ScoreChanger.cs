using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreChanger : MonoBehaviour
{
    private int _score = 0;
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void AddPoint()
    {
        _score++;
        _text.text = _score.ToString();
    }
}
