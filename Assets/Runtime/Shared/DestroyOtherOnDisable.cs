using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOtherOnDisable : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> others;

    private void OnDisable()
    {
        foreach(GameObject target in others)
        {
            Destroy(target);
        }
    }
}
