using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEditor;
using System;

public class PlayerInteraction : MonoBehaviour
{

    private bool IsPlayerHoldTheMug = false;
    private bool IsCoffeMakerOn = false;
    private bool IsCoffeFill = false;
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
        Debug.Log(IsPlayerHoldTheMug);
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

            if (hit.collider.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                currentTarget = interactable;
                ShowPrompt(interactable.GetPrompt());
            }
            else HidePrompt();
        }
        else HidePrompt();

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
        else if (RecentTag == "CoffeeMaker" && IsCoffeMakerOn == false && IsPlayerHoldTheMug == true)
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
        else if (RecentTag == "WorkerTable" && IsPlayerHoldTheMug==true &&TheMugOfThePlayerIsFill==true)
        {

            workerTable.TheWorkerGetTheCoffee();
            mugMNG.activeMugOfPlayer(2);
            TheMugOfThePlayerIsFill = false;
            IsPlayerHoldTheMug = false;
            CoffeStateAni.SetBool("TheMugOfThePlayerIsFill", TheMugOfThePlayerIsFill);



        }
    }
    void TheCoffeeISready()
    {

        IsCoffeFill = true;



    }
}
