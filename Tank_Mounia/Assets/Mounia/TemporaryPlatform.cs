using UnityEngine;

public class TemporaryPlatform : MonoBehaviour
{
    public bool used = false;
    private float timeToDestroy = 3;
    private float elapsedTime = 0;
    public Color deadColor;
    private Color baseColor;
    private Material snow;
    private Renderer snowd;

    private void Start()
    {
        snow = new Material(GetComponent<MeshRenderer>().materials[1]);
        snowd = GetComponent<Renderer>();
        GetComponent<MeshRenderer>().materials[1] = snow;
        baseColor = snow.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (used && !EndManager.instance.end)
        {
            elapsedTime += Time.deltaTime;
            snowd.materials[1].color = Color.Lerp(baseColor, deadColor, elapsedTime / timeToDestroy);
            if (elapsedTime >= timeToDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}
