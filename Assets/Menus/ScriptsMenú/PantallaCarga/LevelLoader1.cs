using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class LevelLoader1
{
    public static string nextLevel;

    public static void LoadSelector(string name)
    {
        nextLevel = name;

        SceneManager.LoadScene("PantallaCarga");
    }
}
