using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Image lifeIndicator;
    [SerializeField] Sprite[] lifeSprites;

    [SerializeField] GameObject[] panelController;

    private void Update()
    {
        if (lifeIndicator != null)
        {
            lifeIndicator.sprite = lifeSprites[gameManager.lifes];
        }
        if(panelController[0] != null)
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                panelController[0].SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void QuitPause()
    {
        panelController[0].SetActive(false);
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
