using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreElement : MonoBehaviour{

    public TMP_Text usernameText;
    public TMP_Text timeText;

    public void NewScoreElement (string username, string time){
        
        usernameText.text = username;
        timeText.text = time;

    }
}