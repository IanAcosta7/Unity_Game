using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreMenu : MonoBehaviour
{

    public GameObject scoreMenuUI;
    public GameObject scoreListUI;
    public GameObject mainMenuUI;
    public Text scoreText;
    public Transform scoreListContent;
    public GameObject scorePrefab;

    //private Player player;
    private string playerName;
    private int score;

    public void OpenMenu ()
    {
        score = ScoreCounter.score;
        Time.timeScale = 0f;
        scoreMenuUI.SetActive(true);
        scoreText.text = score.ToString();
    }

    public void GetData(string name)
    {
        playerName = name;
    }

    public void nextMenu ()
    {
        scoreMenuUI.SetActive(false);
        Player player = new Player(playerName, score);
        player.savePlayer();
        ShowScoreBoard();
    }

    public void ShowScoreBoard ()
    {
        mainMenuUI.SetActive(false);
        Player player = new Player("dummy", 0);
        Player[] players =  player.getAllPlayers();
        if (players != null)
        {
            players = sortPlayersByScore(players);
            showScoreList(players);
        } else
        {
            Application.Quit();
        }
    }

    public Player[] sortPlayersByScore (Player[] players)
    {
        Array.Sort(players, delegate (Player player1, Player player2)
        {
            return player2.playerScore.CompareTo(player1.playerScore);
        });

        return players;
    }

    public void showScoreList (Player[] players)
    {
        Vector3 scorePos = scorePrefab.transform.position;
        int i = 1;

        scoreListUI.SetActive(true);

        foreach (Player playerData in players)
        {
            scorePrefab.GetComponent<Text>().text = i + "\t" + playerData.playerName + "\t\t" + playerData.playerScore;
            GameObject scoreText = Instantiate(scorePrefab, scorePos, Quaternion.identity, scoreListContent);
            scorePos = new Vector3(scorePos.x, scorePos.y - 50, scorePos.z);
            i++;
        }
    }

    public void closeMenu ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
