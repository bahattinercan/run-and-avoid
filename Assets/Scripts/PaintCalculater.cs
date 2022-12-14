using UnityEngine;

public static class PaintCalculater
{
    public static float CalculateFill(Color[] colors, Color reference, float tolerance)
    {
        Vector3 target = new Vector3 { x = reference.r, y = reference.g, z = reference.b };
        int numHits = 0;
        const float sqrt_3 = 1.73205080757f;
        for (int i = 0; i < colors.Length; i++)
        {
            Vector3 next = new Vector3 { x = colors[i].r, y = colors[i].g, z = colors[i].b };
            float mag = Vector3.Magnitude(target - next) / sqrt_3;
            numHits += mag <= tolerance ? 1 : 0;
        }
        return (float)numHits / (float)colors.Length; ;
    }

    private static float CalculateSimilarity(Color[] colors, Color reference)
    {
        Vector3 target = new Vector3 { x = reference.r, y = reference.g, z = reference.b };
        float accu = 0;
        const float sqrt_3 = 1.73205080757f;
        for (int i = 0; i < colors.Length; i++)
        {
            Vector3 next = new Vector3 { x = colors[i].r, y = colors[i].g, z = colors[i].b };
            accu += Vector3.Magnitude(target - next) / sqrt_3;
        }
        return 1f - ((float)accu / (float)colors.Length);
    }
}