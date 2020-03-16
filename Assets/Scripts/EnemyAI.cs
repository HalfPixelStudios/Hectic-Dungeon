using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static GlobalContainer;

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
        Vector3 target = global.player.transform.position;
        Vector3 start = transform.position;
        Vector3[] dirs = {Vector3.left,  Vector3.down, Vector3.right, Vector3.up};
        List<Vector3> queue=new List<Vector3>();
        queue.Add(start);
        HashSet<Vector3> visited = new HashSet<Vector3>();
        visited.Add(start);
        Dictionary<Vector3, Vector3> cameFrom = new Dictionary<Vector3, Vector3>();
        
        while (queue.Count!=0)
        {
            var cur = queue[0];
            queue.RemoveAt(0);
            if (cur == target)
            {
                break;
            }
            
            foreach (var d in dirs)
            {
                var next = cur + d;
                if (checkValid(next.x,next.y) && !visited.Contains(next))
                {
                    
                    visited.Add(next);
                    cameFrom.Add(next,cur);
                    queue.Add(next);
                }
            }
        }

        foreach (var node in cameFrom)
        {
            print(node);
            
        }
        var trace = target;
        while (cameFrom[trace] !=start)
        {
            trace = cameFrom[target];
        }
        
        
        nextStep=trace-start;
        
    }

    bool checkValid(float x,float y)
    {
        int posX = -(int) (y - 1.5f);
        int posY = (int) (x - 1.5f);
        return (0 <= posX && posX < 13)&&(0 <= posY && posY < 14)&&global.tiles[posY][posX] == 1;

    }
}
