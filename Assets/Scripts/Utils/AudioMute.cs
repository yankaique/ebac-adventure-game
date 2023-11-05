using UnityEngine;
using UnityEngine.UI;

public class AudioMute : MonoBehaviour
{
    public Image icon;
    private bool _buttonIsEmpty;

    public void MakeButtonTransparency()
    {
        Image buttonImage = icon.GetComponent<Image>();

        if(!_buttonIsEmpty && buttonImage != null)
        {
            buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, 0.5f);
            MusicPlayer.Instance.Stop();
            _buttonIsEmpty = true;
        }
        else
        {
            buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, 1f);
            MusicPlayer.Instance.Play();
            _buttonIsEmpty = false;
        }
    }
}
