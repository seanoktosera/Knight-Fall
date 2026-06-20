using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject GameoverUI;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GameoverUI.GetComponent<CanvasGroup>();
        GameoverUI.SetActive(false);
    }

    public void ShowGameOver()
    {
        GameoverUI.SetActive(true);
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0f;

        float duration = 1.5f; // durasi fade-in
        float t = 0f;

        while (t < duration)
        {
            t += Time.unscaledDeltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, t / duration);
            yield return null;
        }

        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        Time.timeScale = 0f; // pause game setelah fade selesai
    }

    public void RetryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // pastiin nama scenenya sama persis
    }
}
