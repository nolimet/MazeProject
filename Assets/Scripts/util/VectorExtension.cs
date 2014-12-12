using UnityEngine;
using System.Collections;

public class VectorExtension : MonoBehaviour
{

    public Vector2 angleToVector(float angle)
    {
        float X = (float)Mathf.Cos(angle);
        float Y = (float)Mathf.Sin(angle);

        return new Vector2(X, Y);
    }
}
