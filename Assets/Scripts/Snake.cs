using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    public List<Transform> Tails;
    [Range(0, 3)]
    public float BonesDistance;
    public GameObject BonePreFab;
    [Range(0, 4)]
    public float speed;
    private Transform _transform;
    public GameObject Restart;

    public UnityEvent OnEat;
    public Text textScore;
    public static int Score=0;
    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        MoveSnake(_transform.position + _transform.forward * speed);

        float angel = Input.GetAxis("Horizontal") * 4;
        _transform.Rotate(0, angel, 0);

       

    }
    private void MoveSnake(Vector3 newPosition)
    {
        float sqrDistance = BonesDistance * BonesDistance;
        Vector3 previosPosition = _transform.position;

        foreach (var bone in Tails)
        {
            if ((bone.position - previosPosition).sqrMagnitude>sqrDistance )
            {
                var temp = bone.position;
                bone.position = previosPosition;
                previosPosition = temp;
            }
            else
            {
                break;
            }
        }
        _transform.position = newPosition;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Coins") 
        {
            Destroy(collision.gameObject);
            Score++;
            var bone = Instantiate(BonePreFab);
            Tails.Add(bone.transform);
            textScore.text = "Score: " + Score;
            if (OnEat!= null)
            {
                OnEat.Invoke();
            }
        }
        if (collision.gameObject.tag == "Stone")
        {
            Restart.SetActive(true);
            speed = 0;
            Time.timeScale = 0f;
        }
    }

}
