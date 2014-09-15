using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public bool headTrackingOn = true;

	void Start () {

		#if UNITY_ANDROID
			StopAllCoroutines();
			StartCoroutine(  HeadTrackingProcess() );
		#endif
	}

	IEnumerator HeadTrackingProcess()
	{
		yield return null;

		AndroidJavaClass jc = new AndroidJavaClass("com.limecolor.unity.card_board_for_unity.debris.UnityPlayerNativeActivity");
		Matrix4x4 matrix = new Matrix4x4();

		while( headTrackingOn )
		{

			float[] M = jc.CallStatic<float[]> ("getHeadMatrix");
			
			matrix.SetColumn(0, new Vector4(M[0], M[4], -M[8], M[12]) );
			matrix.SetColumn(1, new Vector4(M[1], M[5], -M[9], M[13]) );
			matrix.SetColumn(2, new Vector4(-M[2], -M[6], M[10], M[14]) );
			matrix.SetColumn(3, new Vector4(M[3], M[7], M[11], M[15]) );
			
			TransformFromMatrix (matrix, gameObject.transform);

			yield return new WaitForEndOfFrame();
		}
	
	}

	public static void TransformFromMatrix(Matrix4x4 matrix, Transform trans) {
		trans.rotation = QuaternionFromMatrix(matrix);
		trans.position = matrix.GetColumn(3); // uses implicit conversion from Vector4 to Vector3
	}
	
	public static Quaternion QuaternionFromMatrix(Matrix4x4 m) {
		Quaternion q = new Quaternion();
		q.w = Mathf.Sqrt( Mathf.Max( 0, 1 + m[0,0] + m[1,1] + m[2,2] ) ) / 2; 
		q.x = Mathf.Sqrt( Mathf.Max( 0, 1 + m[0,0] - m[1,1] - m[2,2] ) ) / 2; 
		q.y = Mathf.Sqrt( Mathf.Max( 0, 1 - m[0,0] + m[1,1] - m[2,2] ) ) / 2; 
		q.z = Mathf.Sqrt( Mathf.Max( 0, 1 - m[0,0] - m[1,1] + m[2,2] ) ) / 2; 
		q.x *= Mathf.Sign( q.x * ( m[2,1] - m[1,2] ) );
		q.y *= Mathf.Sign( q.y * ( m[0,2] - m[2,0] ) );
		q.z *= Mathf.Sign( q.z * ( m[1,0] - m[0,1] ) );
		return q;
	}
}
