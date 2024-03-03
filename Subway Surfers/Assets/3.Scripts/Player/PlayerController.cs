using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    private Rigidbody playerRigid;
    private Animator animator;

    private void Init()
    {
        playerRigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Start() => Init();

    private void Update()
    { 
        float x = Input.GetAxisRaw("Horizontal");

        transform.Translate(x * playerSpeed * Time.deltaTime, 0f, 0f);

        animator.Play("Run");

        OnDrawRay();
    }

    private void OnJump()
    {
        if (Physics.Raycast(transform.position + Vector3.up * 0.25f, Vector3.down, out RaycastHit hit, 0.5f, LayerMask.GetMask("Ground")))
        {

            Debug.Log("Ground");

            playerRigid.velocity = Vector3.up * 100f;

        }
    }

    private void OnDrawRay()
    {
        Debug.DrawRay(transform.position, Vector3.down * 0.5f, new Color(0, 1, 0));
    }
}
