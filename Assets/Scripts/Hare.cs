using System.Collections;
using UnityEngine;

/// <summary>
/// Заяц 
/// ходит 
/// прыгает 
/// кушает
/// </summary>
public class Hare : MonoBehaviour
{
    #region public fields
    public Camera_cnrt cam = null;              // Получить нижнюю границу 
    public float speed_hare = 5.0f;             // скорость
    public float jumpFactor = 0.0f;             // Фактор прыжка
 	#endregion
    #region private fields
    private Rigidbody2D rigidbody2 = null;      // жесткое тело
    private Collider2D collider2 = null;        // коллейдер
    private Transform transform_ = null;
    private int pressedSpace;                   // нажата пробел
	private bool onGround;                      // на земле
	private bool canDoubleJump = true;          // может двойной прыжок
    private bool dead = false;                  // мертвых
    private bool pressedGetMouseDown = false;				// if pressed get mouse down we will jump 
    private GameManager gameManager = null;
    private int score ;
    
    #endregion
    #region Awake
    private void Awake() {
        transform_ = GetComponent<Transform>();
        collider2 = this.GetComponent<Collider2D>();
        rigidbody2 = this.GetComponent<Rigidbody2D>();
    }
    #endregion
    #region Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameState").GetComponent<GameManager>();
        
        if (cam != null)
        {
            // it's work Debug.Log("dot null");
        }
        else {
            Debug.Log("null");
        }
    }
    #endregion
    void FixedUpdate()
    {
        float fixtime  = Time.fixedDeltaTime;
        Vector2 currentVelocity  = rigidbody2.velocity;
        Vector2 impulse = Vector2.zero;
        float desiredSpeed; 
        if(Input.GetKey(KeyCode.LeftArrow)) {
            desiredSpeed = -speed_hare;
            //Debug.Log("<-" + desiredSpeed);
        }else if(Input.GetKey(KeyCode.RightArrow)) {
              desiredSpeed = speed_hare;
            //Debug.Log("->" + desiredSpeed);
        }
        desiredSpeed = speed_hare;
        impulse.x = desiredSpeed - currentVelocity.x;

        // если нажати пробел мы будем прыгать
        if (pressedSpace > 0)
        {
            --pressedSpace;
            if (onGround)
            {
                impulse.y =  jumpFactor;
                //Debug.Log("impulse.y: " + impulse.y + "jump: " + jumpFactor);
            }
            if (!onGround && currentVelocity.y  <= 0f  && canDoubleJump)
            {
                canDoubleJump = false;
                impulse.y  = jumpFactor * 0.8f;
                
            }
        }       	 
        rigidbody2.AddForce(impulse,ForceMode2D.Impulse);
    }
    private void Update(){
		pressedSpace += Input.GetKeyDown(KeyCode.Space) ? 1 : 0;
		if (transform_.position.y + collider2.bounds.size.y <= cam.GetlowerBound()) {
			//Debug.Log("player dead");
			DeadHare();
            //dead = true;
		}
		
	} 
    #region OnTriggerEnter2D is called when the Collider other enters the trigger
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Floor")) 
            	canDoubleJump = onGround = true;
        		pressedGetMouseDown = true;											//pressedGetMouseDown
            /// <summary>
            /// если заяц кушаеть марковь
            /// </summary>
            /// <returns></returns>
        if (other.gameObject.CompareTag("Carrot"))
        {
            // add and high score here 
            gameManager.AddScore(score);
            gameManager.High();
			// если кушаем прибавляется по два          ->  if add eat two
            score += 2;
            gameManager.highScore += 1;
            // марковь сел заяц                         -> carrot sat a hare
            Destroy(other.gameObject);
            
        }else {
        	Debug.Log("Carrot yet here");
        }
        if (other.gameObject.CompareTag("CarrotRed")) {
        	//Debug.Log("CarrotRed");
        	gameManager.AddScore(score++);
        	
        	gameManager.High();
        	gameManager.highScore += 3;
        	Destroy(other.gameObject);
        }
        else {	Debug.Log("Carrot Red  yet here"); }
        
        if(score >= 10 && gameManager.highScore >= 10) {
	        	Debug.Log("You win");
       
        }else { Debug.Log("Yet not score 10 "); }
        
    } 
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Floor"))
            canDoubleJump = onGround = true;
        	pressedGetMouseDown = true;
			
    } 
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Floor"))
            onGround = false;
        	pressedGetMouseDown = false;
    }
    #endregion
    /// <summary>
    /// заяц умер
    /// </summary>
    
    public void DeadHare() {
        Quaternion right_down = new Quaternion(0f,0f,-90 + Time.deltaTime,0f);
        transform.rotation =  right_down;
        dead = true;
        //Debug.Log("player dead =(");
    }
    // jump hate
    public void GetMousePosition(Vector2 impulus) {
    	if (Input.GetMouseButtonDown(0)) {
    		
    		impulus.y = jumpFactor;
    		Debug.Log(impulus.y);
    		
    	}else {
    		impulus.y = jumpFactor * 0.9f;
    		pressedGetMouseDown = false;
    	}
    }
}
