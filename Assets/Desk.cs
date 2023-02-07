using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Desk : MonoBehaviour
{

    bool isActive = false;
    bool complete = false;

    Color color = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async Task<int> activateDesk()
    {
        int score = 500;
        isActive = true;
        complete = false;
        color = Color.blue;
        GetComponent<SpriteRenderer>().color = Color.blue;
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        CancellationToken token = tokenSource.Token;
        tokenSource.CancelAfter(10000);
        while(!complete) {
            await Task.Yield();
            if(token.IsCancellationRequested)
            {
                score = -100;
            }
        }
        tokenSource.Dispose();
        return score;
    }

    public void deactivate()
    {
        isActive = false;
        color = Color.white;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void setComplete()
    {
        complete = true;
    }

    public bool getActive()
    {
        return isActive;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Main.currDesk = this;
        GetComponent<SpriteRenderer>().color = Color.green;
    }

    private void OnTriggerExit2D(Collider2D other) {
        Main.currDesk = null;
        GetComponent<SpriteRenderer>().color = color;
    }
}
