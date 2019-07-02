using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public Button continueBtn;
    public Scrollbar scrollbar;

    private PlayerFile playerFile;
    private string playerName;
    private int score;

    public void Start()
    {
        playerFile = new PlayerFile();
    }

    public void OpenMenu ()
    {
        score = ScoreCounter.score;
        Time.timeScale = 0f;
        scoreMenuUI.SetActive(true);
        scoreText.text = score.ToString();
    }

    public void GetData(string name)
    {
        if (name == "" || name.Contains('|') || name.Contains('-'))
            continueBtn.interactable = false;
        else
            continueBtn.interactable = true;


        playerName = name.ToUpper();
    }

    public void nextMenu ()
    {
        scoreMenuUI.SetActive(false);
        Player player = new Player(playerName, score);
        playerFile.savePlayer(player);
        ShowScoreBoard();
    }

    public void ShowScoreBoard ()
    {
        mainMenuUI.SetActive(false);
        Player[] players =  playerFile.getAllPlayers();
        if (players != null)
        {
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
        // Llevo la scrollbar a su posicion original
        scrollbar.value = 1f;

        // Borro la lista si ya existe
        GameObject[] elements = GameObject.FindGameObjectsWithTag("ScoreText");
        foreach (GameObject element in elements)
        {
            Destroy(element);
        }

        // Ordeno la lista por puntuacion
        players = sortPlayersByScore(players);

        // Y muestro los datos recibidos
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

    public void onSearch (string search)
    {
        Player[] players = playerFile.getAllPlayers();

        // Filtro por nombre 
        players = players.Where(player => player.playerName.Contains(search.ToUpper())).ToArray();
        showScoreList(players);
    }
}
