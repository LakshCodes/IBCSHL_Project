using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject player; 
    [SerializeField] private Button continueButton; 
    [SerializeField] private TMP_text gameOverText;
    [SerializeField] private ScoreSystem scoreSystem; 
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AsteroidSpawner asteroidSpawner;

    public void EndGame()
    {
        asteroidSpawner.enabled = false;

         int finalScore = scoreSystem.EndTimer();
         gameOverText.text = $"Your Score: {finalScore}";

        gameOverDisplay.gameObject.SetActive(true);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void ContinueGame()
    {
        AdManager.Instance.ShowAd(this);

        continueButton.interactable = false; 
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ContinueGame()
    {
        scoreSystem.StartTimer();

        player.transform.position = Vector3.zero; 
        player.SetActive(true); 
        player.GetComponent<RigidBody>().velocity = Vector3.zero; 

        asteroidSpawner.enabled = true; 

        gameOverDisplay.gameObject.SetActive(false);
    }
}

