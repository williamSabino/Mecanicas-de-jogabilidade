using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    private float rangeDestoy =-10f;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemyMove();
        EnemyDestroy();
    }

    //faz o inimigo se mover na direção do player 
    void enemyMove()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }

    //destoi os inimigos que caem do penhasco
    void EnemyDestroy()
    {
        if (transform.position.y < rangeDestoy)
        {
            Destroy(gameObject);
        }
    }

}
