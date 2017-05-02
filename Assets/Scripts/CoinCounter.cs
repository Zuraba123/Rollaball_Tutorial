using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public string coinTagString;
    public string badCoinTagString;

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
        else if (other.tag == badCoinTagString && score > 0)
        {
            score = score - 1;
        }

        Debug.Log("Triggered " + score + " " + other.gameObject.name);

        scoreText.text = "Score: " + score;

        Destroy(other.gameObject);
    }
}
