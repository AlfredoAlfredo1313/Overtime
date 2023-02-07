using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Main : MonoBehaviour
{
    [SerializeField] List<Desk> Desks;
    [SerializeField] TextMeshPro text;

    GameObject minigObject;

    int score = 0;

    public static Desk currDesk;
    // Start is called before the first frame update
    void Start()
    {
        callDesks();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();
    }

    async void callDesks()
    {
        int selectIndex;
        Desk desk;
        while(true) {
            Debug.Log("Selecting new Desk");

            List<Desk> selectDesk = Desks.Where(n => !n.getActive()).ToList();
            selectIndex = (int)Random.Range(0f, 3f);
            desk = Desks[selectIndex];

            minigObject = sortMinigame();
            Minigame minigame = minigObject.GetComponent<Minigame>();
            Debug.Log("Desk " + selectIndex + " selected");
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            tokenSource.CancelAfter(10000);
            while(!minigame.getComplete()) {
                await Task.Yield();
                if(token.IsCancellationRequested)
                {
                    score = -100;
                }
            }      
            tokenSource.Dispose();
            desk.deactivate();
            Debug.Log("Task Complete");
            await Task.Delay(5000);
            Debug.Log("Selecting new Desk");
        }
    }

    public void OnMove(InputValue value)
    {
        //Debug.Log(value.Get<Vector2>());
        PlayerController.Instance.Move(value.Get<Vector2>());
    }

    public void OnInteract()
    {
        if(currDesk == null) return;
        if(!currDesk.getActive()) return;
        currDesk.setComplete();
        Debug.Log("Interagiu");
    }

    GameObject sortMinigame()
    {
        return null;
    }
}
