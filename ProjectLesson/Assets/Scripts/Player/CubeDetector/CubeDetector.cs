using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class CubeDetector : MonoBehaviour
{

    [SerializeField]
    private PlayerMoverRunner PlayerMoverRunner;

    [SerializeField]
    private AudioMixer myMixer;

    public float coinCollectSoundVolume = 0.025f;

    public AudioClip coinSound;

    public TextMeshProUGUI text;
    public int collectedBonus = 0;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Bonus"))
        {
            //Debug.Log("Bonus Point");
            collision.gameObject.SetActive(false);

            AudioSource.PlayClipAtPoint(coinSound, transform.position, coinCollectSoundVolume);

            collectedBonus++;
            text.text = collectedBonus.ToString();

        }

        if (collision.gameObject.CompareTag("Cube"))
        {
            //Debug.Log("Collision");

            var cubeBehaviour = collision.gameObject.GetComponent<CubeBehaviour>();

            if (!cubeBehaviour.isStacked)
            {
                PlayerCubeManager.Instance.GetCube(cubeBehaviour);
            }

        }

    }
    
}
