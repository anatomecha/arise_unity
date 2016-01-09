using System.Collections.Generic;
using UnityEngine;

// This is the most basic genetics lab. It selects a random generator from the list
// of generators every time you call Generate. To make a more interesting genetics lab
// Create a class that inherits from this class and override the Generate function.
public class GeneticsLab : MonoBehaviour {

  [Tooltip("These are the axioms this lab knows how to replace")]
  public string[] axiomsTargetted;

  [Tooltip("These are the generators this lab can produce")]
  public GameObject[] generators;

  public virtual GameObject Generate(GameObject axiom, int generation, string details) {
    if (generators.Length == 0) {
      Debug.LogError("No generators found in " + this.name + ", please add a generator to this lab");
    }

    var selectedGenerator = generators[Random.Range(0, generators.Length)];
    var generator = Instantiate(selectedGenerator);
    generator.name = generator.name.TrimAfter("(Clone)") + "|" + generation + "," + details;
    return generator;
  }
}