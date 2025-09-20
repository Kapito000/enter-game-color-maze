using UnityEngine;

namespace Feature.Physics
{
	public class RigidBodyPush : MonoBehaviour
	{
		[SerializeField] LayerMask pushLayers;
		[Range(0.5f, 5f)]
		[SerializeField] float _strength = 1.1f;

		void OnControllerColliderHit(ControllerColliderHit hit)
		{
			PushRigidBodies(hit);
		}

		void PushRigidBodies(ControllerColliderHit hit)
		{
			if (CanPush(hit) == false)
				return;

			Rigidbody body = hit.collider.attachedRigidbody;
			Vector3 pushDir = PushDir(hit);
			body.AddForce(pushDir * _strength, ForceMode.Impulse);
		}

		bool CanPush(ControllerColliderHit hit)
		{
			Rigidbody body = hit.collider.attachedRigidbody;

			if (IsKinematic(body))
				return false;

			if (IsSuitableLayer(body) == false)
				return false;

			if (IsObjectBelowUs(hit))
				return false;

			return true;
		}

		Vector3 PushDir(ControllerColliderHit hit) =>
			new(hit.moveDirection.x, 0.0f, hit.moveDirection.z);

		bool IsObjectBelowUs(ControllerColliderHit hit) =>
			hit.moveDirection.y < -0.3f;

		bool IsKinematic(Rigidbody body) =>
			body == null || body.isKinematic;

		bool IsSuitableLayer(Rigidbody body)
		{
			var bodyLayerMask = 1 << body.gameObject.layer;
			return (bodyLayerMask & pushLayers.value) != 0;
		}
	}
}