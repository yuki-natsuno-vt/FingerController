using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerController : MonoBehaviour
{
    public GameObject _externalReceiver; // EVMC4U

    public GameObject _model = null; // VRMモデル EVMC4Uを使う場合は自動で読み込む

    // 各指の曲げ割合
    private float _leftThumbRate = 0;
    private float _leftIndexRate = 0;
    private float _leftMiddleRate = 0;
    private float _leftRingRate = 0;
    private float _leftLittleRate = 0;
    private float _rightThumbRate = 0;
    private float _rightIndexRate = 0;
    private float _rightMiddleRate = 0;
    private float _rightRingRate = 0;
    private float _rightLittleRate = 0;
    
    public float _angularVelocity = 0.1f; // 一回の更新で曲げる割合

    public bool _isKeyCodeDebugPrintEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    void UpdateFingerBendingRate(KeyCode keyCode, ref float ratio)
    {
        if (Input.GetKey(keyCode))
        {
            ratio += _angularVelocity;
            if (ratio >= 1.0f) {
                ratio = 1.0f;
            }
        }
        else
        {
            ratio -= _angularVelocity;
            if (ratio < 0) {
                ratio = 0;
            }
        }
    }

    Transform GetBoneTransform(HumanBodyBones bone)
    {
        if (_model == null)
        {
            return null;
        }
        return _model.GetComponent<Animator>().GetBoneTransform(bone);
    }

    void DebugPrintJoystickButton()
    {
        foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                Debug.Log(keyCode.ToString());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isKeyCodeDebugPrintEnabled)
        {
            DebugPrintJoystickButton(); // ジョイパッドのキーコード確認用. Unityのコンソールにログが表示されます.
            return;
        }

        if (_externalReceiver != null)
        {
            var receiverModel = _externalReceiver.GetComponent<EVMC4U.ExternalReceiver>().Model;

            if (_model != receiverModel)
            {
                _model = receiverModel;
            }
        }

        if (_model != null)
        {
            var axis = Vector3.zero;
            /*
             Note
             モデルによって指の向きがXYZ軸に水平、垂直ではない場合があるので
             指ごとに曲げる軸を指定する必要があります。
             親指の根元（第一関節）のみX軸の回転にしています。
             */
            // 左手
            UpdateFingerBendingRate(KeyCode.Joystick1Button0, ref _leftThumbRate);
            axis = new Vector3(0, -1, 0);
            GetBoneTransform(HumanBodyBones.LeftThumbProximal).localRotation = Quaternion.Euler(new Vector3(_leftThumbRate * 50, 0, 0));
            GetBoneTransform(HumanBodyBones.LeftThumbIntermediate).localRotation = Quaternion.AngleAxis(_leftThumbRate * 50, axis);
            GetBoneTransform(HumanBodyBones.LeftThumbDistal).localRotation = Quaternion.AngleAxis(_leftThumbRate * 50, axis);

            UpdateFingerBendingRate(KeyCode.Joystick1Button1, ref _leftIndexRate);
            axis = new Vector3(0.1f, 0, 1);
            GetBoneTransform(HumanBodyBones.LeftIndexProximal).localRotation = Quaternion.AngleAxis(_leftIndexRate * 70, axis);
            GetBoneTransform(HumanBodyBones.LeftIndexIntermediate).localRotation = Quaternion.AngleAxis(_leftIndexRate * 120, axis);
            GetBoneTransform(HumanBodyBones.LeftIndexDistal).localRotation = Quaternion.AngleAxis(_leftIndexRate * 70, axis);

            UpdateFingerBendingRate(KeyCode.Joystick1Button2, ref _leftMiddleRate);
            axis = new Vector3(0, 0, 1);
            GetBoneTransform(HumanBodyBones.LeftMiddleProximal).localRotation = Quaternion.AngleAxis(_leftMiddleRate * 70, axis);
            GetBoneTransform(HumanBodyBones.LeftMiddleIntermediate).localRotation = Quaternion.AngleAxis(_leftMiddleRate * 120, axis);
            GetBoneTransform(HumanBodyBones.LeftMiddleDistal).localRotation = Quaternion.AngleAxis(_leftMiddleRate * 70, axis);

            UpdateFingerBendingRate(KeyCode.Joystick1Button3, ref _leftRingRate);
            axis = new Vector3(0, 0, 1);
            GetBoneTransform(HumanBodyBones.LeftRingProximal).localRotation = Quaternion.AngleAxis(_leftRingRate * 70, axis);
            GetBoneTransform(HumanBodyBones.LeftRingIntermediate).localRotation = Quaternion.AngleAxis(_leftRingRate * 120, axis);
            GetBoneTransform(HumanBodyBones.LeftRingDistal).localRotation = Quaternion.AngleAxis(_leftRingRate * 70, axis);

            UpdateFingerBendingRate(KeyCode.Joystick1Button4, ref _leftLittleRate);
            axis = new Vector3(-0.1f, 0, 1);
            GetBoneTransform(HumanBodyBones.LeftLittleProximal).localRotation = Quaternion.AngleAxis(_leftLittleRate * 70, axis);
            GetBoneTransform(HumanBodyBones.LeftLittleIntermediate).localRotation = Quaternion.AngleAxis(_leftLittleRate * 120, axis);
            GetBoneTransform(HumanBodyBones.LeftLittleDistal).localRotation = Quaternion.AngleAxis(_leftLittleRate * 70, axis);

            // 右手
            UpdateFingerBendingRate(KeyCode.Joystick1Button5, ref _rightThumbRate);
            axis = new Vector3(0, 1, 0);
            GetBoneTransform(HumanBodyBones.RightThumbProximal).localRotation = Quaternion.Euler(new Vector3(_rightThumbRate * 50, 0, 0));
            GetBoneTransform(HumanBodyBones.RightThumbIntermediate).localRotation = Quaternion.AngleAxis(_rightThumbRate * 50, axis);
            GetBoneTransform(HumanBodyBones.RightThumbDistal).localRotation = Quaternion.AngleAxis(_rightThumbRate * 50, axis);

            UpdateFingerBendingRate(KeyCode.Joystick1Button6, ref _rightIndexRate);
            axis = new Vector3(-0.1f, 0, 1);
            GetBoneTransform(HumanBodyBones.RightIndexProximal).localRotation = Quaternion.AngleAxis(_rightIndexRate * -50, axis);
            GetBoneTransform(HumanBodyBones.RightIndexIntermediate).localRotation = Quaternion.AngleAxis(_rightIndexRate * -120, axis);
            GetBoneTransform(HumanBodyBones.RightIndexDistal).localRotation = Quaternion.AngleAxis(_rightIndexRate * -70, axis);

            UpdateFingerBendingRate(KeyCode.Joystick1Button7, ref _rightMiddleRate);
            axis = new Vector3(0, 0, 1);
            GetBoneTransform(HumanBodyBones.RightMiddleProximal).localRotation = Quaternion.AngleAxis(_rightMiddleRate * -50, axis);
            GetBoneTransform(HumanBodyBones.RightMiddleIntermediate).localRotation = Quaternion.AngleAxis(_rightMiddleRate * -120, axis);
            GetBoneTransform(HumanBodyBones.RightMiddleDistal).localRotation = Quaternion.AngleAxis(_rightMiddleRate * -70, axis);

            UpdateFingerBendingRate(KeyCode.Joystick1Button8, ref _rightRingRate);
            axis = new Vector3(0, 0, 1);
            GetBoneTransform(HumanBodyBones.RightRingProximal).localRotation = Quaternion.AngleAxis(_rightRingRate * -50, axis);
            GetBoneTransform(HumanBodyBones.RightRingIntermediate).localRotation = Quaternion.AngleAxis(_rightRingRate * -120, axis);
            GetBoneTransform(HumanBodyBones.RightRingDistal).localRotation = Quaternion.AngleAxis(_rightRingRate * -70, axis);

            UpdateFingerBendingRate(KeyCode.Joystick1Button9, ref _rightLittleRate);
            axis = new Vector3(0.1f, 0, 1);
            GetBoneTransform(HumanBodyBones.RightLittleProximal).localRotation = Quaternion.AngleAxis(_rightLittleRate * -50, axis);
            GetBoneTransform(HumanBodyBones.RightLittleIntermediate).localRotation = Quaternion.AngleAxis(_rightLittleRate * -120, axis);
            GetBoneTransform(HumanBodyBones.RightLittleDistal).localRotation = Quaternion.AngleAxis(_rightLittleRate * -70, axis);
        }
    }
}
