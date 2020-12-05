using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{

	public float XSize = 12f;
	public float ZSize = 12f;
	public GameObject foodPrefab;
	public Vector3 curPos;
	public GameObject curFood;
	void AddNewFood()
	{
		RandomPos();
		curFood = GameObject.Instantiate(foodPrefab, curPos, Quaternion.identity) as GameObject;
		 
	}
	void RandomPos()
	{
		curPos = new Vector3(Random.Range(XSize * -1, XSize), 0.55f, Random.Range(ZSize * -1, ZSize));
		
	}

	void Update()
	{
		if (!curFood)
		{
			AddNewFood();
		}
		else
		{
			return;
		}
       
	}
}
