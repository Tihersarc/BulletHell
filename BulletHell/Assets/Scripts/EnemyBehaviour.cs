using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    protected enum Pattern { Straight, Spin }
    protected enum Direction { Left, Right }

    protected GameObject shootPoint;
    protected GameController gameController;
    protected ShootBehaviour shootBehaviour;
    protected MovementBehaviour mvb;
    protected float timer;

    enum Spawn { A, B }

    [Header("Bullet Patterns")]
    [SerializeField] protected Pattern pattern;
    [SerializeField] protected float shootingRate;
    [SerializeField] protected float rotationRate;
    [SerializeField] protected Direction rotationDirection;

    void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        shootPoint = this.GetComponent<ShootBehaviour>().GetShootPoint();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        shootBehaviour = GetComponent<ShootBehaviour>();
        mvb = GetComponent<MovementBehaviour>();
        timer = 0f;
    }

    void Update()
    {
        if (mvb.GetSpeed() != 0f && !Vector3.Equals(mvb.GetDirection(), Vector3.zero))
        {
            mvb.MoveTransform();
        }

        EnemyShooting();
    }

    protected virtual void EnemyShooting()
    {
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

    // Pattern Test----------
    //int x = 2;
    //public void Test()
    //{
    //    float res = Mathf.Abs(Mathf.Sin(5 * x * Mathf.PI / 360));

    //    shootPoint.transform.eulerAngles = new Vector3(0f, 0f, res);
    //    shootBehaviour.Shoot();
    //    x++;
    //}

    //public void Remove()
    //{
    //    gameController.RemoveEnemy();
    //}

    protected virtual void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
