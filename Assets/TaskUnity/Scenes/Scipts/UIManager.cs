using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{ 
    private List<GameObject> selectedObjects = new List<GameObject>(); // Выделенные объекты

    public GameObject panel; // Панель контекстного меню
    public GameObject mainPanel; // Панель контекстного меню
    public GameObject togglePrefab; // Шаблон Toggle
    public List<GameObject> objects; // Список объектов
    public Slider transparencySlider; // Слайдер для прозрачности
    public Dropdown colorDropdown; // Дропдаун для выбора цвета
    public Toggle visibleToggle; // Чекбокс для видимый/невидимый объект
    public CameraController cameraController; // Камера контроллер (для запрета)

    void Start()
    {
        objects = new List<GameObject>(GameObject.FindGameObjectsWithTag("MyTag"));
        panel.SetActive(false);
        mainPanel.SetActive(false);

        colorDropdown.ClearOptions();
        transparencySlider.gameObject.SetActive(false);
        colorDropdown.gameObject.SetActive(false);
        visibleToggle.gameObject.SetActive(false);
        colorDropdown.AddOptions(new List<string> { "Красный", "Зеленый", "Синий", "Желтый", "Белый" });
        colorDropdown.onValueChanged.AddListener(OnColorDropdownChanged);
        visibleToggle.onValueChanged.AddListener(OnVisibleObject);
        transparencySlider.onValueChanged.AddListener(OnTransparencySliderChanged);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ShowContextMenu();
        }
        if (!mainPanel.activeSelf || !RectTransformUtility.RectangleContainsScreenPoint(mainPanel.GetComponent<RectTransform>(), Input.mousePosition))
        {
            HideContextMenu();
        }
        if (Input.GetMouseButtonDown(0) && !mainPanel.activeSelf)
        {
            SelectObjectUnderMouse();
        }
    }

    void ShowContextMenu() 
    { 
        Vector3 mousePosition = Input.mousePosition;
        mainPanel.transform.position = mousePosition;
        mainPanel.SetActive(true);
        if (cameraController != null)
        {
            cameraController.enabled = false;
        }
        panel.SetActive(true);
        transparencySlider.gameObject.SetActive(true);
        colorDropdown.gameObject.SetActive(true);
        visibleToggle.gameObject.SetActive(true);

        foreach (Transform child in panel.transform)
        {
            if (child.gameObject != togglePrefab)
            {
                Destroy(child.gameObject);
            }
        }

        foreach (GameObject obj in selectedObjects)
        {
            GameObject toggle = Instantiate(togglePrefab, panel.transform);
            toggle.SetActive(true);
            toggle.GetComponentInChildren<Text>().text = obj.name; Toggle toggleComponent = toggle.GetComponent<Toggle>();
            toggleComponent.isOn = selectedObjects.Contains(obj); toggleComponent.onValueChanged.AddListener((isOn) => OnToggleChanged(obj, isOn));
        }
    }

    void OnToggleChanged(GameObject obj, bool isOn)
    {
        if (isOn)
        {
            selectedObjects.Add(obj);
            SelectObject(obj);
        }
        else
        {
            selectedObjects.Remove(obj);
            DeselectObject(obj);
        }
    }

    void OnVisibleObject(bool isOn) 
    {
        foreach (GameObject obj in selectedObjects) 
        {
            SetObjectVisible(obj, isOn);
        }
    }

    void SetObjectVisible(GameObject obj, bool isOn) 
    {
        Renderer renderer = obj.GetComponent<MeshRenderer>();
        if (renderer != null) 
        {
            renderer.enabled = isOn;
        }
    }

    void OnColorDropdownChanged(int index)
    {
        Color selectedColor = Color.white;  // По умолчанию белый
        switch (index)
        {
            case 0: selectedColor = Color.red; break;

            case 1: selectedColor = Color.green; break;

            case 2: selectedColor = Color.blue; break;

            case 3: selectedColor = Color.yellow; break;

            case 4: selectedColor = Color.white; break;

        }
            foreach (GameObject obj in selectedObjects)
            {
                SetObjectColor(obj, selectedColor);
            } 
    }

    void OnTransparencySliderChanged(float value)
    {
        foreach (GameObject obj in selectedObjects)
        {
            SetObjectTransparency(obj, value);
        }
    }

    void SetObjectColor(GameObject obj, Color color)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }

    void SetObjectTransparency(GameObject obj, float value)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            // Проверяем наличие материала
            Material material = renderer.material;
            if (material != null)
            {
                // Проверяем, является ли материал экземпляром Material
                if (material is Material)
                {
                    Debug.Log("Материал: " + material.name);
                    // Устанавливаем шейдер, который поддерживает прозрачность
                    //material.shader = Shader.Find("Transparent/Diffuse");
                    Color color = material.color;
                    color.a = value;

                    material.color = color;
                }
                else
                {
                    Debug.LogError("Материал не является экземпляром Material.");
                }
            }
            else
            {
                Debug.LogError("У объекта нет материала.");
            }
        }
        else
        {
            Debug.LogError("Компонент Renderer не найден на объекте.");
        }
    }

    void SelectObjectUnderMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject obj = hit.collider.gameObject;

            if (obj.CompareTag("MyTag"))
            {
                if (selectedObjects.Contains(obj))
                {
                    selectedObjects.Remove(obj);
                    DeselectObject(obj);
                }
                else
                {
                    selectedObjects.Add(obj);
                    SelectObject(obj);
                }
            }
        }   
    }

    void SelectObject(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            Color originalColor = renderer.material.color;
            renderer.material.color = Color.yellow;
            cameraController.SetTarget(obj.transform);
        }
    }

    void DeselectObject(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        Color prevColor = renderer.material.color;
        if (renderer != null && prevColor != Color.yellow)
        {
            renderer.material.color = prevColor;
        }
        else 
        {
            renderer.material.color = Color.white;
        }
        cameraController.SetTarget(null);
        cameraController.returnPos();
    }

    public void HideContextMenu()
    {
        mainPanel.SetActive(false);
        if (cameraController != null)
        {
            cameraController.enabled = true; // Включаем управление камерой
        }
        panel.SetActive(false);
        transparencySlider.gameObject.SetActive(false);
        colorDropdown.gameObject.SetActive(false);
        visibleToggle.gameObject.SetActive(false);
    }
}