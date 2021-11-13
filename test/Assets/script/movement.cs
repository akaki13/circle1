using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class movement : MonoBehaviour
{
   
    public GameObject efect; 
    public float speed = 1.5f;
    private Vector3 target;
    private Vector3 player;
    public List<Vector3> playerp = new List<Vector3>();
    void Start()
    {
        target = transform.position;
        player = transform.position;
 
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
           target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           target.z = transform.position.z;
           playerp.Add(target  );
        }
        

        if (playerp.Count!=0  &&  transform.position == player)
        {
            player = playerp[0];
            playerp.RemoveAt(0);
            
        }
        transform.position = Vector3.MoveTowards(transform.position, player, speed * Time.deltaTime);

        if (player != transform.position)
        {
            efect.SetActive(true);
        }
        else if (player == transform.position && playerp.Count == 0)
            {
                efect.SetActive(false);
            }
      
    }
    public void speedchange(float newspeed)
    {
        speed = newspeed;
    }
}
