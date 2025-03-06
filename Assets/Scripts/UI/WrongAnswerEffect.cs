using UnityEngine;
using UnityEngine.UI;

public class WrongAnswerEffect : MonoBehaviour
{
    private Image effectImage;

    [SerializeField] private Color effectColor = Color.red;
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private float maxScale = 1.2f;

    private float currentTime = 0f;
    private bool isPlaying = false;

    void Start()
    {
        effectImage = GetComponent<Image>();
        effectImage.sprite = CreateCircleSprite();
        effectImage.color = new Color(effectColor.r, effectColor.g, effectColor.b, 0f);
    }

    void Update()
    {
        if (isPlaying)
        {
            currentTime += Time.deltaTime;
            float t = currentTime / fadeDuration;

            if (t <= 1f)
            {
                float scale = Mathf.Lerp(1f, maxScale, t);
                transform.localScale = new Vector3(scale, scale, 1f);

                float alpha = Mathf.Sin(t * Mathf.PI);
                effectImage.color = new Color(effectColor.r, effectColor.g, effectColor.b, alpha);
            }
            else
            {
                isPlaying = false;
                currentTime = 0f;
                transform.localScale = Vector3.one;
                effectImage.color = new Color(effectColor.r, effectColor.g, effectColor.b, 0f);
            }
        }
    }

    public void TriggerEffect()
    {
        isPlaying = true;
        currentTime = 0f;
    }

    public void SetEffectColor(Color newColor)
    {
        effectColor = newColor;
    }

    private Sprite CreateCircleSprite()
    {
        int size = 256;
        Texture2D tex = new Texture2D(size, size, TextureFormat.ARGB32, false);
        Vector2 center = new Vector2(size / 2, size / 2);
        float radius = size / 2;

        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                float distance = Vector2.Distance(new Vector2(x, y), center);
                if (distance <= radius)
                {
                    tex.SetPixel(x, y, Color.white);
                }
                else
                {
                    tex.SetPixel(x, y, Color.clear);
                }
            }
        }
        tex.Apply();
        return Sprite.Create(tex, new Rect(0, 0, size, size), new Vector2(0.5f, 0.5f));
    }
}
