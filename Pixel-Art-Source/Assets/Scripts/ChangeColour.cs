using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeColour : MonoBehaviour
{
    public int idColour_ = 0;
    public PickColor assigned_Colour;
    public Image Colour;
    GameObject Text_colorId;
    public int whichColour_ = 7;
    int[] Red = { 255, 255, 255, 0, 183, 150, 238 };
    int[] Green = { 79, 157, 255, 128, 233, 75, 130 };
    int[] Blue = { 75, 92, 0, 0, 247, 0, 238 };
    public float red;
    public float green;
    public float blue;
    public void Start()
    {
        Colour = GetComponent<Image>(); // Lỗi chỗ này
    }
    private void Receive_Colour()
    {
        if (Check_ID())
        {
            whichColour_ = assigned_Colour.chosenColor_;
            Set_Colour();
        }
        /*if (Check_ID())
        {
            Set_Colour();
        }*/
    }
    public bool Check_ID()  // True nếu idColour != 8
    {
        if (idColour_ == 8) // Màu đen, nếu là màu gốc là màu đen thì không reset
            return false;
        return true;
    }
    private void ResetColour()
    {
        if (Check_ID())
        {
            whichColour_ = 9;
            Set_Colour();
        }
    }
    private void Set_Colour()
    {
        float R = 0f, G = 0f, B = 0f;
        if (whichColour_ == 1) // Đỏ
        {
            R = Red[0] / 255.0f;
            G = Green[0] / 255.0f;
            B = Blue[0] / 255.0f;
        }
        else if (whichColour_ == 2) // Cam
        {
            R = Red[1] / 255.0f;
            G = Green[1] / 255.0f;
            B = Blue[1] / 255.0f;
        }
        else if (whichColour_ == 3) // Vàng
        {
            R = Red[2] / 255.0f;
            G = Green[2] / 255.0f;
            B = Blue[2] / 255.0f;
        }
        else if (whichColour_ == 4) // Xanh lục
        {
            R = Red[3] / 255.0f;
            G = Green[3] / 255.0f;
            B = Blue[3] / 255.0f;
        }
        else if (whichColour_ == 5) // Xanh lam
        {
            R = Red[4] / 255.0f;
            G = Green[4] / 255.0f;
            B = Blue[4] / 255.0f;
        }
        else if (whichColour_ == 6) // Tím  
        {
            R = Red[5] / 255.0f;
            G = Green[5] / 255.0f;
            B = Blue[5] / 255.0f;
        }
        else if (whichColour_ == 7) // Hồng
        {
            R = Red[6] / 255.0f;
            G = Green[6] / 255.0f;
            B = Blue[6] / 255.0f;
        }
        else if (whichColour_ == 8) // Đen
        {
            R = 0;
            G = 0;
            B = 0;
        }
        else if (whichColour_ == 9) // Trắng
        {
            R = red / 255.0f;
            G = green / 255.0f;
            B = blue / 255.0f;
        }  
        Colour.color = new Color(R, G, B);
    }
    private void Close_Text()
    {
        Text_colorId = transform.GetChild(0).gameObject;
        Text_colorId.GetComponent<TMPro.TextMeshProUGUI>().text = " ";
    }
    private void Receive_ID(int number)
    {
        idColour_ = number;
        if (idColour_ == 8)
        {
            whichColour_ = number;
            Set_Colour();
        }
    }
    private void Receive_Colour_Save(int number)
    {
        if (Check_ID())
        {
            whichColour_ = number;
            Set_Colour();
        }
    }
    public bool Check_WhichColor(int value)
    {
        if (whichColour_ != value)
            return false;
        return true;
    }
}
