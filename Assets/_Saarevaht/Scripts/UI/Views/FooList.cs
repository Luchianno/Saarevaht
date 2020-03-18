// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;
// using UnityEngine.UI;
// using Zenject;
// using System;

// public class FooList<TEelement, TFactory> : MonoBehaviour
//     where TEelement : class
//     // where TFactory : IFactory
// {
// Dictionary

//     public PrefabInstance Data
//     {
//         get { return data; }
//         set
//         {
//             data = value;
//             UpdateView();
//         }
//     }

//     public RectTransform Parent;

//     public void Clear()
//     {
//         foreach (RectTransform item in Parent)
//         {
//             Destroy(item.gameObject);
//         }

//         foreach (var item in cache.Keys)
//         {
//             Destroy(item.gameObject);
//         }
//         cache.Clear();

//         activeToggles.Clear();
//     }

//     public void Load(IEnumerable<T> list)
//     {
//         Clear();

//         foreach (var item in list)
//         {
//             var temp = Instantiate(prefab, parent, false);
//             var toggle = temp.GetComponent<ExtensionsToggle>();
//             var textComponent = temp.GetComponentInChildren<TextMeshProUGUI>();

//             toggle.onToggleChanged.AddListener(OnToggleChanged);
//             textComponent.text = item;

//             cache.Add(toggle, item);
//         }
//     }
// }
