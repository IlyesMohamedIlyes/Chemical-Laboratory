using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDetector : MonoBehaviour {

    private void OnTriggerExit2D(Collider2D collision)
    {
        ShowHidePanelManager.Instance.HideTrash();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("InventorySprite"))
            ShowHidePanelManager.Instance.ShowTrash();
    }
}
