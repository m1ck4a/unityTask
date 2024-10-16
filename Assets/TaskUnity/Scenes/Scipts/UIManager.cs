using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public class UIManager : MonoBehaviour
//{
//    public ItemInfo selectedObject; // Объект, с которым взаимодействуем
//    public Slider transparencySlider;
//    public Image colorImage1;
//    public Image colorImage2;
//    public Image colorImage3;
//    public Toggle visibilityToggle;
//    public Color selectedColor;
//    public GameObject togglePrefab;
//    public Transform toggleContainer;
//    public SelectedObjectManager selectedObjectManager;


//    void Start()
//    {
//        transparencySlider.onValueChanged.AddListener(SetTransparency);
//        colorImage1.GetComponent<Button>().onClick.AddListener(() => SetColor(colorImage1.color));
//        colorImage2.GetComponent<Button>().onClick.AddListener(() => SetColor(colorImage2.color));
//        visibilityToggle.onValueChanged.AddListener(ToggleVisibility);
//    }

//    void Update() 
//    {
//        UpdateToggleList();
//    }

//    void UpdateToggleList()
//    {
//        foreach (Transform child in toggleContainer)
//        {
//            Destroy(child.gameObject);
//        }

//        foreach (var obj in selectedObjectManager.selectedObjects)
//        {
//            GameObject toggleObject = Instantiate(togglePrefab, toggleContainer);
//            Toggle toggle = toggleObject.GetComponent<Toggle>();
//            toggle.isOn = true; // Установите по умолчанию в "включено"
//            toggle.GetComponentInChildren<Text>().text = obj.name; // Установите текст на имя объекта
//            toggle.onValueChanged.AddListener((isOn) =>
//            {
//                if (isOn)
//                {
//                    // Действия при включении чекбокса
//                    selectedObject.Select();
//                }
//                else
//                {
//                    // Действия при выключении чекбокса
//                    selectedObject.Deselect();
//                }
//            });
//        }
//    }

//    void SetTransparency(float alpha)
//    {
//        foreach(var obj in selectedObjectManager.selectedObjects) 
//        {
//            selectedObject = obj.GetComponent<ItemInfo>();
//            if(selectedObject != null) 
//            {
//                selectedObject.setTransparency(alpha);
//            } 
//        }
//    }

//    void SetColor(Color color)
//    {
//        selectedColor = color; // Сохраняем выбранный цвет
//        foreach (var obj in selectedObjectManager.selectedObjects)
//        {
//            selectedObject = obj.GetComponent<ItemInfo>();
//            if (selectedObject != null)
//            {
//                selectedObject.setColor(selectedColor); // Устанавливаем цвет }
//            }
//        }
//    }

//    void ToggleVisibility(bool isVisible)
//    {
//        Debug.Log("ОН НЕ ИНВИЗ");
//        foreach (var obj in selectedObjectManager.selectedObjects)
//        {
//            selectedObject = obj.GetComponent<ItemInfo>();
//            if (selectedObject != null)
//            {
//                selectedObject.toggleVisibility();
//            }
//        }
//    }

//    public void SelectObject(ItemInfo obj)
//    {
//        selectedObject = obj;
//    }
//}

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

//public class UIController : MonoBehaviour
//{
//    public GameObject panel; // Панель контекстного меню
//    public GameObject buttonPrefab; // Шаблон кнопки
//    public List<GameObject> objects; // Список объектов
//    private List<GameObject> selectedObjects = new List<GameObject>(); // Выделенные объекты

//    void Start()
//    {
//        // Инициализация списка объектов (пример)
//        objects = new List<GameObject>(GameObject.FindGameObjectsWithTag("MyTag")); // Замените на ваш тег
//        panel.SetActive(false); // Скрыть панель по умолчанию
//    }

//    void Update()
//    {
//        if (Input.GetMouseButtonDown(1)) 
//        {// Проверяем нажатие правой кнопки мыши {
//            ShowContextMenu();
//        }
//        if (!panel.activeSelf || !RectTransformUtility.RectangleContainsScreenPoint(panel.GetComponent<RectTransform>(), Input.mousePosition))
//        {       
//            HideContextMenu();

//        }
//        if (Input.GetMouseButtonDown(0))
//        {
//            SelectObjectUnderMouse();
//        }
//    }

//    void ShowContextMenu()
//    {
//        // Получаем озицию мыши и устанавливаеманель
//        Vector3 mousePosition = Input.mousePosition;
//        panel.transform.position = mousePosition;
//        panel.SetActive(true);

//        // Очищаем предыдущие кнопки
//        foreach (Transform child in panel.transform)
//        {
//            if (child.gameObject != buttonPrefab)
//            {
//                Destroy(child.gameObject);
//            }
//        }
//        foreach (GameObject obj in selectedObjects)
//        {
//            GameObject button = Instantiate(buttonPrefab, panel.transform);
//            button.SetActive(true);
//            button.GetComponentInChildren<Text>().text = "Action on " + obj.name; // Пример текста кнопки
//            button.GetComponent<Button>().onClick.AddListener(() => OnActionButtonClicked(obj));
//        }
//        Debug.Log("Последний выбранный объект: " + selectedObjects.Last());
//    }
//    void OnActionButtonClicked(GameObject obj)
//    {
//        // Здесь вы можете добавить функционал для работы с объектом
//        Debug.Log("Action performed on: " + obj.name);
//        // Например, вы можете изменить цвет или выполнить другие действия
//    }

//    void SelectObjectUnderMouse()
//{
//    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//    RaycastHit hit;

//    if (Physics.Raycast(ray, out hit))
//    {
//        GameObject obj = hit.collider.gameObject;

//        if (obj.CompareTag("MyTag")) // Проверяем, что объект имеет тег "Selectable"
//        {
//            if (selectedObjects.Contains(obj))
//            {
//                selectedObjects.Remove(obj); // Убираем из выделенных
//                DeselectObject(obj); // Убираем визуальное выделение
//            }
//            else
//            {
//                selectedObjects.Add(obj); // Добавляем в выделенные
//                SelectObject(obj); // Добавляем визуальное выделение
//            }
//        }
//    }
//}

//void SelectObject(GameObject obj)
//{
//    Renderer renderer = obj.GetComponent<Renderer>();
//    if (renderer != null)
//    {
//        // Сохраняем оригинальный цвет, если нужно
//        Color originalColor = renderer.material.color;
//        // Меняем цвет на выделенный
//        renderer.material.color = Color.yellow; // Цвет выделения
//    }
//}

//void DeselectObject(GameObject obj)
//{
//    Renderer renderer = obj.GetComponent<Renderer>();
//        if (renderer != null)
//        {
//            // Возвращаем оригинальный цвет (если вы его сохранили)
//            renderer.material.color = Color.white;
//        } // Или используйте сохраненный цвет }
//    }

//    public void HideContextMenu()
//    {
//        panel.SetActive(false); // Скрыть панель
//    }
//}

public class UIController : MonoBehaviour
{
    public GameObject panel; // Панель контекстного меню
    public GameObject togglePrefab; // Шаблон Toggle
    public List<GameObject> objects; // Список объектов
    private List<GameObject> selectedObjects = new List<GameObject>(); // Выделенные объекты

    public Slider transparencySlider; // Слайдер для прозрачности
    public Dropdown colorDropdown; // Дропдаун для выбора цвета
    public Toggle visibleToggle;

    void Start()
    {
        objects = new List<GameObject>(GameObject.FindGameObjectsWithTag("MyTag"));
        panel.SetActive(false);

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
        if (!panel.activeSelf || !RectTransformUtility.RectangleContainsScreenPoint(panel.GetComponent<RectTransform>(), Input.mousePosition))
        {
            HideContextMenu();
        }
        if (Input.GetMouseButtonDown(0))
        {
            SelectObjectUnderMouse();
        }
    }

    void ShowContextMenu() 
    { 
    // Получаем позицию мыши и устанавливаем панель
        Vector3 mousePosition = Input.mousePosition;
        panel.transform.position = mousePosition;
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
            toggle.GetComponentInChildren<Text>().text = obj.name; 
            Toggle toggleComponent = toggle.GetComponent<Toggle>();
            toggleComponent.isOn = true; 
            toggleComponent.onValueChanged.AddListener((isOn) => OnToggleChanged(obj, isOn));
        }
    }

    void OnToggleChanged(GameObject obj, bool isOn)
    {
        if (isOn)
        {
            selectedObjects.Add(obj);
        }
        else
        {
            selectedObjects.Remove(obj);
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
            Material material = renderer.material;
            Color color = material.color;
            color.a = value;
            material.color = color;
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
        }
    }

    void DeselectObject(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.white;
        }
    }

    public void HideContextMenu()
    {
        panel.SetActive(false);
        transparencySlider.gameObject.SetActive(false);
        colorDropdown.gameObject.SetActive(false);
        visibleToggle.gameObject.SetActive(false);
    }
}