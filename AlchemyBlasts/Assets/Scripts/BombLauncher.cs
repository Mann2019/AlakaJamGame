using UnityEngine;
using System.Collections;

public class BombLauncher : MonoBehaviour {

    public float force;
    public float horizontal;
    public float explosionRadius=5f;
    public LayerMask bombMask;
    public GameObject explosion;

    private Rigidbody2D rbd;

	// Use this for initialization
	void Start () {
        rbd = gameObject.GetComponent<Rigidbody2D>();
        float vert = 2f;
        Vector2 diagonal = new Vector2(horizontal, vert);
        rbd.AddForce(diagonal * force, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, explosionRadius, bombMask);

        for(int i=0;i<colls.Length;i++)
        {
            Collider2D coll = colls[i];
            if (coll.CompareTag("Destroyable"))
            {
                Instantiate(explosion, coll.transform.position, coll.transform.rotation);
                Destroy(coll.gameObject);
            }
        }

        if(collision.collider.CompareTag("Ground"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
