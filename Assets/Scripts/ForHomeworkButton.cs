using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
public class ForHomeworkButton : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _duration;
    [SerializeField] private Color _startColor;

    public void onClickRainbow(){
        StartCoroutine(GoRainbowMF(_image, _duration, _startColor));
    }

    private IEnumerator GoRainbowMF(Image image, float duration, Color startColor){
        
        Color[] colorArray = new Color[4] {Color.red, Color.blue, Color.green, Color.yellow};
        Color currentColor = Color.white;
        float currentTime = 0;
        Color targetColor = Color.blue;

        while (true)
        {   
            //targetColor = colorArray[Random.Range(0,colorArray.Length)];
            while (targetColor == startColor) {
                targetColor = colorArray[Random.Range(0,colorArray.Length)];
            }

            while (currentTime < duration){
                currentColor = Color.Lerp(startColor, targetColor, currentTime / duration);
                image.color = currentColor;
                currentTime += Time.deltaTime;
                yield return null;
            }
            image.color = targetColor;
            currentTime = 0;
            startColor = targetColor;
            
            yield return null;
        }
        
    }
}
