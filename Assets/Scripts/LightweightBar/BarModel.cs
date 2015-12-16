using UnityEngine;

namespace LightweightBar {

	[System.Serializable]
	public struct BarModel {
		[SerializeField] float minValue;
		[HideInInspector, SerializeField] float minValueCache;
		[SerializeField] float maxValue;
		[SerializeField] float currentValue;

		public BarModel(float minValue, float maxValue, float currentValue) {
			this.minValue = minValue;
			this.minValueCache = minValue;
			this.maxValue = maxValue;
			this.currentValue = currentValue;
		}

		public float MinValue {
			get {
				return this.minValue;
			}
		}

		public float MaxValue {
			get {
				return this.maxValue;
			}
		}

		public float CurrentValue {
			get {
				return this.currentValue;
			}
		}

		public float NormalizedValue {
			get {
				return (currentValue - minValue) / (maxValue - minValue);
			}
		}

		void Clamp() {
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

}