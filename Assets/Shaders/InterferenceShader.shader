Shader "Custom/InterferenceShader"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Max_amplitude_color ("Max Amplitude", Color) = (1,0,0)
        _Min_amplitude_color ("Min Amplitude", Color) = (1,0,0)
    }
        SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 200
        CGPROGRAM
        #pragma surface surf Standard //fullforwardshadows
        #pragma target 3.0

        float2 _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        float2 _Sheet_position;
        float _Sheet_size;

        int _Antenna_count;
        float2 _Antenna_position[100];
        
        float _Phase_shift;
        float _Wave_length;
        float _Wave_frequency;
        half3 _Max_amplitude_color;
        half3 _Min_amplitude_color;
        
        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            const float pi = 3.1415926;
            float s_all = 0;
            float2 uv = -(IN.uv_MainTex - 0.5) * _Sheet_size + _Sheet_position;
            for (int i = 0; i < 100; i+=1)
            {
                if (i >= _Antenna_count)
                    break;

                half2 buff = _Antenna_position[i];
                float2 xx = uv - buff;
                float r = length(xx);

                float sin_clear = sin(r * 2 * pi / _Wave_length + i * (_Phase_shift * pi / 180) - _Time * 20 * (2 * pi) * _Wave_frequency);
                float sin_handled = sin_clear / _Antenna_count;

                s_all += sin_handled;
            }
            half3 max = _Max_amplitude_color * s_all;
            half3 min = _Min_amplitude_color * (1 - s_all);

            o.Albedo = max + min;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
