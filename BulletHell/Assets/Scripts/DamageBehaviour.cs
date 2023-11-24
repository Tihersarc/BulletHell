using Cinemachine;
using UnityEngine;

public class DamageBehaviour : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool isSparks;
    [SerializeField] private GameObject sparks;

    private CinemachineImpulseSource impulseSource;

    private void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out HealthBehaviour h) && h.enabled)
        {
            Debug.Log("hit");
            h.Damage(damage);

            if (isSparks)
            {
                Instantiate(sparks, transform.position, Quaternion.identity);
            }

            if (collision.gameObject.TryGetComponent(out PlayerBehaviour p))
            {
                CameraShakeController.instance.CameraShake(impulseSource);
            }
        }
        Destroy(this.gameObject);
    }
}