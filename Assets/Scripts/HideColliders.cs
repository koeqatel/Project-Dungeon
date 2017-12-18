using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideColliders : MonoBehaviour {

    public GameObject Polymap;
    public GameObject PolymapFly;

    // Use this for initialization
    void Start () {
        Polymap.SetActive(false);
        PolymapFly.SetActive(false);
    }
}
