using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public int lives = 5;
    public Image[] hearts;
    public void loseLife()
    {
        if(lives > 0)
        {
            lives--;
            hearts[lives].enabled = false;
        }
        // else
        // {
        //     PlayerPrefs.SetString("Result", "You Lose");
        //     PlayerPrefs.Save();
        //     SceneManager.LoadScene("Result");
        // }
    }
    void Update()
    {
        if(lives<=0)
        {
            PlayerPrefs.SetString("Result", "You Lose");
            PlayerPrefs.Save();
            SceneManager.LoadScene("Result");
        }
    }
}
