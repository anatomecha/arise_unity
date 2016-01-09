/******************************************************************************\
* Copyright (C) Leap Motion, Inc. 2011-2014.                                   *
* Leap Motion proprietary. Licensed under Apache 2.0                           *
* Available at http://www.apache.org/licenses/LICENSE-2.0.html                 *
\******************************************************************************/

using UnityEngine;
using System.Collections;
using Leap;

/** 
 * Updates the hand's opacity based it's confidence rating. 
 * Attach to a HandModel object assigned to the HandController in a scene.
 */
public class ConfidenceTransparencyHack : MonoBehaviour {
	public GameObject target;
	private float speed = 0.005f;
	private float pos_scale = 0.01f;

  void Update() {
	HandModel handModel = GetComponent<HandModel>();
    Hand leap_hand = GetComponent<HandModel>().GetLeapHand();
    //float confidence = leap_hand.Confidence;
	Vector palm_pos = leap_hand.PalmPosition;
	Vector3 palm_rot = handModel.GetPalmRotation ().eulerAngles;
	
    if (leap_hand != null) {
			target.transform.Rotate( palm_rot.z*speed, palm_rot.y*speed, palm_rot.x*speed);
			target.transform.localPosition = new Vector3(palm_pos.x*pos_scale, palm_pos.y*pos_scale, palm_pos.z*pos_scale);
		/*Renderer[] renders = GetComponentsInChildren<Renderer>();
      foreach (Renderer render in renders)
        SetRendererAlpha(render, confidence);*/
    }
  }

  protected void SetRendererAlpha(Renderer render, float alpha) {
    Color new_color = render.material.color;
    new_color.a = alpha;
    render.material.color = new_color;
  }
}
