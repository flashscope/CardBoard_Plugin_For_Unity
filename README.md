CardBoard_Plugin_For_Unity
==========================

CardBoard For Unity is unity3d plugin for Google cardboard system
https://cardboard.withgoogle.com/

It using cardboard jar file included google cardboard sample 
https://developers.google.com/cardboard/get-started


Include Sample Project
--------------

![](https://github.com/flashscope/CardBoard_Plugin_For_Unity/raw/master/SamplePhoto/debri1.png)
![](https://github.com/flashscope/CardBoard_Plugin_For_Unity/raw/master/SamplePhoto/debri2.png)

Simple Shooting Game (Magnetic function include)
https://github.com/flashscope/CardBoard_Plugin_For_Unity/tree/master/CardBoardForUnity


![](https://github.com/flashscope/CardBoard_Plugin_For_Unity/raw/master/SamplePhoto/ar1.png)

Simple Ar Project
https://github.com/flashscope/CardBoard_Plugin_For_Unity/tree/master/CardBoardARKit/CardBoardARKit


How to use
--------------

![](https://github.com/flashscope/CardBoard_Plugin_For_Unity/raw/master/SamplePhoto/ex00.png)

1. you need export unity3d project by android project



![](https://github.com/flashscope/CardBoard_Plugin_For_Unity/raw/master/SamplePhoto/ex01.png)
![](https://github.com/flashscope/CardBoard_Plugin_For_Unity/raw/master/SamplePhoto/ex02.png)

2. add call method in activity
(screen shot is not good to look plese check code)(Careful with SendMessage Class Name)
https://github.com/flashscope/CardBoard_Plugin_For_Unity/blob/master/CardBoardForUnity/DebrisDefragmentation_Android/Debri_Defragmentation/src/com/limecolor/unity/card_board_for_unity/debris/UnityPlayerNativeActivity.java



3. add Android Manifest (for vibrate If you don't use, you don't need)
https://github.com/flashscope/CardBoard_Plugin_For_Unity/blob/master/CardBoardForUnity/DebrisDefragmentation_Android/Debri_Defragmentation/AndroidManifest.xml



![](https://github.com/flashscope/CardBoard_Plugin_For_Unity/raw/master/SamplePhoto/ex03.png)
4. copy CameraControl.cs in to your unity3d project and change package name to yours
https://github.com/flashscope/CardBoard_Plugin_For_Unity/blob/master/CardBoardForUnity/CardBoardForUnity/Assets/CardBoardLogics/Scripts/CameraControl.cs


