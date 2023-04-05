using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickyButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    // Editor controls
    [SerializeField] private Image _img;
    [SerializeField] private Sprite _default, _pressed;
    [SerializeField] private AudioClip _compressClip, _uncompressClip;
    [SerializeField] private AudioSource _source;
    [SerializeField] private float volume = 0.25f;

    public void OnPointerDown(PointerEventData eventData)
    {
        // change sprite to pressed button and play sound
        _img.sprite = _pressed;
        _source.PlayOneShot(_compressClip, volume);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // change sprite to unpressed button and play sound
        _img.sprite = _default;
        _source.PlayOneShot(_uncompressClip, volume);
    }
}
