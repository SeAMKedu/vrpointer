using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RayController : MonoBehaviour {
	public float raycastDistance = 10f;
	public float lineWidthStart = 0.1f;
	public float lineWidthEnd = 0.1f;
	public Color lineColor = Color.red;
	public RaycastHit hitInfo;

	private LineRenderer lineRenderer;

	void Start() {
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.startWidth = lineWidthStart;
		lineRenderer.endWidth = lineWidthEnd;
		lineRenderer.material = new Material(Shader.Find("Unlit/Color")) { color = lineColor };
	}

	void Update() {
		CastRayAndDrawLine();
	}

	void CastRayAndDrawLine() {
		Vector3 origin = transform.position;
		Vector3 direction = transform.forward;

		if (Physics.Raycast(origin, direction, out hitInfo, raycastDistance)) {
			DrawLine(origin, hitInfo.point);
		} else {
			DrawLine(origin, origin + direction * raycastDistance);
		}
	}

	void DrawLine(Vector3 start, Vector3 end) {
		lineRenderer.SetPosition(0, start);
		lineRenderer.SetPosition(1, end);
	}
}
