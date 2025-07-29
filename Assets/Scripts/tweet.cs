using UnityEngine;

public class tweet : MonoBehaviour
{
    GameManager gameManager;
    void Start()
    {
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void TweetResult()
    {
        int score = GameManager.ReturnScore();
        naichilab.UnityRoomTweet.Tweet ("RitanekoTowerDoNotBattle", score + "体積みました", "リタ猫タワーバトらない");
    }
}
