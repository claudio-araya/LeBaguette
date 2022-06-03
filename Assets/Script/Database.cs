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

    private void writeNewUser(string userId, string name, string email) {
        User user = new User(name, email);
        string json = JsonUtility.ToJson(user);

        reference.Child("users").Child(userId).SetRawJsonValueAsync(json);
    }

    public void btn(){
        writeNewUser("Chupalo", "Carlos", "Chupalo11@gmail.com");

    }

}

public class User {
    public string username;
    public string email;

    public User() {
    }

    public User(string username, string email) {
        this.username = username;
        this.email = email;
    }
}