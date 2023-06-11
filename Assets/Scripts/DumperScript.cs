using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumperScript : MonoBehaviour
{
    public List<GameObject> dumpers;
    public LightScript lightScript;
    public ScoreCounterScript scoreCounterScript;

    void Awake() {
        dumpers = new List<GameObject>();
        lightScript = FindObjectOfType<LightScript>();
        scoreCounterScript = FindObjectOfType<ScoreCounterScript>();
    }

    void Start() {
        dumpers.AddRange(GameObject.FindGameObjectsWithTag("Dumper"));
    }

    public void CheckDumper(GameObject dump) {
        int index = dumpers.IndexOf(dump);

        scoreCounterScript.DumperCount();
        //Mission
        ResponseDumper(dump);
        StartCoroutine(ResponseDumperR(dump));
    }

    private void ResponseDumper(GameObject dump) {
        dump.GetComponentInParent<Animator>().SetBool("ResponseDump", true);
        //lightScript.ShutDownLamp(dump.transform.parent.GetComponentInChildren<Light>());
    }
    private IEnumerator ResponseDumperR(GameObject dump) {
        yield return new WaitForSeconds(0.1f);
        dump.GetComponentInParent<Animator>().SetBool("ResponseDump", false);
    }
}