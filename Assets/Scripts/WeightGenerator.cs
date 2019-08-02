using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeightGenerator : MonoBehaviour 
{
	public TextMeshPro _textMesh;

    public bool _clignote = false, _pingPong = false;

	void OnTriggerEnter (Collider collider)
	{
        if (collider.tag == "ChemicalTools")
        {
            Debug.Log("Collider detected on Enter. Name : " + collider.name);
            
            ToolInformations informations = collider.GetComponent<ToolInformations>();

            if (informations.Volume == -1)
                return;

            StartCoroutine(Equilibrator(informations.TotalWeight));

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ChemicalTools")
        {
            Debug.Log("Exit now");
            StopAllCoroutines();

            _clignote = true;
            StartCoroutine("Clignote");
        }

    }

    private void OnTriggerStay(Collider collider)
    {
        
      
    }

    IEnumerator Equilibrator (float total)
	{
		float value = Random.Range (total - 1, total + 1);

		while (value != total) 
		{
			value = Random.Range (value, 2*total - value);
			_textMesh.SetText (value.ToString () + "g");

			yield return new WaitForSeconds (0.4f);
		}


	}

    IEnumerator Clignote()
    {
        yield return new WaitForSeconds(4f);
        _clignote = false;
    }

    private void Update()
    {

        if (_clignote)
            if (_pingPong)
            {
                _textMesh.alpha += Time.deltaTime;

                if (_textMesh.alpha >= 1)
                    _pingPong = false;
            }
            else
            {
                _textMesh.alpha -= Time.deltaTime;

                if (_textMesh.alpha <= 0)
                    _pingPong = true;
            }
        else
            _textMesh.alpha = 1;

    }

}