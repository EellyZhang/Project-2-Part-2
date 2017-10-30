using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject cubePrefab;
	Vector3 cubePosition;
	public static GameObject selectedCube;
	int airplaneX, airplaneY;
	public GameObject[,] allCube;

	// Use this for initialization
	void Start () {

		allCube = new GameObject[16,9];

		//starting position for airplane
		airplaneX = 0;
		airplaneY = 8;

		for (int x = 0; x < 16; x++) {
			for (int y = 0; y < 9; y++) {
				cubePosition = new Vector3 (x*2, y*2, 0);
				allCube[x,y] = Instantiate(cubePrefab, cubePosition, Quaternion.identity);

				allCube[x,y].GetComponent<CubeBehavior>().x = x;
				allCube[x,y].GetComponent<CubeBehavior>().y = y;
				allCube[x,y].GetComponent<CubeBehavior>().isPlane = false;

				if (x == airplaneX && y == airplaneY) {
					allCube[x,y].GetComponent<Renderer>().material.color = Color.red;
					allCube[x,y].GetComponent<CubeBehavior>().isPlane = true;
				}
			}
		}
	}



	public static void PlaneActivation(GameObject planeCube) {
		planeCube.GetComponent<Renderer>().material.color = Color.green;
		selectedCube = planeCube;
		CubeBehavior.planeSelection = true;
	}

	public static void PlaneDeactivation(GameObject planeCube) { 
		planeCube.GetComponent<Renderer>().material.color = Color.red;
		CubeBehavior.planeSelection = false;
	}

	public static void Teleport(GameObject Cloud) { 
		selectedCube.GetComponent<Renderer>().material.color = Color.white;
		selectedCube.GetComponent<CubeBehavior>().isPlane = false;
		selectedCube = Cloud;
		selectedCube.GetComponent<Renderer>().material.color = Color.red;
		selectedCube.GetComponent<CubeBehavior>().isPlane = true;
		CubeBehavior.planeSelection = false;
		}


	// Update is called once per frame
	void Update () {
				
	}
}





	//public static void ProcessClick (GameObject clickCube) {

	//	if (selectedCube != null) {
	//		selectedCube.GetComponent<Renderer>().material.color = Color.white;
	//		}

	//	clickCube.GetComponent<Renderer>().material.color = Color.red;
	//	selectedCube = clickCube;
	//	}
