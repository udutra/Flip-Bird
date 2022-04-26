using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            GameManager.Instance.IncreaseScore();
        }
        if (collision.gameObject.CompareTag("MainCamera")) {
            gameObject.SetActive(false);
        }
    }
}
