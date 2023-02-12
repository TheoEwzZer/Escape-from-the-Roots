using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

namespace TheoEwzZer.UI
{
    public class CustomDropdown : MonoBehaviour, IPointerExitHandler
    {
        [Header("OBJECTS")]
        public GameObject triggerObject;
        public TextMeshProUGUI selectedText;
        public Transform itemParent;
        public GameObject itemObject;
        public GameObject scrollbar;
        public Transform listParent;
        private Transform currentListParent;
        private VerticalLayoutGroup itemList;

        [Header("SETTINGS")]
        public bool enableTrigger = true;
        public bool enableScrollbar = true;
        public bool setHighPriorty = true;
        public bool outOnPointerExit;
        public bool isListItem;
        public bool invokeAtStart = false;

        [Header("SAVING")]
        public bool saveSelected = false;
        [Tooltip("Note that every Dropdown should has its own unique tag.")]
        public string dropdownTag = "Dropdown";

        [Space(10)]
        [Header("CONTENT")]
        public int selectedItemIndex = 0;
        [SerializeField] public List<Item> dropdownItems = new List<Item>();
        [Space(10)]

        private Animator dropdownAnimator;
        private TextMeshProUGUI setItemText;
        private Image setItemImage;

        Sprite imageHelper;
        string textHelper;
        string newItemTitle;
        Sprite newItemIcon;
        bool isOn;
        [HideInInspector] public int index = 0;
        [HideInInspector] public int siblingIndex = 0;

        [System.Serializable]
        public class Item
        {
            public string itemName = "Dropdown Item";
            public Sprite itemIcon;
            public UnityEvent OnItemSelection;
        }

        void Start()
        {
            dropdownAnimator = gameObject.GetComponent<Animator>();
            itemList = itemParent.GetComponent<VerticalLayoutGroup>();
            SetupDropdown();
            currentListParent = transform.parent;
            if (enableScrollbar) {
                itemList.padding.right = 25;
                scrollbar.SetActive(true);
            } else {
                itemList.padding.right = 8;
                scrollbar.SetActive(false);
            }
            if (setHighPriorty)
                transform.SetAsLastSibling();
            if (saveSelected) {
                if (invokeAtStart)
                    dropdownItems[PlayerPrefs.GetInt(dropdownTag + "Dropdown")].OnItemSelection.Invoke();
                else
                    ChangeDropdownInfo(PlayerPrefs.GetInt(dropdownTag + "Dropdown"));
            }
        }

        public void SetupDropdown()
        {
            foreach (Transform child in itemParent)
                GameObject.Destroy(child.gameObject);
            index = 0;
            for (int i = 0; i < dropdownItems.Count; ++i) {
                GameObject go = Instantiate(itemObject, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                go.transform.SetParent(itemParent, false);
                setItemText = go.GetComponentInChildren<TextMeshProUGUI>();
                textHelper = dropdownItems[i].itemName;
                setItemText.text = textHelper;
                Transform goImage;
                goImage = go.gameObject.transform.Find("Icon");
                setItemImage = goImage.GetComponent<Image>();
                imageHelper = dropdownItems[i].itemIcon;
                setItemImage.sprite = imageHelper;
                Button itemButton;
                itemButton = go.GetComponent<Button>();
                if (dropdownItems[i].OnItemSelection != null)
                    itemButton.onClick.AddListener(dropdownItems[i].OnItemSelection.Invoke);
                itemButton.onClick.AddListener(Animate);
                itemButton.onClick.AddListener(delegate {
                    ChangeDropdownInfo(index = go.transform.GetSiblingIndex());
                    if (saveSelected)
                        PlayerPrefs.SetInt(dropdownTag + "Dropdown", go.transform.GetSiblingIndex());
                });
                if (invokeAtStart)
                    dropdownItems[i].OnItemSelection.Invoke();
            }
            selectedText.text = dropdownItems[selectedItemIndex].itemName;
            currentListParent = transform.parent;
        }

        public void ChangeDropdownInfo(int itemIndex)
        {
            selectedText.text = dropdownItems[itemIndex].itemName;
            selectedItemIndex = itemIndex;
        }

        public void Animate()
        {
            if (!isOn) {
                dropdownAnimator.Play("Dropdown In");
                isOn = true;
                if (isListItem) {
                    siblingIndex = transform.GetSiblingIndex();
                    gameObject.transform.SetParent(listParent, true);
                }
            } else {
                dropdownAnimator.Play("Dropdown Out");
                isOn = false;
                if (isListItem) {
                    gameObject.transform.SetParent(currentListParent, true);
                    gameObject.transform.SetSiblingIndex(siblingIndex);
                }
            }
            if (enableTrigger && !isOn)
                triggerObject.SetActive(false);
            else if (enableTrigger && isOn)
                triggerObject.SetActive(true);
            if (outOnPointerExit)
                triggerObject.SetActive(false);
            if (setHighPriorty)
                transform.SetAsLastSibling();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (outOnPointerExit) {
                if (isOn) {
                    Animate();
                    isOn = false;
                }
                if (isListItem)
                    gameObject.transform.SetParent(currentListParent, true);
            }
        }

        public void UpdateValues()
        {
            if (enableScrollbar) {
                itemList.padding.right = 25;
                scrollbar.SetActive(true);
            } else {
                itemList.padding.right = 8;
                scrollbar.SetActive(false);
            }
        }

        public void CreateNewItem()
        {
            Item item = new Item();
            item.itemName = newItemTitle;
            item.itemIcon = newItemIcon;
            dropdownItems.Add(item);
            SetupDropdown();
        }

        public void CreateNewOption(string title)
        {
            Item item = new Item();
            item.itemName = title;
            dropdownItems.Add(item);
        }

        public void SetItemTitle(string title)
        {
            newItemTitle = title;
        }

        public void SetItemIcon(Sprite icon)
        {
            newItemIcon = icon;
        }
    }
}