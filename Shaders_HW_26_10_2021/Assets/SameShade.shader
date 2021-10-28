Shader "Custom/SameShade"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _AddTex ("Albedo (RGB)", 2D) = "blue" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
        //_Metallic ("Metallic", Range(0,1)) = 0.0
        _SomeDigit ("SomeDigit", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _AddTex;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_AddTex;
        };

        half _Glossiness;
        half _Metallic;

        half _SomeDigit;

        fixed4 _Color;


        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {

                // текстура 1
                fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * (1, 1, 1, 1);

                // текстура 2
                fixed4 d = tex2D (_AddTex, IN.uv_AddTex) * (1, 1, 1, 1);

                // ползунком меняем режимы наложения
                if (_SomeDigit == 0) {

                    // режим наложения умножения
                    o.Albedo = d.rgb;

                } else if (_SomeDigit > 0 && _SomeDigit <= 0.25) {

                    // сложение
                    o.Albedo = c.rgb + d.rgb;

                } else if (_SomeDigit > 0.25 && _SomeDigit <= 0.5) {

                    // деление
                    o.Albedo = c.rgb / d.rgb;

                } else if (_SomeDigit > 0.5 && _SomeDigit <= 0.75) {

                    // вычитание
                    o.Albedo = c.rgb - d.rgb;

                } else if (_SomeDigit > 0.75 && _SomeDigit <= 0.99) {

                    // магия
                    o.Albedo = (c.rgb - d.rgb) + (c.rgb * d.rgb);

                }
                else {

                    o.Albedo = c.rgb;
                }




        }
        ENDCG
    }
    FallBack "Diffuse"
}
