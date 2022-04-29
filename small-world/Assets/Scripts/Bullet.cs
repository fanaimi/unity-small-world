using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float m_speed = 100f;
    [SerializeField] private float m_range = 1.5f;

    // Update is called once per frame
    void Update()
    {
        // moving bullets
        transform.Translate(0, 0, m_speed * Time.deltaTime);
      
        // collision detection with Raycast
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, m_range))
        {
            //Debug.DrawLine(transform.position, transform.position + new Vector3(100, 100, 100), Color.green, 5f);
            

            if (hit.transform.gameObject.layer == 8) // 8: planets
            {
                // we hit a planet, destroying planet and bullet
                Destroy(gameObject);
                Destroy(hit.collider.gameObject);

                // =============== ADD ANY REACTION TO PLANET HITTING ===================



                // add KINOGLITCH to environment

                // showing confetti particle system animation

            }
        }


    }
}
