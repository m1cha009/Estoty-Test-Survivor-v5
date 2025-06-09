using UnityEngine;

namespace Code.Gameplay.Lifetime.Behaviours
{
	[RequireComponent(typeof(HideOnDamageApplied))]
	public class ActivateAfterHide : MonoBehaviour
	{
		[SerializeField] private Collider2D _collider2D;
		[SerializeField] private float _timeToAppear;
		
		private HideOnDamageApplied _hideOnDamageApplied;
		private bool _isHidden;
		private float _elapsedTime;
		private GameObject _hiddenGameObject;

		private void Awake()
		{
			_hideOnDamageApplied = GetComponent<HideOnDamageApplied>();
		}

		private void Update()
		{
			if (!_isHidden)
			{
				return;
			}

			if (_elapsedTime < _timeToAppear)
			{
				_elapsedTime += Time.deltaTime;
			}
			else
			{
				_isHidden = false;
				_elapsedTime = 0;
				
				_hiddenGameObject.SetActive(true);
				_collider2D.enabled = true;
			}
		}

		private void OnEnable()
		{
			_hideOnDamageApplied.OnHide += HandleOnHide;
		}

		private void OnDisable()
		{
			_hideOnDamageApplied.OnHide -= HandleOnHide;
		}

		private void HandleOnHide(GameObject hiddenGameObject)
		{
			_isHidden = true;
			_hiddenGameObject = hiddenGameObject;
		}
	}
}