using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    public float respawnTime = 5.0f;

    private Renderer itemRenderer;
    private Collider itemCollider;

    void Start()
    {
        itemRenderer = GetComponent<Renderer>();
        itemCollider = GetComponent<Collider>();
    }

    public void HideAndRespawn()
    {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        itemRenderer.enabled = false;
        itemCollider.enabled = false;

        yield return new WaitForSeconds(respawnTime);

        itemRenderer.enabled = true;
        itemCollider.enabled = true;
    }
}
