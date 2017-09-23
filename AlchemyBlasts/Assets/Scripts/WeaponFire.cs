using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour {

    public GameObject weaponPrefab;
    public Transform spawnPoint;

	// Use this for initialization
	void Start () {
        Invoke("Fire",1f);
	}

    public void Fire()
    {
        Instantiate(weaponPrefab, spawnPoint.position,spawnPoint.rotation);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
