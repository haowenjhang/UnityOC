using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class UnityOC : MonoBehaviour
{
    public InputField[] _inPut;

    [DllImport("__Internal")]
    // 傳給 iOS String參數，有 Return 值回來 
    private static extern string getString(string str);

    [DllImport("__Internal")]
    // 傳給 iOS String參數，用 UnitySendMessage 傳值回來
    private static extern void setDate(string date);

    [DllImport("__Internal")]
    // 傳給 iOS int參數，有 Return 值回來
    private static extern int setMyInt(int date);


    // 傳 String 給 iOS
    public void SetDate()
    {
#if UNITY_IPHONE && !UNITY_EDITOR
          Debug.Log("Unity_SetDate :" + _inPut[0].text);
#else
        Debug.Log("Unity_SetDate :" + _inPut[0].text);
#endif
    }

    // 傳 int 給 iOS
    public void SetMyInt()
    {
#if UNITY_IPHONE && !UNITY_EDITOR
          int result = setMyInt(int.Parse(_inPut[0].text));
          Debug.Log(" Unity_SetMyInt : " + result);
#else
        Debug.Log(" Unity_SetMyInt : " + int.Parse(_inPut[0].text));
#endif
    }


    // 收 iOS 傳回來的 String
    public void GetDate(string date)
    {
        _inPut[0].text = date;
        Debug.Log("Unity_GetDate : " + date);
    }


    public static string GetString(string str)
    {
#if UNITY_IPHONE && !UNITY_EDITOR
          string _str = getString(str);
          Debug.Log("Unity_GetString : " + _str);
          return _str;
#else
        return str;
#endif
    }

    public void Click1()
    {
        string s = getString(_inPut[0].text);
        Debug.Log("Unity _ Click1 :" + s);
    }

    public void Click2()
    {
        SetDate();
    }

    public void Click3()
    {
        SetMyInt();
    }
}
