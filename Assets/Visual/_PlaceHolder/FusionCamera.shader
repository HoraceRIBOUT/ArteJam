Shader "Custom/FusionCamera"
{
    Properties
    {
		_IndexForTest("Wich height ?", Range(-1,5)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

			sampler2D _MainTex;
            float4 _MainTex_ST;

			sampler2D _Texture00;
			sampler2D _Texture01;
			sampler2D _Texture02;
			sampler2D _Texture03;
			sampler2D _Texture04;
			sampler2D _Texture05;
			sampler2D _Texture06;
			sampler2D _Texture07;

			sampler2D _Depture00;
			sampler2D _Depture01;
			sampler2D _Depture02;
			sampler2D _Depture03;
			sampler2D _Depture04;
			sampler2D _Depture05;
			sampler2D _Depture06;
			sampler2D _Depture07;

			float _IndexForTest;
			

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 baseColorValue = tex2D(_Texture00, i.uv);
				fixed4 col01 = tex2D(_Texture01, i.uv);	
				fixed4 col02 = tex2D(_Texture02, i.uv);
				fixed4 col03 = tex2D(_Texture03, i.uv);
				fixed4 col04 = tex2D(_Texture04, i.uv);
				fixed4 col05 = tex2D(_Texture05, i.uv);
				fixed4 col06 = tex2D(_Texture06, i.uv);
				fixed4 col07 = tex2D(_Texture07, i.uv);

				fixed4 baseDepthValue = tex2D(_Depture00, i.uv);
				fixed4 dept01 = tex2D(_Depture01, i.uv);
				fixed4 dept02 = tex2D(_Depture02, i.uv);
				fixed4 dept03 = tex2D(_Depture03, i.uv);
				fixed4 dept04 = tex2D(_Depture04, i.uv);
				fixed4 dept05 = tex2D(_Depture05, i.uv);
				fixed4 dept06 = tex2D(_Depture06, i.uv);
				fixed4 dept07 = tex2D(_Depture07, i.uv);


				if (baseDepthValue.r < dept01.r) {
					baseColorValue = col01;
					baseDepthValue = dept01;
				}
				if (baseDepthValue.r < dept02.r) {
					baseColorValue = col02;
					baseDepthValue = dept02;
				}
				if (baseDepthValue.r < dept03.r) {
					baseColorValue = col03;
					baseDepthValue = dept03;
				}
				if (baseDepthValue.r < dept04.r) {
					baseColorValue = col04;
					baseDepthValue = dept04;
				}
				if (baseDepthValue.r < dept05.r) {
					baseColorValue = col05;
					baseDepthValue = dept05;
				}
				if (baseDepthValue.r < dept06.r) {
					baseColorValue = col06;
					baseDepthValue = dept06;
				}
				if (baseDepthValue.r < dept07.r) {
					baseColorValue = col07;
					baseDepthValue = dept07;
				}


				fixed4 baseBase = tex2D(_Texture00, i.uv);
				fixed4 ecart = ((baseColorValue/8) - baseBase);
				baseColorValue = baseBase + ecart* _IndexForTest;

                return baseColorValue;
            }
            ENDCG
        }
    }
}
