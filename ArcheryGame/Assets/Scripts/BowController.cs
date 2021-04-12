using System;
using UnityEngine;

public class BowController : MonoBehaviour
{
    [SerializeField] GameObject[] arrowPrefabs;
    [SerializeField] Transform arrowSpawnTransform;
    [SerializeField] Transform previewArrow;
    [SerializeField] float arrowVelocityPerDrawSecond;
    [SerializeField] float minDrawTime;
    [SerializeField] float maxDrawTime;
    [SerializeField] float drawMovementPerSecond;

    [Header("Prediction")]
    [SerializeField] LineRenderer predictionRenderer;
    [SerializeField] int segments;
    [SerializeField] float maxPredictionTime;

    float bowDrawTime = 0;
    int currentArrowIndex = 0;

    private void OnEnable()
    {
        Application.onBeforeRender += ArrowPredictionUpdate;
    }

    private void OnDisable()
    {
        Application.onBeforeRender -= ArrowPredictionUpdate;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            CycleThroughArrowUsed();

        BowUpdate();
        ArrowPreviewUpdate();
    }

    private void ArrowPredictionUpdate()
    {
        if (bowDrawTime > minDrawTime)
        {
            if (predictionRenderer.positionCount != segments)
                predictionRenderer.positionCount = segments;

            Vector3[] positions = new Vector3[segments];
            Vector3 p0 = GetArrowPositionAtDrawTime(bowDrawTime);
            Vector3 v0 = GetArrowLaunchVelocity();

            for (int i = 0; i < segments; i++)
            {
                Vector3 point = ProjectilePrediction.Predict(p0, v0, i * maxPredictionTime / segments);
                positions[i] = point;
            }

            predictionRenderer.SetPositions(positions);
        }
        else
        {
            if (predictionRenderer.positionCount != 0)
                predictionRenderer.positionCount = 0;
        }
    }

    private void BowUpdate()
    {
        bool mouseDown = Input.GetMouseButton(0);

        if (mouseDown)
        {
            bowDrawTime += Time.deltaTime;
        }
        else
        {
            if (bowDrawTime > 0)
            {
                if (bowDrawTime > minDrawTime)
                {
                    ShootArrow();
                }
                bowDrawTime = 0;
            }
        }
    }

    private void ShootArrow()
    {
        var arrow = Instantiate(arrowPrefabs[currentArrowIndex], GetArrowPositionAtDrawTime(bowDrawTime), arrowSpawnTransform.rotation);
        var rigidbody = arrow.GetComponent<Rigidbody>();

        if (rigidbody)
        {
            rigidbody.velocity = GetArrowLaunchVelocity();
        }
    }

    private void ArrowPreviewUpdate()
    {
        if (bowDrawTime <= 0)
        {
            previewArrow.gameObject.SetActive(false);
        }
        else
        {
            previewArrow.gameObject.SetActive(true);
            previewArrow.position = GetArrowPositionAtDrawTime(bowDrawTime);
        }
    }

    private Vector3 GetArrowLaunchVelocity()
    {
        return (Mathf.Min(maxDrawTime, bowDrawTime) * arrowVelocityPerDrawSecond * arrowSpawnTransform.forward);
    }

    private Vector3 GetArrowPositionAtDrawTime(float t)
    {
        return arrowSpawnTransform.position + arrowSpawnTransform.forward * (maxDrawTime - Mathf.Min(maxDrawTime, t)) * drawMovementPerSecond;
    }

    public void CycleThroughArrowUsed()
    {
        currentArrowIndex = (currentArrowIndex + 1) % arrowPrefabs.Length;
        UpdatePreviewMaterial();
    }

    private void UpdatePreviewMaterial()
    {
        var renderer = previewArrow.GetComponentInChildren<Renderer>();
        renderer.sharedMaterial = arrowPrefabs[currentArrowIndex].GetComponentInChildren<Renderer>().sharedMaterial;
    }
}

public static class ProjectilePrediction
{
    public static Vector3 Predict(Vector3 p0, Vector3 v0, float t)
    {
        Vector3 g = Physics.gravity;
        // a = g => change of velocity over time 
        // v  => change of position over time 
        // f''(t) = g
        // f'(t) = gt + v0 
        // f(t) = 0.5f * g * t * t + v0 * t + p0

        return 0.5f * g * t * t + v0 * t + p0;
    }
}
