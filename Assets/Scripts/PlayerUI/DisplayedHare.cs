using UnityEngine;
using UnityEngine.UI;
public class DisplayedHare : MonoBehaviour{
    

    public Text UI_text;
    public string my_text;
    public GameObject button;
    public GameObject input_field;
    public float speed_ui;
    public float seconds;
    
    private HareUI user = null;
    private GameManager ganeManager = null;


    private void Start() {
        user = new HareUI();
        Debug.Log(user.ToString());
    }
    public void Speed_UI() {
        UI_text.text = "Speed: " + user.Speed(speed_ui).ToString();
    }
    
    public void clike(GameManager game) {
        ganeManager = game;
        my_text = input_field.GetComponent<Text>().text;
        button.GetComponent<Text>().text = "Welcome " + my_text + " to the game ";
        game.StartCoroutine(game.StartGame(seconds));
    }
}
