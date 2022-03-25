using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour
{
    public Button colorId;
    public Canvas boardId;
    public GameObject Text_colorId;
    public GameObject spawnObj;
    Transform spawnPos;
    void Start()
    {
        spawnPos = spawnObj.GetComponent<Transform>();
        
        Testing();
    }
    private void Testing()
    {
        Button clone = Instantiate(colorId, spawnPos.position, spawnPos.rotation, boardId.transform);
        clone.transform.position = Camera.main.WorldToScreenPoint(spawnPos.position);
        Text_colorId = clone.transform.GetChild(0).gameObject;
        Text_colorId.GetComponent<TMPro.TextMeshProUGUI>().text = "2";
        
    }
}
