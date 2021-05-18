using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    public bool showTraject = true;
    public GameObject[] trajectpoints;
    private int noOfTrajectory;
    private Vector3 d = new Vector3 (0.0f, 0.0f, -11f);
    public GameObject traject;
   

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
        
    }

    private void Trajectory()
    {
        if (selectedWeapon != 0 && showTraject==true)
         {
            trajectpoints = GameObject.FindGameObjectsWithTag("TrajectoryPath");
            foreach (GameObject target in trajectpoints)
            {
                target.SetActive(false);
            }
            showTraject = false;
        }
        if (selectedWeapon == 0 && showTraject == false)
        {
            foreach (GameObject target in trajectpoints)
            {
                target.SetActive(true);
            }
            showTraject = true;
        }



    }
    // Update is called once per frame
    void Update()
    {

        int previousSelectedWeapon = selectedWeapon;



        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;

        }
        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
        Trajectory();
       
     

    }
    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;

        }


    }
}
