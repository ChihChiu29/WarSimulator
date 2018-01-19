using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// Remember to keep prefabs under Assets/Resources/Prefabs/ folder.
namespace resource
{
  public class ObjectProvider
  {
    private static string PREFAB_FOLDER = "Prefabs/";

    public static GameObject CreateGameObject (
      // Name of the prefab.
      string prefabName,
      // Name of the object.
      string name,
      // How much should the sprite be rotated counter-clockwisely.
      Vector2 location = default(Vector2),
      float rotation = 0.0f)
    {
      GameObject obj = 
        MonoBehaviour.Instantiate (
          Resources.Load<GameObject> (GetFullPath (prefabName)), 
          location,
          Quaternion.identity);
      obj.name = name;
      obj.transform.Rotate (Vector3.forward * rotation);
      return obj;
    }

    private static string GetFullPath (string name)
    {
      return Path.Combine (PREFAB_FOLDER, name);
    }
  }
}