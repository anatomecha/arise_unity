public var wedge : Transform;
public var refinery : Transform;
public var canyonCutouts : GameObject[];

function Start () {
	var wedgesAll = GameObject("wedges_all");
	wedgesAll.transform.parent = wedge.parent;
	
	// tag the canyonCutout with a component so it can be found after duplication
	// need to delete the area where Velotron starts because it is a custom made set piece
	for(obj in canyonCutouts) {
		obj.AddComponent(XionCanyon);
	}
	
	// create a mirrored copy of the wedge
	wedge.localEulerAngles.y = -15;
	var wedge2 = Instantiate(wedge);
	wedge2.localEulerAngles.y = 15;
	wedge2.localScale.x = -1;
	
	// find the canyonCutouts
	var mirroredCanyonCutouts = wedge2.GetComponentsInChildren(XionCanyon);
	for(obj in mirroredCanyonCutouts) {
		print("mirror = " + obj);
	}
	
	// create a group of the two mirrored wedges, which is one sixth of the whole circle
	var sixth = GameObject("sixth");
	sixth.transform.parent = wedgesAll.transform;
	wedge.parent = sixth.transform;
	wedge2.parent = sixth.transform;
	
	// create radial copies of the wedge
	for (var i=1; i<6; i++) {
		var sixth2 = Instantiate(sixth);
		sixth2.transform.parent = sixth.transform.parent;
		sixth2.transform.localEulerAngles.y = 60*i;
		
	}
	
	// build refinery
	for (i=1; i<6; i++) {
		var newRefinery = Instantiate(refinery);
		newRefinery.transform.parent = refinery.transform.parent;
		newRefinery.transform.localEulerAngles.y = 60*i;
	}
	
	// get rid of the canyon cutouts
	for(obj in canyonCutouts) { Destroy(obj); }
	for(obj in mirroredCanyonCutouts) { Destroy(obj.gameObject); }
	
}