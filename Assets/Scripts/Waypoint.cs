using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Waypoint : MonoBehaviour
{
	public bool isExplored = false;
	public Waypoint exploreFrom;
	public bool isPlaceable = true;

	Vector2Int gridPos;
	const int gridSize = 10;
	
	public int GetGridSize()
	{
		return gridSize;
	}
	
	public Vector2Int GetGridPos()
	{
		return new Vector2Int(
	   Mathf.RoundToInt(transform.position.x / gridSize),
	   Mathf.RoundToInt(transform.position.z / gridSize)

		);
	}

    private void OnMouseOver()
    {
		var clicked = Input.GetMouseButtonDown(0);
		if(clicked) 
		{
			if(isPlaceable)
			{
				FindObjectOfType<TowerFactory>().AddTower(this);
            }
			else
			{
                print("Can not place");
            }
            
        }
		
    }
	


    /*
	public void SetTopColor(Color color)
	{
		MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
		topMeshRenderer.material.color = color;
	}
	*/
}
