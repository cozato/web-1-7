using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chara_control : MonoBehaviour {
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

	// Use this for initialization
	void Start () {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }
        //左右移動
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //プレイヤーの速度
        float speed_x = Mathf.Abs(this.rigid2D.velocity.x);

        //スピード制限
        if(speed_x < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
        //向き転換
        if(key!= 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        //速度に応じてアニメーションの速度も調整する
        this.animator.speed = speed_x / 2.0f;
    }
}
