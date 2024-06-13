using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{
	public float speed;
	public bool isMoving;

	Vector2 min;    // Bottom left border
	Vector2 max;    // top right border

	void Awake()
	{
		isMoving = false;
		min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		// max.y plus half of the sprite height 
		max.y = max.y + GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
		// min.y clips half of the sprite height
		min.y = min.y - GetComponent<SpriteRenderer>().sprite.bounds.extents.y;

	}
	// Update is called once per frame
	void Update()
	{
		if (!isMoving)
			return;
		// Get the current position and add the y-axis momentum to update the position
		Vector2 position = transform.position;
		position = new Vector2(position.x, position.y + speed * Time.deltaTime);
		transform.position = position;
		// run off the screen
		if (transform.position.y < min.y)
		{
			isMoving = false;
		}
	}

	public void ResetPosition()
	{
		// x is random
		transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
	}
}
