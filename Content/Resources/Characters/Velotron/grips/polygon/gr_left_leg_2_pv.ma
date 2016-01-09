//Maya ASCII 2013 scene
//Name: gr_left_leg_2_pv.ma
//Last modified: Thu, Dec 31, 2015 02:07:35 PM
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
createNode transform -n "gr_left_leg_2_pv_transform1";
createNode mesh -n "left_leg_2_pvDisplayShape" -p "gr_left_leg_2_pv_transform1";
	setAttr -k off ".v";
	setAttr -s 2 ".iog";
	setAttr ".ove" yes;
	setAttr ".ovc" 14;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 89 ".uvst[0].uvsp[0:88]" -type "float2" 0 0.16666667 0.083333336
		 0.16666667 0.16666667 0.16666667 0.25 0.16666667 0.33333334 0.16666667 0.41666669
		 0.16666667 0.5 0.16666667 0.58333331 0.16666667 0.66666663 0.16666667 0.74999994
		 0.16666667 0.83333325 0.16666667 0.91666657 0.16666667 0.99999988 0.16666667 0 0.33333334
		 0.083333336 0.33333334 0.16666667 0.33333334 0.25 0.33333334 0.33333334 0.33333334
		 0.41666669 0.33333334 0.5 0.33333334 0.58333331 0.33333334 0.66666663 0.33333334
		 0.74999994 0.33333334 0.83333325 0.33333334 0.91666657 0.33333334 0.99999988 0.33333334
		 0 0.5 0.083333336 0.5 0.16666667 0.5 0.25 0.5 0.33333334 0.5 0.41666669 0.5 0.5 0.5
		 0.58333331 0.5 0.66666663 0.5 0.74999994 0.5 0.83333325 0.5 0.91666657 0.5 0.99999988
		 0.5 0 0.66666669 0.083333336 0.66666669 0.16666667 0.66666669 0.25 0.66666669 0.33333334
		 0.66666669 0.41666669 0.66666669 0.5 0.66666669 0.58333331 0.66666669 0.66666663
		 0.66666669 0.74999994 0.66666669 0.83333325 0.66666669 0.91666657 0.66666669 0.99999988
		 0.66666669 0 0.83333337 0.083333336 0.83333337 0.16666667 0.83333337 0.25 0.83333337
		 0.33333334 0.83333337 0.41666669 0.83333337 0.5 0.83333337 0.58333331 0.83333337
		 0.66666663 0.83333337 0.74999994 0.83333337 0.83333325 0.83333337 0.91666657 0.83333337
		 0.99999988 0.83333337 0.041666668 0 0.125 0 0.20833334 0 0.29166669 0 0.375 0 0.45833334
		 0 0.54166669 0 0.625 0 0.70833337 0 0.79166669 0 0.875 0 0.95833337 0 0.041666668
		 1 0.125 1 0.20833334 1 0.29166669 1 0.375 1 0.45833334 1 0.54166669 1 0.625 1 0.70833337
		 1 0.79166669 1 0.875 1 0.95833337 1;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".ds" no;
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 62 ".pt[0:61]" -type "float3"  0.12087582 -0.24175164 -0.069787689 
		0.069787689 -0.24175164 -0.12087582 0 -0.24175164 -0.13957538 -0.069787689 -0.24175164 
		-0.12087582 -0.12087582 -0.24175164 -0.069787689 -0.13957538 -0.24175164 0 -0.12087582 
		-0.24175164 0.069787689 -0.069787689 -0.24175164 0.12087582 0 -0.24175164 0.13957538 
		0.069787689 -0.24175164 0.12087582 0.12087582 -0.24175164 0.069787689 0.13957538 
		-0.24175164 0 0.20936306 -0.13957536 -0.12087583 0.12087583 -0.13957536 -0.20936306 
		0 -0.13957536 -0.24175166 -0.12087583 -0.13957536 -0.20936306 -0.20936306 -0.13957536 
		-0.12087583 -0.24175166 -0.13957536 0 -0.20936306 -0.13957536 0.12087583 -0.12087583 
		-0.13957536 0.20936306 0 -0.13957536 0.24175166 0.12087583 -0.13957536 0.20936306 
		0.20936306 -0.13957536 0.12087583 0.24175166 -0.13957536 0 0.24175164 0 -0.13957538 
		0.13957538 0 -0.24175164 0 0 -0.27915075 -0.13957538 0 -0.24175164 -0.24175164 0 
		-0.13957538 -0.27915075 0 0 -0.24175164 0 0.13957538 -0.13957538 0 0.24175164 0 0 
		0.27915075 0.13957538 0 0.24175164 0.24175164 0 0.13957538 0.27915075 0 0 0.20936306 
		0.13957536 -0.12087583 0.12087583 0.13957536 -0.20936306 0 0.13957536 -0.24175166 
		-0.12087583 0.13957536 -0.20936306 -0.20936306 0.13957536 -0.12087583 -0.24175166 
		0.13957536 0 -0.20936306 0.13957536 0.12087583 -0.12087583 0.13957536 0.20936306 
		0 0.13957536 0.24175166 0.12087583 0.13957536 0.20936306 0.20936306 0.13957536 0.12087583 
		0.24175166 0.13957536 0 0.12087582 0.24175164 -0.069787689 0.069787689 0.24175164 
		-0.12087582 0 0.24175164 -0.13957538 -0.069787689 0.24175164 -0.12087582 -0.12087582 
		0.24175164 -0.069787689 -0.13957538 0.24175164 0 -0.12087582 0.24175164 0.069787689 
		-0.069787689 0.24175164 0.12087582 0 0.24175164 0.13957538 0.069787689 0.24175164 
		0.12087582 0.12087582 0.24175164 0.069787689 0.13957538 0.24175164 0 0 -0.27915075 
		0 0 0.27915075 0;
	setAttr -s 62 ".vt[0:61]"  0.21650635 -0.43301269 -0.125 0.125 -0.43301269 -0.21650635
		 0 -0.43301269 -0.25 -0.125 -0.43301269 -0.21650635 -0.21650635 -0.43301269 -0.125
		 -0.25 -0.43301269 0 -0.21650635 -0.43301269 0.125 -0.125 -0.43301269 0.21650635 0 -0.43301269 0.25
		 0.125 -0.43301269 0.21650635 0.21650635 -0.43301269 0.125 0.25 -0.43301269 0 0.375 -0.24999999 -0.21650636
		 0.21650636 -0.24999999 -0.375 0 -0.24999999 -0.43301272 -0.21650636 -0.24999999 -0.375
		 -0.375 -0.24999999 -0.21650636 -0.43301272 -0.24999999 0 -0.375 -0.24999999 0.21650636
		 -0.21650636 -0.24999999 0.375 0 -0.24999999 0.43301272 0.21650636 -0.24999999 0.375
		 0.375 -0.24999999 0.21650636 0.43301272 -0.24999999 0 0.43301269 0 -0.25 0.25 0 -0.43301269
		 0 0 -0.5 -0.25 0 -0.43301269 -0.43301269 0 -0.25 -0.5 0 0 -0.43301269 0 0.25 -0.25 0 0.43301269
		 0 0 0.5 0.25 0 0.43301269 0.43301269 0 0.25 0.5 0 0 0.375 0.24999999 -0.21650636
		 0.21650636 0.24999999 -0.375 0 0.24999999 -0.43301272 -0.21650636 0.24999999 -0.375
		 -0.375 0.24999999 -0.21650636 -0.43301272 0.24999999 0 -0.375 0.24999999 0.21650636
		 -0.21650636 0.24999999 0.375 0 0.24999999 0.43301272 0.21650636 0.24999999 0.375
		 0.375 0.24999999 0.21650636 0.43301272 0.24999999 0 0.21650635 0.43301269 -0.125
		 0.125 0.43301269 -0.21650635 0 0.43301269 -0.25 -0.125 0.43301269 -0.21650635 -0.21650635 0.43301269 -0.125
		 -0.25 0.43301269 0 -0.21650635 0.43301269 0.125 -0.125 0.43301269 0.21650635 0 0.43301269 0.25
		 0.125 0.43301269 0.21650635 0.21650635 0.43301269 0.125 0.25 0.43301269 0 0 -0.5 0
		 0 0.5 0;
	setAttr -s 132 ".ed[0:131]"  0 1 0 1 2 0 2 3 0 3 4 0 4 5 0 5 6 0 6 7 0
		 7 8 0 8 9 0 9 10 0 10 11 0 11 0 0 12 13 0 13 14 0 14 15 0 15 16 0 16 17 0 17 18 0
		 18 19 0 19 20 0 20 21 0 21 22 0 22 23 0 23 12 0 24 25 0 25 26 0 26 27 0 27 28 0 28 29 0
		 29 30 0 30 31 0 31 32 0 32 33 0 33 34 0 34 35 0 35 24 0 36 37 0 37 38 0 38 39 0 39 40 0
		 40 41 0 41 42 0 42 43 0 43 44 0 44 45 0 45 46 0 46 47 0 47 36 0 48 49 0 49 50 0 50 51 0
		 51 52 0 52 53 0 53 54 0 54 55 0 55 56 0 56 57 0 57 58 0 58 59 0 59 48 0 0 12 0 1 13 0
		 2 14 0 3 15 0 4 16 0 5 17 0 6 18 0 7 19 0 8 20 0 9 21 0 10 22 0 11 23 0 12 24 0 13 25 0
		 14 26 0 15 27 0 16 28 0 17 29 0 18 30 0 19 31 0 20 32 0 21 33 0 22 34 0 23 35 0 24 36 0
		 25 37 0 26 38 0 27 39 0 28 40 0 29 41 0 30 42 0 31 43 0 32 44 0 33 45 0 34 46 0 35 47 0
		 36 48 0 37 49 0 38 50 0 39 51 0 40 52 0 41 53 0 42 54 0 43 55 0 44 56 0 45 57 0 46 58 0
		 47 59 0 60 0 0 60 1 0 60 2 0 60 3 0 60 4 0 60 5 0 60 6 0 60 7 0 60 8 0 60 9 0 60 10 0
		 60 11 0 48 61 0 49 61 0 50 61 0 51 61 0 52 61 0 53 61 0 54 61 0 55 61 0 56 61 0 57 61 0
		 58 61 0 59 61 0;
	setAttr -s 72 -ch 264 ".fc[0:71]" -type "polyFaces" 
		f 4 0 61 -13 -61
		mu 0 4 0 1 14 13
		f 4 1 62 -14 -62
		mu 0 4 1 2 15 14
		f 4 2 63 -15 -63
		mu 0 4 2 3 16 15
		f 4 3 64 -16 -64
		mu 0 4 3 4 17 16
		f 4 4 65 -17 -65
		mu 0 4 4 5 18 17
		f 4 5 66 -18 -66
		mu 0 4 5 6 19 18
		f 4 6 67 -19 -67
		mu 0 4 6 7 20 19
		f 4 7 68 -20 -68
		mu 0 4 7 8 21 20
		f 4 8 69 -21 -69
		mu 0 4 8 9 22 21
		f 4 9 70 -22 -70
		mu 0 4 9 10 23 22
		f 4 10 71 -23 -71
		mu 0 4 10 11 24 23
		f 4 11 60 -24 -72
		mu 0 4 11 12 25 24
		f 4 12 73 -25 -73
		mu 0 4 13 14 27 26
		f 4 13 74 -26 -74
		mu 0 4 14 15 28 27
		f 4 14 75 -27 -75
		mu 0 4 15 16 29 28
		f 4 15 76 -28 -76
		mu 0 4 16 17 30 29
		f 4 16 77 -29 -77
		mu 0 4 17 18 31 30
		f 4 17 78 -30 -78
		mu 0 4 18 19 32 31
		f 4 18 79 -31 -79
		mu 0 4 19 20 33 32
		f 4 19 80 -32 -80
		mu 0 4 20 21 34 33
		f 4 20 81 -33 -81
		mu 0 4 21 22 35 34
		f 4 21 82 -34 -82
		mu 0 4 22 23 36 35
		f 4 22 83 -35 -83
		mu 0 4 23 24 37 36
		f 4 23 72 -36 -84
		mu 0 4 24 25 38 37
		f 4 24 85 -37 -85
		mu 0 4 26 27 40 39
		f 4 25 86 -38 -86
		mu 0 4 27 28 41 40
		f 4 26 87 -39 -87
		mu 0 4 28 29 42 41
		f 4 27 88 -40 -88
		mu 0 4 29 30 43 42
		f 4 28 89 -41 -89
		mu 0 4 30 31 44 43
		f 4 29 90 -42 -90
		mu 0 4 31 32 45 44
		f 4 30 91 -43 -91
		mu 0 4 32 33 46 45
		f 4 31 92 -44 -92
		mu 0 4 33 34 47 46
		f 4 32 93 -45 -93
		mu 0 4 34 35 48 47
		f 4 33 94 -46 -94
		mu 0 4 35 36 49 48
		f 4 34 95 -47 -95
		mu 0 4 36 37 50 49
		f 4 35 84 -48 -96
		mu 0 4 37 38 51 50
		f 4 36 97 -49 -97
		mu 0 4 39 40 53 52
		f 4 37 98 -50 -98
		mu 0 4 40 41 54 53
		f 4 38 99 -51 -99
		mu 0 4 41 42 55 54
		f 4 39 100 -52 -100
		mu 0 4 42 43 56 55
		f 4 40 101 -53 -101
		mu 0 4 43 44 57 56
		f 4 41 102 -54 -102
		mu 0 4 44 45 58 57
		f 4 42 103 -55 -103
		mu 0 4 45 46 59 58
		f 4 43 104 -56 -104
		mu 0 4 46 47 60 59
		f 4 44 105 -57 -105
		mu 0 4 47 48 61 60
		f 4 45 106 -58 -106
		mu 0 4 48 49 62 61
		f 4 46 107 -59 -107
		mu 0 4 49 50 63 62
		f 4 47 96 -60 -108
		mu 0 4 50 51 64 63
		f 3 -1 -109 109
		mu 0 3 1 0 65
		f 3 -2 -110 110
		mu 0 3 2 1 66
		f 3 -3 -111 111
		mu 0 3 3 2 67
		f 3 -4 -112 112
		mu 0 3 4 3 68
		f 3 -5 -113 113
		mu 0 3 5 4 69
		f 3 -6 -114 114
		mu 0 3 6 5 70
		f 3 -7 -115 115
		mu 0 3 7 6 71
		f 3 -8 -116 116
		mu 0 3 8 7 72
		f 3 -9 -117 117
		mu 0 3 9 8 73
		f 3 -10 -118 118
		mu 0 3 10 9 74
		f 3 -11 -119 119
		mu 0 3 11 10 75
		f 3 -12 -120 108
		mu 0 3 12 11 76
		f 3 48 121 -121
		mu 0 3 52 53 77
		f 3 49 122 -122
		mu 0 3 53 54 78
		f 3 50 123 -123
		mu 0 3 54 55 79
		f 3 51 124 -124
		mu 0 3 55 56 80
		f 3 52 125 -125
		mu 0 3 56 57 81
		f 3 53 126 -126
		mu 0 3 57 58 82
		f 3 54 127 -127
		mu 0 3 58 59 83
		f 3 55 128 -128
		mu 0 3 59 60 84
		f 3 56 129 -129
		mu 0 3 60 61 85
		f 3 57 130 -130
		mu 0 3 61 62 86
		f 3 58 131 -131
		mu 0 3 62 63 87
		f 3 59 120 -132
		mu 0 3 63 64 88;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
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
connectAttr "left_leg_2_pvDisplayShape.iog" ":initialShadingGroup.dsm" -na;
// End of gr_left_leg_2_pv.ma
