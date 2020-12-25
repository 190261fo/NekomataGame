using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour {

	public AudioClip bombSE;

	void Start () {

	}

	void Update () {

	}
	
	void OnMouseDown() {
		Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, 1f);
		GetComponentInParent<BlockManager> ().OnBlockClear (colliders.Length);

		foreach (Collider2D collider in colliders) {
			if (Block.IsBlock(collider.gameObject)) {
				Destroy (collider.gameObject);
				AudioManager.GetInstance().PlaySound(13);
			}
		}
		Destroy (gameObject);
	}
}
