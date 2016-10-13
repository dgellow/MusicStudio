using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// [ExecuteInEditMode]
[RequireComponent(typeof(JointAnchor))]
public class AnchorStart : MonoBehaviour {
	public int numberOfPoints = 20;
	public Relationship prefabRelationShip;

	SourceElement sourceElement;
	IntermediaryElement intermediaryElement;
	List<Element> targetElements;
	LineRenderer[] lineRenderers;
	const int nbPoints = 6;

	void Awake() {
		sourceElement = GetComponentInParent<SourceElement> ();
		intermediaryElement = GetComponentInParent<IntermediaryElement> ();

		if (sourceElement != null) {
			targetElements = sourceElement.targetElements;
		} else if (intermediaryElement != null) {
			targetElements = intermediaryElement.targetElements;
		} else {
			throw new MissingComponentException ("Parent is missing component SourceElement or IntermediaryElement");
		}
	}

	void Update () {		
		// Clear existing relationships
		foreach (var child in GetComponentsInChildren<Relationship> ()) {
			DestroyImmediate (child.gameObject);
		}

		// Initialize renderers array
		lineRenderers = new LineRenderer[targetElements.Count];

		// Loop on targeted elements
		for (var targetIndex = 0; targetIndex < targetElements.Count; targetIndex++) {
			var targetElement = targetElements [targetIndex];
			var targetAnchor = targetElement.GetComponentInChildren<AnchorEnd> ();

			lineRenderers [targetIndex] = Instantiate (prefabRelationShip).GetComponent<LineRenderer> ();
			lineRenderers [targetIndex].transform.parent = transform;

			// Setup control points
			var points = new Transform[nbPoints];
			points [0] = transform.parent.transform;
			points [1] = transform;
			points [2] = GetComponentInChildren<JointControl> ().transform;
			points [3] = targetAnchor.GetComponentInChildren<JointControl> ().transform;				
			points [4] = targetAnchor.transform;
			points [5] = targetElement.transform;

			lineRenderers [targetIndex].SetVertexCount (numberOfPoints * (points.Length - 2));
			DrawBezier (points, lineRenderers[targetIndex]);
		}
	}

	void DrawBezier(Transform[] points, LineRenderer lineRenderer) {
		// Bézier spline
		// Based on https://en.wikibooks.org/wiki/Cg_Programming/Unity/B%C3%A9zier_Curves
		Vector3 p0;
		Vector3 p1;
		Vector3 p2;

		for (var j = 0; j < points.Length - 2; j++) {
			// Check control points
			if (points[j] == null || points[j + 1] == null || points[j + 2] == null) {
				return;  
			}

			// Determine control points of segment
			p0 = 0.5f * (points[j].transform.position 
				+ points[j + 1].transform.position);
			p1 = points[j + 1].transform.position;
			p2 = 0.5f * (points[j + 1].transform.position 
				+ points[j + 2].transform.position);

			// Set points of quadratic Bezier curve
			Vector3 position;
			float t;
			var pointStep = 1f / numberOfPoints;

			if (j == points.Length - 3) {
				pointStep = 1f / (numberOfPoints - 1f);
				// Last point of last segment should reach p2
			}  

			for(var i = 0; i < numberOfPoints; i++) {
				t = i * pointStep;
				position = (1f - t) * (1f - t) * p0 
					+ 2f * (1f - t) * t * p1
					+ t * t * p2;
				lineRenderer.SetPosition(i + j * numberOfPoints, position);
			}
		}
	}
}
