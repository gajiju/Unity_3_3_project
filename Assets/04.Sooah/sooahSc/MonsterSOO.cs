using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterSO", menuName = "Characters/Enemy", order = 0)]
public class MonsterSOO : ScriptableObject
{
    [field: SerializeField] public float FollowRange { get; private set; } = 10f;
    [field: SerializeField] public float AttackRange { get; private set; } = 1.5f;
    [field: SerializeField] public int Damage { get; set; }
    [field: SerializeField] public float speed { get; set; }
    [field: SerializeField] public int maxHP { get; set; }
    //[field: SerializeField][field: Range(0f, 3f)] public float ForceTransitionTime { get; private set; }
    //[field: SerializeField][field: Range(-10f, 10f)] public float Force { get; private set; }

    //[field: SerializeField][field: Range(0f, 1f)] public float Dealing_Start_TransitionTime { get; private set; }
    //[field: SerializeField][field: Range(0f, 1f)] public float Dealing_End_TransitionTime { get; private set; }
}
