using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class CharTemplate : ScriptableObject {

    [Header("Speed")]
    public float minSpeed = 1f;
    public float maxSpeed = 2f;
    [Header("Size")]
    public float minSize= 1f;
    public float maxSize = 2f;

}
