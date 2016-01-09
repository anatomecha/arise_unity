public static class StringExtensionMethods {

  // Lookes for doomedCharacters in src and deletes them (and everything after them)
  //
  // Usage:
  // var myStr = "This is good__this is doomed";
  // var trimmed = myStr.TrimAfter("__");
  // Debug.Log("trimmed = " + trimmed + "!"); // Outputs: trimmed = This is good!
  //
  public static string TrimAfter(this string src, string doomedCharacters) {
    var indexOfDOOM = src.IndexOf(doomedCharacters);
    if (indexOfDOOM >= 0) {
      src = src.Substring (0, indexOfDOOM);
    }
    return src;
  }

  // Lookes for doomedCharacters in src and deletes them (and everything before them)
  //
  // Usage:
  // var myStr = "This is doomed__this is good";
  // var trimmed = myStr.TrimAfter("__");
  // Debug.Log("trimmed = " + trimmed + "!"); // Outputs: trimmed = This is good!
  //
  public static string TrimBefore(this string src, string doomedCharacters) {
    var indexOfDOOM = src.IndexOf(doomedCharacters);
    if (indexOfDOOM >= 0) {
      src = src.Substring (indexOfDOOM + doomedCharacters.Length);
    }
    return src;
  }
}