﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlockManager: MonoBehaviour {

	Text timeText;
	Text finishText;
	Text resultText;
	float time = 1000;
	Boolean FlagTimeStart = false;
	Boolean isRunning = true;

	public GameObject blockPrefab;
	public GameObject bombPrefab;

	GameObject firstBlock;
	GameObject lastBlock;
	List<GameObject> removeBlockList = new List<GameObject> ();

	ScoreManager scoreManager;
	FeverManager feverManager;

    public Fade fade;


	void Start () {
		scoreManager = gameObject.AddComponent<ScoreManager> ();
		feverManager = gameObject.AddComponent<FeverManager> ();
		feverManager.RegisterOnFeverCallBack (() => AddTime(5));
		GameObject canvas = GameObject.Find ("Canvas");
		if (FlagTimeStart) {
			StartCoroutine (GenerateBlocks (60));
			if (canvas != null) {
				// 制限時間
				time = 60;
				Transform timeGUI = canvas.transform.Find ("TimeGUI");
				Transform finishGUI = canvas.transform.Find ("FinishGUI");
				Transform resultGUI = canvas.transform.Find ("ResultGUI");
				if (timeGUI != null) {
					timeText = timeGUI.GetComponent<Text> ();
					SyncTimeGUI ();
				}
				if (finishGUI != null) {
					finishText = finishGUI.GetComponent<Text> ();
				}
				if (resultGUI != null) {
        			resultText = resultGUI.GetComponent<Text> ();
      			}
			}
		}
	}

	void Update () {
		if (FlagTimeStart) {
			if (Input.GetMouseButton (0) && firstBlock == null) {
				OnDragStart ();
			} else if (Input.GetMouseButton (0) && firstBlock) {
				OnDragging ();
			} else if (Input.GetMouseButtonUp (0) && firstBlock) {
				OnDragEnd ();
			}
		}
		time -= Time.deltaTime;
		if (time < 0) {
			time = 0;
			if (isRunning) {
                AudioManager.GetInstance().PlaySound(14);
                isRunning = false;
            }
			SyncfinishGUI ();
			SyncResultGUI ();
		}
		SyncTimeGUI ();
	}        

	public void StartClick() {
		AudioManager.GetInstance().PlaySound(10);
		FlagTimeStart = true;
		Start();
	}

	public void AddTime(float deltaTime) {
		time += deltaTime;
	}

	void SyncTimeGUI() {
		if (timeText != null) {
			timeText.text = "残り" + ((int)time).ToString () + "秒";
		}
	}

	void SyncfinishGUI() {
		if (finishText != null) {
			finishText.text = "そこまで！！";
		}
	}

	public void SyncResultGUI() {
  		if (resultText != null) {
			
    		if (int.Parse(scoreManager.scoreText.text) >= 150000){
      			resultText.text = "クリアSSS";
				PlayerPrefs.SetInt("Tsumu", 1);
				PlayerPrefs.Save();
				CallInvoke();
			} else if (int.Parse(scoreManager.scoreText.text) >= 100000){
      			resultText.text = "クリアS";
				PlayerPrefs.SetInt("Tsumu", 1);
				PlayerPrefs.Save();
				CallInvoke();
			} else if (int.Parse(scoreManager.scoreText.text) >= 80000){
      			resultText.text = "クリアA";
				PlayerPrefs.SetInt("Tsumu", 1);
				PlayerPrefs.Save();
				CallInvoke();
			} else {
      			resultText.text = "クリア失敗";
			}
    	}
  	}

	public void CallInvoke()
    {
		if(PlayerPrefs.GetInt("MiniGameMode2") == 1)
        {
			
        }
        else
        {
			Invoke("Isekai", 3.0f);
		}
    }
	
	// ミニゲーム後の遷移
	void Isekai()
	{
		// フェードイン
		fade.FadeIn(1.3f, () =>
		{
			// フェードイン完了後の処理（画面は真っ暗）
			SceneManager.LoadScene("IsekaiScene"); //　シーン遷移
		});
	}

	IEnumerator GenerateBlocks(int n){
		for (int i = 0; i < n; i++) {
			yield return new WaitForSeconds (0.01f);
			GameObject block = GameObject.Instantiate (blockPrefab);
			block.transform.parent = transform;
		}
	}

	void GenerateBomb(Vector3 position) {
		GameObject bomb = GameObject.Instantiate (bombPrefab);
		bomb.transform.position = position;
		bomb.transform.parent = transform;
	}

	void OnDragStart() {
		if (time != 0) {
			GameObject newBlock = MousedOverBlock();
			if (newBlock != null) {
				firstBlock = newBlock;
				lastBlock = newBlock;
				AddToRemoveBlockList(newBlock);
			}
		}
	}

	void OnDragging() {
		GameObject newBlock = MousedOverBlock ();
		if (newBlock != null && newBlock != lastBlock) {
			if (IsNewBlockRemovable (newBlock)) {
				lastBlock = newBlock;
				AddToRemoveBlockList (newBlock);
			}
		}
	}

	void OnDragEnd() {
		int count = removeBlockList.Count;
		if (count >= 3) {
			OnBlockClear(count);
			AudioManager.GetInstance().PlaySound(12);
			// 6個以上でボム生成
			if (count >= 6) { 
				GenerateBomb (lastBlock.transform.position);
				AudioManager.GetInstance().PlaySound(11);
			}
			ClearRemoveBlockList ();
		} else {
			ResetRemoveBlockList ();
		}
		firstBlock = null;
		lastBlock  = null;
	}

	GameObject MousedOverBlock() {
		RaycastHit2D hit = Physics2D.Raycast (
			                   Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);

		if (hit.collider != null) {
			GameObject hitObject = hit.collider.gameObject;
			if (Block.IsBlock (hitObject)) {
				return hitObject;
			}
		}
		return null;
	}

	bool IsNewBlockRemovable(GameObject newBlock) {
		if (!Block.IsSameType (newBlock, firstBlock)) {
			return false;
		} else if (newBlock.GetComponent<Block> ().IsOnChain ()) {
			return false;
		}

		RaycastHit2D[] hits = Physics2D.RaycastAll (
			                      (Vector2)lastBlock.transform.position,
			                      (Vector2)(newBlock.transform.position - lastBlock.transform.position),
			                      1);

		if (hits.Length > 1) {
			if (hits [1].collider != null) {
				if (hits [1].collider.gameObject == newBlock.gameObject) {
					return true;
				}
			}
		}
		return false;
	}

	void AddToRemoveBlockList(GameObject block) {
		removeBlockList.Add (block);
		block.GetComponent<Block> ().SetIsOnChain (true);
		block.GetComponent<Block> ().SetTransparency (0.5f);
	}

	void ClearRemoveBlockList() {
		foreach (GameObject block in removeBlockList) {
			Destroy (block);
		}
		removeBlockList.Clear ();
	}

	void ResetRemoveBlockList() {
		foreach (GameObject block in removeBlockList) {
			block.GetComponent<Block> ().SetIsOnChain (false);
			block.GetComponent<Block> ().SetTransparency (1f);
		}
		removeBlockList.Clear ();
	}

	public void OnBlockClear(int chain) {
		scoreManager.AddScore (ScoreManager.CalculateScore (chain, 1, feverManager.IsFever()));
		feverManager.AddFeverValue (chain);
		StartCoroutine (GenerateBlocks (chain));
	}
}