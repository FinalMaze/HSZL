using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region 单例模式
    public static UIManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    #region 集合
    public Dictionary<string, GameObject> panelList = new Dictionary<string, GameObject>();
    public Dictionary<string, Dictionary<string, GameObject>> uiList = new Dictionary<string, Dictionary<string, GameObject>>();
    #endregion

    #region 注册UI
    public void RegistUI(string panelName,string uiName,GameObject uiObj)
    {
        if (!uiList.ContainsKey(panelName))
        {
            uiList[panelName] = new Dictionary<string, GameObject>();
        }
        uiList[panelName].Add(uiName, uiObj);
    }
    #endregion

    #region 注册Panel
    public void RegistPanel(string panelName,GameObject panelObj)
    {
        panelList.Add(panelName, panelObj);
    }
    #endregion

    #region 得到UI
    public GameObject GetUI(string panelName,string uiName)
    {
        return uiList[panelName][uiName];
    }
    #endregion

    #region 得到Panel
    public GameObject GetPanel(string panelName)
    {
        return panelList[panelName];
    }
    #endregion
}
