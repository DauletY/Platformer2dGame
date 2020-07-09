using UnityEngine;



// Hare UI 
public class HareUI 
{
    private Hare hare =  Object.FindObjectOfType<Hare>();
    public HareUI () {
        
    }   
    public override  string ToString() {
        return $"{hare}";
    } 
    public  float Speed(float speed) {

        hare.speed_hare = speed;
        Debug.Log(hare.speed_hare);
        
        return hare.speed_hare;
    }
}
