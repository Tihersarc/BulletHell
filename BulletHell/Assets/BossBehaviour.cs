using UnityEngine;

public class BossBehaviour : EnemyBehaviour
{
    
    protected override void EnemyShooting()
    {
        if (mvb.GetSpeed() != 0f && !Vector3.Equals(mvb.GetDirection(), Vector3.zero))
        {
            mvb.MoveTransform();
        }

        timer += Time.deltaTime;

        if (timer >= shootingRate)
        {
            if (pattern == Pattern.Spin)
            {
                if (rotationDirection == Direction.Left)
                {
                    shootPoint.transform.eulerAngles = new Vector3(0f, 0f, shootPoint.transform.eulerAngles.z + -rotationRate);
                }
                else
                {
                    shootPoint.transform.eulerAngles = new Vector3(0f, 0f, shootPoint.transform.eulerAngles.z + rotationRate);
                }
                shootBehaviour.Shoot();
            }
            if (pattern == Pattern.Straight)
            {
                shootBehaviour.ShootPlayer();
            }
            timer = 0f;
        }
    }

    protected override void OnBecameInvisible()
    {
        base.OnBecameInvisible();
    }
}
