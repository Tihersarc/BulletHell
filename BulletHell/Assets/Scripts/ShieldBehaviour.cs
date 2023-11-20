using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject shield;

    public GameObject ShieldInstance { get; private set; }
    public bool IsEnabled { get; set; }

    public void EnableShield()
    {
        IsEnabled = true;
        if (ShieldInstance == null)
        {
            ShieldInstance = Instantiate(shield, transform.position, Quaternion.identity, transform);
        }
    }

    public void DisableShield()
    {
        IsEnabled = false;

        StartCoroutine(ShieldAnimation());
    }

    IEnumerator ShieldAnimation()
    {
        ShieldInstance.GetComponent<Animator>().SetTrigger("Destroy");

        yield return new WaitForSeconds(0.7f);

        Object.Destroy(ShieldInstance);
    }
}
