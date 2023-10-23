using GameFramework.Customize;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityGameFramework.Runtime;
using Cinemachine;
using UnityEngine.Rendering;

namespace GameName
{
    public class CameraComponent : CustomizeComponent, ICustomizeModule
    {
        public Camera PrebootCamera;
        public Camera MainCamera;
        private Camera UICamera;
        public CinemachineVirtualCamera virtualCamera;
        private CinemachineFramingTransposer FramingTrans;

        protected override void Awake()
        {
            base.Awake();
            base.AddModel(this);

            SetUICamera();
            SetVirtualCamera();
        }
        private void Start()
        {
            PrebootCamera = this.transform.GetComponentInChildren<Camera>();
            PrebootCamera.GetUniversalAdditionalCameraData().cameraStack.Add(UICamera);
        }

        public void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {

        }

        private void SetVirtualCamera()
        {

            virtualCamera = new GameObject("CM vcam").AddComponent<CinemachineVirtualCamera>();
            //virtualCamera.transform.Rotate(new Vector3(0, 0, 0));
            virtualCamera.transform.SetParent(this.transform);
            virtualCamera.m_Lens.OrthographicSize = 5;
            FramingTrans = virtualCamera.AddCinemachineComponent<CinemachineFramingTransposer>();
            FramingTrans.m_TrackedObjectOffset = new Vector3(0f, 0, 0f);
            virtualCamera.gameObject.SetActive(false);
        }


        public void SetMainCamera(Camera mainCamera)
        {
            MainCamera = mainCamera;
            MainCamera.GetUniversalAdditionalCameraData().cameraStack.Add(UICamera);
            PrebootCamera.gameObject.SetActive(false);
        }

        public void SetUICamera()
        {
            UICamera = new GameObject("UICamera").AddComponent<Camera>();
            UICamera.transform.SetParent(this.transform);
            UICamera.GetUniversalAdditionalCameraData().renderType = CameraRenderType.Overlay;
            UICamera.cullingMask = LayerMask.GetMask("UI");
            UICamera.orthographic = true;

        }
        public Vector2 GetObjUIPos(RectTransform canvasRectTransform, Vector3 pos_)
        {
            Vector2 UICameraPostion = Vector2.zero;
            Vector2 ScreenPos = RectTransformUtility.WorldToScreenPoint(MainCamera, pos_);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, ScreenPos, UICamera, out UICameraPostion);
            return UICameraPostion;
        }
        public Vector2 GetMouseUIPos(RectTransform canvasRectTransform, Vector2 pos_)
        {
            Vector2 mouseUIPostion = Vector2.zero;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, pos_, UICamera, out mouseUIPostion);
            return mouseUIPostion;
        }

        public void SetUIRenderer(int Index)
        {
            UICamera.GetUniversalAdditionalCameraData().SetRenderer(Index);
        }
        public void OpenVirtualCamera(bool isAc)
        {
            if (virtualCamera != null)
            {
                virtualCamera.gameObject.SetActive(isAc);
                if (!isAc)
                    virtualCamera.Follow = null;
            }
        }
        //private void OnDestroy()
        //{
        //    if (GameEntry.Event.Check(EventName.RotatingLensSlider, RotatingLensEvent))
        //    {
        //        GameEntry.Event.Unsubscribe(EventName.RotatingLensSlider, RotatingLensEvent);
        //    }
        //    if (GameEntry.Event.Check(EventName.RotatingLensOpen, RotatingLensOpenEvent))
        //    {
        //        GameEntry.Event.Unsubscribe(EventName.RotatingLensOpen, RotatingLensOpenEvent);
        //    }
        //}
        public object GetData()
        {
            return UICamera;
        }


    }
}

