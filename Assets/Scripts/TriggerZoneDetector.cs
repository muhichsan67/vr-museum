using UnityEngine;

public class TriggerZoneDetector : MonoBehaviour
{
    public static bool isPlayerAuthorized = false;
    public GameObject gadgetModel; 

    private void OnTriggerEnter(Collider other)
    {
        // PESAN TES: Setiap ada objek apapun yang menyentuh lantai ini, pesan ini AKAN MUNCUL!
        Debug.Log("Ada objek yang menginjak lantai ini! Nama objeknya adalah: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            isPlayerAuthorized = true;
            Debug.Log("<color=green>[AUTH] Player terdeteksi! Gawai diaktifkan.</color>");

            if (gadgetModel != null)
            {
                gadgetModel.SetActive(false); 
            }
        }
    }
}