Shader "Custom/SpaceBoxST" {
Properties {
	_MainTex ("SpaceBoxST", 2D) = "white" {}
}

SubShader {
	Tags { "Queue"="Background" "RenderType"="Background" }
	Cull Off ZWrite Off Fog { Mode Off }
	Pass {
		SetTexture [_MainTex] { combine texture }
	}
}
}
