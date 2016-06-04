using UnityEngine;
using System.Collections.Generic;

public abstract class AActor : SingletonMonoBehaviour<AActor>, IActor
{
    public int cost { get; set; }
    public int ally { get; set; }
    public List<UnitController> unitList { get; set; }

    protected GameManager gm;
    protected MenuManager mm;
    protected MapController mc;
    protected UnitManager um;
    
    protected void init()
    {
    }
    
    public void useCost(int value)
    {

    }
}
