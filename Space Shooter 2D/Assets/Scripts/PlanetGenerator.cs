using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetGenerator : MonoBehaviour
{
	public GameObject[] planets;
	Queue<GameObject> avaliablePlanets = new Queue<GameObject>();
	// Use this for initialization
	void Start()
	{
        // put into queue
        avaliablePlanets.Enqueue(planets[0]);
		avaliablePlanets.Enqueue(planets[1]);
		avaliablePlanets.Enqueue(planets[2]);
        avaliablePlanets.Enqueue(planets[3]);
		// every 20 sec
		InvokeRepeating("MovePlanet", 0, 10f);
	}

	// Take planets from queue and let them start flowing down
	void MovePlanet()
	{
		EnqueuePlanets();
		// There is nothin gin the queue
		if (avaliablePlanets.Count == 0)
			return;

		// get planets
		GameObject aplanet = avaliablePlanets.Dequeue();
		aplanet.GetComponent<Planet>().isMoving = true;
	}

	// planets on off the screen and does not run
	void EnqueuePlanets()
	{
		//int i = 0;
		foreach (GameObject a_planet in planets)
		{
			if ((a_planet.transform.position.y < 0) && !(a_planet.GetComponent<Planet>().isMoving))
			{
				a_planet.GetComponent<Planet>().ResetPosition();
				avaliablePlanets.Enqueue(a_planet);
			}
		}
	}
}
