using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class LevelLoader 
{
    public static string nextLevel;

    public static void LoadLevel(string name)
    {
        nextLevel = name;
        int index = Random.Range(1, 6);
        SceneManager.LoadScene("Consejo " + index);
    }
}
