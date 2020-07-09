using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Держатель
/// </summary>
public class Holder : MonoBehaviour
{   
    public GameObject initSpawn = null;                                 /* Порождать */
    public GameObject[] platfroms = null;                               /* площадки для зайца */
    public Camera_cnrt camera_Cnrt = null;                              /* Контроллер камеры  */
    public float bounds;                                                /*оценки */
    public Vector3 initPosition;

    #region private members
        private Vector3 currentPosition;                                /*текущая позиция */
        private GameObject prev;
        private float camPosition;

    #endregion
    private void Awake() {
        initPosition  = initSpawn.transform.position;

        currentPosition = initPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateBlock();
    }
    private void CreateBlock() {
        prev = Instantiate(platfroms[Random.Range(0, platfroms.Length)], currentPosition, Quaternion.identity, transform);
        float minClear = prev.GetComponent<EdgeCollider2D>().bounds.size.x;
        float diff = Random.Range(minClear + 3f, minClear + 4.5f);
        currentPosition = currentPosition + new Vector3(diff, Random.Range(-1.8f, 1.8f), 0f);
        currentPosition.y = Mathf.Clamp(currentPosition.y, initPosition.y - bounds, initPosition.y + bounds);    
    }
    // Update is called once per frame
    void Update()
    {
        if (prev.transform.position.x <=  camera_Cnrt.GetRightBound()   +  camera_Cnrt.GetCameraLenth())
        {
            CreateBlock();
        }
        int childCount = transform.childCount;

        for (int c = childCount - 1; c >= 0; --c) {
            var tranf = transform.GetChild(c);
            if (tranf.position.x + camera_Cnrt.GetCameraLenth() * 1.8f <= camera_Cnrt.transform.position.x  )
            {
                Destroy(tranf.gameObject);
            }    
        }
    }
}
