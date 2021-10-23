using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
	public static HitManager Instance { get; private set; }
	public int IsHit = 0;

	public void Awake()
	{
		Instance = this;
	}

	

}
