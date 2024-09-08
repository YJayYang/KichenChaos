using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour {

    //[SerializeField] ���Ա�ʾ������������� Unity �༭���н����޸ġ�
    [SerializeField] private float moveSpeed = 7f;

    [SerializeField] private float rotateSpeed = 7f;

    [SerializeField] private GameInput gameInput;

    private bool isWalking;

    private void Update() {

        // ����������벢������������
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        //��������ƶ�
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y).normalized;


        // ����������ƶ������ƶ���Ҳ���ת��ɫ
        if (moveDir != Vector3.zero) {
            MovePlayer(moveDir);
            SmoothRotatePlayer(moveDir);
            isWalking = true;  // ����Ϊ����״̬
        } else {
            isWalking = false; // û��������������
        }


    }

    public bool IsWalking() {
        return isWalking;
    }




    private void MovePlayer(Vector3 moveDir) {
        transform.position += moveSpeed * Time.deltaTime * moveDir;
    }


    private void SmoothRotatePlayer(Vector3 moveDir) {

        //ͨ������ Time.deltaTime��ʹ�ý�ɫ���ƶ�����ƽ��������֡�ʵ�Ӱ��


        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

    }




}
