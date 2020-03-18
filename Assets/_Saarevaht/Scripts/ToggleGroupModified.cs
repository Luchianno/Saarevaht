using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// [AddComponentMenu("UI/Extensions/Extensions Toggle Group")]
[DisallowMultipleComponent]
public class ToggleGroupModified : UIBehaviour
{
    [SerializeField]
    private bool m_AllowSwitchOff = false;
    public bool AllowSwitchOff { get { return m_AllowSwitchOff; } set { m_AllowSwitchOff = value; } }

    private List<Toggle> m_Toggles = new List<Toggle>();

    [Serializable]
    public class ToggleGroupEvent : UnityEvent<bool>
    { }

    public ToggleGroupEvent onToggleGroupChanged = new ToggleGroupEvent();
    public ToggleGroupEvent onToggleGroupToggleChanged = new ToggleGroupEvent();

    public Toggle SelectedToggle { get; private set; }

    private void ValidateToggleIsInGroup(Toggle toggle)
    {
        if (toggle == null || !m_Toggles.Contains(toggle))
            throw new ArgumentException(string.Format("Toggle {0} is not part of ToggleGroup {1}", new object[] { toggle, this }));
    }

    public void NotifyToggleOn(Toggle toggle)
    {
        ValidateToggleIsInGroup(toggle);

        // disable all toggles in the group
        for (var i = 0; i < m_Toggles.Count; i++)
        {
            if (m_Toggles[i] == toggle)
            {
                SelectedToggle = toggle;
                continue;
            }

            m_Toggles[i].isOn = false;
        }
        onToggleGroupChanged.Invoke(AnyTogglesOn());
    }

    public void UnregisterToggle(Toggle toggle)
    {
        if (m_Toggles.Contains(toggle))
        {
            m_Toggles.Remove(toggle);
            toggle.onValueChanged.RemoveListener(NotifyToggleChanged);
        }
    }

    private void NotifyToggleChanged(bool isOn)
    {
        onToggleGroupToggleChanged.Invoke(isOn);
    }

    public void RegisterToggle(Toggle toggle)
    {
        if (!m_Toggles.Contains(toggle))
        {
            m_Toggles.Add(toggle);
            toggle.onValueChanged.AddListener(NotifyToggleChanged);
        }
    }

    public bool AnyTogglesOn()
    {
        return m_Toggles.Find(x => x.isOn) != null;
    }

    public IEnumerable<Toggle> ActiveToggles()
    {
        return m_Toggles.Where(x => x.isOn);
    }

    public void SetAllTogglesOff()
    {
        bool oldAllowSwitchOff = m_AllowSwitchOff;
        m_AllowSwitchOff = true;

        for (var i = 0; i < m_Toggles.Count; i++)
            m_Toggles[i].isOn = false;

        m_AllowSwitchOff = oldAllowSwitchOff;
    }

    public void HasTheGroupToggle(bool value)
    {
        Debug.Log("Testing, the group has toggled [" + value + "]");
    }

    public void HasAToggleFlipped(bool value)
    {
        Debug.Log("Testing, a toggle has toggled [" + value + "]");
    }
}