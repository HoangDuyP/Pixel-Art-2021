using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayGoiY : MonoBehaviour
{
    public GameObject BongDen;
    public GameObject TraiTao;

    [System.Obsolete]
    void Update()
    {
        if(!BongDen.activeSelf)
        {
            StartCoroutine(WaitandDisable(5f));
        }
    }
    private IEnumerator WaitandDisable(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        TraiTao.SetActive(false);
        BongDen.SetActive(true);
    }
}
