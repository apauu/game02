using UnityEngine;
using System.Collections.Generic;

public abstract class AActor : IActor
{
    public int cost { get; set; }
    public int ally { get; set; }
    public List<Unit> unitList { get; set; }

    protected GameManager gm;
    protected MenuManager mm;
    protected MapController mc;
    protected UnitManager um;

    public void Init()
    {
        gm = GameManager.Instance;
        mm = MenuManager.Instance;
        mc = MapController.Instance;
        um = UnitManager.Instance;
    }
    
    public void UseCost(int value)
    {

    }
}
