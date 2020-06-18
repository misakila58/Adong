using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameoverScreen;
    public Text scoreText;
    public Shooting shooting;

    void Update()
    {
        if (PlayerStats.Hp <= 0)
        {
            PlayerStats.Died = true;
            gameoverScreen.SetActive(true);
            scoreText.text = PlayerStats.Score.ToString();
            shooting.possibilityShoot = false;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
