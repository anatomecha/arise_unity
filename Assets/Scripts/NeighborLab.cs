using UnityEngine;

public class NeighborLab : GeneticsLab {

  static readonly char[] deliminators = {','};

  public override GameObject Generate(GameObject axiom, int generation, string details) {
    var name = axiom.name.TrimBefore("__");
    var splits = details.Split(deliminators);
    var result = base.Generate(axiom, generation, details);
    return result;
  }
}