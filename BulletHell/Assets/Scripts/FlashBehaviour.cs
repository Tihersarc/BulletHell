using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashBehaviour : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float duration;

    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    private IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flashMaterial;

        yield return new WaitForSeconds(duration);

        spriteRenderer.material = originalMaterial;

        flashRoutine = null;
    }

    public void Flash()
    {
        if (gameObject.activeSelf) 
        {
            if (flashRoutine != null)
            {
                StopCoroutine(FlashRoutine());
            }

            flashRoutine = StartCoroutine(FlashRoutine());
        }
    }
        
}
