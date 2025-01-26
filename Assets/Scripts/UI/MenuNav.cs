using System.Collections.Generic;
using UnityEngine;

public class MenuNav : ButtonBase
{
    [SerializeField] private List<GameObject> menuItemsToShow = new List<GameObject>();
    [SerializeField] private List<GameObject> menuItemsToHide = new List<GameObject>();

    public void ChangeView()
    {
        foreach (GameObject menuItem in menuItemsToShow)
        {
            menuItem.SetActive(true);
        }
        foreach (GameObject menuItem in menuItemsToHide)
        {
            menuItem.SetActive(false);
        }
    }
}
