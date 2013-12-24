//Maya ASCII 2013 scene
//Name: fx_cylinder.ma
//Last modified: Mon, Dec 23, 2013 04:56:12 PM
//Codeset: 1252
requires maya "2013";
requires "stereoCamera" "10.0";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2013";
fileInfo "version" "2013 x64";
fileInfo "cutIdentifier" "201202220241-825136";
fileInfo "osv" "Microsoft Windows 7 Business Edition, 64-bit Windows 7 Service Pack 1 (Build 7601)\n";
fileInfo "license" "education";
createNode transform -s -n "persp";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 1.1641676883085337 1.2395050171979678 12.315608811619148 ;
	setAttr ".r" -type "double3" -5.7218466252613274 5.4000000000005342 0 ;
createNode camera -s -n "perspShape" -p "persp";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999986;
	setAttr ".coi" 12.432452862446228;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".tp" -type "double3" -1.1920928955078125e-007 0 -1.7881393432617188e-007 ;
	setAttr ".hc" -type "string" "viewSet -p %camera";
createNode transform -s -n "top";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 200.1 0 ;
	setAttr ".r" -type "double3" -89.999999999999986 0 0 ;
createNode camera -s -n "topShape" -p "top";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 200.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
createNode transform -s -n "front";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 0 200.1 ;
createNode camera -s -n "frontShape" -p "front";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 200.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
createNode transform -s -n "side";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 200.1 0 0 ;
	setAttr ".r" -type "double3" 0 89.999999999999986 0 ;
createNode camera -s -n "sideShape" -p "side";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 200.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
createNode transform -n "fx_cylinder_mesh";
createNode mesh -n "fx_cylinder_meshShape" -p "fx_cylinder_mesh";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 36 ".uvst[0].uvsp[0:35]" -type "float2" 5.9604645e-008 0.99999994
		 -5.9604645e-008 0.87798464 -5.9604645e-008 0.75198966 0 0.6259948 0 0.49999991 5.9604645e-008
		 0.37400514 0 0.24801019 0 0.12201536 0 1.1920929e-007 1 1.000000119209 1 0.87798464
		 1 0.75198966 1 0.62599486 1 0.49999988 1 0.37400508 0.99999994 0.2480102 1 0.12201531
		 1 4.7260119e-008 5.9604645e-008 0.99999994 -5.9604645e-008 0.87798464 1 0.87798464
		 1 1.000000119209 -5.9604645e-008 0.75198966 1 0.75198966 0 0.6259948 1 0.62599486
		 0 0.49999991 1 0.49999988 5.9604645e-008 0.37400514 1 0.37400508 0 0.24801019 0.99999994
		 0.2480102 0 0.12201536 1 0.12201531 0 1.1920929e-007 1 4.7260119e-008;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 24 ".pt[0:23]" -type "float3"  -0.35355335 0 0.35355335 
		0 0 0.49999994 0.35355335 0 0.35355335 0.49999994 0 0 0.35355335 0 -0.35355335 -1.3877788e-017 
		0 -0.49999997 -0.35355338 0 -0.35355338 -0.5 0 0 -0.35355335 0 0.35355335 0 0 0.49999994 
		0.35355335 0 0.35355335 0.49999994 0 0 0.35355335 0 -0.35355335 0 0 -0.49999997 -0.35355338 
		0 -0.35355338 -0.5 0 0 0 0 0.49999994 -0.35355335 0 0.35355335 0.35355335 0 0.35355335 
		0.49999994 0 0 0.35355335 0 -0.35355335 -2.7755576e-017 0 -0.49999997 -0.35355338 
		0 -0.35355338 -0.5 0 0;
	setAttr -s 24 ".vt[0:23]"  0.70710671 0 -0.70710671 0 0 -0.99999988
		 -0.70710671 0 -0.70710671 -0.99999988 0 0 -0.70710671 0 0.70710671 2.7755576e-017 0 0.99999994
		 0.70710677 0 0.70710677 1 0 0 0.70710671 1 -0.70710671 0 1 -0.99999988 -0.70710671 1 -0.70710671
		 -0.99999988 1 0 -0.70710671 1 0.70710671 0 1 0.99999994 0.70710677 1 0.70710677 1 1 0
		 0 -1 -0.99999988 0.70710671 -1 -0.70710671 -0.70710671 -1 -0.70710671 -0.99999988 -1 0
		 -0.70710671 -1 0.70710671 5.5511151e-017 -1 0.99999994 0.70710677 -1 0.70710677 1 -1 0;
	setAttr -s 40 ".ed[0:39]"  0 1 0 1 2 0 2 3 0 3 4 0 4 5 0 5 6 0 6 7 0
		 7 0 0 8 9 0 9 10 0 10 11 0 11 12 0 12 13 0 13 14 0 14 15 0 15 8 0 0 8 1 1 9 1 2 10 1
		 3 11 1 4 12 1 5 13 1 6 14 1 7 15 1 1 16 1 17 16 0 0 17 1 2 18 1 16 18 0 3 19 1 18 19 0
		 4 20 1 19 20 0 5 21 1 20 21 0 6 22 1 21 22 0 7 23 1 22 23 0 23 17 0;
	setAttr -s 16 -ch 64 ".fc[0:15]" -type "polyFaces" 
		f 4 0 17 -9 -17
		mu 0 4 0 1 10 9
		f 4 1 18 -10 -18
		mu 0 4 1 2 11 10
		f 4 2 19 -11 -19
		mu 0 4 2 3 12 11
		f 4 3 20 -12 -20
		mu 0 4 3 4 13 12
		f 4 4 21 -13 -21
		mu 0 4 4 5 14 13
		f 4 5 22 -14 -22
		mu 0 4 5 6 15 14
		f 4 6 23 -15 -23
		mu 0 4 6 7 16 15
		f 4 7 16 -16 -24
		mu 0 4 7 8 17 16
		f 4 26 25 -25 -1
		mu 0 4 18 21 20 19
		f 4 24 28 -28 -2
		mu 0 4 19 20 23 22
		f 4 27 30 -30 -3
		mu 0 4 22 23 25 24
		f 4 29 32 -32 -4
		mu 0 4 24 25 27 26
		f 4 31 34 -34 -5
		mu 0 4 26 27 29 28
		f 4 33 36 -36 -6
		mu 0 4 28 29 31 30
		f 4 35 38 -38 -7
		mu 0 4 30 31 33 32
		f 4 37 39 -27 -8
		mu 0 4 32 33 35 34;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode lightLinker -s -n "lightLinker1";
	setAttr -s 2 ".lnk";
	setAttr -s 2 ".slnk";
createNode displayLayerManager -n "layerManager";
createNode displayLayer -n "defaultLayer";
createNode renderLayerManager -n "renderLayerManager";
createNode renderLayer -n "defaultRenderLayer";
	setAttr ".g" yes;
createNode script -n "sceneConfigurationScriptNode";
	setAttr ".b" -type "string" "playbackOptions -min 1 -max 24 -ast 1 -aet 48 ";
	setAttr ".st" 6;
select -ne :time1;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -k on ".o" 1;
	setAttr ".unw" 1;
select -ne :renderPartition;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -s 2 ".st";
select -ne :initialShadingGroup;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -k on ".mwc";
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -k on ".mwc";
	setAttr ".ro" yes;
select -ne :defaultShaderList1;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -s 2 ".s";
select -ne :postProcessList1;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :renderGlobalsList1;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
select -ne :defaultLightSet;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -k on ".mwc";
	setAttr ".ro" yes;
select -ne :hardwareRenderGlobals;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :defaultHardwareRenderGlobals;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr ".fn" -type "string" "im";
	setAttr ".res" -type "string" "ntsc_4d 646 485 1.333";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "fx_cylinder_meshShape.iog" ":initialShadingGroup.dsm" -na;
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
// End of fx_cylinder.ma
