using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

	Transform SelfTransform;
	public float moveSpeed = 3.0f;
	NavMeshAgent SelfNavmeshAgent;
	public Camera SudCamera;
	public Transform SudCameraTrans;


	void Move(Vector3 axis)
	{
		SelfNavmeshAgent.Move(axis * moveSpeed * Time.deltaTime);
	}

	public static Vector3 GetMoveAxis()
	{
		Vector3 axis = Vector3.zero;
		axis.x = Input.GetAxis("Horizontal");
		axis.z = Input.GetAxis("Vertical");
		return axis;
	}

	void Update()
	{
		SelfTransform = transform;
		SudCamera = GetComponentInChildren<Camera>();
		SudCameraTrans = SudCamera.transform;
		SelfNavmeshAgent = GetComponent<NavMeshAgent>();
		Vector3 moveAxis = GetMoveAxis();

		// カメラの方向から、X-Z平面の単位ベクトルを取得
		Vector3 cameraForward = Vector3.Scale(SudCameraTrans.forward, new Vector3(1, 0, 1)).normalized;

		// 方向キーの入力値とカメラの向きから、移動方向を決定
		Vector3 moveForward = cameraForward * moveAxis.z + SudCameraTrans.right * moveAxis.x;

		// 移動量が入っていたら、移動させる
		if (moveForward.sqrMagnitude > 0.0f)
		{
			Move(moveForward.normalized);
			SelfTransform.localRotation = Quaternion.LookRotation(moveForward.normalized);
		}
	}
}
