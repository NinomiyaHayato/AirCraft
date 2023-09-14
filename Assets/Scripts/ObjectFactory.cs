using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ObjectFactory
{
    GameObject CreateObject(Vector3 position);
}
