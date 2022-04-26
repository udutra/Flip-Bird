using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

    private Rigidbody2D rb;
    [SerializeField] private float speed = 2.5f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void OnEnable() {
        rb.velocity = Vector2.left * speed;
    }

    private void Update() {
        if (GameManager.Instance.isGameOver) {
            rb.velocity = Vector2.zero;
        }
    }



}
