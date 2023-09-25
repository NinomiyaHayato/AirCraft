using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectFactory : ScriptableObject
{
   public abstract GameObject CreateObject(Vector3 position);
}
