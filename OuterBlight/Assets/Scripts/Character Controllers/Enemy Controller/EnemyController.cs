using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterController
{
    GameObject CurrentTarget;
    int CurrentTargetPriority;
    List<Targets> target;
    private float enemyCurHealth = 200f;
    private float enemyMaxHealth = 250f;

    void Start()
    {
        myTurn = false;
        currentState = TurnState.WAITING;
        Init();

    }


    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward);

        switch (currentState)
        {
            case (TurnState.MOVING):
                EnemyMovement();
                break;

            case (TurnState.CASTING):

                break;

            case (TurnState.LONGCASTING):

                break;

            case (TurnState.RUNNING):

                break;

            case (TurnState.RUSHING):

                break;

            case (TurnState.WAITING):
                ShouldEndTurn();
                break;

            case (TurnState.DEAD):

                break;
        }

        if(TurnManager.playerTurn)
        {
            myTurn = false;
        }
        else if(TurnManager.enemyTurn)
        {
            myTurn = true;
        }

        if (!myTurn)
        {
            return;
        }
        else
        {
            if (currentActionPoints > 0 && moveActionsThisTurn == 0)
            {

                moveSelected = true;

                if (!isMoving)
                {
                    currentState = TurnState.MOVING;
                }
            }
            else
            {
                ShouldEndTurn();
            }
        }
    }
    void CalculatePath()
    {
        Tile targetTile = GetTargetTile(CurrentTarget);
        FindPath(targetTile);
    }
    void FindNearestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

        GameObject nearest = null;
        float distance = Mathf.Infinity;

        foreach (GameObject obj in targets)
        {
            float d = Vector3.Distance(transform.position, obj.transform.position);

            if (d < distance)
            {
                distance = d;
                nearest = obj;

            }
        }

        CurrentTarget = nearest;
    }

    void FindBestTarget()
    {
        target.Clear();
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < targets.Length; i++)
        {
            Targets temp;
            CharacterController tempController = targets[i].GetComponent<CharacterController>();
            temp.target = targets[i];
            float d = Vector3.Distance(transform.position, targets[i].transform.position);
            temp.Priority = 1000 - (int)tempController.currentHealth - (int)d;
            target.Add(temp);
        }
        foreach (Targets item in target)
        {
            if((CurrentTargetPriority == 0 || CurrentTarget == null) || item.Priority > CurrentTargetPriority)
            {
                CurrentTargetPriority = item.Priority;
                CurrentTarget = item.target;
            }
        }
    }

    void EnemyMovement()
    {
        if (!isMoving)
        {
            FindNearestTarget();
            CalculatePath();
            FindSelectableTiles();
            actualTargetTile.target = true;

        }
        else
        {
            gameObject.tag = "ActivePlayer";
            moveSelected = true;
            Move();
        }
    }

    void ShouldEndTurn()
    {
        if(currentActionPoints <= 0)
        {
            TurnManager.FinishTurn();
            gameObject.tag = "NPC";
            TurnManager.enemyTurn = false;
            TurnManager.playerTurn = true;

        }

        if(moveActionsThisTurn > 0)
        {
            TurnManager.FinishTurn();
            gameObject.tag = "NPC";
            TurnManager.enemyTurn = false;
            TurnManager.playerTurn = true;

        }
    }
}

public struct Targets
{
    public int Priority;
    public GameObject target;
}
