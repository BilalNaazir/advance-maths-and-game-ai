using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] tiles;
    public GameObject walls;
    public GameObject npc;
    public int columns;
    public int rows;
    public int maxBlue;
    public int maxRed;
    public int maxYellow ;
    public int maxGreen;
    public int howManyWhite;
    private int whiteTileCount;
    private int greenTileCount;
    private int redTileCount;
    private int blueTileCount;
    private int yellowTileCount;
    private int tileToGenerate = 0;
    private int resetHowManyWhite;
    // Start is called before the first frame update
    void Start()
    {
        resetHowManyWhite = howManyWhite;
        LoadMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadMap(){
        greenTileCount = 0;
        whiteTileCount = 0;
        redTileCount = 0;
        blueTileCount = 0;
        yellowTileCount = 0;
        for (int x = -52; x < rows-1; x++){
            
            GameObject wall1;
            GameObject wall2;
            GameObject wall3;
            GameObject wall4;
            wall1 = Instantiate(walls, new Vector3(x, 0, -53f), Quaternion.identity);
            wall2 = Instantiate(walls, new Vector3(x, 0, 48f), Quaternion.identity);
            wall3 = Instantiate(walls, new Vector3(48f, 0, x), Quaternion.identity);
            wall4 = Instantiate(walls, new Vector3(-53f, 0, x), Quaternion.identity);
            wall1.transform.parent = transform;
            wall2.transform.parent = transform;
            wall3.transform.parent = transform;
            wall4.transform.parent = transform;
        }



        for (int x = -50; x < rows; x+=5)
        {
            for (int y = -50; y < columns; y+=5)
            {
                if (x >= 0 && x < 3 && y >= 0 && y < 5){
                    tileToGenerate = 1;
                    CheckTile(tileToGenerate);
                    GameObject obj;
                    obj = Instantiate(tiles[tileToGenerate], new Vector3(x, -0.5f, y), Quaternion.identity);
                    obj.transform.parent = transform;
                }
                else if (x == rows - 5 && y == columns - 5)
                {
                    tileToGenerate = 0;
                    greenTileCount++;
                    GameObject obj;
                    obj = Instantiate(tiles[tileToGenerate], new Vector3(x, -0.5f, y), Quaternion.identity);
                    obj.transform.parent = transform;
                }
                else if (x >= rows - 3 && y >= columns - 3)
                {
                    tileToGenerate = 1;
                    CheckTile(tileToGenerate);
                    GameObject obj;
                    obj = Instantiate(tiles[tileToGenerate], new Vector3(x, -0.5f, y), Quaternion.identity);
                    obj.transform.parent = transform;
                }
                else
                {
                    Vector3 pos = new Vector3(x, 0, y);
                    tileToGenerate = Random.Range(0, 5);
                    CheckTile(tileToGenerate);
                    GameObject obj;
                    obj = Instantiate(tiles[tileToGenerate], new Vector3(x, -0.5f, y), Quaternion.identity);
                    obj.transform.parent = transform;
                    
                }
            }
        }
    }

    void CheckTile(int randomTile){
        switch (randomTile){

            case 0:
                if (greenTileCount >= maxGreen - 1)
                {
                    tileToGenerate = 1;
                    whiteTileCount++;
                    howManyWhite--;
                    break;
                }
                else
                {
                    if (howManyWhite <= 0)
                    {
                        greenTileCount++;
                        howManyWhite = resetHowManyWhite;
                        break;
                    }
                    else
                    {
                        tileToGenerate = 1;
                        whiteTileCount++;
                        howManyWhite--;
                        break;
                    }
                }

            case 1:
                whiteTileCount++;
                howManyWhite--;
                break;

            case 2:
                if (redTileCount >= maxRed){
                    tileToGenerate = 1;
                    whiteTileCount++;
                    howManyWhite--;
                     break;
                }
                else{
                    redTileCount++;
                    break;
                }

            case 3:
                if (blueTileCount >= maxBlue){
                    tileToGenerate = 1;
                    whiteTileCount++;
                    howManyWhite--;
                    break;
                }
                else{
                    blueTileCount++;
                    break;
                }

            case 4:
                if (yellowTileCount >= maxYellow){
                    tileToGenerate = 1;
                    whiteTileCount++;
                    howManyWhite--;
                    break;
                }
                else{
                    yellowTileCount++;
                    break;
                }

            default:
                whiteTileCount++;
                howManyWhite--;
                break;   
        }
    }
}
