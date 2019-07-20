using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    private Vector3 target;
    public GameObject ShootPoint;
    public GameObject StarPrefab;

    public float StarSpeed = 60.0f;
    private float cooldown = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        Vector3 difference = target - ShootPoint.transform.position;
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        ShootPoint.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation_z);
        if (Input.GetMouseButtonDown(0) && cooldown <= 0f)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            FireStar(direction, rotation_z);
        }
        
    }

    void FireStar(Vector2 direction,float rotationZ)
    {
        GameObject s = Instantiate(StarPrefab) as GameObject;
        s.transform.position = ShootPoint.transform.position;
        s.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        s.GetComponent<Rigidbody2D>().velocity = direction * StarSpeed;
        cooldown = 0.5f;
    }
}
