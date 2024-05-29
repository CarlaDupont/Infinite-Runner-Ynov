using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject,5f);
    }
}
