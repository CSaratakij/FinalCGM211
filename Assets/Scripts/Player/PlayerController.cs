﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveForce;

    [SerializeField]
    float radius;

    [SerializeField]
    LayerMask layerMask;


    int hitCount;

    Vector3 inputDir;
    Rigidbody rigid;

    Collider[] results;


    void Awake()
    {
        results = new Collider[1];
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _InputHandler();
    }

    void FixedUpdate()
    {
       if (!GameController.IsGameStart)
        {
            rigid.velocity = Vector3.zero;
            return;
        }

        _CollisionHandler();
        _MovementHandler();
    }

    void _InputHandler()
    {
        inputDir.x = Input.GetAxis("Horizontal");
        inputDir.z = Input.GetAxis("Vertical");
    }

    void _CollisionHandler()
    {
         hitCount = Physics.OverlapSphereNonAlloc(rigid.position, radius, results, layerMask);

        if (hitCount > 0)
        {
            foreach (Collider col in results)
            {
                if (!col.gameObject.activeSelf)
                {
                    continue;
                }

                if (col.CompareTag("Box"))
                {
                    Global.AddScore(1);
                }
                else if (col.CompareTag("Goal"))
                {
                    GameController.GameOver();
                    break;
                }

                col.gameObject.SetActive(false);
            }
        }
    }

    void _MovementHandler()
    {
        rigid.AddForce(inputDir * moveForce * Time.deltaTime);
    }
}