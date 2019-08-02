using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHidePanelManager : MonoBehaviour
{

    public Animator _InventoryUIAnimator;
    public Animator _TrashUIAnimator;

    private WaitForSeconds _wait = new WaitForSeconds(3);

    public static ShowHidePanelManager Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public void ShowTrash()
    {
        if (_TrashUIAnimator.GetBool("Show") == true)
            return;

        _TrashUIAnimator.SetBool("Show", true);
        _TrashUIAnimator.SetTrigger("Action");
    }
    

    public void HideTrash()
    {
        if (_TrashUIAnimator.GetBool("Show") == false)
            return;

        _TrashUIAnimator.SetBool("Show", false);
        _TrashUIAnimator.SetTrigger("Action");
    }

    public void ShowInventory()
    {
        if (_InventoryUIAnimator.GetBool("Show") == true)
            return;

        _InventoryUIAnimator.SetBool("Show", true);
        _InventoryUIAnimator.SetTrigger("Action");
    }

    public void HideInventory ()
    {
        if (_InventoryUIAnimator.GetBool("Show") == false)
            return;

        _InventoryUIAnimator.SetBool("Show", false);
        _InventoryUIAnimator.SetTrigger("Action");
    }
}
