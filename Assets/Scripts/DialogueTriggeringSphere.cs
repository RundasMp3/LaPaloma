using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggeringSphere : MonoBehaviour {

	void OnTriggerEnter (Collider other)
    {
        Debug.Log("Object entered the trigger.");
    }
}
