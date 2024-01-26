using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Stack<UI_Popup> popupStack = new();
    private GameObject root;
    private UI_Hover currentHover;

    private int currentOrder;

    private void Start()
    {
        root = GameObject.Find("@UI_Root");
        if (root == null)
            root = new GameObject("@UI_Root");

        currentHover = null;
        currentOrder = 10;
    }

    public T ShowPopup<T>(string name) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject _go = GameManager.Resource.Instantiate($"UI/Popup/{name}", root.transform);
        T _scene = _go.GetOrAddComponent<T>();
        SetCanvas(_go, true);
        popupStack.Push(_scene);

        return _scene;
    }

    public void ClosePopup(UI_Popup popup)
    {
        if (popupStack.Count <= 0)
            return;

        if (popupStack.Peek() != popup)
            return;

        ClosePopup();
    }

    public void ClosePopup()
    {
        if (popupStack.Count <= 0)
            return;

        UI_Base _popup = popupStack.Pop();
        if (_popup != null)
        {
            GameManager.Resource.Destroy(_popup.gameObject);
        }
        currentOrder--;
    }

    public void CloseAllPopup()
    {
        while (popupStack.Count > 0)
            ClosePopup();
    }

    public T ShowHover<T>(string name, Vector2 position) where T : UI_Hover
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        if (currentHover != null)
            GameManager.Resource.Destroy(currentHover.gameObject);

        GameObject _go = GameManager.Resource.Instantiate($"UI/Hover/{name}", root.transform);
        _go.transform.position = position;
        SetCanvas(_go, true);
        T _hover = _go.GetOrAddComponent<T>();
        currentHover = _hover;

        return _hover;
    }

    public void CloseHover()
    {
        GameManager.Resource.Destroy(currentHover.gameObject);
        currentHover = null;
    }

    private void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas _canvas = go.GetOrAddComponent<Canvas>();
        _canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        _canvas.overrideSorting = true;

        if (sort)
        {
            _canvas.sortingOrder = currentOrder;
            currentOrder++;
        }
        else
        {
            _canvas.sortingOrder = 0;
        }
    }
}
