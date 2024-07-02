using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GameManager : Player
{
    private bool playerActive = false;
    private bool gameOver = false;
    private bool gameStart = false;
    public static GameManager Instance = null;

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject deathMenu;

    Player Up;
    public bool GameStart
    {
        get { return gameStart; }
    }
    public bool PlayerActive
    {
        get { return playerActive; }    
    }
    public bool GameOver
    {
        get { return gameOver; }
    }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        

        Assert.IsNotNull(mainMenu);
        Assert.IsNotNull(deathMenu);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public void PlayerCollided()
    {
        gameOver = true;
        deathMenu.SetActive(true);
        gameStart = false;
    }

    public void PlayerStartedGame()
    {
        playerActive = true;
    }

    public void EnterGame()
    {
        mainMenu.SetActive(false);
        gameStart = true;
    }

    public void Replaybtn()
    {
        deathMenu.SetActive(false);
        gameOver = false;
        playerActive = false;
        zombie().transform.Translate(0.4127463f, 13.152f, 2.861698f);
        zombie().useGravity = false;
        Up.Update();

    }
    public void MainMenuBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
