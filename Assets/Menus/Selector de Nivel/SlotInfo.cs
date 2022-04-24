using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SlotInfo : MonoBehaviour
{
    public string lvlKey = "Nivel ";
    public int numberLvl;

    public Text lvlNumberShow; 

    // Start is called before the first frame update
    void Start()
    {
        lvlNumberShow.text = ("Nivel " + numberLvl.ToString());
    }

    public void CargaNivel()
    {
        SceneManager.LoadScene(lvlKey + numberLvl.ToString());
        
    }
}
