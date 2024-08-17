Shader "Custom/Water"
{
    Properties
    {
        _MainTex("tex", 2D) = "white"{}
        _CUBE("Cubemap", CUBE) = ""{}
        _BumpTex("Bump Map", 2D) = "bump"{}
    }
    SubShader
    {
        Tags {"RenderType" = "Transparent""Queue"="Transparent"}
        LOD 200

        CGPROGRAM
        #pragma surface surf water alpha:blend
        #pragma target 3.0
        sampler2D _MainTex;
        samplerCUBE _CUBE;
        sampler2D _BumpTex;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldRefl;
            float2 uv_BumpTex;
            INTERNAL_DATA
        };

        void surf(Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Normal = UnpackNormal(tex2D(_BumpTex, IN.uv_BumpTex+_Time.y*0.05));
            float4 reflection = texCUBE(_CUBE, WorldReflectionVector(IN, o.Normal));
            
            o.Emission = reflection;
            o.Alpha = c.a;
        }

        float4 Lightingwater(SurfaceOutput s, float3 lightDir, float3 viewDir, float atten)
        {
            //Rim
            float rim = saturate(dot(s.Normal, viewDir));
            rim = pow(1 - rim, 3);

            float4 final = rim * _LightColor0;

            return final;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
