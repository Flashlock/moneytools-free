using System.Collections.Generic;
using UnityEngine;

namespace Tab_System {
    /// <summary>
    /// The manager for all of the tabs to be controlled.
    /// </summary>
    public abstract class TabManager : MonoBehaviour
    {
        public static MissingComponentException missingITabable =
            new MissingComponentException("Reference Object Does Not Implement ITabable");

        [SerializeField]
        protected List<Tab> tabs;
        public List<Tab> Tabs
        {
            get { return tabs; }
            protected set { tabs = value; }
        }

        public Tab selectedTab { get; protected set; }

        /// <summary>
        /// Selects a Tab.
        /// </summary>
        /// <param name="tab">
        /// The Tab to be selected.
        /// </param>
        public void SelectTab(Tab tab)
        {
            if (selectedTab != null) selectedTab.DeselectTab();
            selectedTab = tab;
        }

        /// <summary>
        /// Deselects a Tab
        /// </summary>
        /// <param name="tab">
        /// The Tab to be deselected.
        /// </param>
        public void DeselectTab(Tab tab)
        {
            tab.DeselectTab();
            if (selectedTab == tab)
                selectedTab = null;
        }

        /// <summary>
        /// Clears my selected Tab.
        /// </summary>
        public void ClearSelection()
        {
            if (selectedTab != null)
            {
                selectedTab.DeselectTab();
                selectedTab = null;
            }
        }

        /// <summary>
        /// Changes a Tab's Reference Object.
        /// </summary>
        /// <param name="tab">
        /// The Tab to change.
        /// </param>
        /// <param name="reference">
        /// The Object the tab should reference.
        /// </param>
        public void ChangeReference(Tab tab, GameObject reference)
        {
            tab.ChangeReference(reference);
        }

        /// <summary>
        /// Changes a Tab's Reference Object.
        /// </summary>
        /// <param name="tag">
        /// The name of the Tab to change.
        /// </param>
        /// <param name="reference">
        /// The Object the tab should reference.
        public void ChangeReference(string tag, GameObject reference)
        {
            GetTab(tag).ChangeReference(reference);
        }

        /// <summary>
        /// Adds a Tab to manaage.
        /// </summary>
        /// <param name="tab">
        /// The Tab to add.
        /// </param>
        public virtual void AddTab(Tab tab)
        {
            tabs.Add(tab);
        }

        /// <summary>
        /// Removes a Tab from my management.
        /// </summary>
        /// <param name="tab">
        /// The Tab to remove.
        /// </param>
        /// <returns>
        /// If the Tab was present to be removed.
        /// </returns>
        public virtual bool RemoveTab(Tab tab)
        {
            return tabs.Remove(tab);
        }

        /// <summary>
        /// Removes a Tab based on its tag.
        /// </summary>
        /// <param name="tag">
        /// The Tab's tag.
        /// </param>
        /// <returns>
        /// The Tab removed, or null if not present.
        /// </returns>
        public virtual Tab RemoveTab(string tag)
        {
            Tab tab = GetTab(tag);
            if (tab != null)
                tabs.Remove(tab);
            return tab;
        }

        /// <summary>
        /// Gets a Tab from my management based on its tag.
        /// </summary>
        /// <param name="tag">
        /// The name of the Tab.
        /// </param>
        /// <returns>
        /// The Tab found, null if not found.
        /// </returns>
        public Tab GetTab(string tag)
        {
            return tabs.Find(t => t.TabTag.CompareTo(tag) == 0);
        }

        /// <summary>
        /// Commands the selected tab's reference.
        /// </summary>
        /// <param name="command">
        /// The command the reference must perform.
        /// </param>
        public void CommandSelectedTab(int command)
        {
            if (selectedTab != null)
                selectedTab.CommandReference(command);
        }
    }
}
