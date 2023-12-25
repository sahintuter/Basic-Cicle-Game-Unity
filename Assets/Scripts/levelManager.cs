using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] engelPrefablari;
    public Transform olusumNoktasi;
    public float olusumAraligi = 2f; // engellerin oluþturulma aralýðý

    public float minYukseklikAraligi = 1f;
    public float maxYukseklikAraligi = 3f;
    public float yokOlmaSuresi = 10f;
    public float maxUzaklik = 50f;


    private void Start()
    {
        StartCoroutine(OlusturEngeller());
    }
    private IEnumerator OlusturEngeller() // Engel Oluþturmak
    {
        float oncekiYukseklik = olusumNoktasi.position.y;

        while (true)
        {

            int randomIndex = Random.Range(0, engelPrefablari.Length);
            GameObject secilenEngelPrefab = engelPrefablari[randomIndex];


            float yukseklik = oncekiYukseklik + Random.Range(minYukseklikAraligi, maxYukseklikAraligi);


            Vector3 olusumPozisyonu = new Vector3(olusumNoktasi.position.x, yukseklik, olusumNoktasi.position.z);
            GameObject yeniEngel = Instantiate(secilenEngelPrefab, olusumPozisyonu, Quaternion.identity);

            oncekiYukseklik = yukseklik;


            StartCoroutine(YokEtCoroutine(yeniEngel));

            yield return new WaitForSeconds(olusumAraligi);
        }
    }



    private IEnumerator YokEtCoroutine(GameObject engel)
    {
        yield return new WaitForSeconds(yokOlmaSuresi);
        if (engel != null && Vector3.Distance(transform.position, engel.transform.position) > maxUzaklik)
        {
            Destroy(engel);
        }
    } 
}
