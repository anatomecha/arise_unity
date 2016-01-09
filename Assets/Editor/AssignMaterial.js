// An editor script that assignes materials to multiple selected objects
// copied from here http://forum.unity3d.com/threads/assign-a-material-to-multiple-object.35445/

class AssignMaterial extends ScriptableWizard
{
    var theMaterial : Material;
   
    function OnWizardUpdate()
    {
        helpString = "Select Game Obects";
        isValid = (theMaterial != null);
    }
   
    function OnWizardCreate()
    {
       
        var gos = Selection.gameObjects;
   
        for (var go in gos)
        {
            go.GetComponent.<Renderer>().material = theMaterial;
        }
    }
   
    @MenuItem("Custom/Assign Material", false, 4)
    static function assignMaterial()
    {
        ScriptableWizard.DisplayWizard(
            "Assign Material", AssignMaterial, "Assign");
    }
}