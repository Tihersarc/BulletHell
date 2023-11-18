using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour p))
        {
            collision.GetComponent<ShieldBehaviour>().EnableShield();
            Destroy(this.gameObject);
        }
    }
}
