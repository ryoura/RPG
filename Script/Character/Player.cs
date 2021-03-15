using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
	[SerializeField]
	int MaxHp = 100;

	public Camera SudCamera;
	public Transform SudCameraTrans;

	public static Vector3 GetMoveAxis()
	{
		Vector3 axis = Vector3.zero;
		axis.x = Input.GetAxis("Horizontal");
		axis.z = Input.GetAxis("Vertical");
		return axis;
	}


	// Update is called once per frame
	void Update()
	{

		SudCamera = GetComponentInChildren<Camera>();
		SudCameraTrans = SudCamera.transform;
		Vector3 moveAxis = GetMoveAxis();
		//Debug.Log(moveAxis);
		// カメラの方向から、X-Z平面の単位ベクトルを取得
		Vector3 cameraForward = Vector3.Scale(SudCameraTrans.forward, new Vector3(1, 0, 1)).normalized;

		// 方向キーの入力値とカメラの向きから、移動方向を決定
		Vector3 moveForward = cameraForward * moveAxis.z + SudCameraTrans.right * moveAxis.x;

		// 移動量が入っていたら、移動させる
		if (moveForward.sqrMagnitude > 0.0f)
		{

			Move(moveForward.normalized);
		}
	}
}
