using UnityEngine;

public class FireBulletBill : MonoBehaviour
{
    public GameObject bulletBillModel;
    public GameObject bulletBillExplosionEffect;
    public float flyDistance = 13f;
    public float flySpeed = 5f;

    private GameObject bulletBill;
    private Vector3 origin;

    private void Start()
    {
        origin = transform.position + new Vector3(0f, 0.45f, 0f);

        bulletBill = Instantiate(bulletBillModel, origin, transform.rotation);
    }

    private void Update()
    {
        bulletBill.transform.position += transform.rotation * Vector3.forward * flySpeed * Time.deltaTime;

        if (Vector3.Distance(bulletBill.transform.position, transform.position) > flyDistance)
        {
            Instantiate(
                bulletBillExplosionEffect, 
                bulletBill.transform.position + new Vector3(0f, 0.45f), 
                bulletBill.transform.rotation
            );
            bulletBill.transform.position = origin;

            AudioManager.instance.PlayEffect(AudioManager.SFX.BillBlaster, origin);
        }
    }
}
