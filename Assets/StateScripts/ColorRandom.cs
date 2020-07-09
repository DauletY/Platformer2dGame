using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class All<T> {
    public T t_or;

    
    public GameObject this_plate;
    public All(T t) {
        this.t_or = t;
    }
    public T new_T_void(T new_this_t) {
        T new_t = new_this_t;
        new_this_t = t_or;
        t_or = new_t;
        return new_t;
    }
    public T typeSize() {
        T new_t = t_or;
        Debug.Log("Typeof" + new_t.GetType().Name);
        return new_t;
    }
    public int Smart<U> (int smart, int count, int dollor) {
        All_result(smart);
        return smart + (count * dollor);
    }
    public void All_result(int smart) {
        Debug.Log(smart);
    }
    /// <summary>
    /// add new object
    /// </summary>
    /// <param name="obj"></param>
    public void Add(GameObject obj) {
        GameObject new_object = obj;
        obj = this_plate;
        this_plate = new_object;
        Debug.Log("this plate" + this_plate);
    }
}
public class ColorRandom : MonoBehaviour
{
    public float hueMax , hueMin, max, min, time;
    public float timeScaled = 0f;
    public float seconds = 0f;
    public SpriteRenderer rendererA;

    // Start is called before the first frame update
    void Start()
    {
        All<int> there = new All<int>(default);
        
        rendererA = GetComponent<SpriteRenderer>();

        Coroutine stateCoroutine = StartCoroutine("ColorChange");
    }
    private IEnumerator ColorChange()
    {
        while(timeScaled < seconds) {
            rendererA.color = Random.ColorHSV(Random.Range(hueMin, max), Random.Range(min, hueMax));
            Debug.Log("i = " + timeScaled);
             yield return null;
            timeScaled += Time.deltaTime;
            
        }
    }
}
