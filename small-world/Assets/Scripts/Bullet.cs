using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float m_speed = 100f;

    private Vector3 m_prevPos;

    private void Start()
    {
        m_prevPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        m_prevPos = transform.position;
        transform.Translate(0, 0, m_speed * Time.deltaTime);
        RaycastHit[] hits = Physics.RaycastAll(
            new Ray(
                m_prevPos, 
                (transform.position - m_prevPos).normalized),
                (transform.position - m_prevPos).magnitude
        );

        foreach (var hit in hits)
        {
            if (hit.collider.gameObject.layer == 8)
            {
                Destroy(gameObject);
                Destroy(hit.collider.gameObject);
            }
        }

    }
}
