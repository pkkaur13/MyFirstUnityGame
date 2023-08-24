using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerlife : MonoBehaviour
{
    bool dead =false;

    private void Update()
    {
    if (transform.position.y < -1f && !dead)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<movement>().enabled = false;
            Die();
        }
    }
    // Start is called before the first frame update
   private void OnCollisionEnter(Collision collision)
   {
    if(collision.gameObject.CompareTag("Enemy Body"))
    {
        Die();
    }
   }

   void Die()
   {
    Invoke(nameof(reloadlevel),1.3f);
    dead= true;
    
   }

   void reloadlevel()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
}