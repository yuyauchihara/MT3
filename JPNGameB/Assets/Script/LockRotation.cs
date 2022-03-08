using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LockRotation : MonoBehaviour
{
	[SerializeField]
	[Tooltip("対象物(向く方向)")]
	private GameObject target;

	private void Update()
	{
		// 対象物と自分自身の座標からベクトルを算出
		Vector2 dir = target.transform.position - this.transform.position;

		this.transform.rotation = Quaternion.FromToRotation(Vector2.up, dir);
	}
}