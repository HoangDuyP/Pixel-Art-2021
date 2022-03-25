﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CreateMapCoca : MonoBehaviour
{
    int dai = 45, rong = 29;
    public int maxPoint = 0;
    string AppleArraySave = String.Empty;
    string AppleArray2 = "999999999999999999999999999999999999999999999999999999999999999999889999999999999999999999999999999999999999998118999999999999999999999999999999999999999981111899999999999999999999999999999999999999981111899999999999999999999999999999999999999988888899999999999999999999999999999999999999988998899999999999999999999999999999999999999989999899999999999999999999999999999999999999899999989999999999999999999999999999999999999889999889999999999999999999999999999999999998668888688999999999999999999999999999999999998666666668999999999999999999999999999999999998666666668999999999999999999999999999999999998886666888999999999999999999999999999999999998188888818999999999999999999999999999999999998111111118999999999999999999999999999999999998111111118999999999999999999999999999999999998111111118999999999999999999999999999999999998111111118999999999999999999999999999999999998881111888999999999999999999999999999999999998188888868999999999999999999999999999999999998666666668999999999999999999999999999999999998666666668999999999999999999999999999999999998666666668999999999999999999999999999999999998666666668999999999999999999999999999999999998866666688999999999999999999999999999999999999886666889999999999999999999999999999999999999988888899999999999999999999999999999999999999999999999999999999999999999";
    public GameObject spawnObject;
    public List<GameObject> ToGiay = new List<GameObject>();
    Vector3 ToaDo;
    Vector3 ToaDo_con;
    public Button O_Vuong;    // 1 ô vuông tô màu
    public Canvas KhungTranh;    // Canvas chứa các ô vuông tô màu
    public List<GameObject> Texts = new List<GameObject>();
    public List<GameObject> Stars = new List<GameObject>();
    void Awake()
    {
        ToaDo = spawnObject.GetComponent<Transform>().position;
        //TestPlace();
    }
    private void TestPlace()
    {
    }
    private void Start()
    {
        if (SaveSystem.LoadPictureCoca() != null)
        {
            Debug.Log("load success");
            AppleArraySave = SaveSystem.LoadPictureCoca();
        }
        if (String.IsNullOrEmpty(AppleArraySave))
        {
            Debug.Log("Null or empty");
            Create_PaintMap();
        }
        else
        {
            Debug.Log("Not null or empty");
            Create_PaintMap_Saved(); 
        }
    }
    private void Create_PaintMap()
    {
        int countList = 0;
        int value = 0;
        for (int j = 0; j < rong; j++)
        {
            for (int i = 0; i < dai; i++)
            {
                Create_O_Vuong();
                value = (int)Char.GetNumericValue(AppleArray2, countList);
                ToGiay[countList].gameObject.SendMessage("Receive_ID", value);
                ToaDo.x++;
                countList++;
            }
            ToaDo.y--;
            ToaDo.x -= dai;
        }
        StaticBatchingUtility.Combine(O_Vuong.gameObject);
        Destroy(O_Vuong.gameObject);
        Destroy(spawnObject);
    }
    private void Create_PaintMap_Saved()
    {
        int countList = 0;
        int value = 0;
        int value_saved = 0;
        for (int j = 0; j < rong; j++)
        {
            for (int i = 0; i < dai; i++)
            {
                Create_O_Vuong();
                value = (int)Char.GetNumericValue(AppleArray2, countList);
                value_saved = (int)Char.GetNumericValue(AppleArraySave, countList);
                ToGiay[countList].gameObject.SendMessage("Receive_ID", value);
                ToGiay[countList].gameObject.SendMessage("Receive_Colour_Save", value_saved);
                ToaDo.x++;
                countList++;
            }
            ToaDo.y--;
            ToaDo.x -= dai;
        }
        StaticBatchingUtility.Combine(O_Vuong.gameObject);
        Destroy(O_Vuong.gameObject);
        Destroy(spawnObject);
    }
    private void Create_O_Vuong()
    {
        Button clone = Instantiate(O_Vuong, ToaDo, spawnObject.GetComponent<Transform>().rotation, KhungTranh.transform);
        ToaDo_con = clone.GetComponent<RectTransform>().localPosition;
        ToaDo_con.z = 0f;
        clone.GetComponent<RectTransform>().localPosition = ToaDo_con;
        ToGiay.Add(clone.gameObject);
    } 
    public void Reset_To_Giay()
    {
        for(int i = 0; i < ToGiay.Count; i++)
        {
            ToGiay[i].gameObject.SetActive(true);
            ToGiay[i].gameObject.SendMessage("ResetColour");
        }
        maxPoint = 0;
    }
    public void Print_Success()
    {
        int Point = Check_Success();
        int MaxPoint = maxPoint;
        if (Point > MaxPoint/3)
        {
            if (Point > (MaxPoint/3 * 2))
            {
                if (Point == MaxPoint)
                {
                    Texts[0].SetActive(true);
                    Stars[0].SetActive(true);
                    Stars[1].SetActive(true);
                    Stars[2].SetActive(true);
                }
                else
                {
                    Texts[1].SetActive(true);
                    Stars[0].SetActive(true);
                    Stars[1].SetActive(true);
                }
            }
            else
            {
                Texts[2].SetActive(true);
                Stars[0].SetActive(true);
            }
        }
        else
        {
            Texts[3].SetActive(true);
        }
    }
    public int Check_Success()
    {
        int ValueWhichColour = 0;
        int ValueIdColour = 0;
        int point = 0;
        for(int i = 0; i < AppleArray2.Length; i++)
        {
            ValueWhichColour = ToGiay[i].gameObject.GetComponent<ChangeColour>().whichColour_;
            ValueIdColour = ToGiay[i].gameObject.GetComponent<ChangeColour>().idColour_;
            if(ValueIdColour != 8 && ValueIdColour != 9)
            {
                if (ValueIdColour == ValueWhichColour)
                    point++;
                else
                    point--;
                maxPoint++;
            }
                
        }
        return point;
    }
    public void Save_Picture()
    {
       AppleArraySave = String.Empty;
       for(int i = 0; i < ToGiay.Count; i++)
       {
            AppleArraySave += ToGiay[i].gameObject.GetComponent<ChangeColour>().whichColour_;
       }
       SaveSystem.SavePictureCoca(AppleArraySave);
    }
    public void Disable_White()
    {
        for(int i = 0; i < ToGiay.Count;i++)
        {
            if (ToGiay[i].gameObject.GetComponent<ChangeColour>().whichColour_ == 9)
                ToGiay[i].gameObject.SetActive(false);
        }
    }
}

