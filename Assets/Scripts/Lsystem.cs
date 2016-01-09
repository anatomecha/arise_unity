using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*notes
- texturing from parent
- cooridinates in space where the instance is created
*/

public class Lsystem : MonoBehaviour {

	[Tooltip("Number of iterations fractal to undergo. Should probably be less that 9999")]
	public int iterations = 3;

	[Tooltip("If not null, this is the base fractal model that gets built up")]
	public GameObject target;

	[Tooltip("Only used if 'target' is null. This is the 'first thing to create'")]
	public GameObject defaultGenerator;

	[Tooltip("These are the generators that replace axioms")]
	public GameObject[] generators;

	[Tooltip("These use genetic logic to determine which generator should replace an axiom")]
	public GeneticsLab[] geneticsLabs;

	private List<GameObject> members = new List<GameObject>();
	private int instanceCount = 0;
	private int totalInstanceCount = 0;
	private Dictionary<string, GameObject> nameToGeneratorMappings;
	private Dictionary<string, GeneticsLab> nameToGeneticsLabs;

	void Awake() {
		// Look at all the generators and store them by name. Thus when we have an axiom
		// we can know what to replace it with. This can me made fancier.
		nameToGeneratorMappings = new Dictionary<string, GameObject>();
		for (int i=0; i<generators.Length; i++) {
			var generator = generators[i];
			var generatorName = generator.name.Replace("_generator", "");
			nameToGeneratorMappings.Add(generatorName, generator);
		}

		// Store all the genetics labs and which things they know how to create
		nameToGeneticsLabs = new Dictionary<string, GeneticsLab>();
		for (int i = 0; i < geneticsLabs.Length; i++) {
			var lab = geneticsLabs[i];
			for (int n = 0; n < lab.axiomsTargetted.Length; n++) {
				var axiomName = lab.axiomsTargetted[n];
				if (!nameToGeneticsLabs.ContainsKey(axiomName)) {
					nameToGeneticsLabs.Add(axiomName, lab);
				} else {
					Debug.LogWarning("Duplicate genetics labs exist to handle axiom " + axiomName);
				}
			}
		}
	}

	void Start () {
		Generate ();
	}

	// affine transformation fractal generation
	public void Generate() {

		// If a target was set, we are going to start running generation on that. If not
		// we use the "defaultGenerator" and create one of those instead and work with that.
		if (target == null) {
			target = Instantiate(defaultGenerator);
			target.transform.parent = transform;
			target.transform.localScale = Vector3.one;
			target.transform.localPosition = Vector3.zero;
			target.transform.localEulerAngles = Vector3.zero;
		}
		target.name = target.name.TrimAfter("(Clone)") + "|0";

		for (int i=0; i < target.transform.childCount; i++) {
			members.Add(target.transform.GetChild(i).gameObject);
		}
		List<GameObject> newMembers = new List<GameObject>();
		List<GameObject> children = new List<GameObject>();

		for(int i=0; i<iterations; i++){ //print( "i=" + i );

			for(int m=0; m<members.Count; m++) { //print( i + "m=" + m );

				children = Reproduce( members[m], i, m );

				// add children to the list of new members
				for( int c=0; c<children.Count; c++){
					newMembers.Add( children[c] );
				}
			}

			// refresh the list of members
			members.Clear();
			for( int nm=0; nm<newMembers.Count; nm++ ){
				members.Add( newMembers[nm] );
			}
			newMembers.Clear();

			instanceCount = members.Count;
			totalInstanceCount += members.Count;
		}

	}

	// Replace low detail object with higher details obect of the children.
	List<GameObject> Reproduce( GameObject axiom, int i, int m ) {
		List<GameObject> children = new List<GameObject> ();

		// create the generator object (make the triforce)
		var inheritedDetails = axiom.transform.parent.name.TrimBefore("|").TrimBefore(",");
		var newGenerator = InstantiateCorrectChild (axiom, i + 1, inheritedDetails);

		// parent it to the axiom's parent
		newGenerator.transform.SetParent (axiom.transform.parent);

		// copy over transforms from axiom to children
		newGenerator.transform.localScale = axiom.transform.localScale;
		newGenerator.transform.position = axiom.transform.position;
		newGenerator.transform.eulerAngles = axiom.transform.eulerAngles;

		// add children to the list of children
		for( int c = 0; c < newGenerator.transform.childCount; c++ ){
			Transform child = newGenerator.transform.GetChild(c);
			children.Add( child.gameObject );
		}

		Destroy ( axiom );
		return children;
	}

	// Find the collect child of "source" and instantiate it.
	// TODO: Anatomecha - should this function be called InstantiateCorrectGenerator
	// and "source" be renamed to "axiom"? I'm still getting my head around the
	// terminology.
	GameObject InstantiateCorrectChild(GameObject source, int generation, string details) {
		// strip the name after __
		var name = source.name.TrimAfter("__");

		// If there is a genetics lab for this axiom, use that.
		// If not then check for a generator meant for that axiom.
		// If none of those exist either return and empty GameObject and complain
		if (nameToGeneticsLabs.ContainsKey(name)) {
			return nameToGeneticsLabs[name].Generate(source, generation, details);
		} else if (nameToGeneratorMappings.ContainsKey(name)) {
			GameObject generator = nameToGeneratorMappings[name];
			var rv = Instantiate(generator);
			rv.name = rv.name.TrimAfter("(Clone)") + "|" + generation;
			return rv;
		} else {
			Debug.LogWarning("Cannot find generator " + name + " returning empty GameObject");
			return new GameObject("Placeholder for " + name);
		}
	}
}


