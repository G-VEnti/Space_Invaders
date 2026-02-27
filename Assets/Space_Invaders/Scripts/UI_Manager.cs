using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;
    public int playerLives = 3;
    public int score = 0;
    public TMP_Text livesNum;
    public TMP_Text scoreNum;
    public TMP_Text finalScoreNum;
    public TMP_Text tittleText;
    public GameObject gameOverPanel;
    public GameObject mainMenuPanel;
    public GameObject pausePanel;
    public bool panelActive;
    private bool inGame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        panelActive = true;
        inGame = false;
        mainMenuPanel.SetActive(true);
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        livesNum.text = playerLives.ToString();
        scoreNum.text = score.ToString();
        finalScoreNum.text = score.ToString();

        // If any panel is active, game stops
        if (panelActive == true)
        {
            Time.timeScale = 0;
        }
        if (panelActive == false)
        {
            Time.timeScale = 1f;
        }

        // If escape is pressed, pause menu toggles between shown/not shown
        if (Keyboard.current.escapeKey.wasPressedThisFrame && inGame == true)
        {
            panelActive = !panelActive;
            pausePanel.SetActive(panelActive);
        }

        // If player don't have lives game over panel shows
        if (playerLives <= 0)
        {
            panelActive = true;
            gameOverPanel.SetActive(panelActive);
            inGame = false;
        }

        if (inGame == false)
        {
            tittleText.color = new Color(Random.value, Random.value, Random.value);
        }
    }

    /// <summary>
    /// Restarts actual scene and disables game over panel
    /// </summary>
    public void Retry()
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Restarts actual scene
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Starts game and disables main menu panel
    /// </summary>
    public void StartGame()
    {
        panelActive = false;
        mainMenuPanel.SetActive(panelActive);
        inGame = true;
    }

    /// <summary>
    /// Resumes game and disables pause panel
    /// </summary>
    public void ResumeGame()
    {
        panelActive = false;
        pausePanel.SetActive(panelActive);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
