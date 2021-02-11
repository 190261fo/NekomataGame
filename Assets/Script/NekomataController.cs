using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Fungus;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Assets.Script;
using UnityEngine.SceneManagement;

public class NekomataController : MonoBehaviour
{
    //キャラの移動速度変更用
    public float speed = 3.0f;
    DataManager dataManager;
    //宣言
    public Rigidbody2D rigidbody2d;
    float horizontal; 
    float vertical;

    public Animator animator;
    public Vector2 lookDirection = new Vector2(0,-1);
    Vector2 move;

    //会話用
    public Flowchart flowchart1;
    public Flowchart flowchart2;
    public  Boolean checkMove = false;

    //開始関数(update関数の前に1度だけ呼び出される)
    void Start()
    {
        // ↓どのスペックでも同じになるようにゲームの速度を制御(現在は必要ない)
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 10; // 10フレーム/1sに設定し直す

        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //更新関数(フレーム毎に呼び出される)
    void Update()
    {
        
        
        if (flowchart1.GetBooleanVariable("IsTalking") || flowchart2.GetBooleanVariable("IsTalking"))
        {
            //Debug.Log("Don't move!");
            dataManager.SaveGame();
            //dataManager.SaveScene(SceneManager.GetActiveScene().name);
            move = new Vector2(0, 0);
            animator.SetFloat("Speed", move.magnitude);
        }
        else
        {
            if (PlayerPrefs.GetInt("nekoMove") == 1)
            {
                
                move = new Vector2(0, 0);
                animator.SetFloat("Speed", move.magnitude);
                
            }
            else
            {
                horizontal = Input.GetAxis("Horizontal");
                vertical = Input.GetAxis("Vertical");

                move = new Vector2(horizontal, vertical);

                if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
                {
                    lookDirection.Set(move.x, move.y);
                    lookDirection.Normalize();
                }

                animator.SetFloat("Look X", lookDirection.x);
                animator.SetFloat("Look Y", lookDirection.y);
                animator.SetFloat("Speed", move.magnitude);
            }
            
        }
    }

    private void FixedUpdate()
    {
        if (flowchart1.GetBooleanVariable("IsTalking") || flowchart2.GetBooleanVariable("IsTalking"))
        {

        }
        else
        {
            if (PlayerPrefs.GetInt("nekoMove") == 1)
            {
            }
            else
            { // 移動量を加算する
                Vector2 position = rigidbody2d.position;
                position.x = position.x + speed * horizontal * Time.deltaTime;
                position.y = position.y + speed * vertical * Time.deltaTime;
                rigidbody2d.MovePosition(position);
            }
        }
        
    }


    private void Awake()
    {
        dataManager = FindObjectOfType<DataManager>();
        dataManager.SetLoad();
        PlayerPrefs.SetInt("nekoMove", 0);
        PlayerPrefs.Save();
    }

    public void PlayWalkSound() {
        AudioManager.GetInstance().PlaySound(1);
    }
    
    public void OnCollisionEnter2D(UnityEngine.Collision2D collision) {
        AudioManager.GetInstance().PlaySound(2);
    }

    public  void setCheckMove(Boolean check)
    {
        checkMove = check;
    }

    public  Boolean getCheckMove() {
        return checkMove;
    }

    public void Move(Boolean move)
    {
        if (move)
        {
            PlayerPrefs.SetInt("nekoMove", 0);
            Debug.Log("move");
        }
        else
        {
            PlayerPrefs.SetInt("nekoMove", 1);
            Debug.Log("stop");
        }
        PlayerPrefs.Save();
    }



    
}