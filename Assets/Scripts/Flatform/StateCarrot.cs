using UnityEngine;

namespace StateMachine.Assets.Scripts.Flatform
{
    public class StateCarrot : MonoBehaviour
    {
        public GameObject Carrot = null;
        public Transform transform_this_carrot = null;

        private void Start() {
            Instantiate(Carrot, transform_this_carrot.position,Quaternion.identity);
        }
    }
}