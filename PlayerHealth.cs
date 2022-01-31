using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private GameOverHandler gameOverHandler;
    public void Crash()
    {
        gameOverHandler.EndGame();
        
        gameObject.SetActive(false);
    }
}
