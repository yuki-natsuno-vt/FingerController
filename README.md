# FingerController
UnityでHumanoidモデルの指をジョイパッドなどから操作するためのスクリプトです。

## 出来る事
指定したHumanoidモデルの各指ボーンをキーボードやジョイパッドから簡単に制御できます。
[EVMC4U](https://github.com/gpsnmeajp/EasyVirtualMotionCaptureForUnity)を使用している場合は、自動ロードされたモデルに対しても機能します。

## 既知の問題点
Unityの仕組み上アプリウインドウがアクティブではない場合は入力を受け付けません。
Unityエディタ上ではGameウインドウ、ビルド済の場合はアプリのウインドウがアクティブな状態で入力操作を行う必要があります。

## 使い方
### 導入
1. パッケージをダウンロードして、Unityにインポートします。

2. FingerControllerフォルダ内のFingerController.prefabをシーンに追加します。

3. 追加したシーン上のFingerControllerのInspectorのFinger Controller (Script)のModelプロパティにHumanoidモデルを設定します。
   - EVMC4Uを利用している場合はシーン上のExternalReceiverをFinger Controller (Script)のExternalReceiverプロパティに設定すると、実行時に自動ロードされるVRMモデルが自動でModelに設定されます。

### 調整
1. Scripts/FingerController.cs を開きます。
   - 各指に対しキーコードを設定します。コード内の [UpdateFingerBendingRate](https://github.com/yuki-natsuno-vt/FingerController/blob/4df93bc010084142a0246a3cadb0ce6407808121/FingerController/Scripts/FingerController.cs#L100) を呼び出している箇所を任意のキー、またはボタンに変更します。
   - キーやボタンのKeyCodeが分からない場合はシーン上のFingerControllerのInspectorのFinger Controller (Script)のIs Key Code Debug Print Enabled にチェックを入れるとUnity下部のコンソール表示に入力対応したKeyCodeが表示されます。

2. 指の角度調整では曲げるための[軸](https://github.com/yuki-natsuno-vt/FingerController/blob/4df93bc010084142a0246a3cadb0ce6407808121/FingerController/Scripts/FingerController.cs#L101)と第一～第三関節の[角度](https://github.com/yuki-natsuno-vt/FingerController/blob/4df93bc010084142a0246a3cadb0ce6407808121/FingerController/Scripts/FingerController.cs#L103)を指定する必要があります。
   - 親指の回転軸は特殊な場合が多く、付け根(第一関節)だけはX軸での回転になるようにしています。

