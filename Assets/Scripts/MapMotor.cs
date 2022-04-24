using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMotor : MonoBehaviour {

    public void Level1()
    {
        SceneManager.LoadScene("Game");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
}
