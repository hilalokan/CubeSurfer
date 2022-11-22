using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{

    public bool isStacked = false;

    private RaycastHit hit;

    private void FixedUpdate()
    {
        if (!isStacked)
            return;

        Debug.DrawRay(transform.position, Vector3.forward * 0.075f, Color.red);

        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 0.075f))
        {
            if (hit.transform.gameObject.CompareTag("Obstacle"))
            {
                PlayerCubeManager.Instance.DropCube(this);
            }
        }


    }
}
