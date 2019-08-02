
using UnityEngine;

public class DeclareElementIn : MonoBehaviour
{
     
    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "ChemicalElement")
        {
            var infos = other.GetComponent<ElementInformations> ();

            if (infos == null)
            {
                Debug.Log("No ElementInformations component in element");
                return;
            }

            if (infos.InUse)
            {
                Debug.Log("Element already in use");
                return;
            }

            infos.InUse = true;

            var react = GetComponentInParent<ReactElements>();
            if (react == null)
            {
                Debug.Log("No ReactElements component in parent");
                return;

            }

            react.AddElement(infos);
        }
                
                
    }

}
