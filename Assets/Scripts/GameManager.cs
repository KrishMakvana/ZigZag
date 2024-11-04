using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isStarted;
    public GameObject platformSpawner;

    [Header("GameOver")]
    public GameObject GameOverPanel;
    public Text lastScoreText;

    [Header("Score")]
    public Text ScoreText;
    public Text BestText;
    bool countScore;

    [Header("Player")]
    public GameObject[] player;
    Vector3 playerStartPos = new Vector3(0f, 0.512f, 0f);

    int selectedCar = 0;



    int score = 0;
    int bestScore;


    private void Awake()
    {
        selectedCar = PlayerPrefs.GetInt("SelectCar");
        Instantiate(player[selectedCar], playerStartPos, Quaternion.identity);

        if (Instance == null)
            Instance = this;
    }
    private void Start()
    {

        bestScore =  PlayerPrefs.GetInt("bestScore");
        BestText.text = bestScore.ToString();

    }

    private void Update()
    {
        if (!isStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStarted();
            }
        }
    }
    public void GameStarted()
    {
        isStarted = true;
        countScore = true;
        StartCoroutine(UpdateScore());
        platformSpawner.SetActive(true);
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        lastScoreText.text = score.ToString();
        countScore = false;
        platformSpawner.SetActive(false);
        if (score > bestScore)
        {
            PlayerPrefs.SetInt("bestScore", score);
        }

    }

    public IEnumerator UpdateScore()
    {
        while (countScore)
        {
            yield return new WaitForSeconds(1f);
            score++;
            if (score >= bestScore)
            {
                ScoreText.text = score.ToString();
                BestText.text = score.ToString();
            }
            else
            {
                ScoreText.text = score.ToString();
            }
        }
    }
    public void Retry()
    {
        SceneManager.LoadScene("Level");
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    } 


}//Main
