using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidBody;
    
    public float rotationSpeed, moveSpeed, maxInteractDistance;
   
    bool isGamePaused;
    public bool isLevelComplete;
    public Transform InteractionPanelsParent;
    //public MouseLook mouseLook = new MouseLook();
    //Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        isGamePaused = false;
        
        //mouseLook.Init(transform, camera.transform);

        
        isLevelComplete = false;
            }
    /*
    private void RotateView()
    {
        //avoids the mouse looking if the game is effectively paused
        if (Mathf.Abs(Time.timeScale) < float.Epsilon) return;

        // get the rotation before it's changed
        float oldYRotation = transform.eulerAngles.y;

        mouseLook.LookRotation(transform, cam.transform);

        if (m_IsGrounded || advancedSettings.airControl)
        {
            // Rotate the rigidbody velocity to match the new direction that the character is looking
            Quaternion velRotation = Quaternion.AngleAxis(transform.eulerAngles.y - oldYRotation, Vector3.up);
            m_RigidBody.velocity = velRotation * m_RigidBody.velocity;
        }
    }
    */

    IEnumerator GoToNextLevel()
    {
        yield return new WaitForSeconds(2);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;

        SceneManager.LoadScene(nextSceneIndex);
    }

    bool isAnyInteractionPanelOpen()
    {
        bool isAnyPanelOpen = false;
       

        return isAnyPanelOpen;
    }

   
    // Update is called once per frame
    void Update()
    {
        if (isGamePaused == false)
        {
            
            //Camera camera = Camera.main;
            //Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
            //camera.transform.LookAt(camera.ScreenToWorldPoint(mousePos), Vector3.up);
            bool isMoving = false;
            if (Input.GetKey(KeyCode.W) && isAnyInteractionPanelOpen() == false)
            {
                print("tests: " + isAnyInteractionPanelOpen());
                rigidBody.AddForce(transform.forward * moveSpeed * Time.deltaTime);
                isMoving = true;
            }
            /*
            if (Input.GetKey(KeyCode.A) && isAnyInteractionPanelOpen() == false)
            {
                rigidBody.AddForce(transform.forward * moveSpeed * Time.deltaTime);
                isMoving = true;
            }
            if (Input.GetKey(KeyCode.D) && isAnyInteractionPanelOpen() == false)
            {
                rigidBody.AddForce(transform.forward * moveSpeed * Time.deltaTime);
                isMoving = true;
            }
            */
            if (Input.GetKey(KeyCode.S) && isAnyInteractionPanelOpen() == false)
            {
                rigidBody.AddForce(-transform.forward * moveSpeed / 2 * Time.deltaTime);
                isMoving = true;
            }
            if (isMoving == false && Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, maxInteractDistance))
                {
                   
                }
            }
            /*if(isMoving == false)
            {
                rigidBody.velocity = Vector3.zero;
            }
            */
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 jumpForce = new Vector3(0, 5f, 0);
            rigidBody.AddForce(jumpForce, ForceMode.Impulse);
        }  
    }
}
