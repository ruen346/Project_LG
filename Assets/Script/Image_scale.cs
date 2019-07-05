using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image_scale : MonoBehaviour
{
    IEnumerator Start()
    {
        while (true)
        {
            transform.localScale += new Vector3(0.1f, 0, 0);

            yield return new WaitForSeconds(5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
