using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    public enum Moveble { FORWARDAndSTOP, СYCLE }
    public enum dir { ToA, ToB }
    [Tooltip("Type move")]
    public Moveble Type;
    [Tooltip("In the direction of which point will be the first jerk")]
    public dir Direction;
    [Range(2,10)]public float Speed = 5;    
    [Header("Points"),Tooltip("Points between which the movement will be carried out")]
    [Space(20)]
    public Transform PointA;
    public Transform PointB;
    void Update()
    {
        switch (Type)
        {
            case Moveble.FORWARDAndSTOP: transform.position = Vector3.Slerp(transform.position, (Direction == dir.ToA ? PointA : PointB).position, Time.deltaTime / (12 - Speed)); break;
            case Moveble.СYCLE: transform.position = Vector3.Lerp(transform.position, (Direction == dir.ToA ? PointA : PointB).position, Time.deltaTime / (12 - Speed));
                if ((Direction == dir.ToA ? PointA : PointB) && Vector3Int.CeilToInt(transform.position) == Vector3Int.CeilToInt((Direction == dir.ToA ? PointA : PointB).position))
                    if (Direction == dir.ToA) Direction = dir.ToB; else Direction = dir.ToA; break;
        }
    }
}
