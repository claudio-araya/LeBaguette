using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class Database : MonoBehaviour
{
    DatabaseReference reference;

    // Start is called before the first frame update
    void Start() {
        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void writeNewUser(string userId, string name, string time, int score) {
        Niveles user = new Niveles(name,time,score);
        string json = JsonUtility.ToJson(user);

        reference.Child("Nivel 1").Child(userId).SetRawJsonValueAsync(json);
    }

    public void btnN1(){
         
        writeNewUser("1", "Test","00:00:00", 1111);
    
    }

}

public class Niveles {
    public string username;
    public string time;
    public int score;

    public Niveles(string username, string time, int score) {
        this.username = username;
        this.time = time;
        this.score = score;
    }
}