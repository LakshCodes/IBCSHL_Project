using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_text scoreText;
    [SerializeField] private float scoreMultiplier;

    priavte bool shouldCount = true; 
    private float score;

    void Update()
    {
        if(!shouldCount) {return;}
        score += Time.deltaTime * scoreMultiplier;

        scoreText.text = Mathf.FloorToInt(score).ToString();
    }
    
    public void StartTimer()
    {
        shouldCount = true; 
    }


    public void EndTimer()
    {
        shouldCount = false; 

        scoreText.text = string.Empty;

        return Mathf.FloorToInt(score);
    }
}
