using UnityEngine;

public class BombLauncher : MonoBehaviour {

    public float horizontal=4f;
    public float vertical=2f;
    public float explosionRadius=5f;
    public float bombMass = 0.25f;
    public LayerMask bombMask;
    public GameObject explosion;

    private Rigidbody2D rbd;
    private float force = 1.2f;

    // Use this for initialization
    void Start () {
        rbd = gameObject.GetComponent<Rigidbody2D>();
        Vector2 diagonal = new Vector2(horizontal, vertical);
        rbd.mass = bombMass;
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
                Scoring sc= coll.gameObject.GetComponent<Scoring>();
                sc.IncrementScore();
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
