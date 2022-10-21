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

#define max_antennas_count 980 // wtf. can not increase this number
#define PI 3.1415926

        float2 _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        float2 _sheet_position;
        float2 _sheet_size;

        int _antenna_count;

        float2 _positions[max_antennas_count];
        float _wave_length[max_antennas_count];
        float _wave_period[max_antennas_count];
        float _phase_shift[max_antennas_count];

        half3 _max_amplitude_color;
        half3 _min_amplitude_color;
        

        void surf (Input IN, inout SurfaceOutputStandard o)
        {

            float result = 0;

            float2 uv = -(IN.uv_MainTex - 0.5) * _sheet_size + _sheet_position; // pixel world position

            float amplitude = 1. / _antenna_count;   // aka 'A'
            float wave_number;                      // aka 'k' in math
            float angular_frequency;                // aka 'w' in math
            float radius;                           // distance from emitter to any interference point

            for (int i = 0; i < max_antennas_count; i++)
            {
                if (i >= _antenna_count)
                    break;

                if (_wave_length[i] == 0 || _wave_period[i] == 0)
                    continue;

                radius = length(uv - _positions[i]);
                wave_number = 2 * PI / _wave_length[i];
                angular_frequency = 2 * PI / _wave_period[i];
                

                float real_time = _Time * 20; // Make a '1' equal to second

                float sin_clear = amplitude * sin(wave_number * radius - real_time * angular_frequency + _phase_shift[i]); // energy from current emitter

                result += sin_clear;
            }
            half3 max = _max_amplitude_color * result;
            half3 min = _min_amplitude_color * (1 - result);

            o.Albedo = max + min;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
