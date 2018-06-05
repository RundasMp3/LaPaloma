using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour {

    // Update is called once per frame
    public GameObject node;
    private Transform target;
    private CarNodes nextNode;
    private float speed = 50f;
    private List<GameObject> nodeList;
    int num;

    private void Start()
    {
        target = node.transform;
        nodeList = new List<GameObject>();
    }

    void FixedUpdate () {
        Drive();
	}

    private void Drive()
    {
        float step = speed * Time.deltaTime;
        System.Random rnd = new System.Random();

        if (Vector3.Distance(transform.position, target.position) < 3f)
        {
            nextNode = node.GetComponent<CarNodes>();


            if (nextNode.Izquierda != null)
                nodeList.Add(nextNode.Izquierda);

            if (nextNode.Frente != null)
                nodeList.Add(nextNode.Frente);

            if (nextNode.Derecha != null)
                nodeList.Add(nextNode.Derecha);

            if (nextNode.DerechaDos != null)
                nodeList.Add(nextNode.DerechaDos);

            if (nextNode.IzquierdaDos != null)
                nodeList.Add(nextNode.IzquierdaDos);

            //num = rnd.Next(0, nodeList.Count-1);
            num = rnd.Next(nodeList.Count);
            target = nodeList[num].transform;

            node = nodeList[num];

            nodeList.Clear();


        }
        else
        {
            Vector3 targetDir = target.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            transform.rotation = Quaternion.LookRotation(newDir);
            Debug.Log(name+" en "+Vector3.Distance(transform.position, target.position));
        }
    }

}
