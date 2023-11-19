using UnityEngine;

public class CameraFade : MonoBehaviour
{
    [Tooltip("How fast should the texture be faded out?")]
    public float fadeTime;

    [Tooltip("How long will the screen stay black?")]
    public float blackScreenDuration;

    [Tooltip("Choose the color, which will fill the screen.")]
    public Color fadeColor;

    private float alpha = 1.0f;
    private Texture2D texture;

    private float passedBlackScreenTime;

    private void Start()
    {
        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
        texture.Apply();
    }


    public void OnGUI()
    {
        // If the texture is no more visible, we are done.
        if (alpha <= 0.0f)
        {
            return;
        }

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);

        if (passedBlackScreenTime < blackScreenDuration)
        {
            passedBlackScreenTime += Time.deltaTime;
            return;
        }

        calculateTexture();
    }

    private void calculateTexture()
    {
        alpha -= Time.deltaTime / fadeTime;
        texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
        texture.Apply();
    }
}