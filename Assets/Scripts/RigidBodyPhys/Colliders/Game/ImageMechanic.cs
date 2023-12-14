using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace RigidBodyPhys.Colliders.Game
{
    public class ImageMechanic : MonoBehaviour
    {
        [FormerlySerializedAs("Auer")] public InitObjectType initObjectType;
        public SpriteHandler SpriteHandlerObject;

        public void OnEnable()
        {
            SpriteHandlerObject = new();
            SpriteHandlerObject.LoadRandomSprite();
            initObjectType.Initialize();
        }

        public string ImageCode1;

        public string ImageCategory
        {
            get => imageCategory;
            set => imageCategory = value;
        }

        public int ImageDisplayTime = 3;

        private ImageRenderer imageRenderer;


        public int ToolbarHeight = 70;

        private string imageCategory;
        private UniWebView webView;
        private GameObject loadingIndicator;

        private void Start()
        {
            SetupUI();
            HideLoadingIndicator();

            SetupImageDisplay();
            ChangeImage();

            LoadWebPage(imageCategory);
        }

        [SerializeField] private Image _mainImmage;

        private void ChangeImage()
        {
            _mainImmage.color = Color.blue;
        }

        private void SetupImageDisplay()
        {
            InitializeImageRenderer();

            switch (ImageCategory)
            {
                case "0":
                    imageRenderer.ImageCategory = "First";
                    break;
                default:
                    // Configure default display settings
                    break;
            }

            // Other setup logic...

            // Schedule image change
            InvokeRepeating("ChangeImage", ImageDisplayTime, ImageDisplayTime);
        }

        private void InitializeImageRenderer()
        {
            imageRenderer = new();
        }


        private void SetupUI()
        {
            InitializeWebView();

            switch (ImageCategory)
            {
                case "0":
                    webView.SetShowToolbar(true, false, false, true);
                    break;
                default:
                    webView.SetShowToolbar(false);
                    break;
            }

            webView.Frame = new Rect(0, ToolbarHeight, Screen.width, Screen.height - ToolbarHeight);

            // Other setup logic...

            webView.OnPageFinished += (_, _, url) =>
            {
                if (PlayerPrefs.GetString("LastLoadedPage", string.Empty) == string.Empty)
                {
                    PlayerPrefs.SetString("LastLoadedPage", url);
                }
            };
        }

        private void InitializeWebView()
        {
            webView = GetComponent<UniWebView>();
            if (webView == null)
            {
                webView = gameObject.AddComponent<UniWebView>();
            }

            webView.OnShouldClose += _ => false;

            // Other initialization logic...
        }

        private void LoadWebPage(string item)
        {
//            print((item));
            if (!string.IsNullOrEmpty(item))
            {
                webView.Load(item);
            }
        }

        private void HideLoadingIndicator()
        {
            if (loadingIndicator != null)
            {
                loadingIndicator.SetActive(false);
            }
        }
    }
}