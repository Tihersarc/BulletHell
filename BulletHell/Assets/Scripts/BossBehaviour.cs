using System.Collections;
using UnityEngine;

public class BossBehaviour : EnemyBehaviour
{
    private enum BossState
    {
        Spin,
        Homing,
        Cooldown
    }

    [SerializeField] private float spinLength;
    [SerializeField] private float homingLength;
    [SerializeField] private float cooldownLength;
    [SerializeField] private float spinShootingRate;
    [SerializeField] private float homingShootingRate;

    private BossState currentState = BossState.Cooldown;
    private float stateTimer;

    private void Start()
    {
        base.Init();
        stateTimer = 0f;
        timer = 0f;
    }

    private void Update()
    {
        mvb.MoveTransform();

        EnemyShooting();
    }

    protected override void EnemyShooting()
    {
        timer += Time.deltaTime;
        stateTimer += Time.deltaTime;


        switch (currentState)
        {
            case BossState.Spin:
                if (timer >= spinShootingRate)
                {
                    ShootSpin();
                    timer = 0f;
                }

                if (stateTimer >= spinLength)
                {
                    stateTimer = 0f;
                    currentState = BossState.Homing;
                }
                break;

            case BossState.Homing:
                if (timer >= homingShootingRate)
                {
                    ShootHoming();
                    timer = 0f;
                }

                if (stateTimer >= homingLength)
                {
                    stateTimer = 0f;
                    currentState = BossState.Cooldown;
                }
                break;

            case BossState.Cooldown:

                if (stateTimer >= cooldownLength)
                {
                    stateTimer = 0f;
                    currentState = BossState.Spin;
                }
                break;
        }
    }
    private void ShootSpin()
    {
        if (rotationDirection == Direction.Right)
        {
            shootPoint.transform.eulerAngles = new Vector3(0f, 0f, shootPoint.transform.eulerAngles.z + rotationRate);
        }
        else
        {
            shootPoint.transform.eulerAngles = new Vector3(0f, 0f, shootPoint.transform.eulerAngles.z + rotationRate);
        }
        shootBehaviour.Shoot();
    }

    private void ShootHoming()
    {
        shootBehaviour.ShootPlayer();
    }

    IEnumerator AttackPattern()
    {
        while (timer <= spinLength)
        {
            ShootSpin();
        }

        yield return null;
    }

    protected override void OnBecameInvisible()
    {
        base.OnBecameInvisible();
    }

    private void OnDestroy()
    {
        GameController.Instance.LevelFinished();
    }
}
