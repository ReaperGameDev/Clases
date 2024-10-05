Shader "Custom/OutlineShader" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Color ("Main Color", Color) = (1,1,1,1)
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _Outline ("Outline width", Range (.002, 0.1)) = .005
    }
    SubShader {
        Tags {"RenderType"="Opaque"}
        LOD 200

        Pass {
            // Regular Object Render
            Name "BASE"
            Tags {"LightMode"="ForwardBase"}

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            struct appdata {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _Color;

            v2f vert (appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                // Sample the texture and multiply by the main color
                fixed4 texColor = tex2D(_MainTex, i.uv) * _Color;
                return texColor;
            }
            ENDCG
        }

        Pass {
            // Outline Pass
            Name "OUTLINE"
            Tags {"LightMode"="Always"}

            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite On
            Cull Front  // Cull Front faces to render the outline on back-facing polygons
            ColorMask RGB

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            struct appdata {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f {
                float4 pos : POSITION;
            };

            fixed4 _OutlineColor;
            float _Outline;

            v2f vert (appdata v) {
                // Expand vertex along normal to simulate outline
                v2f o;
                float3 norm = normalize(v.normal);
                o.pos = UnityObjectToClipPos(v.vertex + float4(norm * _Outline, 0));
                return o;
            }

            fixed4 frag () : SV_Target {
                return _OutlineColor;  // Use the outline color defined in properties
            }
            ENDCG
        }
    }

    // Set fallback to Standard shader if unsupported
    Fallback "Diffuse"
}
