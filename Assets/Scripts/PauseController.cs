using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button restartBut;
    [SerializeField] private Button quitBut;
    [SerializeField] private Button pauseBut;

    private AdBanner banner;
    private bool isPause = false;

    private void Awake()
    {
        banner = FindObjectOfType<AdBanner>();
    }
    void Start()
    {
        restartBut.onClick.AddListener(Restart);
        pauseBut.onClick.AddListener(SetPause);
        quitBut.onClick.AddListener(QuitGame);
        pausePanel.SetActive(false);
    }
    private void Restart()
    {
        Time.timeScale = 1f;
        banner.HideBanner();
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
    private void QuitGame()
    {
        print("Quit Game");
        Application.Quit();
    }
    private void SetPause()
    {
        isPause = !isPause;
        pausePanel.SetActive(isPause);
        Time.timeScale = isPause ? 0f : 1f;
        if (isPause) banner.ShowBanner();
        else banner.HideBanner();
    }
}
