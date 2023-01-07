using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class PostProcess : MonoBehaviour
{
    [Range(0, 1)]
    public float intensity = 0.009f; 
    [Range(0,1)]
    public float fishEye = 0f; 


    public Material matToApply;
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (matToApply != null)
        {
            matToApply.SetFloat("_intensity", intensity);
            matToApply.SetFloat("_Distortion", fishEye * 3f);
            matToApply.SetFloat("_zoomFactor", Mathf.Lerp(1, 0.75f, fishEye));
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
