using System;
using System.Collections.Generic;
using UnityEngine;
using XynokConvention.Data.Saver;
using XynokEntity.Core;

public interface IMove<T>
{
    T Data { get; }
}

[Serializable]
public class Hero : IMove<string>
{
    public string data;
    public string Data => data;
}

[Serializable]
public class Superman : Hero
{
}

[Serializable]
public class Batman : Hero
{
}
public class NewBehaviourScript : AMonoEntity
{

  protected override void Init()
  {
      throw new NotImplementedException();
  }

  protected override void OnDispose()
  {
      throw new NotImplementedException();
  }
}