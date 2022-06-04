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

    private void writeNewUser(string userId, string name, int time) {
        Niveles user = new Niveles(name,time);
        string json = JsonUtility.ToJson(user);

        reference.Child("Nivel 1").Child(userId).SetRawJsonValueAsync(json);
    }

    public void btn(){
         
        writeNewUser("1", "Test", 1000);

    }

}

public class Niveles {
    public string username;
    public int time;

    public Niveles(string username, int time) {
        this.username = username;
        this.time = time;
    }
}