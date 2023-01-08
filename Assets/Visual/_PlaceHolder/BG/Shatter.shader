Shader "Custom/Shatter"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Shatter ("Shatter", 2D) = "white" {}
        _intensity("Intensity", Range(0, 1)) = 1
        _Distortion("Distortion", Range(-3, 3)) = -1
        _zoomFactor("_zoomFactor", Range(-3, 3)) = 1
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

            float _Distortion;
            float _zoomFactor;

            fixed4 frag (v2f i) : SV_Target
            {
                // lens distortion coefficient
                float k = -0.15;

                float r2 = (i.uv.x - 0.5) * (i.uv.x - 0.5) + (i.uv.y - 0.5) * (i.uv.y - 0.5);
                float f = 0;

                //only compute the cubic distortion if necessary
                if (_Distortion == 0.0)
                {
                    f = 1 + r2 * k;
                }
                else
                {
                    f = 1 + r2 * (k + _Distortion * sqrt(r2));
                };

                // get the right pixel for the current position
                float x = f * (i.uv.x - 0.5) * _zoomFactor + 0.5;
                float y = f * (i.uv.y - 0.5) * _zoomFactor + 0.5;




                fixed4 dis = tex2D(_Shatter, i.uv);
                dis = 1 - dis;
                dis -= 0.5;
                fixed2 uv = fixed2(x + dis.r * _intensity, y + dis.g * _intensity);//, 
                fixed4 col = tex2D(_MainTex, uv);
                // just invert the colors
                col.rgb = col.rgb;
                return col;
            }
            ENDCG
        }
    }
}
