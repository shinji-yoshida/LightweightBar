using UnityEngine;
using System.Collections;

namespace LightweightBar {
	public class SpriteResizingBar : MonoBehaviour {
		[SerializeField] BarModel barModel;
		[SerializeField] Transform bar;

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
		}

		void UpdateView () {
			bar.localScale = new Vector3(barModel.NormalizedValue, 1, 1);
		}
	}
}
