using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class spaceShooterUI : MonoBehaviour
{
    // [SerializeField] private TextMeshProUGUI scoreText;
    private TMP_Text scoreText;
    private int hits = 0;

    void Start()
    {
        scoreText = GetComponentInChildren<TMP_Text>();
        UpdateScoreText();
    }

    public void IncrementHitCount()
    {
        hits+=1;
        Debug.Log("Hits: " + hits);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + hits.ToString();
    }

    // Other variables and methods...
}
