//The script is designed to customize the color of the stone and all its components at once.

using UnityEngine;

namespace sergeyiwanski.effectspack
{
    public class SkillColor : MonoBehaviour
    {
        public Color color = Color.gray;
        [Range(-1, 1)] public float bright = 0.3f;
        public Texture texture;

        Color emissionColor = Color.white;
        ParticleSystem[] particles;

        //It works immediately in the editor when changing settings
        void OnValidate()
        {
            emissionColor.r = color.r + bright;
            emissionColor.g = color.g + bright;
            emissionColor.b = color.b + bright;

            //Preliminary preparation
            MaterialPropertyBlock mat = new MaterialPropertyBlock();
            mat.SetColor("_Color", color);
            mat.SetColor("_EmissionColor", emissionColor);
            mat.SetFloat("_Glossiness", 0.0f);
            if (texture != null)
            {
                mat.SetTexture("_MainTex", texture);
                mat.SetTexture("_EmissionMap", texture);
            }

            //Object color change
            foreach (MeshRenderer rend in GetComponentsInChildren<MeshRenderer>())
            {
                rend.sharedMaterial.SetColor("_Color", color);
                rend.sharedMaterial.SetColor("_EmissionColor", emissionColor);
                rend.sharedMaterial.SetFloat("_Glossiness", 0.0f);
                rend.sharedMaterial.SetTexture("_MainTex", texture);
                rend.sharedMaterial.SetTexture("_EmissionMap", texture);
                rend.SetPropertyBlock(mat);
            }

            //Сhange the color of the electrons
            foreach (TrailRenderer trail in GetComponentsInChildren<TrailRenderer>())
            {
                trail.startColor = bright > 0 ? emissionColor : color;
                trail.endColor = bright > 0 ? color : emissionColor;
            }

            //Сhange the color of the internal glow
            particles = GetComponentsInChildren<ParticleSystem>();
            for (int i = 0; i < particles.Length; i++)
            {
                var main = particles[i].main;
                main.startColor = bright > 0 ? emissionColor : color;
            }

            //Display changes in the editor
#if UNITY_EDITOR
            UnityEditor.EditorApplication.RepaintProjectWindow();
#endif
        }
    }
}
