using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class EditorSnap : MonoBehaviour
{
	Waypoint waypoint;

	private void Awake()
	{
		waypoint = GetComponent<Waypoint>();
	}

	void Update()
	{
		SnaptoGrid();
		UpdateGrid();
	}
	//snap grid pos
	private void SnaptoGrid()
	{
		int gridSize = waypoint.GetGridSize();
		transform.position = new Vector3(
			waypoint.GetGridPos().x * gridSize, 
			0f, 
			waypoint.GetGridPos().y * gridSize
			);
	}
	//for showing grid pos point
	private void UpdateGrid()
	{
		TextMesh textMesh = GetComponentInChildren<TextMesh>();
		string labelText = 
			waypoint.GetGridPos().x
			+ "," + 
			waypoint.GetGridPos().y;

		textMesh.text = labelText;
		gameObject.name = labelText;
	}
}
