using UnityEngine;
using System.Collections;

namespace LightweightBar {

	public class ResizingBar : MonoBehaviour {
		[SerializeField] BarModel barModel;
		[SerializeField] RectTransform bar;
		[SerializeField] RectTransform fillArea;

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