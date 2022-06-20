using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using System.Linq;
using UnityEngine.UI;

public class Database : MonoBehaviour
{
    DatabaseReference reference;
    private Key coso;
    public string nivel;
    private string input1;
    private string input2;
    public GameObject scoreElement;
    public Transform scoreboardContent;
    public Button boton;


    // Start is called before the first frame update
    void Start() {
        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        coso = FindObjectOfType<Key>();
    }

    // Update is called once per frame
    void Update(){
        
    }


    private void writeNewUser(string name, string time, float score) {
        Niveles user = new Niveles(name,time,score);
        string json = JsonUtility.ToJson(user);

        string key = reference.Child(nivel).Push().Key;
        reference.Child(nivel).Child(key).SetRawJsonValueAsync(json);
    }


    public void ReadInputUsername(string username ){

        input1 = username;

    }    
    

    public void btn(){

        
        writeNewUser(input1, coso.tiempoS, coso.puntaje *-1);
        ReadDataBase();
        boton.interactable = false;
    
    }

    public void ReadDataBase(){
        StartCoroutine(LoadDataBase());
    }

    public IEnumerator LoadDataBase(){

        var Dbtask = reference.Child(nivel).OrderByChild("score").LimitToLast(10).GetValueAsync();
    
        yield return new WaitUntil(predicate: () => Dbtask.IsCompleted);

        if (Dbtask.Exception != null){
            Debug.LogWarning(message: $"Failed to register task with {Dbtask.Exception}");

        }else{

            DataSnapshot snapshot = Dbtask.Result;
    
            string jsonStr = snapshot.GetRawJsonValue(); 

            foreach(Transform child in scoreboardContent.transform){
                Destroy(child.gameObject);
            }
            
            foreach (DataSnapshot childSnapshot in snapshot.Children.Reverse<DataSnapshot>()){
               
                string username = childSnapshot.Child("username").Value.ToString();
                string time = childSnapshot.Child("time").Value.ToString();

                GameObject scoreboardElement = Instantiate(scoreElement, scoreboardContent);
                scoreboardElement.GetComponent<ScoreElement>().NewScoreElement(username, time);

            }     
        }

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