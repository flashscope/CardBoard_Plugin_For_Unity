package com.limecolor.unity.card_board_for_unity.debris;

import com.unity3d.player.*;
import android.annotation.SuppressLint;
import android.app.NativeActivity;
import android.content.res.Configuration;
import android.graphics.PixelFormat;
import android.os.Build;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.MotionEvent;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;

import com.google.vrtoolkit.cardboard.sensors.HeadTracker;
import com.google.vrtoolkit.cardboard.sensors.MagnetSensor;
import android.content.Context;
import android.os.Vibrator;
import android.util.Log;

public class UnityPlayerNativeActivity extends NativeActivity implements MagnetSensor.OnCardboardTriggerListener
{
	protected UnityPlayer mUnityPlayer;		// don't change the name of this variable; referenced from native code

	private int currentApiVersion = 0;
	
	// Setup activity layout
	@SuppressLint("NewApi") @Override protected void onCreate (Bundle savedInstanceState)
	{
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		super.onCreate(savedInstanceState);

		getWindow().takeSurface(null);
		setTheme(android.R.style.Theme_NoTitleBar_Fullscreen);
		getWindow().setFormat(PixelFormat.RGB_565);

		currentApiVersion = android.os.Build.VERSION.SDK_INT;

	    final int flags = View.SYSTEM_UI_FLAG_LAYOUT_STABLE
	            | View.SYSTEM_UI_FLAG_LAYOUT_HIDE_NAVIGATION
	            | View.SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN
	            | View.SYSTEM_UI_FLAG_HIDE_NAVIGATION
	            | View.SYSTEM_UI_FLAG_FULLSCREEN
	            | View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY;

	    // This work only for android 4.4+
	    if (currentApiVersion >= 19) {

	        getWindow().getDecorView().setSystemUiVisibility(flags);
	        // Code below is for case when you press Volume up or Volume down.
	        // Without this after pressing valume buttons navigation bar will
	        // show up and don't hide
	        final View decorView = getWindow().getDecorView();
	        decorView
	                .setOnSystemUiVisibilityChangeListener(new View.OnSystemUiVisibilityChangeListener() {

	                    @Override
	                    public void onSystemUiVisibilityChange(int visibility) {
	                        if ((visibility & View.SYSTEM_UI_FLAG_FULLSCREEN) == 0) {
	                            decorView.setSystemUiVisibility(flags);
	                        }
	                    }
	                });
	    }
		

		mUnityPlayer = new UnityPlayer(this);
		if (mUnityPlayer.getSettings ().getBoolean ("hide_status_bar", true))
			getWindow ().setFlags (WindowManager.LayoutParams.FLAG_FULLSCREEN,
			                       WindowManager.LayoutParams.FLAG_FULLSCREEN);

		getWindow().addFlags(WindowManager.LayoutParams.FLAG_KEEP_SCREEN_ON);
		
		setContentView(mUnityPlayer);
		mUnityPlayer.requestFocus();
		
		
		InitializeCardBoard();
	}

	
	private MagnetSensor mMagnetSensor;
	//private NfcSensor mNfcSensor;
	
	private Vibrator mVibrator;
	
	private static HeadTracker mHeadTracker;
	private static float[] mHeadView = new float[16];
	
	
	private void InitializeCardBoard() {
		
	    this.mMagnetSensor = new MagnetSensor(this);
	    this.mMagnetSensor.setOnCardboardTriggerListener(this);
	    
	    
		mVibrator = (Vibrator) getSystemService(Context.VIBRATOR_SERVICE);
		
		
		
		mHeadTracker = new HeadTracker(getApplicationContext());
		
		mHeadTracker.startTracking();
	}
	
	
	public static float[] getHeadMatrix() {
		mHeadTracker.getLastHeadView(mHeadView, 0);
		return mHeadView;
	}
	
	@Override
	public void onCardboardTrigger() {
		mVibrator.vibrate(50);
		UnityPlayer.UnitySendMessage("TriggerInput", "GetTriggerEvent", "");
	}
	
	
	
	
	// Quit Unity
	@Override protected void onDestroy ()
	{
		mUnityPlayer.quit();
		super.onDestroy();
		//this.mNfcSensor.removeOnCardboardNfcListener(this);
	}

	// Pause Unity
	@Override protected void onPause()
	{
		super.onPause();
		mUnityPlayer.pause();
	    this.mMagnetSensor.stop();
	    //this.mNfcSensor.onPause(this);
	}

	// Resume Unity
	@Override protected void onResume()
	{
		super.onResume();
		mUnityPlayer.resume();
	    this.mMagnetSensor.start();
	    //this.mNfcSensor.onResume(this);
	}

	// This ensures the layout will be correct.
	@Override public void onConfigurationChanged(Configuration newConfig)
	{
		super.onConfigurationChanged(newConfig);
		mUnityPlayer.configurationChanged(newConfig);
	}

	// Notify Unity of the focus change.
	@SuppressLint("NewApi")
	@Override public void onWindowFocusChanged(boolean hasFocus)
	{
		super.onWindowFocusChanged(hasFocus);
		mUnityPlayer.windowFocusChanged(hasFocus);
		
		if (currentApiVersion >= 19 && hasFocus) {
	        getWindow().getDecorView().setSystemUiVisibility(
	                View.SYSTEM_UI_FLAG_LAYOUT_STABLE
	                        | View.SYSTEM_UI_FLAG_LAYOUT_HIDE_NAVIGATION
	                        | View.SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN
	                        | View.SYSTEM_UI_FLAG_HIDE_NAVIGATION
	                        | View.SYSTEM_UI_FLAG_FULLSCREEN
	                        | View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY);
	    }
		
	}

	// For some reason the multiple keyevent type is not supported by the ndk.
	// Force event injection by overriding dispatchKeyEvent().
	@Override public boolean dispatchKeyEvent(KeyEvent event)
	{
		if (event.getAction() == KeyEvent.ACTION_MULTIPLE)
			return mUnityPlayer.injectEvent(event);
		return super.dispatchKeyEvent(event);
	}

	// Pass any events not handled by (unfocused) views straight to UnityPlayer
	@Override public boolean onKeyUp(int keyCode, KeyEvent event)     { return mUnityPlayer.injectEvent(event); }
	@Override public boolean onKeyDown(int keyCode, KeyEvent event)   { return mUnityPlayer.injectEvent(event); }
	@Override public boolean onTouchEvent(MotionEvent event)          { return mUnityPlayer.injectEvent(event); }
	/*API12*/ public boolean onGenericMotionEvent(MotionEvent event)  { return mUnityPlayer.injectEvent(event); }


}