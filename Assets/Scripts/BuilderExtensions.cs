using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class BuilderExtensions
{
    public static GameObject SetName(this GameObject gameObject, string name)
    {
        gameObject.name = name;
        return gameObject;
    }

    public static GameObject AddRigidbody(this GameObject gameObject, float mass)
    {
        var component = gameObject.AddComponent<Rigidbody>();
        component.mass = mass;
        return gameObject;
    }

    public static GameObject AddBoxCollider(this GameObject gameObject)
    {
        gameObject.AddComponent<Rigidbody>();
        return gameObject;
    }
    public static GameObject AddMesh(this GameObject gameObject)
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        return gameObject;
    }
}

