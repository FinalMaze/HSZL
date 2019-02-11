using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    #region 初始化
    private void Awake()
    {
        Initial();
        UIManager.Instance.RegistPanel(transform.name, gameObject);
    }
    #region 给指定子物体挂上脚本
    Transform[] allChild;
    void Initial()
    {
        allChild = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChild)
        {
            if (child.name.EndsWith("_UI"))
            {
                child.gameObject.AddComponent<UIBehaviour>();
            }
        }
    }
    #endregion
    #endregion

    #region 得到UI
    public GameObject GetUI(string uiName)
    {
        return UIManager.Instance.GetUI(transform.name, uiName);
    }
    #endregion
}
