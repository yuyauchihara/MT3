using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
	GameObject target;

    void Start()
    {
        target = GameObject.Find("Player");
	}

    private void Update()
	{
		// 対象物と自分自身の座標からベクトルを算出
		Vector2 dir = target.transform.position - this.transform.position;

		this.transform.rotation = Quaternion.FromToRotation(Vector2.up, dir);
	}
}