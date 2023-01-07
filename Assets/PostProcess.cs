using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class PostProcess : MonoBehaviour
{
    [Range(0, 1)]
    public float intensity = 0.009f; 


    public Material matToApply;
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (matToApply != null)
        {
            matToApply.SetFloat("_intensity", intensity);
            RenderTexture tmp = destination;
            Graphics.Blit(source, tmp, matToApply);
            //Graphics.Blit(tmp, destination);
            //Graphics.Blit(tmp, destination); //doesn't seem usefull (only one blit, so less calcul)
        }
        else
            Graphics.Blit(source, destination);
    }

    //probably some screenshake
}
