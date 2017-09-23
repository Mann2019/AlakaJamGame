using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public ScoreValues[] scores;
    public GameObject weaponPrefab;
    public Transform spawnPoint;
    public Text score;

    public static int currentScore = 0;

    // Use this for initialization
    void Start () {
        Invoke("Fire", 1f);
    }

    private void Update()
    {
        score.text = currentScore.ToString();
    }

    public void Fire()
    {
        Instantiate(weaponPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
