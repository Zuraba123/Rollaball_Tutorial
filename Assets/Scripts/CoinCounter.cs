using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public string coinTagString;
    public string badCoinTagString;
    
    public Text resultText;
    public string winString;
    public string loseString;

    public GameObject menu;
    public PlayerMover myMover;
    public Rigidbody myBody;

    int targetScore;

    void Start()
    {
        targetScore = GameObject.FindGameObjectsWithTag(coinTagString).Length;

        menu.SetActive(false);
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collision " + col.gameObject.name);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == coinTagString)
        {
            score = score + 1;
        }
        else if (other.tag == badCoinTagString)
        {
            GameOver(false);
        }

        Debug.Log("Triggered " + score + " " + other.gameObject.name);

        scoreText.text = "Score: " + score;

        if (targetScore == score)
        {
            GameOver(true);
        }

        Destroy(other.gameObject);
    }

    void GameOver(bool didWin)
    {
        menu.SetActive(true);
        myMover.enabled = false;
        myBody.isKinematic = true;

        if (didWin)
        {
            resultText.text = winString;
        }
        else
        {
            resultText.text = loseString;
        }
    }
}
