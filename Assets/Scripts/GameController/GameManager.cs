
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public  class GameManager : MonoBehaviour{
    public Text UI_score;
    public Text UI_high_score;
    public int score;
    public int highScore ;
    public float seconds = .5f;
    
    private void Start() {
    	//High();
    }
    /// <summary>
    /// score to hare
    /// </summary>
    /// <param name="add"></param>
    public void AddScore(int add) {
        score = add;
        UI_score.text = "Score: " + score.ToString();  
    }
    /// <summary>
    ///  dead zone to hare
    /// </summary>
    public void HareLose() {
       
        StartCoroutine(LoseEnumerator());
    }
    public void High() {
         UI_high_score.text = "High score: " + highScore.ToString();
    }
    public IEnumerator LoseEnumerator()
    {             
        yield return new WaitForSeconds(seconds);

        SceneManager.LoadScene("HareHistory");        
    }
    // select DisplayHare text
    public IEnumerator StartGame(float seconds) {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("HareHistory");
    }
}