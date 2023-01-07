Shader "Custom/Shatter"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Shatter ("Shatter", 2D) = "white" {}
        _intensity("Intensity", Range(0, 1)) = 1
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            sampler2D _Shatter;
            float _intensity;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 dis = tex2D(_Shatter, i.uv);
                dis = 1 - dis;
                fixed2 uv = fixed2(i.uv.x + dis.r * _intensity, i.uv.y + dis.g * _intensity);//, 
                fixed4 col = tex2D(_MainTex, uv);
                // just invert the colors
                col.rgb = col.rgb;
                return col;
            }
            ENDCG
        }
    }
}
