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

    public enum who
    {
        mirror,
        muslce,
        calvitie,
        pixel,
        girlBoss
    }
    [System.Serializable]
    public struct colorPerPerso
    {
        public who whos;
        public Color text;
        public Color bg;
    }

    public List<colorPerPerso> colorPerPersos = new List<colorPerPerso>();

    public string textToAdd;
    [Button]
    void AddBubble()
    {
        AddBubble(textToAdd, who.mirror);
    }

    public void AddBubble(string text, who who)
    {
        if (text == "")
            return;

        colorPerPerso chooseCol = new colorPerPerso();
        foreach(colorPerPerso col in colorPerPersos)
        {
            if (col.whos == who)
                chooseCol = col;
        }

        Bubble bubb = Instantiate(bubbleGO, this.transform);

        bubb.Create(text, height, spawnPoint.transform.position, chooseCol);
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
