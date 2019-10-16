using UnityEngine;
using System.Collections;

public class SnowFlakesManager : MonoBehaviour
{
    public float speed;
    public int coefficient; 
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {        
        transform.position += speed * Vector3.down;
	}
    void OnMouseDown()
    {
        Destroy(gameObject);
        GM.instance.click += GM.instance.SummAllLvls() * coefficient + 100;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("DeadZone"))
        {
            Destroy(gameObject);
        }
    }
}
