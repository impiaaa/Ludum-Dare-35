using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    abstract public void Move(float move, bool crouch, bool jump);
}
