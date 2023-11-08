using UnityEngine;

public class StoneControl : MonoBehaviour
{
    ParticleSystem grindingParticle;
    GameManager gameManager;
    GaugeBar gaugeBar;

    bool isClicked = false;
    Vector3 mousePosition;

    void Start()
    {
        grindingParticle = GetComponentInChildren<ParticleSystem>();
        gameManager = FindObjectOfType<GameManager>();
        gaugeBar = FindObjectOfType<GaugeBar>();
    }

    void Update()
    {
        if (isClicked) // ���� Ŭ���Ǹ�
        {
            if (gameManager.GetGameResult() == GameState.none)
            {
                ProcessGrinding();
            }
        }
    }

    void ProcessGrinding()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, 10f);
        var emissionModule = grindingParticle.emission;

        if (hit) // ������ z������ ������ �߻�
        {
            if (hit.transform.gameObject.name == "Tool_Grinding_Plate") // ���� �� ���� ������쿡��
            {
                Vector3 mouseDiff = GetMouseDiff();

                emissionModule.enabled = true;
                mousePosition = Input.mousePosition;

                DetectGrindingSpeed(mouseDiff); // ���� �ӵ� �Ǻ�
            }
        }
        else
        {
            emissionModule.enabled = false;
            return;
        }
    }

    void DetectGrindingSpeed(Vector3 mouseDiff)
    {
        if (mouseDiff.x > 0 || mouseDiff.y > 0)
        {
            gaugeBar.AddForceToGauge();
        }
    }

    Vector3 GetMouseDiff()
    {
        float mouseDiffX;
        float mouseDiffY;

        mouseDiffX = Mathf.Abs(mousePosition.x - Input.mousePosition.x);
        mouseDiffY = Mathf.Abs(mousePosition.y - Input.mousePosition.y);

        return new Vector3(mouseDiffX, mouseDiffY, 0);
    }

    void OnMouseDown()
    {
        isClicked = true;
        mousePosition = Input.mousePosition;
    }

    void OnMouseUp()
    {
        isClicked = false;
    }

    void OnMouseDrag()
    {
        if (gameManager.GetGameResult() == GameState.none)
        {
            float distance = Camera.main.WorldToScreenPoint(transform.position).z;

            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);

            transform.position = objPos;
        }
    }
}
