using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    [SerializeField]
    private SwerveInputSystem SwerveInputSystem;

    [SerializeField]
    private float swerveSpeed = 0.5f;

    [SerializeField]
    private float maxSwerveAmount = 1f;

    private float canMoveFactor = 1f;

    private void Update()
    {
        if (PlayerBehaviour.Instance.PlayerMoverRunner.CanMotion)
            canMoveFactor = 1f;
        else
            canMoveFactor = 0f;
        float swerveAmount = Time.deltaTime * swerveSpeed * SwerveInputSystem.MoveFactoryX * canMoveFactor;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmount, 0f, 0f);
    }
}
