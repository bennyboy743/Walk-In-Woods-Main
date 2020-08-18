    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmoz : MonoBehaviour
{

    public float gizmosSize = .75f;
    public Color colorGizmos = Color.yellow;
    private void OnDrawGizmos()
    {
        Gizmos.color = colorGizmos;
        Gizmos.DrawSphere(transform.position, gizmosSize);
    }

}
