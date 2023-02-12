using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Minigame : MonoBehaviour 
{
    public abstract Task<int> completeCondition(CancellationToken token);

    public abstract bool getComplete();
}
