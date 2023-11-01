using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class spaceShooterUI : MonoBehaviour
{
    // [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TMP_Text bulletCountText;
    private TMP_Text scoreText;
    public int hits;
    public int currentBulletCount;

    void Start()
    {
        hits = 0;
        currentBulletCount = 0;
        scoreText = GetComponentInChildren<TMP_Text>();
        UpdateScoreText();
    }

   

    public void IncrementHitCount()
    {
        hits = hits + 1;
        Debug.Log("Hits: " + hits);
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        // scoreText.text = "# Score: " + hits.ToString();
        // currentBulletCount = gs.bulletLeft();
        scoreText.text = "Score: " + hits + "\nBullets: " + currentBulletCount;
    
    }

    public void bulletIncrement(int curr){
        currentBulletCount = curr;
    }

}
