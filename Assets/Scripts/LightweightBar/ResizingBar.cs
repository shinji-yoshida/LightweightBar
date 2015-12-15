using UnityEngine;
using System.Collections;

namespace LightweightBar {

	[System.Serializable]
	public struct BarModel {
		public float minValue;
		[HideInInspector, SerializeField] float minValueCache;
		public float maxValue;
		public float currentValue;

		public BarModel(float minValue, float maxValue, float currentValue) {
			this.minValue = minValue;
			this.minValueCache = minValue;
			this.maxValue = maxValue;
			this.currentValue = currentValue;
		}

		public void Clamp() {
			if(currentValue < minValue)
				currentValue = minValue;
			else if(currentValue > maxValue)
				currentValue = maxValue;
		}

		public void FixParameter() {
			if(minValue > maxValue)
				FixMinValueContradiciton();
			Clamp();
			UpdateMinValueCache();
		}

		void FixMinValueContradiciton() {
			if(minValue != minValueCache)
				minValue = minValueCache;

			if(minValue > maxValue)
				maxValue = minValue;
		}

		void UpdateMinValueCache() {
			minValueCache = minValue;
		}
	}

	public class ResizingBar : MonoBehaviour {
		[SerializeField] BarModel barModel;
		[SerializeField] RectTransform frame;
		[SerializeField] RectTransform bar;

		// Use this for initialization
		void Start () {
		
		}

		protected void OnValidate() {
			barModel.FixParameter();
			Debug.Log("val");
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}

}