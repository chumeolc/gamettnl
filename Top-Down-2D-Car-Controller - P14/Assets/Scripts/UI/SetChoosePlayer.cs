using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetChoosePlayer : MonoBehaviour
{
    public void StartGame1Player()
    {
        SceneManager.LoadScene("1Player");
    }
    public void StartGame2Player()
    {
        SceneManager.LoadScene("2Player");
    }
    public void BackGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
