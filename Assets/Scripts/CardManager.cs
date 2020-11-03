using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    #region Variables

    public static CardManager Instance;

    [SerializeField] List<Skin> skins;
    [SerializeField] List<Image> frames;
    [SerializeField] int moveCount;
    [SerializeField] Color frameColor;
    [SerializeField] Color defaultColor;
    [SerializeField] Color unlockedColor;
    [SerializeField] Button unlockButton;

    int currentRandomNumber;
    Image currentImage;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        Instance = this;
        currentRandomNumber = -1;
        currentImage = frames[0];
    }

    #endregion

    #region Other Methods

    IEnumerator OpenRandomCard()
    {
        if (skins.Count == 1)
            moveCount = 1;
        for (int i = 0; i < moveCount; i++)
        {
            MoveFrame(RandomGenerator());
            yield return new WaitForSeconds(.25f);
        }
        ShowSkin();
    }

    int RandomGenerator()
    {
        int random = Random.Range(0, skins.Count);

        if (currentRandomNumber == random && skins.Count > 1)
            currentRandomNumber = RandomGenerator();
        else
            currentRandomNumber = random;

        return currentRandomNumber;
    }

    void ShowSkin()
    {
        skins[currentRandomNumber].PlayAnimation();
        skins.Remove(skins[currentRandomNumber]);
        frames[currentRandomNumber].color = unlockedColor;
        frames.Remove(frames[currentRandomNumber]);
        currentImage = null;
    }

    public void Unlock()
    {
        unlockButton.interactable = false;
        if (skins.Count > 0)
            StartCoroutine(OpenRandomCard());
        else
            Debug.Log("YOU GEL ALL SKINS");
    }

    void MoveFrame(int index)
    {
        if(currentImage !=null)
            currentImage.color = defaultColor;
        currentImage = frames[index];
        currentImage.color = frameColor;
    }

    public void ActiveButton()
    {
        unlockButton.interactable = true;
    }

    #endregion
}
