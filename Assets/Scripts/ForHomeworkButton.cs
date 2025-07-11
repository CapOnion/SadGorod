using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
public class ForHomeworkButton : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _duration;
    [SerializeField] private Color _targetColor;
    [SerializeField] private Color _startColor;

    public void onClickRainbow(){
        StartCoroutine(GoRainbowMF(_image, _duration, _targetColor, _startColor));
    }

    private IEnumerator GoRainbowMF(Image image, float duration, Color targetColor, Color startColor){
        
        float currentTime = 0;
        Color currentColor = Color.white;

        while (currentTime < duration)
        {
            currentColor = Color.Lerp(startColor, targetColor, currentTime / duration);
            image.color = currentColor;
            currentTime += Time.deltaTime;
            yield return null;
        }
        
        image.color = targetColor;

        currentTime = 0;
        while (currentTime < duration)
        {
            currentColor = Color.Lerp(targetColor, startColor, currentTime / duration);
            image.color = currentColor;
            currentTime += Time.deltaTime;
            yield return null;
        }

        image.color = startColor;
    }
}
