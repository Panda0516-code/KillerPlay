using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnrandomly : MonoBehaviour
{
    public GameObject mapfloor;//マップ内の床
    private Vector3 spawnpoint;//スポーン地点
    private void Start()
    {
        spawnpoint = mapfloor.transform.position;

    }



}
