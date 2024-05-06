using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "ShieldSkill", menuName = "Skill/Shield")]
public class ShieldComponentSkill : Skill
{
    [SerializeField] private GameObject barrierPrefab;
    [SerializeField] private bool ifChildOfPlayer;
    [SerializeField] private bool playerCanMove;
    [SerializeField] private float duration;

    private GameObject barrierInstance;

    public override IEnumerator PerformSkill(Transform transform = null, Vector3 startTransform = default, Vector3 endTransform = default)
    {
        if (barrierPrefab == null)
        {
            Debug.LogWarning("Barrier prefab is not set!");
            yield break;
        }

        if (transform == null)
        {
            Debug.LogWarning("Transform is not set!");
            yield break;
        }

        float startTime = Time.time;
        Vector3 offset = new Vector3(0, 1f, 0);
        Vector3 startPosition = transform.position;

        if (barrierInstance == null)
        {
            barrierInstance = Instantiate(barrierPrefab, startPosition+offset, Quaternion.identity);
            if (ifChildOfPlayer)
                barrierInstance.transform.SetParent(transform);
        }

        while (Time.time - startTime < duration)
        {
            barrierInstance.SetActive(true);

            if (playerCanMove == false)
                transform.position = startPosition;

            yield return null;
        }

        barrierInstance.SetActive(false);
    }
}