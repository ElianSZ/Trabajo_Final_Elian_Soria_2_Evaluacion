using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionLight : MonoBehaviour
{
    public GameObject explosionLight;

    // Start is called before the first frame update
    void Start()
    {
        explosionLight.SetActive(true);
        StartCoroutine(ExplosionLightWaiter());
    }

    IEnumerator ExplosionLightWaiter()
    {
        //Wait for 0.05 seconds
        yield return new WaitForSeconds(0.05f);
        explosionLight.SetActive(false);
    }
}
