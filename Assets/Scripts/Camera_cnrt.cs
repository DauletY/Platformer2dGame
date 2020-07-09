using UnityEngine;
public class Camera_cnrt  : MonoBehaviour{
    
    public Transform hare  = null;     /* Заец */
    [Range(0, 10)] public float offsetX;
    private Camera cam = null;
    
    private void Awake()
    {
        cam = GetComponent<Camera>();
    }
    private void Start() {
        offsetX = transform.position.x - hare.position.x;
    }
    public float GetCameraLenth(/*Получить длину камеры */) {
        //Соотношение сторон (ширина делится на высоту).
        return 2 * cam.orthographicSize * cam.aspect;
    }
    public float GetlowerBound() {
        return transform.position.y - cam.orthographicSize;
    }
    public float GetRightBound(/*  Получите правильную связь */){   
        return transform.position.x + GetCameraLenth() / 2;
    }
    private void LateUpdate() {
        transform.position = new Vector3(hare.position.x + offsetX, transform.position.y,
                                                                    transform.position.z);
    }
}