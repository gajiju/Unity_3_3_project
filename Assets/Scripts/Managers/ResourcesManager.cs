using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if(prefab == null)
        {
            Debug.Log($"파일이 없습니다. : {path}");
            return null;
        }

        return Object.Instantiate(prefab, parent);

    }

    public void Destory(GameObject go, float _time = 0)
    {
        if (go == null) return;
        Object.Destroy(go, _time);
    }
}
