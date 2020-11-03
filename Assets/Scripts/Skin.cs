using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    #region Variables

    [SerializeField] Sprite skinImage;

    Image image;
    Animator anim;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        image = GetComponent<Image>();
        anim = GetComponent<Animator>();
    }

    #endregion

    #region Other Methods

    public void ShowSkin()
    {
        image.sprite = skinImage;
    }

    public void PlayAnimation()
    {
        anim.enabled = true;
    }

    public void ActiveButton()
    {
        CardManager.Instance.ActiveButton();
    }

    #endregion
}
