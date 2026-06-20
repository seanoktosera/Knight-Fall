using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    public GameObject WinUI;
    private CanvasGroup canvasGroup;

    void Start()
    {
            canvasGroup = WinUI.GetComponent<CanvasGroup>();
        WinUI.SetActive(false);
    }

    public void ShowWinScreen()
    {
        WinUI.SetActive(true);
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0f;

        float duration = 1.5f;
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
        Time.timeScale = 0f;
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
