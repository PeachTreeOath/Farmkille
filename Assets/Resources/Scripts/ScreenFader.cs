using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFader : MonoBehaviour
{

    public float fadeSpeed = 10f;

    private SpriteRenderer image;
    private Color srcColor;
    private Color invisColor;

    private bool isFading;
    private bool isFadingIn;
    private float elapsedTime;

    void Awake()
    {
        image = GetComponent<SpriteRenderer>();
        Color col = image.color;
        srcColor = new Color(col.r, col.g, col.b, 1);
        invisColor = new Color(col.r, col.g, col.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFading)
        {
            elapsedTime += fadeSpeed * Time.deltaTime;

            if(isFadingIn)
            {
                image.color = Color.Lerp(srcColor, invisColor, elapsedTime);
            }
            else
            {
                image.color = Color.Lerp(invisColor,srcColor, elapsedTime);
            }
            if(elapsedTime > 1)
            {
                isFading = false;
                if(isFadingIn == false)
                {
                    GameManager.instance.GoToNextYear();
                }
            }
        }
    }

    public void FadeIn()
    {
        isFading = true;
        isFadingIn = true;
        elapsedTime = 0;
    }

    public void FadeOut()
    {
        isFading = true;
        isFadingIn = false;
        elapsedTime = 0;
    }
}
