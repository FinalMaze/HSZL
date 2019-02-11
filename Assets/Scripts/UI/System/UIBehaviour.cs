using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    private void Awake()
    {
        UIBase tempBase = GetComponentInParent<UIBase>();
        UIManager.Instance.RegistUI(tempBase.name, transform.name, gameObject);
    }

    #region  给UI添加Button点击事件
    public void AddButtonListen(UnityAction action)
    {
        Button tmpBtn = transform.GetComponent<Button>();
        if (tmpBtn == null)
        {
            tmpBtn = gameObject.AddComponent<Button>();
        }
        tmpBtn.onClick.AddListener(action);
    }
    #endregion

    #region 添加拖拽事件
    public void AddDrag(UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();
        }
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Drag;
        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);
        trigger.triggers.Add(entry);
    }
    #endregion

    #region 添加拖拽开始事件
    public void AddOnBeginDrag(UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();
        }
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.BeginDrag;
        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);
        trigger.triggers.Add(entry);
    }
    #endregion

    #region 添加结束拖拽事件
    public void AddOnEndDrag(UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();
        }
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.EndDrag;
        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);
        trigger.triggers.Add(entry);
    }
    #endregion

    #region 添加点击事件
    public void AddPointClick(UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();
        }
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);
        trigger.triggers.Add(entry);
    }
    #endregion

    #region 添加点击按下事件
    public void AddPointClickDown(UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();
        }
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);
        trigger.triggers.Add(entry);
    }
    #endregion

    #region 添加点击抬起事件
    public void AddPointClickUP(UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();
        }
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);
        trigger.triggers.Add(entry);
    }
    #endregion
}
