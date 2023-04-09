using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MFancesControl : MonoBehaviour
{
    public BuildingControl buildingControl;
    public GameObject MFances;
    public AudioSource sfxSource;
    public AudioClip spawnSFX;
    public AudioClip destroySFX;
    private bool M_Spawned = false;
    private GameObject spawnedMFances;

    // Update is called once per frame
    void Update()
    {
        if (buildingControl.Value == 1 && !M_Spawned)
        {
            StartCoroutine(PlaySpawnSFX());
            Vector3 spawnPosition = new Vector3(-2.51f, 1.4f, -84.09f);
            spawnedMFances = Instantiate(MFances, spawnPosition, transform.rotation);
            M_Spawned = true;
        }
        if (buildingControl.Value == 2 && M_Spawned)
        {
            StartCoroutine(PlayDestroySFX());
            Destroy(spawnedMFances);
            M_Spawned = false;
        }
    }

    private IEnumerator PlaySpawnSFX()
    {
        sfxSource.PlayOneShot(spawnSFX);
        yield return new WaitForSeconds(spawnSFX.length);
    }

    private IEnumerator PlayDestroySFX()
    {
        sfxSource.PlayOneShot(destroySFX);
        yield return new WaitForSeconds(destroySFX.length);
    }
}
