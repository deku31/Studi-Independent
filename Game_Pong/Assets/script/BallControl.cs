﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Vector2 trajectoryOrigin;
    // Rigidbody 2D bola
    private Rigidbody2D rigidBody2D;

    [Header("gaya mendorong bola")]
    // Besarnya gaya awal yang diberikan untuk mendorong bola
    public float xInitialForce;
    public float yInitialForce;

    void ResetBall()
    {
        // Reset posisi menjadi (0,0)
        transform.position = Vector2.zero;

        // Reset kecepatan menjadi (0,0)
        rigidBody2D.velocity = Vector2.zero;
    }
    void PushBall()
    {
        // Tentukan nilai komponen y dari gaya dorong antara -yInitialForce dan yInitialForce
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);

        // Tentukan nilai acak antara 0 (inklusif) dan 2 (eksklusif)
        float randomDirection = Random.Range(0, 2);

     
        if (randomDirection < 1.0f)
        {
            // Gunakan gaya untuk menggerakkan bola ini.
            rigidBody2D.AddForce(new Vector2(xInitialForce, -yInitialForce));
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(-xInitialForce, -yInitialForce));
        }

    }
    //private void OnCollisionEnter2D(Collision2D coll)
    //{
    //    if (coll.collider.CompareTag("Player"))
    //    {
    //        Vector2 vel;
    //        vel.x = rigidBody2D.velocity.x;
    //        vel.y = (rigidBody2D.velocity.y / 2.0f) + (coll.collider.attachedRigidbody.velocity.y / 3.0f);
    //        rigidBody2D.velocity = vel;
    //    }
    //}
    void RestartGame()
    {
        // Kembalikan bola ke posisi semula
        ResetBall();

        // Setelah 2 detik, berikan gaya ke bola
        Invoke("PushBall", 2);
    }
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        // mulai game
        RestartGame();
        trajectoryOrigin = transform.position;
    }
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }
}
