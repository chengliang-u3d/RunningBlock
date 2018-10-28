using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformManager : MonoBehaviour {

    public GameObject sectionA;
    public GameObject sectionB;
    public GameObject sectionC;

    private Queue<GameObject> sectionQueue = new Queue<GameObject>();

    //float screenWidthInUnit = 10;

    // Use this for initialization
    void Start () {
        //set section width equal to screen width
        
        float screenWidthInUnit = GameManager.Instance.screenWidthInUnit;
        sectionA.transform.localScale = new Vector3(screenWidthInUnit, 0.2f, 1);
        sectionB.transform.localScale = new Vector3(screenWidthInUnit, 0.2f, 1);
        sectionC.transform.localScale = new Vector3(screenWidthInUnit, 0.2f, 1);

        //set initial position of platform
        sectionB.transform.position += new Vector3(screenWidthInUnit, 0);
        sectionC.transform.position += new Vector3(screenWidthInUnit * 2, 0);

        sectionQueue.Enqueue(sectionA);
        sectionQueue.Enqueue(sectionB);
        sectionQueue.Enqueue(sectionC);

        //spawn obstacles
        GameManager.Instance.SpawnObstacle(0, screenWidthInUnit);
        GameManager.Instance.SpawnObstacle(screenWidthInUnit, screenWidthInUnit * 3);
        GameManager.Instance.SpawnObstacle(screenWidthInUnit * 2, screenWidthInUnit * 3);
    }
	
	// Update is called once per frame
	void Update () {
        float screenWidthInUnit = GameManager.Instance.screenWidthInUnit;
        float cameraX = Camera.main.transform.position.x;
        float curSectionEnd = sectionQueue.Peek().transform.position.x + screenWidthInUnit ;

        if(cameraX > curSectionEnd)
        {
            GameObject tailSection = sectionQueue.Last();

            GameObject lastSection = sectionQueue.Dequeue();
            lastSection.transform.position = tailSection.transform.position + new Vector3(screenWidthInUnit, 0);

            sectionQueue.Enqueue(lastSection);

            //spawn new blocks
            float newSectionStartX = lastSection.transform.position.x - screenWidthInUnit / 2;
            float newSectionEndX = lastSection.transform.position.x + screenWidthInUnit / 2;
            GameManager.Instance.SpawnObstacle(newSectionStartX , newSectionEndX);
        }
	}
}
