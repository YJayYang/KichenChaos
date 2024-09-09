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

    [SerializeField] private LayerMask counterLayerMask;

    private bool isWalking;
    private Vector3 lastInteractDir;
    

    private void Update() {
        HandleMovement();
        HandleInteractions();



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

    private void HandleMovement() {
        // ����������벢������������
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        //��������ƶ�
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y).normalized;
        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove) {
            Vector3 moveDriX = new Vector3(moveDir.x, 0, 0);
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDriX, moveDistance);

            if (canMove) {
                moveDir = moveDriX;
            } else {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove) {
                    moveDir = moveDirZ;
                } else {

                }
            }
        }
        if (canMove) {
            if (moveDir != Vector3.zero) {
                MovePlayer(moveDir);
                SmoothRotatePlayer(moveDir);
                isWalking = true;  // ����Ϊ����״̬
            } else {
                isWalking = false; // û��������������
            }
        }

    }

    private void HandleInteractions() {
       
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
      
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y).normalized;
        if (moveDir != Vector3.zero) {
            lastInteractDir = moveDir;
        }
        float interactDistance = 2f;
        if(Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, counterLayerMask)) {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter)) {
                clearCounter.Interact();
            }
        }

    }



    }

