using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehaviour : MonoBehaviour
{
    [SerializeField] private bool isMove;
    private MovementBehaviour mvb;

    private void Start()
    {
        mvb = GetComponent<MovementBehaviour>();

        if (isMove)
        {
            StartCoroutine(Move());
        }
    }

    private IEnumerator Move()
    {
        while (mvb != null)
        {
            mvb.MoveTransform();

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour p))
        {
            collision.GetComponent<ShieldBehaviour>().EnableShield();
            Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        
    }
}
