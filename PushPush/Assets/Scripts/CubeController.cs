using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour 
{
	private float moveSpeed = 0f;
	private float gridSize = 0f;
	private Vector2 input;
	private bool isMoving = false;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private float t;
	private float factor;	
	void OnCollisionEnter(Collision other)
	{
		if(other.collider.tag != "Player")
		{
			return;
		}

		moveSpeed = other.gameObject.GetComponent<PlayerController>().moveSpeed;
		gridSize = other.gameObject.GetComponent<PlayerController>().gridSize;
		input = other.gameObject.GetComponent<PlayerController>().input;

		if (!isMoving) 
		{
			if (input != Vector2.zero) 
			{                     
				StartCoroutine(move(transform));                
			}
		}
	}	
	public IEnumerator move(Transform transform) 
	{        
        isMoving = true;
		startPosition = transform.position;
		t = 0;		
		endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
			                      startPosition.y + System.Math.Sign(input.y) * gridSize, 
		                          startPosition.z);		
		factor = 1f;        
		while (t < 1f) 
		{
			t += Time.deltaTime * (moveSpeed/gridSize) * factor;
			transform.position = Vector3.Lerp(startPosition, endPosition, t);
			yield return null;
		}

		isMoving = false;
		yield return 0;
	}
}

