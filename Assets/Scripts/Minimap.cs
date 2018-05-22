using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

    public Transform player;

	void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = player.position.y + 20;
        transform.position = newPosition;
    }
}
