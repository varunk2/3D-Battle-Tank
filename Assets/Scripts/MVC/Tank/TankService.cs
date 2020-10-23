using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    public TankView tankView;
    //public GameObject tankView;

    // Start is called before the first frame update
    private void Start()
    {
        TankModel model = new TankModel(5, 100f);
        TankController tank = new TankController(model, tankView);
    }
}
