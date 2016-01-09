//Maya ASCII 2013 scene
//Name: gr_spine_3.ma
//Last modified: Thu, Dec 31, 2015 02:07:36 PM
//Codeset: 1252
requires maya "2013";
requires "stereoCamera" "10.0";
currentUnit -l centimeter -a degree -t ntsc;
fileInfo "application" "maya";
fileInfo "product" "Maya 2013";
fileInfo "version" "2013 x64";
fileInfo "cutIdentifier" "201202220241-825136";
fileInfo "osv" "Microsoft Windows 7 Business Edition, 64-bit Windows 7 Service Pack 1 (Build 7601)\n";
fileInfo "license" "education";
createNode transform -n "gr_spine_3_transform1";
createNode mesh -n "gr_spine_3_boxShape" -p "gr_spine_3_transform1";
	setAttr -k off ".v";
	setAttr -s 2 ".iog";
	setAttr ".ove" yes;
	setAttr ".ovc" 6;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 22 ".uvst[0].uvsp[0:21]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.625 0.87441695 0.75058305 0 0.24941695 0 0.375 0.87441695
		 0.24941695 0.25 0.375 0.37558305 0.625 0.37558305 0.75058305 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".ds" no;
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".bnr" 0;
	setAttr -s 12 ".pt[0:11]" -type "float3"  -1.2031775 -1.7947091 -0.61764288 
		1.1950867 1.8562508 -0.61764288 -3.3965077 -1.4679807 -1.6199638 -0.68892783 3.3813913 
		-1.6199645 -3.3965077 -1.4679807 1.6199638 -0.68892783 3.3813913 1.6199645 -1.2031775 
		-1.7947091 0.617643 1.1950867 1.8562508 0.61764294 1.1646954 0.53216308 0.026106358 
		-1.1697704 -0.46292537 0.026106358 -3.3631017 -0.13803682 0.031742573 -0.71931857 
		1.9603183 0.031742573;
	setAttr -s 12 ".vt[0:11]"  1.012646914 5.79081011 5.59693623 -1.32703054 -7.32342768 5.59693623
		 5.25513077 5.65283108 6.80529642 2.58481145 -9.073265076 6.80529642 5.25513077 5.65283108 -6.80529642
		 2.58481145 -9.073265076 -6.80529642 1.012646914 5.79081011 -5.59693623 -1.32703054 -7.32342768 -5.59693623
		 -1.32703054 -7.32342768 -0.026106358 1.012646914 5.79081011 -0.026106358 5.25513077 5.65283108 -0.031742573
		 2.58481145 -9.073265076 -0.031742573;
	setAttr -s 20 ".ed[0:19]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 10 0
		 3 11 0 4 6 0 5 7 0 6 9 0 7 8 0 8 1 0 9 0 0 8 9 1 10 4 0 9 10 1 11 5 0 10 11 1 11 8 1;
	setAttr -s 10 -ch 40 ".fc[0:9]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 18 17 -3 -16
		mu 0 4 19 20 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 14 -11
		mu 0 4 6 7 14 17
		f 4 19 -12 -10 -18
		mu 0 4 21 15 10 11
		f 4 10 16 15 8
		mu 0 4 12 16 18 13
		f 4 -15 12 -1 -14
		mu 0 4 17 14 9 8
		f 4 -17 13 4 6
		mu 0 4 18 16 0 2
		f 4 1 7 -19 -7
		mu 0 4 2 3 20 19
		f 4 -13 -20 -8 -6
		mu 0 4 1 15 21 3;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".vnm" 0;
createNode mesh -n "polySurfaceShape1" -p "gr_spine_3_transform1";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".ove" yes;
	setAttr ".ovc" 6;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".ds" no;
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".bnr" 0;
	setAttr -s 8 ".pt[0:7]" -type "float3"  1.5126469 6.2908101 5.0969362 
		-1.8270305 -6.8234277 5.0969362 5.7551308 5.1528311 6.3052964 2.0848114 -9.5732651 
		6.3052964 5.7551308 5.1528311 -6.3052964 2.0848114 -9.5732651 -6.3052964 1.5126469 
		6.2908101 -5.0969362 -1.8270305 -6.8234277 -5.0969362;
	setAttr -s 8 ".vt[0:7]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.5 -0.5 -0.5;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".vnm" 0;
select -ne :time1;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -k on ".o" 1;
	setAttr ".unw" 1;
select -ne :renderPartition;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -s 13 ".st";
select -ne :initialShadingGroup;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -k on ".mwc";
	setAttr ".ro" yes;
	setAttr -s 10 ".gn";
select -ne :initialParticleSE;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -k on ".mwc";
	setAttr ".ro" yes;
select -ne :defaultShaderList1;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -s 13 ".s";
select -ne :postProcessList1;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :renderGlobalsList1;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
select -ne :defaultRenderGlobals;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -k on ".clip";
	setAttr -k on ".edm";
	setAttr -k on ".edl";
	setAttr -av -k on ".esr";
	setAttr -k on ".ors";
	setAttr -k on ".outf";
	setAttr -k on ".gama";
	setAttr ".fs" 1;
	setAttr ".ef" 10;
	setAttr -k on ".bfs";
	setAttr -k on ".be";
	setAttr -k on ".fec";
	setAttr -k on ".ofc";
	setAttr -k on ".comp";
	setAttr -k on ".cth";
	setAttr -k on ".soll";
	setAttr -k on ".rd";
	setAttr -k on ".lp";
	setAttr -k on ".sp";
	setAttr -k on ".shs";
	setAttr -k on ".lpr";
	setAttr -k on ".mm";
	setAttr -k on ".npu";
	setAttr -k on ".itf";
	setAttr -k on ".shp";
	setAttr -k on ".uf";
	setAttr -k on ".oi";
	setAttr -k on ".rut";
	setAttr -av -k on ".mbf";
	setAttr -k on ".afp";
	setAttr -k on ".pfb";
	setAttr -av -k on ".bll";
	setAttr -k on ".bls";
	setAttr -k on ".smv";
	setAttr -k on ".ubc";
	setAttr -k on ".mbc";
	setAttr -k on ".udbx";
	setAttr -k on ".smc";
	setAttr -k on ".kmv";
	setAttr -k on ".rlen";
	setAttr -av -k on ".frts";
	setAttr -k on ".tlwd";
	setAttr -k on ".tlht";
	setAttr -k on ".jfc";
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
select -ne :ikSystem;
	setAttr -s 4 ".sol";
connectAttr "gr_spine_3_boxShape.iog" ":initialShadingGroup.dsm" -na;
// End of gr_spine_3.ma
