using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] characters;//キャラクターオブジェクト配列
    bool isGene = false;//キャラクターが生成されたかどうか
    GameObject geneChara; //生成されたキャラクター単体
    bool isInterval = false; //キャラクター生成の間隔を制御
    bool isButtonHover = false; //ボタンがホバーされているかどうか
    public static bool isGameOver = false; //ゲームオーバー状態を管理
    void Start()
    {

    }

    void Update()
    {
        //ゲームオーバー状態であれば処理を終了
        if (isGameOver)
            return;

        //キャラクターが生成されていないかつキャラが静止している場合
        if (!isGene && !isInterval && !CheckMove())
        {
            CreateCharacter(); //キャラクターを生成
            isGene = true;
        }
        //マウスの左ボタンが離されたとき、かつキャラクターが生成されている場合
        else if (Input.GetMouseButtonUp(0) && isGene && !isButtonHover)
        {
            //物理挙動を有効にする
            geneChara.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            isGene = false; //キャラクター生成フラグをリセット
            StartCoroutine(IntervalCoroutine()); //キャラクター生成の間隔を制御
        }
        else if (Input.GetMouseButton(0) && isGene && !isButtonHover)
        {
            //マウスの左ボタンが押されている間、キャラクターを移動させる(x座標のみ)
            float mousePositionX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            geneChara.transform.position = new Vector2(mousePositionX, transform.position.y);
        }
    }
    void CreateCharacter()
    {
        //回転せずにGameManagerの座標にランダムにキャラ生成
        geneChara = Instantiate(characters[Random.Range(0, characters.Length)],
        transform.position, Quaternion.identity);
        //物理挙動をさせない状態にする
        geneChara.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
    IEnumerator IntervalCoroutine()
    {
        isInterval = true; //間隔制御フラグを立てる
        yield return new WaitForSeconds(1f); //1秒待機
        isInterval = false; //間隔制御フラグをリセット
    }

    bool CheckMove()
    {
        //Characterタグのオブジェクトを取得
        GameObject[] characterObjects = GameObject.FindGameObjectsWithTag("Character");
        foreach (GameObject character in characterObjects)
        {
            //キャラクターの速度が0.001以上なら動いていると判断
            if (character.GetComponent<Rigidbody2D>().linearVelocity.magnitude > 0.001f)
            {
                return true; //キャラクターが動いている場合はtrue
            }
        }
        return false; //キャラクターが動いていない場合はfalse
    }


    public void RotateCharacter()
    {
        if (isGene)
            geneChara.transform.Rotate(0, 0, -30);//30度ずつ回転
    }

    public void IsButtonChange(bool isX)
    {
        isButtonHover = isX; //ボタンの状態を変更
    }
    
}