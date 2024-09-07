using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour {

    //[SerializeField] ���Ա�ʾ������������� Unity �༭���н����޸ġ�
    [SerializeField] private float moveSpeed = 7f;

    [SerializeField] private float rotateSpeed = 10f;
    private void Update() {

        // ����������벢������������
        Vector2 inputVector = GetInputVector();

        //��������ƶ�
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y).normalized;


        // ������ƶ����룬����λ�ò���ת��ɫ
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

        //ͨ������ Time.deltaTime��ʹ�ý�ɫ���ƶ�����ƽ��������֡�ʵ�Ӱ��


        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

    }




}
