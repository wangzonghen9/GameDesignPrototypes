using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour {

	private int horiz;
	private int vert;

	private bool[,] hWalls;
	private bool[,] vWalls;

	public GameObject[] hhw = new GameObject[12];
	public GameObject[] vvw = new GameObject[12];

	public GameObject[,] hw = new GameObject[4,3];
	public GameObject[,] vw = new GameObject[3,4];


	public Maze(int horizontalSize, int verticalSize) {
		int i, j;


		horiz = horizontalSize;
		vert = verticalSize;
		if ((horiz < 1) || (vert < 1) || ((horiz == 1) && (vert == 1))) {
			return;                                    // There are no interior walls
		}
		// Create all of the horizontal interior walls.  Initially, every
		// horizontal wall exists; they will be removed later by the maze
		// generation algorithm.
		if (vert > 1) {
			hWalls = new bool[horiz,vert - 1];
			for (j = 0; j < vert - 1; j++) {
				for (i = 0; i < horiz; i++) {
					hWalls[i,j] = true;
				}
			}
		}
		// Create all of the vertical interior walls.
		if (horiz > 1) {
			vWalls = new bool[horiz - 1,vert];
			for (i = 0; i < horiz - 1; i++) {
				for (j = 0; j < vert; j++) {
					vWalls[i,j] = true;
				}
			}
		}
		int walls=(vWalls.Length*(horizontalSize))+(hWalls.Length*(verticalSize-1));
		int[,] array=new int[walls,3];
		int k=0;
		if (vert > 1) {
			for (j = 0; j < vert - 1; j++) {
				for (i = 0; i < horiz; i++) {
					array[k,0]=i;
					array[k,1]=j;
					array[k,2]=0; //0 is horizontal
					k++;
				}
			}
		}
		if (horiz > 1) {
			for (i = 0; i < horiz - 1; i++) {
				for (j = 0; j < vert; j++) {
					array[k,0]=i;
					array[k,1]=j;
					array[k,2]=1; //1 is vertical
					k++;
				}
			}
		}

		for (int a=walls; a>0; a--) {
			int randInt=Random.Range (0, a);

			int[] holder=new int[3];

			holder[0]=array[randInt,0];
			holder[1]=array[randInt,1];
			holder[2]=array[randInt,2];

			array[randInt,0]=array[a-1,0];
			array[randInt,1]=array[a-1,1];
			array[randInt,2]=array[a-1,2];

			array[a-1,0]=holder[0];
			array[a-1,1]=holder[1];
			array[a-1,2]=holder[2];
		}

		DisjointSets set=new DisjointSets(horiz*vert);
		for (int a=0; a<walls; a++) {
			int x=array[a,0];
			int y=array[a,1];
			if (array[a,2]==1) {         //0 is horizontal
				int l_map=x+(y*horiz);
				int r_map=l_map+1;
				int left=set.find(l_map);
				int right=set.find(r_map);
				if (left!=right) {
					set.union(left,right);
					vWalls[x,y]=false;
				}
			} else if (array[a,2]==0) {    //1 is vertical
				int t_map=x+(y*horiz);
				int top=set.find(t_map);
				int b_map=t_map+horiz;
				int bot=set.find(b_map);
				if (top!=bot) {
					set.union(top,bot);
					hWalls[x,y]=false;
				}
			}
		}
	}


	bool horizontalWall(int x, int y) {
		if ((x < 0) || (y < 0) || (x > horiz - 1) || (y > vert - 2)) {
			return true;
		}
		return hWalls[x,y];
	}

	bool verticalWall(int x, int y) {
		if ((x < 0) || (y < 0) || (x > horiz - 2) || (y > vert - 1)) {
			return true;
		}
		return vWalls[x,y];
	}



	void Start(){
		Maze m = new Maze (7, 5);
		for (int j = 0; j < 4; j++) {
			for (int i = 0; i < 7; i++) {
				if (m.hWalls[i, j] == false) {
					hhw [j * 7 + i].tag = "Door";
				}
			}
		}

		for (int i = 0; i < 6; i++) {
			for (int j = 0; j < 5; j++) {
				if (m.vWalls[i, j] == false) {
					vvw [j * 6 + i].tag = "Door";
				}
			}
		}

	}
}



