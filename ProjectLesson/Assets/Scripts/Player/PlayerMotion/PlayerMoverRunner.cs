using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverRunner : MonoBehaviour
{
    private bool canMotion = true;

    public bool CanMotion { get => canMotion; set => canMotion = value; }



    public float velocity;

    private void FixedUpdate()
    {
        if (!canMotion)
        {
            return;
        }

        transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * velocity;

        if (transform.position.x > .1343f)
        {
            transform.position = new Vector3(.1343f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -.1609f)
        {
            transform.position = new Vector3(-.1609f, transform.position.y, transform.position.z);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.CompareTag("EndPoint"))
        {
            Debug.Log("playermoverrunner EndPoint");
            AccessEndPoint();
            PlayerCubeManager.Instance.ActivateWinUI();
        }
    }

    public void AccessEndPoint()
    {
        canMotion = false;
    }

}