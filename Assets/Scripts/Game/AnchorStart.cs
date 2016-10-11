﻿using UnityEngine;
using System.Collections;

// [ExecuteInEditMode]
[RequireComponent(typeof(JointAnchor))]
public class AnchorStart : MonoBehaviour {
	public int numberOfPoints = 20;
	public Relationship prefabRelationShip;

	SourceElement sourceElement;
	LineRenderer[] lineRenderers;
	const int nbPoints = 6;

	void Awake() {
		sourceElement = GetComponentInParent<SourceElement> ();
	}

	void Update () {		
		foreach (var child in GetComponentsInChildren<Relationship> ()) {
			DestroyImmediate (child.gameObject);
			Debug.Log ("destroy child");
		}
		lineRenderers = new LineRenderer[sourceElement.targetObjects.Count];
		for (var targetIndex = 0; targetIndex < sourceElement.targetObjects.Count; targetIndex++) {
			var targetElement = sourceElement.targetObjects [targetIndex];
			var targetAnchor = targetElement.GetComponentInChildren<AnchorEnd> ();

			lineRenderers [targetIndex] = Instantiate (prefabRelationShip).GetComponent<LineRenderer> ();
			lineRenderers [targetIndex].transform.parent = transform;

			var points = new Transform[nbPoints];
			points [0] = transform;
			points [1] = transform;
			points [2] = sourceElement.GetComponentInChildren<JointControl> ().transform;
			points [3] = targetElement.GetComponentInChildren<JointControl> ().transform;				
			points [4] = targetAnchor.transform;
			points [5] = targetAnchor.transform;

			lineRenderers [targetIndex].SetVertexCount (numberOfPoints * (points.Length - 2));

			Vector3 p0;
			Vector3 p1;
			Vector3 p2;

			for (var j = 0; j < points.Length - 2; j++) {
				// check control points
				if (points[j] == null || points[j + 1] == null || points[j + 2] == null) {
					return;  
				}

				// determine control points of segment
				p0 = 0.5f * (points[j].transform.position 
					+ points[j + 1].transform.position);
				p1 = points[j + 1].transform.position;
				p2 = 0.5f * (points[j + 1].transform.position 
					+ points[j + 2].transform.position);

				// set points of quadratic Bezier curve
				Vector3 position;
				float t;
				var pointStep = 1f / numberOfPoints;

				if (j == points.Length - 3) {
					pointStep = 1f / (numberOfPoints - 1f);
					// last point of last segment should reach p2
				}  

				for(var i = 0; i < numberOfPoints; i++) {
					t = i * pointStep;
					position = (1f - t) * (1f - t) * p0 
						+ 2f * (1f - t) * t * p1
						+ t * t * p2;
					lineRenderers [targetIndex].SetPosition(i + j * numberOfPoints, position);
				}
			}	
		}
	}
}