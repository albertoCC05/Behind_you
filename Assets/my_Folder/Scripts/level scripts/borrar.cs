using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borrar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"angulo fl: {Vector3.SignedAngle(Vector3.forward, Vector3.left, Vector3.up)}");
        Debug.Log($"angulo lf: {Vector3.SignedAngle(Vector3.left, Vector3.forward, Vector3.up)}");

        Debug.Log($"angulo fr: {Vector3.SignedAngle(Vector3.forward, Vector3.right, Vector3.up)}");
        Debug.Log($"angulo rf: {Vector3.SignedAngle(Vector3.right, Vector3.forward, Vector3.up)}");

        Debug.Log($"angulo lb: {(Vector3.SignedAngle(Vector3.left, Vector3.back, Vector3.up) + 360) % 360}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
