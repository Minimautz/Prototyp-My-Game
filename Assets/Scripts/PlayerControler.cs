using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour {

    public Rigidbody2D rb;
    public float forcefactor; //horizontalerichtung
    public float maxspeed = 10f;

    private bool jump;
    public float jumpForce;

    public Transform groundCheck;
    private bool grounded = false;

    public Transform graphic;
       
    public Text score;

    public Animator animator;

    public string levelName;

    private bool onClimble;

    public float velocityDamageThreshold;

    // Use this for initialization
    void Start () {
	}

    // Update is called once per frame
    private void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")); // Auf Boden?

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }
    
    void FixedUpdate () {
                                                                 //Rechts/links bewegen Anfang
        float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h * maxspeed, rb.velocity.y);   //Ende   

        if (Mathf.Abs(rb.velocity.x) > 0.5)                         //Graphic wird geflipt
        {
            graphic.localScale = new Vector2(Mathf.Sign(rb.velocity.x) * Mathf.Abs(graphic.localScale.x), graphic.localScale.y); 
        }
            
        if (onClimble)
        {
            float v = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, v * maxspeed);
        }

        if (jump)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }

        animator.speed = Mathf.Abs(rb.velocity.x) / maxspeed;
             
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > velocityDamageThreshold)
        {
            SaveStatus.count = 0;
            StartCoroutine(DestroyAndWait());
        }
    }

    IEnumerator DestroyAndWait()
    {
        this.enabled = false;
        graphic.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(levelName);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            SaveStatus.count = SaveStatus.count + 1;
            score.text = "Acorns : " + SaveStatus.count;
        }
                
        if (other.CompareTag("Climble"))
        {
            onClimble = true;
            rb.gravityScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Climble"))
        {
            onClimble = false;
            rb.gravityScale = 1;
        }
    }


}
