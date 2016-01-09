//Maya ASCII 2013 scene
//Name: gr_spine_4.ma
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
createNode transform -n "gr_spine_4_transform1";
createNode mesh -n "polySurfaceShape1" -p "gr_spine_4_transform1";
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
	setAttr -s 8 ".pt[0:7]" -type "float3"  6.9586301 -8.29284 6.8453488 
		5.9586287 7.0832109 6.8453488 1.5238655 -9.2928438 6.8453488 0.52386546 6.0832105 
		6.8453488 1.5238655 -9.2928438 -6.8453488 0.52386546 6.0832105 -6.8453488 6.9586301 
		-8.29284 -6.8453488 5.9586287 7.0832109 -6.8453488;
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
createNode mesh -n "spine_4_boxShape" -p "gr_spine_4_transform1";
	setAttr -k off ".v";
	setAttr -s 2 ".iog";
	setAttr ".ove" yes;
	setAttr ".ovc" 6;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 30 ".uvst[0].uvsp[0:29]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.25 0.25 0.375 0.375 0.625 0.375 0.75 0.25 0.25 0
		 0.375 0.875 0.625 0.875 0.75 0 0.375 0 0.625 0 0.625 0.25 0.375 0.25 0.375 0.5 0.625
		 0.5 0.625 0.75 0.375 0.75;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 20 ".pt[0:19]" -type "float3"  5.7724185 -40.9193 12.113699 
		5.7724185 -54.60186 -1.5688639 10.249473 -45.396355 12.113699 10.249473 -59.078915 
		-1.5688639 3.4399111 -45.396355 5.3041368 3.4399111 -59.078915 -8.3784256 -1.0371435 
		-40.9193 5.3041368 -1.0371435 -54.60186 -8.3784256 6.8446922 -44.733501 9.3717709 
		6.8446922 -59.622372 -5.5170984 2.3676374 -40.256447 9.3717709 2.3676374 -55.145317 
		-5.5170984 8.6355 -42.445644 13.450436 8.6355 -53.254665 2.6414127 13.112555 -57.73172 
		2.6414127 13.112555 -46.922699 13.450436 0.57682967 -46.922699 0.91471052 0.57682967 
		-57.73172 -9.8943119 -3.9002249 -53.254665 -9.8943119 -3.9002249 -42.445644 0.91471052;
	setAttr -s 20 ".vt[0:19]"  -3.40478086 48.12368774 -8.70891762 -3.40478086 48.12368774 4.97364473
		 -3.40478086 52.60074234 -8.70891762 -3.40478086 52.60074234 4.97364473 3.40478086 52.60074234 -8.70891762
		 3.40478086 52.60074234 4.97364473 3.40478086 48.12368774 -8.70891762 3.40478086 48.12368774 4.97364473
		 -5.1371278e-017 52.60074234 -9.37177086 4.9673709e-015 52.60074234 5.51709843 5.1370854e-017 48.12368774 -9.37177086
		 5.0701118e-015 48.12368774 5.51709843 -6.26786232 48.12368774 -7.18257284 -6.26786232 48.12368774 3.62644958
		 -6.26786232 52.60074234 3.62644958 -6.26786232 52.60074234 -7.18257284 6.26786232 52.60074234 -7.18257284
		 6.26786232 52.60074234 3.62644958 6.26786232 48.12368774 3.62644958 6.26786232 48.12368774 -7.18257284;
	setAttr -s 36 ".ed[0:35]"  0 1 1 2 3 1 4 5 1 6 7 1 0 2 1 1 3 1 2 8 0
		 3 9 0 4 6 1 5 7 1 6 10 0 7 11 0 8 4 0 9 5 0 10 0 0 11 1 0 9 8 1 11 10 1 11 9 1 10 8 1
		 0 12 0 1 13 0 12 13 0 3 14 0 13 14 0 2 15 0 15 14 0 12 15 0 4 16 0 5 17 0 16 17 0
		 7 18 0 17 18 0 6 19 0 19 18 0 16 19 0;
	setAttr -s 18 -ch 72 ".fc[0:17]" -type "polyFaces" 
		f 4 22 24 -27 -28
		mu 0 4 22 23 24 25
		f 4 1 7 16 -7
		mu 0 4 2 3 16 15
		f 4 30 32 -35 -36
		mu 0 4 26 27 28 29
		f 4 3 11 17 -11
		mu 0 4 6 7 20 19
		f 4 -16 18 -8 -6
		mu 0 4 1 21 17 3
		f 4 10 19 12 8
		mu 0 4 12 18 14 13
		f 4 -17 13 -3 -13
		mu 0 4 15 16 5 4
		f 4 -18 15 -1 -15
		mu 0 4 19 20 9 8
		f 4 -19 -12 -10 -14
		mu 0 4 17 21 10 11
		f 4 -20 14 4 6
		mu 0 4 14 18 0 2
		f 4 0 21 -23 -21
		mu 0 4 0 1 23 22
		f 4 5 23 -25 -22
		mu 0 4 1 3 24 23
		f 4 -2 25 26 -24
		mu 0 4 3 2 25 24
		f 4 -5 20 27 -26
		mu 0 4 2 0 22 25
		f 4 2 29 -31 -29
		mu 0 4 4 5 27 26
		f 4 9 31 -33 -30
		mu 0 4 5 7 28 27
		f 4 -4 33 34 -32
		mu 0 4 7 6 29 28
		f 4 -9 28 35 -34
		mu 0 4 6 4 26 29;
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
connectAttr "|gr_spine_4_transform1|spine_4_boxShape.iog" ":initialShadingGroup.dsm"
		 -na;
// End of gr_spine_4.ma
