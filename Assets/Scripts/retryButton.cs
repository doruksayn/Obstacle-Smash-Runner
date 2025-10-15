using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class retryButton : MonoBehaviour
{
    public GameObject button;
    public GameObject button2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.SetActive(false);
        button2.SetActive(false);
    }

    // Update is called once per frame
    void Update() { }

    public void showRetry()
    {
        button.SetActive(true);
        button2.SetActive(true);
    }

    public void retryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
