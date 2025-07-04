using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Car : MonoBehaviour
{   
    public float speed = 20f;
    public float turnSpeed = 45f;
    private float horizontalInput;
    private float forwardInput;

    public int totalItems = 5;
    private int collectedItems = 0;

    public TextMeshProUGUI itemText;

    public GameObject UI;
    public GameObject MenuUI;
    public GameObject gameOverUI;
    private bool canFinish = false;

    public GameObject mainCamera;
    public GameObject mainCamera2;

    void Start()
    {
        UpdateItemUI();
        UI.SetActive(false);
        MenuUI.SetActive(false);
        mainCamera2.SetActive(false);
        gameOverUI.SetActive(false);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            collectedItems++;
            Destroy(other.gameObject);
            UpdateItemUI();
            
            if (collectedItems >= totalItems)
            {
                canFinish = true;
            }
        }

        if (other.CompareTag("GameOver"))
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 1f;
        }


        if (other.CompareTag("Finish") && canFinish)
        {
            UI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void UpdateItemUI()
    {
        itemText.text = "DogBite: " + collectedItems + "/" + totalItems;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            mainCamera.SetActive(!mainCamera.activeSelf);
            mainCamera2.SetActive(!mainCamera.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuUI.SetActive(true);
            Time.timeScale = 0f;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        MenuUI.SetActive(false);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
