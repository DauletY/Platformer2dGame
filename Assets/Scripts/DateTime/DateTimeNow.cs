using UnityEngine;
using System.Collections;

/* сценарий время для задержки марковов  */
namespace StateMachine.Assets.Scripts.DateTime
{
    public class DateTimeNow : MonoBehaviour
    {
        public float seconds;           /* секунды */
        public float repate;            /* павтор  */
        
        private void Start() {
            Destroy(gameObject, repate);
            StartCoroutine(TimeScaleNow());
        }
        IEnumerator TimeScaleNow()
        {
            while(seconds <= repate) {
                seconds += Time.deltaTime;
                //Debug.Log("sec: " + seconds);
                yield return null;
            }
        }
    }
}