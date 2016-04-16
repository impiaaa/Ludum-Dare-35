using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Mover))]
public class PatrolAI : MonoBehaviour {
    public float waitTime = 3.0f;
    public float walkTime = 3.0f;

    private Mover character;
    private enum PatrolAction { WALK, WAIT };
    private PatrolAction action;
    private float timeSinceLastAction;
    private enum Facing { RIGHT, LEFT };
    private Facing facing = Facing.RIGHT;

    private void Awake()
    {
        character = GetComponent<Mover>();
        timeSinceLastAction = Time.time;
    }

    private void FixedUpdate()
    {
        if (action == PatrolAction.WAIT) {
            if (Time.time - timeSinceLastAction > waitTime) {
                action = PatrolAction.WALK;
                switch (facing) {
                    case Facing.LEFT:
                        facing = Facing.RIGHT;
                        break;
                    case Facing.RIGHT:
                        facing = Facing.LEFT;
                        break;
                }
                timeSinceLastAction = Time.time;
            }
            character.Move(0, false, false);
        }
        else if (action == PatrolAction.WALK) {
            if (Time.time - timeSinceLastAction > walkTime) {
                action = PatrolAction.WAIT;
                timeSinceLastAction = Time.time;
            }
            else {
                float h;
                switch (facing) {
                    case Facing.LEFT:
                        h = -1.0f;
                        break;
                    case Facing.RIGHT:
                        h = 1.0f;
                        break;
                    default:
                        return;
                }
                character.Move(h, false, false);
            }
        }
    }
}
