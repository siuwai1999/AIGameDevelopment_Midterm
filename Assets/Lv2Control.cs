using System.Collections;
using TMPro;
using UnityEngine;

public class Lv2Control : MonoBehaviour
{
    private PrintScore printScore;
    public BuildingControl buildingControl;
    public int Sorce;
    public GameObject gamearea;
    public GameObject square;
    public float showDuration = 3f;
    public float destroyDelay = 20f;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI SocreText;
    public GameObject pickup;
    private GameObject StartPickup;
    private bool triggered = false;
    private bool spwanpickup = false;

    private void Start()
    {
        timerText.text = "";
        SocreText.text = "";
        square.SetActive(false);
    }

    private void Update()
    {
        printScore = FindObjectOfType<PrintScore>();
        string text = printScore.Value;
        int intValue;
        int.TryParse(text, out intValue);
        Sorce = intValue;
        if (buildingControl.Value == 4 && !spwanpickup && Sorce == 0)
        {
        Vector3 spawnPosition1 = new Vector3(5.6f, 1f, 17.4f);
        StartPickup = Instantiate(pickup, spawnPosition1, transform.rotation);
        spwanpickup = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag("Player") && buildingControl.Value == 4 && Sorce == 0)
        {
            triggered = true;
            StartCoroutine(GeneratePrefab());
            StartCoroutine(StartTiimer());
            StartCoroutine(AreaTip());
        }
    }

    private IEnumerator AreaTip() 
    {
        yield return new WaitForSeconds(showDuration);
        square.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        square.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        square.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        square.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        square.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        square.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        square.SetActive(false);
    }
    private IEnumerator StartTiimer()
    {
        float timer = destroyDelay;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer < destroyDelay/2){timerText.text = "<color=red>剩餘 " + timer.ToString("F0") + " 秒</color>";}
            else{timerText.text = "<color=white>剩餘 " + timer.ToString("F0") + " 秒</color>";}
            if (Sorce * 2 < 60){SocreText.text = "<color=red>相似度" + (Sorce * 2).ToString() + " %</color>";}
            else{SocreText.text = "<color=green>相似度 " + (Sorce * 2).ToString() + " %</color>";}
            yield return null;
            timerText.text = "";
            SocreText.text = "";
        }
    }

    private IEnumerator GeneratePrefab()
    {
        square.SetActive(true);
        Vector3 spawnPosition = new Vector3(8.6f, -0.76f, -6.6f);
        GameObject Lv2Game = Instantiate(gamearea, spawnPosition, transform.rotation);
        yield return new WaitForSeconds(destroyDelay);
        Destroy(Lv2Game);
        yield return new WaitForSeconds(0.5f);
        if (Sorce * 2 < 60)
        {
            SocreText.text = "<color=red>通關失敗！</color>";
            timerText.text = "請前往旁邊的按鈕處申請重考！";
            Vector3 spawnPosition1 = new Vector3(5.6f, 1f, 17.4f);
            triggered = false;
            spwanpickup = false;
        }
        else
        {
            SocreText.text = "<color=green>成功通關！</color>";
            timerText.text = "請前往旁邊的按鈕處提交成績！";
        }
        yield return new WaitForSeconds(5f);
        timerText.text = "";
        SocreText.text = "";
    }
}