using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour {

    //[SerializeField] 属性表示这个变量可以在 Unity 编辑器中进行修改。
    [SerializeField] private float moveSpeed = 7f;

    [SerializeField] private float rotateSpeed = 7f;

    [SerializeField] private GameInput gameInput;

    private bool isWalking;

    private void Update() {

        // 处理玩家输入并计算输入向量
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        //控制玩家移动
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y).normalized;


        // 如果有输入移动，则移动玩家并旋转角色
        if (moveDir != Vector3.zero) {
            MovePlayer(moveDir);
            SmoothRotatePlayer(moveDir);
            isWalking = true;  // 设置为行走状态
        } else {
            isWalking = false; // 没有输入则不在行走
        }


    }

    public bool IsWalking() {
        return isWalking;
    }




    private void MovePlayer(Vector3 moveDir) {
        transform.position += moveSpeed * Time.deltaTime * moveDir;
    }


    private void SmoothRotatePlayer(Vector3 moveDir) {

        //通过引入 Time.deltaTime，使得角色的移动更加平滑，不受帧率的影响


        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

    }




}
