using System;
using System.Collections.Generic;

using UnityEngine;


public interface ITest{}
[Serializable]
public class Test : ITest
{
    
     public string name= "test";
}

[Serializable]
public class Test2 : ITest
{
    public string name= "test2";
}



public class NewBehaviourScript: MonoBehaviour
{
    [SerializeReference]public List<ITest> listData;
}