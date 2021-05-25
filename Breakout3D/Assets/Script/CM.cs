using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CM : MonoBehaviour
{

    [SerializeField] private int Lives = 3;
    [SerializeField] private int bricks = 30;
    [SerializeField] private float resetDelay = 1f;
    [SerializeField] private Text livesText;
    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject YouWon;
    [SerializeField] private GameObject bricksPrefab;
    [SerializeField] private GameObject paddle;
    [SerializeField] private GameObject DeathParticles;
    public static CM instance = null;

    private GameObject clonepaddle;
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