
using UnityEngine;

namespace StateMachine.Assets.Scripts.Zone
{
    public class DeadZone : MonoBehaviour
    {
        public Hare hare = null;
        public GameManager gameManager;
        private void OnTriggerExit2D(Collider2D other) {

            if (other.gameObject.CompareTag("Player"))
            {
                hare.DeadHare();
                
                gameManager.HareLose();
                
            }
            else {
                Debug.Log("null");
            }
           
        }
    }    
}