using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private Slider volumeSlider;

    public bool isGrounded = true, isPlayerOnExit = false, isOnLadder = false, isPlayerOnPortal = false;
    public Transform feetPos;
    public float checkRadius, speed, jumpPower, moveImput, timeForChangeLvl = 1.6f;
    public LayerMask whatIsGround, whatIsLadder;
    public GameObject schetchik, HP, TextAbovePlayer, InfoForText, smert, TomatoForSchetchik, plusOneText, menu, settings, door;
    public int tomatoes = 0, health = 5, savedHealth = 5;
    public AudioClip victory, pomidorka, neverGonna, die, jumpSound;
    static List<Vector3> collectedCheckpoints = new List<Vector3>();
    public AudioSource audioSource;
    public Vector3 startPointPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (collectedCheckpoints.Count > 0)
        {
            transform.position = collectedCheckpoints[collectedCheckpoints.Count - 1];
        }
        Cursor.visible = false;
    }

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Lvl - 5")
        {
            startPointPosition.x = -7.822f;
            startPointPosition.y = -1.865f;
            StartCoroutine(waitForSurvive());
            IEnumerator waitForSurvive()
            {
                yield return new WaitForSeconds(60);
                Destroy(GameObject.Find("RedDoor"));
                Instantiate(door, startPointPosition, Quaternion.identity);
            }
        }
    }

    void Update()
    {
        moveImput = Input.GetAxis("Horizontal");

        Vector3 pos = transform.position;
        pos.x += moveImput * speed * Time.deltaTime;
        transform.position = pos;

        rb.velocity = new Vector2(moveImput * speed, rb.velocity.y);

        if (moveImput > 0)
        {
            Flip();
        }
        else if (moveImput != 0)
        {
            Flip();
        }

        if (moveImput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        isOnLadder = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsLadder);
        if ((isGrounded || isOnLadder) && Input.GetKeyDown(KeyCode.Space)) // Jump
        {
            Jump();
        }
        if (isPlayerOnPortal)
        {
            SceneManager.LoadScene("Meme");
        }
        if (Input.GetKeyDown(KeyCode.E) && isPlayerOnExit && schetchik.GetComponent<Text>().text == "3 / 3") // Locate to Next Lvl
        {
            LoadNextLvl();
        }
        if (Input.GetKeyDown(KeyCode.Escape)) // Menu
        {
            OpenMenu();
        }
        if (Input.GetKeyDown(KeyCode.R)) // Restart
        {
            RestartLevel();
        }
    }
    private void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Tomatoes") // Take Tomatoes
        {
            TakeTomato(Player);
        }
        if (Player.gameObject.tag == "Exit")
        {
            isPlayerOnExit = true;
        }
        if (Player.gameObject.tag == "Portal")
        {
            isPlayerOnPortal = true;
        }
        if (Player.gameObject.tag == "Meteorit" || Player.gameObject.tag == "Arrow" || Player.gameObject.name == "HitZone") // Damage Taken
        {
            Hurt();
        }
        if (Player.gameObject.tag == "DieSpace" || Player.gameObject.name == "Boom" || Player.gameObject.tag == "Spike") // Instant Death
        {
            Dead();
        }
        if (Player.gameObject.tag == "CheckPoint" && !IsCheckpointCollected(Player.gameObject.transform.position)) // CheckPoint
        {
            collectedCheckpoints.Add(Player.gameObject.transform.position);
            savedHealth = health;
        }
        bool IsCheckpointCollected(Vector3 checkingCheckpointPosition) // CheckPoint Check
        {
            if (collectedCheckpoints.Count > 0)
            {
                foreach (Vector3 collectedCheckpoint in collectedCheckpoints)
                {
                    if (checkingCheckpointPosition == collectedCheckpoint)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Exit")
        {
            isPlayerOnExit = false;
        }
    }

    void Flip()
    {
        if (moveImput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (moveImput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    void Hurt()
    {
        health--;
        HP.GetComponent<Text>().text = "" + health;
        AudioSource.PlayClipAtPoint(die, transform.position, volumeSlider.value);
        if (health <= 0)
        {
            Time.timeScale = 0;
            smert.SetActive(true);
        }
    }

    void Dead()
    {
        AudioSource.PlayClipAtPoint(die, transform.position, volumeSlider.value);
        plusOneText.SetActive(false);
        TomatoForSchetchik.SetActive(false);
        HP.GetComponent<Text>().text = "0";
        Time.timeScale = 0;
        smert.SetActive(true);
    }

    void TakeTomato(Collider2D Player)
    {
        AudioSource.PlayClipAtPoint(pomidorka, transform.position, volumeSlider.value);
        Destroy(Player.gameObject);
        tomatoes++;
        schetchik.GetComponent<Text>().text = tomatoes + " / 3";
        StartCoroutine(Tomatoes());
        IEnumerator Tomatoes()
        {
            plusOneText.SetActive(true);
            TomatoForSchetchik.SetActive(true);
            yield return new WaitForSeconds(1);
            plusOneText.SetActive(false);
            TomatoForSchetchik.SetActive(false);
        }
    }

    void RestartLevel() 
    {
        if (SceneManager.GetActiveScene().name != "Meme")
        {
            if (collectedCheckpoints.Count != 0)
            {
                transform.position = collectedCheckpoints[collectedCheckpoints.Count - 1];
                health = savedHealth;
                HP.GetComponent<Text>().text = "" + health;
                Time.timeScale = 1;
                smert.SetActive(false);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void OpenMenu()
    {
        if (!menu.activeSelf)
        {
            Cursor.visible = true;
            menu.SetActive(true);
            settings.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            Cursor.visible = false;
            Time.timeScale = 1;
            menu.SetActive(false);
        }
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        anim.SetTrigger("jumpStart");
        AudioSource.PlayClipAtPoint(jumpSound, transform.position, volumeSlider.value);
    }

    void LoadNextLvl()
    {
        if (SceneManager.GetActiveScene().name == "Meme")
        {
            SceneManager.LoadScene("Lvl - 1");
        }
        else
        {
            TextAbovePlayer.GetComponent<Text>().text = "Level complete!";
            audioSource.Stop();
            AudioSource.PlayClipAtPoint(victory, transform.position, volumeSlider.value);
            StartCoroutine(waitForChangeLvl());
            IEnumerator waitForChangeLvl()
            {
                yield return new WaitForSeconds(timeForChangeLvl);
                if (SceneManager.GetActiveScene().name == "Lvl - 1")
                {
                    SceneManager.LoadScene("Lvl - 2");
                }
                else if (SceneManager.GetActiveScene().name == "Lvl - 2")
                {
                    SceneManager.LoadScene("Lvl - 3");
                }
                else if (SceneManager.GetActiveScene().name == "Lvl - 3")
                {
                    SceneManager.LoadScene("Lvl - 4");
                }
                else if (SceneManager.GetActiveScene().name == "Lvl - 4")
                {
                    SceneManager.LoadScene("Lvl - 5");
                }
                else if (SceneManager.GetActiveScene().name == "Lvl - 5")
                {
                    SceneManager.LoadScene("Subtile");
                }
            }
        }
    }
}