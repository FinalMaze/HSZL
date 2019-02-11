using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMManager
{
    int count = 0;
    sbyte state = -1;
    private FSMBase[] allFSM;
    public FSMManager(int count)
    {
        allFSM = new FSMBase[count];
    }
    public void AddState(FSMBase tempBase)
    {
        if (count <= allFSM.Length)
        {
            allFSM[count] = tempBase;
            count++;
        }
        else
        {
            Debug.LogError("动画已达上限！！！");
        }
    }
    public void ChangeState(sbyte animatorName)
    {
        if (state != -1)
        {
            allFSM[state].OnExit();
        }
        state = animatorName;
        allFSM[state].OnEnter();
    }
}
public class FSMBase
{
    public virtual void OnEnter() { }
    public virtual void OnStay() { }
    public virtual void OnExit() { }
}
