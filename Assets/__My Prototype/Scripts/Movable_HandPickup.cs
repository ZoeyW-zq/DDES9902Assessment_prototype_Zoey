using UnityEngine;

public class Movable_HandPickup : MonoBehaviour
{
    public Movable movableScript;     // ���� EZPZ ��ԭ Movable �ű�
    public Transform handTransform;   // ���������ֵ�λ��
    public float followSpeed = 10f;

    private bool isHeld = false;

    private void Start()
    {
        if (movableScript == null)
            movableScript = GetComponent<Movable>();
    }

    private void Update()
    {
        if (isHeld && handTransform != null)
        {
            transform.position = Vector3.Lerp(handTransform.position, handTransform.position, Time.deltaTime * followSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, handTransform.rotation, Time.deltaTime * followSpeed);
        }
    }

    public void Pickup(Transform hand)
    {
        if (movableScript != null)
        {
            movableScript.myRbody.isKinematic = true;
            movableScript.myCollider.enabled = false;
        }

        handTransform = hand;
        isHeld = true;
    }

    public void Drop()
    {
        isHeld = false;
        if (movableScript != null)
        {
            movableScript.myRbody.isKinematic = false;
            movableScript.myCollider.enabled = true;
        }
    }
}
