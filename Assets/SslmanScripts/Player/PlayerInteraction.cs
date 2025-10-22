using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEditor;
using System;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{

 [Header("UI Elements")]
    public GameObject loadingBoxUI; 
    public Image loadingProgressBar;

    [Header("Bools")]
    private bool IsPlayerHoldTheMug = false;
    private  bool isPlayerHoldFixItem = false;
    private bool IsCoffeMakerOn = false;
    private bool IsCoffeFill = false;
    private bool isInteracting = false;
    private float interactionTime = 2f; 
    private float interactionTimer = 0f;
    public GameObject fixItem;
    private bool isCoffeNeedFixing = true;
    private bool TheMugOfThePlayerIsFill = false;




    [SerializeField] private Animator coffee;
    [SerializeField] private Animator Bottun;
    [SerializeField] private Animator CoffeStateAni;




    [Header("References")]
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private CanvasGroup promptCanvas;
    [SerializeField] private TMP_Text promptText;

    [Header("Settings")]
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private bool showDebugRay = false;
    [SerializeField] private float fadeDuration = 0.2f;
    [SerializeField] private float scalePop = 1.1f;
    [SerializeField] private MugMNG mugMNG;
    private WorkerTable workerTable;
    private dialogueSys dialogueSyss;
    private String RecentTag;
    private IInteractable currentTarget;
    private bool promptVisible;

    private void Awake()
    {
        if (promptCanvas)
        {
            promptCanvas.alpha = 0f;
            promptCanvas.transform.localScale = Vector3.one;
        }
    }

    private void Update()
    {


if (isInteracting)
        {
            interactionTimer += Time.deltaTime;
            loadingProgressBar.fillAmount = interactionTimer / interactionTime;
            if (interactionTimer >= interactionTime)
            {
                CompleteInteraction();
            }
        }



        Vector3 origin = cameraTransform.position;
        Vector3 dir = cameraTransform.forward;

        if (Physics.Raycast(origin, dir, out RaycastHit hit, interactDistance, interactableLayer))
        {
            RecentTag = hit.collider.tag;
            if (RecentTag == "WorkerTable")
            {

                if (hit.collider.gameObject.GetComponent<WorkerTable>() != null)
                {

                    workerTable = hit.collider.gameObject.GetComponent<WorkerTable>();
                }

            }
            else workerTable = null;
             if (RecentTag == "Worker")
            {

                if (hit.collider.gameObject.GetComponent<dialogueSys>() != null)
                {

                    dialogueSyss = hit.collider.gameObject.GetComponent<dialogueSys>();
                }
            }


            if (hit.collider.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                currentTarget = interactable;
                ShowPrompt(interactable.GetPrompt());
            }
            else HidePrompt();
        }

        else
        {


            RecentTag = "";
 workerTable = null;
dialogueSyss = null;
            HidePrompt();
        }
        if (showDebugRay)
            Debug.DrawRay(origin, dir * interactDistance, currentTarget != null ? Color.green : Color.red);
    }

    private void ShowPrompt(string text)
    {
        if (!promptCanvas) return;

        promptText.text = text;

        if (!promptVisible)
        {
            promptVisible = true;

            LeanTween.cancel(promptCanvas.gameObject);
            promptCanvas.transform.localScale = Vector3.one * 0.8f;

            LeanTween.scale(promptCanvas.gameObject, Vector3.one * scalePop, fadeDuration).setEaseOutBack();
            LeanTween.alphaCanvas(promptCanvas, 1f, fadeDuration);
        }
    }

    private void HidePrompt()
    {
        if (!promptCanvas || !promptVisible) return;

        promptVisible = false;

        LeanTween.cancel(promptCanvas.gameObject);
        LeanTween.scale(promptCanvas.gameObject, Vector3.one * 0.8f, fadeDuration).setEaseInBack();
        LeanTween.alphaCanvas(promptCanvas, 0f, fadeDuration);
    }

    public void OnInteract(InputAction.CallbackContext ctx)
    {


        if (RecentTag == null) return;
        if (RecentTag == "FixItem" && IsPlayerHoldTheMug == false)
        {
            if (ctx.started)
            {
                fixItem.SetActive(true);
                isPlayerHoldFixItem = true;
                Debug.Log("Picked up fix item");
            }
        }
        if (RecentTag == "CoffeeMaker" && isPlayerHoldFixItem == true && isCoffeNeedFixing == true)
        {
            if (ctx.started)
            {
                StartInteraction();
            }
        }




        if (RecentTag == "coffeeTable" && IsPlayerHoldTheMug == false)
        {
            if (ctx.started && mugMNG.isThereAvailableCubs == true)
            {
                Debug.Log("eee");

                mugMNG.checkIfThereAnyEmptyCup();
                IsPlayerHoldTheMug = true;


                mugMNG.activeMugOfPlayer(1);

            }

        }
        else if (RecentTag == "CoffeeMaker" && IsCoffeMakerOn == false && IsPlayerHoldTheMug == true && TheMugOfThePlayerIsFill == false)
        {
            if (ctx.started)
            {

                mugMNG.activeMugOfCoffeeMaker(1);
                mugMNG.activeMugOfPlayer(2);
                IsPlayerHoldTheMug = false;
                IsCoffeMakerOn = true;

            }


        }


        else if (RecentTag == "CoffeeMaker" && IsCoffeFill == true && IsPlayerHoldTheMug == false)
        {
            if (ctx.started)
            {

                mugMNG.activeMugOfCoffeeMaker(2);
                mugMNG.activeMugOfPlayer(1);


                IsCoffeFill = false;

                IsPlayerHoldTheMug = true;
                IsCoffeMakerOn = false;

                TheMugOfThePlayerIsFill = true;
                CoffeStateAni.SetTrigger("FillTheMug");
                CoffeStateAni.SetBool("TheMugOfThePlayerIsFill", TheMugOfThePlayerIsFill);

            }


        }

        else if (RecentTag == "BTN" && IsCoffeMakerOn == true && IsPlayerHoldTheMug == false)
        {
            if (ctx.started)
            {

                coffee.SetTrigger("OnBTNPress");

                Invoke("TheCoffeeISready", 7);
                Bottun.SetTrigger("BTN");

            }
        }
        else if (RecentTag == "WorkerTable" && IsPlayerHoldTheMug == true && TheMugOfThePlayerIsFill == true && workerTable.TheTableReserved == false)
        {

            workerTable.TheWorkerGetTheCoffee();
            mugMNG.activeMugOfPlayer(2);
            TheMugOfThePlayerIsFill = false;
            IsPlayerHoldTheMug = false;
            CoffeStateAni.SetBool("TheMugOfThePlayerIsFill", TheMugOfThePlayerIsFill);



        }
        else if (RecentTag == "Worker" && dialogueSyss.IsDialogueAppear == false && IsPlayerHoldTheMug == false)
        {
            if (ctx.started)
            {
                dialogueSyss.AppearTheDialogue();
                gameObject.GetComponent<PlayerMovement>().enabled = false;
            }
        }
        else if (RecentTag == "Worker" && dialogueSyss.IsDialogueAppear == true && IsPlayerHoldTheMug == false)
        {
            if (ctx.started)
            {
                dialogueSyss.DisappearTheDialogue();
                gameObject.GetComponent<PlayerMovement>().enabled = true;


            }
        }
        
         else if (RecentTag == "CleaningSink" &&  IsPlayerHoldTheMug == true )
        {
            if (ctx.started)
            {
                mugMNG.activeMugOfPlayer(2);
                mugMNG.ResetTheMug();
                IsPlayerHoldTheMug = false;
                TheMugOfThePlayerIsFill = false;

            }
        }
    }

        void TheCoffeeISready()
        {

            IsCoffeFill = true;



        }
    


private void StartInteraction()
    {
        isInteracting = true;
        interactionTimer = 0f;
        loadingBoxUI.SetActive(true); // Show the loading box
    }

private void CompleteInteraction()
    {
        isInteracting = false;
        loadingBoxUI.SetActive(false); // Hide the loading box
        loadingProgressBar.fillAmount = 0f;

        // Add your logic for what happens after interaction completes
        Debug.Log("Interaction completed!");
    }


}
