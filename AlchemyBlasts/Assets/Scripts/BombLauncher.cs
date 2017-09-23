using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLauncher : MonoBehaviour {

    public float force;

    private Rigidbody2D rbd;

	// Use this for initialization
	void Start () {
        rbd = gameObject.GetComponent<Rigidbody2D>();
        float vert = 2f;
        float hor = 4f;
        Vector2 diagonal = new Vector2(hor, vert);
        rbd.AddForce(diagonal * force, ForceMode2D.Impulse);
    }
	
	// Update is called once per frame
	/*void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            float vert = 2f;
            float hor = 2f;
            Vector2 diagonal = new Vector2(hor,vert);
            rbd.AddForce(diagonal * force, ForceMode2D.Impulse);
        }
    }*/
}
