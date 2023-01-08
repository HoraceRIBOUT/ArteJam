using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BubbleGenerator : MonoBehaviour
{
    [Header("Prog")]
    public Bubble bubbleGO;
    public RectTransform spawnPoint;
    public float offsetBubble = 80;
    public float height = 80;

    public List<Bubble> pastBubble;

    public string textToAdd;
    [Button]
    void AddBubble()
    {
        AddBubble(textToAdd);
    }

    public void AddBubble(string text)
    {
        Bubble bubb = Instantiate(bubbleGO, this.transform);

        bubb.Create(text, height, spawnPoint.transform.position);
        bubb.transform.position = spawnPoint.transform.position + Vector3.right * 200;

        if (pastBubble.Count != 0)
        {
            foreach (Bubble pastBubb in pastBubble)
            {
                pastBubb.SetTargetPos_Relative(offsetBubble * Vector3.up); 
            }
        }

        pastBubble.Add(bubb);
    }
}
