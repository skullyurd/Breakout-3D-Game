using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CM : MonoBehaviour
{

    public int Lives = 3;
    public int bricks = 30;
    public float resetDelay = 1f;
    public Text livesText;
    public GameObject GameOver;
    public GameObject YouWon;
    public GameObject bricksPrefab;
    public GameObject paddle;
    public GameObject DeathParticles;
    public static CM instance = null;

    private GameObject clonepaddle;

    // Use this for initialization
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Setup();

    }

    public void Setup()
    {
        clonepaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }

    void CheckGameOver()
    {
        if (bricks < 1)
        {
            YouWon.SetActive(true);

            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }

        if (Lives < 1)
        {
            GameOver.SetActive(true);

            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
    }

    void Reset()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LoseLife()
    {
        Lives --;
        livesText.text = "Lives:" + Lives;
        Instantiate(DeathParticles, clonepaddle.transform.position, Quaternion.identity);
        Destroy(clonepaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    void SetupPaddle()
    {
        clonepaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        bricks--;
        CheckGameOver();
    }

    

}