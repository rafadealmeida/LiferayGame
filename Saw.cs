using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed = 2f;
    public Transform[] pointsToMove;
    private int startingPoint;

    private DamageHandler damageHandler;

    void Start()
    {
        damageHandler = GetComponent<DamageHandler>();
        anim = GetComponent<Animator>();
        if (pointsToMove.Length > 0)
        {
            transform.position = pointsToMove[startingPoint].transform.position;
        }
    }

    void Update()
    {
        if (pointsToMove.Length > 0)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointsToMove[startingPoint].transform.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, pointsToMove[startingPoint].transform.position) < 0.1f)
        {
            startingPoint = (startingPoint + 1) % pointsToMove.Length;
        }
    }
}
