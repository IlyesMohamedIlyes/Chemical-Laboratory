using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ReactionProcess
{
    public string density { get; set; }
    public float time { get; set; }
    public Vector4 color { get; set; }
    public string reactionIDs { get; set; }

    public Dictionary<string, string> _reactionDensity;

    public ReactionProcess(int j)
    {
        density = null;
        time = 0.0f;
           color = new Vector4 (0f,0f,0f,0f);
        reactionIDs = null;
           _reactionDensity = new Dictionary<string, string>();
    }

    public Dictionary<string, string> ReactionDensity
    {
        get
        {
            string[] reactions = reactionIDs.Split('+');
            string[] densities = density.Split('+');

            _reactionDensity.Clear ();

            for (int i = 0; i < reactions.Length; i++)
                _reactionDensity.Add (reactions [i], densities [i]);

            return _reactionDensity;
        }
    }
}

public class DataLoader : MonoBehaviour {
    
    private WWW _data = null;

    string _fileName;
    

    public WWW ConnectDB (string fields, string tableName)
    {
        
        _fileName = WritePHPFile.Main (fields, tableName);

        _data = new WWW("http://localhost:10080/LaboratoryProject/" + _fileName);

        while (!_data.isDone) ;



        return _data;
    }

    private void Start()
    {

        WWW d = ConnectDB("ElementToInteract, TimeLapse, ReactionID, Density, Color, Duree", "Interaction");

        string[] lines = d.text.Split("<br>".ToCharArray());
        List<ReactionProcess> r = new List <ReactionProcess>();

        // Normally i will get only one line 
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains("|"))
            {
                var split = lines[i].Split('|');

                r.Add(new ReactionProcess() { reactionIDs = split[2], density = split[3], _reactionDensity = new Dictionary<string, string> ()});
            }

        }

        foreach (var k in r)
            Debug.Log(k.ReactionDensity.Count);


    }
                
    }



