// UTAGE: Unity Text Adventure Game Engine (c) Ryohei Tokimura
using UnityEngine;
using UnityEngine.UI;
using Utage;
using System.Collections.Generic;

namespace Utage
{

	/// <summary>
	/// ギャラリー表示のサンプル
	/// </summary>
	[AddComponentMenu("Utage/TemplateUI/UtageUguiGallery")]
	public class UtageUguiGallery : UguiView
	{
		public UguiView[] views;
		protected int tabIndex = -1;

		/// <summary>
		/// オープンしたときに呼ばれる
		/// </summary>
		protected virtual void OnOpen()
		{
			if (tabIndex >= 0)
			{
				views[tabIndex].ToggleOpen(true);
			}
		}

		//一時的に表示オフ
		public virtual void Sleep()
		{
			this.gameObject.SetActive(false);
		}

		//一時的な表示オフを解除
		public virtual void WakeUp()
		{
			this.gameObject.SetActive(true);
		}

		public virtual void OnTabIndexChanged(int index)
		{
			if (index >= views.Length)
			{
				Debug.LogError("index < views.Length");
				return;
			}

			for (int i = 0; i < views.Length; ++i)
			{
				if (views[i] == null)
				{
					Debug.LogError($"views[{i}] is null",this);
					continue;
				}
				if (i == index)
				{
					views[i].ToggleOpen(true);
				}
				else
				{
					views[i].ToggleOpen(false);
				}
			}

			tabIndex = index;
		}
	}
}
