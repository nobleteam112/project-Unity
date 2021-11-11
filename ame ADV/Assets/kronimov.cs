using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kronimov : MonoBehaviour
{
    public float speed, startwaittime;
    private float Waittime;
    public Transform[] moveSpots;
    private int randomspot;

    // Start is called before the first frame update
    void Start()
    {
        Waittime = startwaittime;
        randomspot = Random.Range(0, moveSpots.Length);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomspot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomspot].position) < 0.2f)
        {

            if (Waittime <= 0)
            {
                randomspot = Random.Range(0, moveSpots.Length);
                Waittime = startwaittime;
            }
            else Waittime -= Time.deltaTime;
        }
    }
}
