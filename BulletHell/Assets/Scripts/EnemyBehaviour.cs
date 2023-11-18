using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    enum Pattern { Straight, Spin }
    enum Direction { Left, Right }

    private GameObject shootPoint;
    private GameController gameController;
    private ShootBehaviour shootBehaviour;
    private MovementBehaviour mvb;

    //private float rotation;
    private float timer;

    enum Spawn { A, B }

    [Header("Bullet Patterns")]
    [SerializeField] private Pattern pattern;
    [SerializeField] private float shootingRate;
    [SerializeField] private float rotationRate;
    [SerializeField] private Direction rotationDirection;

    void Start()
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

        timer += Time.deltaTime;

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
        }

        if (timer >= shootingRate)
        {
            shootBehaviour.Shoot();
            timer = 0f;
            //Test();
        }
    }

    // Pattern Test----------
    int x = 2;
    public void Test()
    {
        float res = Mathf.Abs(Mathf.Sin(5 * x * Mathf.PI / 360));

        shootPoint.transform.eulerAngles = new Vector3(0f, 0f, res);
        shootBehaviour.Shoot();
        x++;
    }

    public void Remove()
    {
        gameController.RemoveEnemy();
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
