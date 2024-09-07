using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour {

    //[SerializeField] 属性表示这个变量可以在 Unity 编辑器中进行修改。
    [SerializeField] private float moveSpeed = 7f;

    [SerializeField] private float rotateSpeed = 10f;
    private void Update() {

        // 处理玩家输入并计算输入向量
        Vector2 inputVector = GetInputVector();

        //控制玩家移动
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y).normalized;


        // 如果有移动输入，更新位置并旋转角色
        if (moveDir != Vector3.zero) {
            MovePlayer(moveDir);
            SmoothRotatePlayer(moveDir);
        }

       

    }


    private Vector2 GetInputVector() {
        Vector2 inputVector = new(0, 0);
        if (Input.GetKey(KeyCode.W)) {
            inputVector.y = +1;

        }
        if (Input.GetKey(KeyCode.S)) {
            inputVector.y = -1;

        }
        if (Input.GetKey(KeyCode.A)) {
            inputVector.x = -1;

        }
        if (Input.GetKey(KeyCode.D)) {
            inputVector.x = +1;

        }

        return inputVector.normalized;
    }


    private void MovePlayer(Vector3 moveDir) {
        transform.position += moveSpeed * Time.deltaTime * moveDir;
    }


    private void SmoothRotatePlayer(Vector3 moveDir) {

        //通过引入 Time.deltaTime，使得角色的移动更加平滑，不受帧率的影响


        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

    }




}
