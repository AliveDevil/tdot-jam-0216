using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UIStack : MonoBehaviour
{
	[SerializeField]
	private UIView currentView;
	[SerializeField]
	private UIView initialView;
	[SerializeField]
	private Stack<UIView> openGameObjects;
	[SerializeField]
	private RectTransform parent;
	[SerializeField]
	private UIView parentView;

	public UIView CurrentView
	{
		get
		{
			return currentView;
		}
	}

	public UIStack ParentStack
	{
		get
		{
			return parentView != null ? parentView.UIStack : null;
		}
	}

	public UIView ParentView
	{
		get
		{
			return parentView;
		}
		set
		{
			parentView = value;
		}
	}

	public void Back(int index)
	{
		while (openGameObjects.Count > index + 1)
			Pop();
		UpdateCurrentView();
	}

	public void Clear()
	{
		while (openGameObjects.Count > 0)
			PopInternal();
		UpdateCurrentView();
	}

	public bool IsOpen(Type type)
	{
		foreach (var item in openGameObjects)
		{
			if (item.GetType() == type)
				return true;
		}
		return false;
	}

	public void Pop()
	{
		PopInternal();
		ActivateLast();
		UpdateCurrentView();
	}

	public TView Push<TView>(TView view) where TView : UIView
	{
		var instance = Create(view);
		DisableLast();
		openGameObjects.Push(instance);
		UpdateCurrentView();
		return instance;
	}

	public TView PushInstance<TView>(TView view) where TView : UIView
	{
		Initialize(view);
		DisableLast();
		PushInternal(view);
		UpdateCurrentView();
		return view;
	}

	public TView Replace<TView>(TView view) where TView : UIView
	{
		PopInternal();
		var instance = Create(view);
		PushInstance(instance);
		ActivateLast();
		UpdateCurrentView();
		return instance;
	}

	public TView ReplaceInstance<TView>(TView view) where TView : UIView
	{
		PopInternal();
		PushInstance(view);
		ActivateLast();
		UpdateCurrentView();
		return view;
	}

	public TView Set<TView>(TView view) where TView : UIView
	{
		Clear();
		return Push(view);
	}

	public TView SetInstance<TView>(TView view) where TView : UIView
	{
		Clear();
		return PushInstance(view);
	}

	private void ActivateLast()
	{
		if (openGameObjects.Count < 1)
			return;
		openGameObjects.Peek().gameObject.SetActive(true);
	}

	private void Awake()
	{
		openGameObjects = new Stack<UIView>();
	}

	private TView Create<TView>(TView view) where TView : UIView
	{
		TView instance = Instantiate(view);
		Initialize(instance);
		return instance;
	}

	private void DisableLast()
	{
		if (openGameObjects.Count < 1)
			return;
		openGameObjects.Peek().gameObject.SetActive(false);
	}

	private void Initialize<TView>(TView view) where TView : UIView
	{
		view.transform.SetParent(parent, false);
		view.UIStack = this;
	}

	private void PopInternal()
	{
		if (openGameObjects.Count < 1)
			return;
		UIView view = openGameObjects.Pop();
		Destroy(view.gameObject);
	}

	private void PushInternal<TView>(TView view) where TView : UIView
	{
		openGameObjects.Push(view);
	}

	private void Start()
	{
		Set(initialView);
	}

	private void UpdateCurrentView()
	{
		currentView = openGameObjects.Count > 0 ? openGameObjects.Peek() : null;
	}
}
