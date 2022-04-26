using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D playerRb;
    private Animator playerAnimator;
    private bool isDead;

    [SerializeField] private float upForce = 350f;
    

    private void Start() {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0) && !isDead) {
            Flap();
        }
    }

    private void Flap() {
        playerRb.velocity = Vector2.zero;
        playerRb.AddForce(Vector2.up * upForce);
        playerAnimator.SetTrigger("Flap");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        isDead = true;
        playerAnimator.SetTrigger("Die");
        GameManager.Instance.GameOver();
    }
}
