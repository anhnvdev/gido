using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementConfig", menuName = "GameConfiguration/PlayerMovement", order = 1)]
public class PlayerMovement_Create : ScriptableObject
{
    public float speed;
    public float jumpForce;
}
