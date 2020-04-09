using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [Header("TextBoxes")]
    public Text scoreText;
    public Text lifeText;
    public Text finalScoreText;

    [Header("Prefabs")]
    public PlatformScript platform;
    public PickUpScripts[] pickUps;

    [Header("UI")]
    public GameObject menuObject;
    public GameObject userInterfaceObject;

    [Header("Other")]
    public string congratulationsText;


    int lifeCount;
    int scoreCount;
    float timer = 0;
    float launchTime = 2f;
    bool isStarted;

    void StartGame()
    {
        isStarted = true;
        launchTime = 2f;

        lifeCount = 5;
        lifeText.text = lifeCount.ToString();

        scoreCount = 0;
        scoreText.text = scoreCount.ToString();

        Instantiate(platform);
    }

    void Start()
    {
        StartGame();
    }

    public void ScoreUpdate(int scoreUp)
    {
        scoreCount += scoreUp;
        scoreText.text = scoreCount.ToString();
    }


    public void LifeUpdate(int lifeUp)
    {
        lifeCount += lifeUp;

        if (lifeCount <= 0)
        {
            Lose();
        }
        else
        {
            lifeText.text = lifeCount.ToString();
        }
    }

    void Lose()
    {
        ClearScreen();
        finalScoreText.text = congratulationsText + scoreCount.ToString();
        isStarted = false;
        menuObject.gameObject.SetActive(true);
        userInterfaceObject.gameObject.SetActive(false);
    }

    void ClearScreen()
    {
        var pickUps = FindObjectsOfType<PickUpScripts>();
        foreach(var i in pickUps)
        {
            Destroy(i.gameObject);
        }
        var platform = FindObjectsOfType<PlatformScript>();
        foreach (var i in platform)
        {
            Destroy(i.gameObject);
        }
    }

    public void StartAgainButton()
    {
        timer = Time.time + Random.Range(0, launchTime);
        menuObject.gameObject.SetActive(false);
        userInterfaceObject.gameObject.SetActive(true);
        StartGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Time.time > timer && isStarted)
        {
            timer += Random.Range(0, launchTime);
            int tmp = Random.Range(0, 1000000);
            if (tmp % 25 == 0) LaunchPickUp(pickUps[0]);
            if (tmp % 25 > 0 && tmp % 25 < 5) LaunchPickUp(pickUps[1]);
            if (tmp % 25 > 4 && tmp % 25 < 9) LaunchPickUp(pickUps[2]);
            if (tmp % 25 > 8 && tmp % 25 < 13) LaunchPickUp(pickUps[3]);
            if (tmp % 25 > 12 && tmp % 25 < 17) LaunchPickUp(pickUps[4]);
            if (tmp % 25 > 16 && tmp % 25 < 21) LaunchPickUp(pickUps[5]);
            if (tmp % 25 > 20 && tmp % 25 < 25) LaunchPickUp(pickUps[6]);
            if (launchTime > 0.5f) launchTime -= 0.01f;
        }
    }

    void LaunchPickUp(PickUpScripts pickUp)
    {
        Instantiate(pickUp);
    }

}
