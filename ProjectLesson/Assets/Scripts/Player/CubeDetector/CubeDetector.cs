using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeDetector : MonoBehaviour
{

    [SerializeField]
    private PlayerMoverRunner PlayerMoverRunner;

    public TextMeshProUGUI text;
    private int collectedBonus = 0;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Bonus"))
        {
            Debug.Log("Bonus Point");
            collision.gameObject.SetActive(false);

            collectedBonus++;
            text.text = collectedBonus.ToString();

        }

        if (collision.gameObject.CompareTag("Cube"))
        {
            Debug.Log("Collision");

            var cubeBehaviour = collision.gameObject.GetComponent<CubeBehaviour>();

            if (!cubeBehaviour.isStacked)
            {
                PlayerCubeManager.Instance.GetCube(cubeBehaviour);
            }

        }

    }
    
}
