using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellManager : MonoSingletonGeneric<ShellManager>
{
    [SerializeField] private ShellController shellObject;
    //[SerializeField] private Vector3 defaultShellSpawn;

    protected override void Awake() {
        base.Awake();
    }

    public ShellController GetShell() {
        ShellController shell = Instantiate<ShellController>(shellObject, this.transform.position, Quaternion.identity);
        return shell;
    }
}
