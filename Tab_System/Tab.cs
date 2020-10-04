using UnityEngine;
using UnityEngine.UI;

namespace Tab_System
{
    /// <summary>
    /// Tabs are buttons that hold references to other objects.
    /// e.g. menu panels, a group of troups, etc.
    /// Tabs can be selected and can perform actions on their referenced objects.
    /// </summary>
    public abstract class Tab : MonoBehaviour
    {
        [SerializeField]
        protected string tabTag;
        public string TabTag
        {
            get { return tabTag; }
            private set { tabTag = value; }
        }

        [SerializeField]
        protected TabManager tabManager;
        public TabManager TabManager
        {
            get { return tabManager; }
            private set { tabManager = value; }
        }

        [SerializeField]
        protected GameObject reference;
        public GameObject Reference
        {
            get { return reference; }
            private set { reference = value; }
        }

        [SerializeField]
        protected Sprite stdSprite, selectedSprite;

        /// <summary>
        /// Selects this tab.
        /// </summary>
        public virtual void SelectTab()
        {
            Image image;
            if (selectedSprite != null && (image = GetComponent<Image>()) != null)
                image.sprite = selectedSprite;
            tabManager.SelectTab(this);
        }

        /// <summary>
        /// Deselects this tab.
        /// </summary>
        public virtual void DeselectTab()
        {
            Image image;
            if (stdSprite != null && (image = GetComponent<Image>()) != null)
                image.sprite = stdSprite;
        }

        /// <summary>
        /// Deselects this tab.
        /// </summary>
        public void DeselectTab(bool alertManager)
        {
            if (alertManager)
                tabManager.DeselectTab(this);
            else DeselectTab();
        }

        /// <summary>
        /// Commands the referenced object.
        /// </summary>
        /// <param name="command">
        /// The command my object should perform.
        /// </param>
        public void CommandReference(int command)
        {
            ITabable reference;
            if ((reference = this.reference.GetComponent<ITabable>()) != null)
                reference.ReceiveCommand(command);
            else throw TabManager.missingITabable;
        }

        /// <summary>
        /// Changes the object I have reference to.
        /// </summary>
        /// <param name="reference">
        /// My new reference.
        /// </param>
        public void ChangeReference(GameObject reference)
        {
            if (reference.GetComponent<ITabable>() == null)
                throw TabManager.missingITabable;
            this.reference = reference;
        }
    }
}
