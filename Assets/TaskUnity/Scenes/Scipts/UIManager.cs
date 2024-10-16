using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public class UIManager : MonoBehaviour
//{
//    public ItemInfo selectedObject; // ������, � ������� ���������������
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
//            toggle.isOn = true; // ���������� �� ��������� � "��������"
//            toggle.GetComponentInChildren<Text>().text = obj.name; // ���������� ����� �� ��� �������
//            toggle.onValueChanged.AddListener((isOn) =>
//            {
//                if (isOn)
//                {
//                    // �������� ��� ��������� ��������
//                    selectedObject.Select();
//                }
//                else
//                {
//                    // �������� ��� ���������� ��������
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
//        selectedColor = color; // ��������� ��������� ����
//        foreach (var obj in selectedObjectManager.selectedObjects)
//        {
//            selectedObject = obj.GetComponent<ItemInfo>();
//            if (selectedObject != null)
//            {
//                selectedObject.setColor(selectedColor); // ������������� ���� }
//            }
//        }
//    }

//    void ToggleVisibility(bool isVisible)
//    {
//        Debug.Log("�� �� �����");
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
//    public GameObject panel; // ������ ������������ ����
//    public GameObject buttonPrefab; // ������ ������
//    public List<GameObject> objects; // ������ ��������
//    private List<GameObject> selectedObjects = new List<GameObject>(); // ���������� �������

//    void Start()
//    {
//        // ������������� ������ �������� (������)
//        objects = new List<GameObject>(GameObject.FindGameObjectsWithTag("MyTag")); // �������� �� ��� ���
//        panel.SetActive(false); // ������ ������ �� ���������
//    }

//    void Update()
//    {
//        if (Input.GetMouseButtonDown(1)) 
//        {// ��������� ������� ������ ������ ���� {
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
//        // �������� ������ ���� � ������������������
//        Vector3 mousePosition = Input.mousePosition;
//        panel.transform.position = mousePosition;
//        panel.SetActive(true);

//        // ������� ���������� ������
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
//            button.GetComponentInChildren<Text>().text = "Action on " + obj.name; // ������ ������ ������
//            button.GetComponent<Button>().onClick.AddListener(() => OnActionButtonClicked(obj));
//        }
//        Debug.Log("��������� ��������� ������: " + selectedObjects.Last());
//    }
//    void OnActionButtonClicked(GameObject obj)
//    {
//        // ����� �� ������ �������� ���������� ��� ������ � ��������
//        Debug.Log("Action performed on: " + obj.name);
//        // ��������, �� ������ �������� ���� ��� ��������� ������ ��������
//    }

//    void SelectObjectUnderMouse()
//{
//    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//    RaycastHit hit;

//    if (Physics.Raycast(ray, out hit))
//    {
//        GameObject obj = hit.collider.gameObject;

//        if (obj.CompareTag("MyTag")) // ���������, ��� ������ ����� ��� "Selectable"
//        {
//            if (selectedObjects.Contains(obj))
//            {
//                selectedObjects.Remove(obj); // ������� �� ����������
//                DeselectObject(obj); // ������� ���������� ���������
//            }
//            else
//            {
//                selectedObjects.Add(obj); // ��������� � ����������
//                SelectObject(obj); // ��������� ���������� ���������
//            }
//        }
//    }
//}

//void SelectObject(GameObject obj)
//{
//    Renderer renderer = obj.GetComponent<Renderer>();
//    if (renderer != null)
//    {
//        // ��������� ������������ ����, ���� �����
//        Color originalColor = renderer.material.color;
//        // ������ ���� �� ����������
//        renderer.material.color = Color.yellow; // ���� ���������
//    }
//}

//void DeselectObject(GameObject obj)
//{
//    Renderer renderer = obj.GetComponent<Renderer>();
//        if (renderer != null)
//        {
//            // ���������� ������������ ���� (���� �� ��� ���������)
//            renderer.material.color = Color.white;
//        } // ��� ����������� ����������� ���� }
//    }

//    public void HideContextMenu()
//    {
//        panel.SetActive(false); // ������ ������
//    }
//}

public class UIController : MonoBehaviour
{
    public GameObject panel; // ������ ������������ ����
    public GameObject togglePrefab; // ������ Toggle
    public List<GameObject> objects; // ������ ��������
    private List<GameObject> selectedObjects = new List<GameObject>(); // ���������� �������

    public Slider transparencySlider; // ������� ��� ������������
    public Dropdown colorDropdown; // �������� ��� ������ �����
    public Toggle visibleToggle;

    void Start()
    {
        objects = new List<GameObject>(GameObject.FindGameObjectsWithTag("MyTag"));
        panel.SetActive(false);

        colorDropdown.ClearOptions();
        transparencySlider.gameObject.SetActive(false);
        colorDropdown.gameObject.SetActive(false);
        visibleToggle.gameObject.SetActive(false);
        colorDropdown.AddOptions(new List<string> { "�������", "�������", "�����", "������", "�����" });
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
    // �������� ������� ���� � ������������� ������
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
        Color selectedColor = Color.white;  // �� ��������� �����
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