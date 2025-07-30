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
        naichilab.UnityRoomTweet.Tweet ("ritanekotowerdonotbattle", "リタ猫タワーバトらないで【"+score + "体】積みました", "リタ猫タワーバトらない");
    }
}
