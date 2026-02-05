using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    public float speed = 15f;
    public float arcHeight;

    private Transform target;
    private Vector3 startPos;
    private float travelTime;
    private float timer;

    public void Init(Transform target)
    {
        this.target = target;
        startPos = transform.position;

        float distance = Vector3.Distance(startPos, target.position);
        travelTime = distance / speed;
    }

    void Update()
    {
        if (target == null)
        {
            HitTarget();
            return;
        }

        timer += Time.deltaTime;
        float t = timer / travelTime;

        if (t >= 1f)
        {
            HitTarget();
            return;
        }

        Vector3 currentPos = Vector3.Lerp(startPos, target.position, t);

        // tạo đường cong
        arcHeight = Vector3.Distance(startPos, target.position) * 1.5f;
        currentPos.y += arcHeight * Mathf.Sin(Mathf.PI * t) * 0.1f;

        transform.position = currentPos;

        // xoay mũi tên theo hướng bay
        Vector3 dir = (target.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(dir);
    }

    void HitTarget()
    {
        // TODO: Damage target
        Destroy(gameObject);
    }
}
