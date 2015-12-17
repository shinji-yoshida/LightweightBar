using UnityEngine;
using System;

public class WorldSpaceTransformChaser : MonoBehaviour {
	[SerializeField] Transform target;
	Canvas canvasRef;

	protected void Awake () {
		UpdateCanvasReference();
	}

	public void UpdateCanvasReference() {
		canvasRef = transform.GetComponentInParent<Canvas>();
	}
	
	protected void LateUpdate () {
		switch(canvasRef.renderMode) {
		case RenderMode.ScreenSpaceOverlay:
			transform.position = Camera.main.WorldToScreenPoint(target.position);
			return;
		default:
			throw new Exception("not implemented for canvas renderMode " + canvasRef.renderMode.ToString());
		}
	}
}
