using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class Database : MonoBehaviour
{
    DatabaseReference reference;
    private Key coso;
    public string nivel;
    private string input1;
    private string input2;
    

    // Start is called before the first frame update
    void Start() {
        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        coso = FindObjectOfType<Key>();
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void writeNewUser(string userId, string name, string time, float score) {
        Niveles user = new Niveles(name,time,score);
        string json = JsonUtility.ToJson(user);

        reference.Child(nivel).Child(userId).SetRawJsonValueAsync(json);
    }

    public void ReadInputID(string id ){

        input1 = id;

    } 

    public void ReadInputUsername(string username ){

        input2 = username;

    }    
    

    public void btn(){

        
        writeNewUser(input1, input2, coso.tiempoS, coso.puntaje);
    
    }

}

public class Niveles {
    public string username;
    public string time;
    public float score;

    public Niveles(string username, string time, float score) {
        this.username = username;
        this.time = time;
        this.score = score;
    }
}