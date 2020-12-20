using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSeatSpawner : MonoBehaviour
{

    public List<Transform> Seats;
    //Odd is left, Even is Right unless the seat is captain spot?
    public List<bool> isOccupied;
    public List<Transform> CargoSpot;
    public Transform CaptainSeat;
    public BoatScript boatSC;
    // Start is called before the first frame update

    private void Awake()
    {
        boatSC = GetComponent<BoatScript>();
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void FillSeat(int PlayerNum, PlayerController player)
    //{
    //    player.transform.position = Seats[PlayerNum-1].position;
    //    player.SeatNumber = PlayerNum;
    //    player.Boat = boatSC;
    //    player.transform.SetParent(Seats[PlayerNum-1]);
    //    if(player.SeatNumber %2 == 0)
    //    {
    //        //even is on the right
    //        player.dir = 1;
    //    }
    //    else
    //    {
    //        player.dir = -1;
    //    }
    //    //update this to be more dynamic
    //}

    public int FindNextOpenSeat()
    {
        for (int i = 0; i < isOccupied.Count; i++)
        {
            if(isOccupied[i] == false)
            {
                return i;
            }
        }
        Debug.Log("Open Seat Not Found");
        return 10;

    }
}
