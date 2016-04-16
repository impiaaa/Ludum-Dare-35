using UnityEngine;

[RequireComponent(typeof (Mover))]
public abstract class AI : MonoBehaviour
{
    protected Mover character;
    void Awake()
    {
        character = GetComponent<Mover>();
    }
}
