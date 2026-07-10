using UnityEngine;

namespace GT_CustomMapSupportRuntime;

public class ConsensusGravityZoneSettings : BasicGravityZoneSettings
{
	[SerializeField]
	public float weightForce = 0f;

	[SerializeField]
	public float centeringForce = 0f;

	[SerializeField]
	public float drag = 0f;

	[SerializeField]
	public float rotMin = -45f;

	[SerializeField]
	public float rotMax = 45f;
}
