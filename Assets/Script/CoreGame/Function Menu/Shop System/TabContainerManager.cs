using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabContainerManager : MonoBehaviour
{
    private GameObject computerButton;
    private GameObject graphicCardButton;
    private GameObject asicButton;
    public int currentTab;

    private Image computerImage;
    private Image graphicCardImage;
    private Image asicImage;

    private Color activeColor = new Color(255f,255f,255f,0f);
    private Color inactiveColor = new Color(255f,255f,255f,1f);

    void Start(){
        computerButton = transform.Find("ComputerButton").gameObject;
        graphicCardButton = transform.Find("GraphicCardButton").gameObject;
        asicButton = transform.Find("ASICButton").gameObject;

        computerImage = computerButton.GetComponent<Image>();
        graphicCardImage = graphicCardButton.GetComponent<Image>();
        asicImage = asicButton.GetComponent<Image>();

        //Defualt computer tab
        computerImage.color = activeColor;
        ComputerTab();
    }

    public void ComputerTab(){
        computerImage.color = activeColor;
        graphicCardImage.color = inactiveColor;
        asicImage.color = inactiveColor;
        currentTab = 1;
    }

    public void GrapgicCardTab(){
        computerImage.color = inactiveColor;
        graphicCardImage.color = activeColor;
        asicImage.color = inactiveColor;
        currentTab = 2;
    }

    public void AsicTab(){
        computerImage.color = inactiveColor;
        graphicCardImage.color = inactiveColor;
        asicImage.color = activeColor;
        currentTab = 3;
    }
}
