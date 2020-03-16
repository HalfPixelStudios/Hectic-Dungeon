using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Vector3 nextStep;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2[] dirs = {Vector2.left,  Vector2.down, Vector2.right, Vector2.up};
        List<Vector2> queue=new List<Vector2>();
        while (queue.Count!=0)
        {
            var cur = queue[0];
            queue.RemoveAt(0);
            foreach (var d in dirs)
            {
                break;

            }

        }
        nextStep=new Vector3(1,0,0);
        
        

    }

    void checkValid(float x,float y)
    {
        if (GlobalContainer.global.tiles[(int) (y-1.5f)][(int) (x-1.5f)]==0)
        {
            
            
        }
        
    }
}
