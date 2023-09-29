using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectFactory : ScriptableObject
{
    public abstract GameObject CreateNormalBullet(Vector3 position);
    public abstract GameObject CreateSpecialBullet(Vector3 position);
    public abstract GameObject CreateRicochetBullet(Vector3 position);
}
