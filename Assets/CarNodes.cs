using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarNodes : MonoBehaviour {

    public GameObject Frente;
    public GameObject Derecha;
    public GameObject Izquierda;
    public GameObject DerechaDos;
    public GameObject IzquierdaDos;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if (Frente != null)
            Gizmos.DrawLine(transform.position, Frente.transform.position);
        if (Derecha != null)
            Gizmos.DrawLine(transform.position, Derecha.transform.position);
        if (Izquierda != null)
            Gizmos.DrawLine(transform.position, Izquierda.transform.position);
        if (DerechaDos != null)
            Gizmos.DrawLine(transform.position, DerechaDos.transform.position);
        if (IzquierdaDos != null)
            Gizmos.DrawLine(transform.position, IzquierdaDos.transform.position);
    }
}
