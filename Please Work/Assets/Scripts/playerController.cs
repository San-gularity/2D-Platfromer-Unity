using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator anim;
    private enum State { idle, run, jump, falling, hurt};
    private State state = State.idle;
    private Collider2D coll;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpforce = 10f;
    [SerializeField] private int cherries = 0;
    [SerializeField] private Text cherryText;
    [SerializeField] private float hurtforce = 5f;

    [SerializeField] private float deadZone = -9.5f;
    //[SerializeField] private float endZone = 120f;

    [SerializeField] private float checkX = -7;
    [SerializeField] private float checkY = 3.4f;
    [SerializeField] private int lives = 3;
    [SerializeField] private TextMeshProUGUI livesText;

    //public Transform CamTarget;
    //public float aheadAmount, aheadSpeed;

    public ParticleSystem Dust;
    public GameOverScreen GameOverVar;
    public new AudioManager audio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state != State.hurt)
        {
            movement();
        }
        if(rb.position.y < deadZone)
        {
            transform.position = new Vector2(checkX, checkY);
            livesUpdater();
        }
        VelocityState();
        anim.SetInteger("State", (int)state);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Froggy frog = other.gameObject.GetComponent<Froggy>();
        if (other.gameObject.tag == "Enemy" && state == State.falling)
        {
            frog.jumpedOn();
            audio.Play("Explosion");
            jump();
        }
        else if(other.gameObject.tag == "Eagle" && state == State.falling)
        {
            Eagle eagle = other.gameObject.GetComponent<Eagle>();
            eagle.jumpedOn();
            audio.Play("Explosion");
            jump();
        }
        else if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Eagle")
        {
            state = State.hurt;
            livesUpdater();

            if (other.gameObject.transform.position.x > transform.position.x)
            {
                //Enemy to my right and damage angle should be left
                rb.velocity = new Vector2(-hurtforce, rb.velocity.y);
            }
            else
            {
                //enemy to left and damage to right
                rb.velocity = new Vector2(hurtforce, rb.velocity.y);
            }
        }
    }
        private void movement()
    {
        float hDirection = Input.GetAxisRaw("Horizontal");
        if (hDirection > 0)
        {
            CreateDust();
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);

        }

        else if (hDirection < 0)
        {
            CreateDust();
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);

        }
        else
        {

        }

        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(Ground))
        {
            jump();
        }
        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0 )
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
        }
    }

    private void jump()
    {
        //FindObjectOgType<AudioManager>().Play("PlayerJump");
        audio.Play("PlayerJump");
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        state = State.jump;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Collectable")
        {
            Destroy(collision.gameObject);
            cherries += 1;
            audio.Play("Collectables");
            cherryText.text = cherries.ToString();
        }
        else if(collision.gameObject.tag == "CheckPoint")
        {
            CheckFlag checkFlag = collision.gameObject.GetComponent<CheckFlag>();
            checkX = checkFlag.GetPositionX();
            checkY = checkFlag.GetPositionY();
            audio.Play("Collectables");
            checkFlag.ReachedIt();
        }
        else if(collision.gameObject.tag == "Gem")
        {
            Gem gem = collision.gameObject.GetComponent<Gem>();
            gem.ReachedIt();
            audio.Play("Collectables");
        }
    }
    private void VelocityState()
    {
        if (state == State.jump)
        {
            if (rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if (state == State.falling)
        {
            if (coll.IsTouchingLayers(Ground))
            {
                state = State.idle;
            }
        }
        else if(state == State.hurt)
        {
            if(Mathf.Abs(rb.velocity.x) < .1f)
            {
                state = State.idle;
            }
        }
        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            state = State.run;
        }
        else
        {
            state = State.idle;
        }
    }
     private void livesUpdater()
    {
        lives -= 1;
        audio.Play("DeathVoice");
        livesText.text = lives.ToString();
        if(lives <= 0)
        {
            lives = 3;
            livesText.text = lives.ToString();
            GameOverVar = GameObject.FindObjectOfType(typeof(GameOverScreen)) as GameOverScreen;
            audio.Play("GameOver");
            GameOverVar.GameOverPart();
        }
    }

    void CreateDust()
    {
        Dust.Play();
    }
}
