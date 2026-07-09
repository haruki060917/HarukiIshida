using UnityEngine;
using TMPro;
using System.Collections;

public class StartText : MonoBehaviour
{
    public TextMeshProUGUI startText;

    void Start()
    {
        StartCoroutine(ShowStart());
    }

    IEnumerator ShowStart()
    {
        startText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        startText.gameObject.SetActive(false);
    }
}