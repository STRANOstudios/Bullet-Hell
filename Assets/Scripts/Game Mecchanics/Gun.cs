using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] List<GameObject> typeList = new();
    [SerializeField, Min(0)] int type;
    [SerializeField] Pattern pattern;

    [SerializeField, Min(0)] int fireRatio;


}
