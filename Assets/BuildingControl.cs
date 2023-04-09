using System.Collections;
using UnityEngine;

public class BuildingControl : MonoBehaviour
{
    private PrintProgress printProgress;
    public Camera FullView;
    public Camera ArtCam;
    public int Value;
    public int ArtSelect;
    public GameObject M;
    public GameObject M_Level;
    public GameObject M_Tower;
    public GameObject A;
    public GameObject A_Level;
    public GameObject A_Tower;
    private GameObject A_LevelArea;
    public GameObject I;
    public GameObject I_Level;
    public GameObject I_Tower;
    public GameObject G;
    public GameObject D3;
    public GameObject G_LevelArea;
    public GameObject G_Level;
    public GameObject G_Tower;
    public GameObject Museum;
    public GameObject Museum_Level;
    public GameObject Museum_Tower;
    public GameObject TheThinker;
    public GameObject TheThinkerVR;
    public GameObject TheThinkerNFT;
    public AudioSource sfxSource;
    public AudioClip spawnSFX;
    public AudioClip destroySFX;
    private bool M_Spawned = false;
    private bool A_Spawned = false;
    private bool I_Spawned = false;
    private bool G_Spawned = false;
    private bool Museum_Spawned =false;

    private void Start()
    {
        FullView.enabled = false;
        ArtCam.enabled = false;
        I_Level.SetActive(false);
        G_LevelArea.SetActive(false);
        Museum_Level.SetActive(false);
    }

    void Update()
    {
        printProgress = FindObjectOfType<PrintProgress>();
        string text = printProgress.Value;
        int intValue;
        int.TryParse(text, out intValue);
        Value = intValue;
 
        if (Value == 3 && !M_Spawned)
        {
            StartCoroutine(SwitchFullViews(9.5f));
            StartCoroutine(Generate_Building_M());
            M_Spawned = true;
        }

        if (Value == 6 && !A_Spawned)
        {
            StartCoroutine(SwitchFullViews(9.5f));
            StartCoroutine(Generate_Building_A());
            A_Spawned = true;

        }
        if (Value == 9 && !I_Spawned)
        {
            StartCoroutine(SwitchFullViews(11f));
            StartCoroutine(Generate_Building_I());
            I_Spawned = true;
        }
        if (Value == 11 && !G_Spawned)
        {
            StartCoroutine(SwitchFullViews(12.5f));
            StartCoroutine(Generate_Building_G());
            G_Spawned = true;
        }
        if (Value == 12 ^ Value == 13 ^ Value == 14)
        {
            ArtSelect = Value;
        }
        if (Value == 15 && !Museum_Spawned)
        {
            if (ArtSelect == 12) { StartCoroutine(Generate_Building_Museum(TheThinker)); }
            if (ArtSelect == 13) { StartCoroutine(Generate_Building_Museum(TheThinkerVR)); }
            if (ArtSelect == 14) { StartCoroutine(Generate_Building_Museum(TheThinkerNFT)); }
            Museum_Spawned = true;
        }
    }
    private IEnumerator SwitchFullViews(float Seconds)
    {
        FullView.enabled = true;
        yield return new WaitForSeconds(Seconds);
        FullView.enabled = false;
    }

    private IEnumerator Generate_Building_M()
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlayDestroySFX());
        Destroy(M_Level);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlaySpawnSFX());
        Vector3 spawnPosition = new Vector3(-2.1f, -25.2f, -44.3f);
        GameObject Building_M = Instantiate(M, spawnPosition, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlayDestroySFX());
        Destroy(M_Tower);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlaySpawnSFX());
        Vector3 spawnPosition1 = new Vector3(13.8f, -2.7f, 4.2f);
        A_LevelArea = Instantiate(A_Level, spawnPosition1, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlaySpawnSFX());
        A_Tower.SetActive(true);
    }
    private IEnumerator Generate_Building_A()
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlayDestroySFX());
        Destroy(A_LevelArea);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlaySpawnSFX());
        Vector3 spawnPosition = new Vector3(16f, 0f, 0.48f);
        GameObject Building_A = Instantiate(A, spawnPosition, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlayDestroySFX());
        Destroy(A_Tower);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlaySpawnSFX());
        I_Level.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlaySpawnSFX());
        I_Tower.SetActive(true);
    }

    private IEnumerator Generate_Building_I()
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlayDestroySFX());
        Destroy(I_Level);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlaySpawnSFX());
        I.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlayDestroySFX());
        Destroy(I_Tower);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlaySpawnSFX());
        G_LevelArea.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlaySpawnSFX());
        G_Level.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlaySpawnSFX());
        G_Tower.SetActive(true);
    }
    private IEnumerator Generate_Building_G()
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlayDestroySFX());
        Destroy(G_LevelArea);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlayDestroySFX());
        Destroy(G_Level);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlaySpawnSFX());
        G.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlaySpawnSFX());
        D3.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlayDestroySFX());
        Destroy(G_Tower);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlaySpawnSFX());
        Museum_Level.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlaySpawnSFX());
        Museum_Tower.SetActive(true);
    }
    private IEnumerator Generate_Building_Museum(GameObject Name)
    {
        FullView.enabled = true;
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlayDestroySFX());
        Museum_Level.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlaySpawnSFX());
        Museum.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlayDestroySFX());
        Museum_Tower.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        FullView.enabled = false;
        ArtCam.enabled = true;
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(PlaySpawnSFX());
        Name.SetActive(true);
        yield return new WaitForSeconds(2f);
        ArtCam.enabled = false;
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
