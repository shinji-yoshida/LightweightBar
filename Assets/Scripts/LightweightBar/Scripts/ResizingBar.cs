using UnityEngine;
using System.Collections;

namespace LightweightBar {

	public class ResizingBar : MonoBehaviour {
		[SerializeField] BarModel barModel;
		[SerializeField] RectTransform bar;
		[SerializeField] RectTransform fillArea;

		public void ChangeParameters (float minValue, float maxValue, float currentValue) {
			barModel.ChangeParameters (minValue, maxValue, currentValue);
			UpdateView ();
		}

		public void ChangeCurrentValue (float value) {
			barModel.ChangeCurrentValue (value);
			UpdateView ();
		}

		protected void OnValidate() {
			barModel.FixParameter();
			FixParameter();
			UpdateView();
		}

		void FixParameter() {
			bar.pivot = new Vector2(0, bar.pivot.y);
		}
		
		void UpdateView () {
			bar.sizeDelta = new Vector2(fillArea.rect.width * (barModel.NormalizedValue - 1f), 0);
		}
	}

}