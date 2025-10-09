using TMPro;
using UnityEngine;

public class distanceMeter : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI distanceText;
    private float startZ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startZ = player.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = player.position.z - startZ;
        int distanceInt = Mathf.FloorToInt(distance);
        distanceText.text = distanceInt.ToString("D6");
    }
}
