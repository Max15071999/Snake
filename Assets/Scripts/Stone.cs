using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stone : MonoBehaviour
{
    public UnityEvent OnEat;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Snake")
        {

            if (OnEat != null)
            {
                OnEat.Invoke();
            }
        }
        if (collision.gameObject.tag == "Coins")
        {
            Destroy(collision.gameObject);

        }
    }
}
