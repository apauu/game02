using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour, IObserver {
    [SerializeField]
    private GameObject target;
    // 高さ:15 奥行き:-4
    [SerializeField]
    private Vector3 distance = new Vector3(0, 15, -4);
    [SerializeField]
    private Vector3 lookPoint = new Vector3(0, 1.35f, 0);

    void Start()
    {
    }

    void Update()
    {
        if (target != null)
        {
            this.transform.position = target.transform.position + distance;

        }

        //Vector3 lookVector = target.transform.position + lookPoint - this.transform.position;
        //this.transform.rotation = Quaternion.LookRotation(lookVector);

    }

    public void SetTargetObject(GameObject obj)
    {
        target = obj;
    }

    /// <summary>
    /// Observerに通知された場合の処理
    /// </summary>
    /// <param name="value"></param>
    public void Update(GameObject obj)
    {
        target = obj;
    }
}
