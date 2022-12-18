using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace uGIF
{
	public class CaptureToGIF : MonoBehaviour
	{
		[SerializeField] Vector2Int resolution;
		[SerializeField] int frame_rate = 60;
		[SerializeField] int capture_time = 1;
		[SerializeField] int downscale = 1;
		[SerializeField] bool use_bilinear_scaling = true;

		List<Image> frames = new List<Image>();
		
		RenderTexture current_frame;

		[System.NonSerialized]
		public byte[] bytes = null;

		void Start()
		{
		}

		public void Encode()
		{
			bytes = null;
			Thread thread = new Thread(_Encode);
			thread.Start();
			StartCoroutine(WaitForBytes());
		}

		IEnumerator WaitForBytes()
		{
			while(bytes == null) yield return null;
			System.IO.File.WriteAllBytes(Application.dataPath + "/test_gif.gif", bytes);
			bytes = null;

			Debug.Log("done");
		}

		public void _Encode()
		{
			GIFEncoder encoder = new GIFEncoder();
			encoder.useGlobalColorTable = true;
			encoder.repeat = 0;
			encoder.FPS = frame_rate;
			encoder.transparent = new Color32(255, 0, 255, 255);
			encoder.dispose = 1;

			MemoryStream stream = new MemoryStream();
			encoder.Start(stream);
			foreach(Image f in frames) 
			{
				if(downscale != 1) 
				{
					if(use_bilinear_scaling) 
					{
						f.ResizeBilinear(f.width/downscale, f.height/downscale);
					} 
					else 
					{
						f.Resize(downscale);
					}
				}
				f.Flip();
				encoder.AddFrame(f);
			}
			encoder.Finish();
			bytes = stream.GetBuffer();
			stream.Close();
		}
		
		
        private void Update()
        {
			if (!Input.GetKeyDown(KeyCode.Y))
				return;

			OnCaptureStarted();
		}

        void OnPostRender()
		{ // start

			
			//RaycastHit hit = new RaycastHit();
			
			//T += Time.deltaTime;
			//if (T >= shot_delay)
			//{
			//	T = 0;
				

			//	color_buffer.ReadPixels(new Rect(0, 0, color_buffer.width, color_buffer.height), 0, 0, false);
			//	frames.Add(new Image(color_buffer));
			//}
			//if (Time.time > (start_time + capture_time))
			//{
				
			//	Encode();
			//}

		}
		[SerializeField] ComputeShader interference_shader;
		public struct TransferedEmitter
        {
			public Vector2 position;
			public float wave_length;
			public float wave_period;
			public float phase_shift;

			public TransferedEmitter(Vector2 pos, float len, float per, float shift)
			{
				position = new Vector2(pos.x, pos.y);
				wave_length = len;
				wave_period = per;
				phase_shift = shift;
			}
		}
		[SerializeField] MeshRenderer plane_ren;
		public void OnCaptureStarted()
        {//On capture command called

			current_frame = new RenderTexture(resolution.x, resolution.y, 24);

			current_frame.enableRandomWrite = true;
			current_frame.Create();

			plane_ren.material.mainTexture = current_frame;

			interference_shader.SetTexture(0, "Result", current_frame);


			{ //Emitters Transfer
				int total_size = 0;
				{ //Struct Element Size Calc
					int pos_size = sizeof(float) * 2;
					int wave_length_size = sizeof(float);
					int wave_period_size = sizeof(float);
					int wave_shift_size = sizeof(float);

					total_size = pos_size + wave_length_size + wave_period_size + wave_shift_size;
				}

				int emitters_count = SimulationController.Instance.EmittersCount;
				interference_shader.SetInt("emitters_count", emitters_count);

				List<TransferedEmitter> emitter_transfer_bufer = new List<TransferedEmitter>();

				foreach (Transform emitter_transform in SimulationController.Instance.Emitters)
				{
					Emitter emitter = emitter_transform.gameObject.GetComponent<Emitter>();
					emitter_transfer_bufer.Add(new TransferedEmitter(emitter.transform.position, emitter.WaveLength, emitter.WavePeriod, emitter.PhaseShift));
				}

				if (emitters_count != 0)
				{
					ComputeBuffer compute_buffer = new ComputeBuffer(emitters_count, total_size);
					compute_buffer.SetData(emitter_transfer_bufer);
					interference_shader.SetBuffer(0, "emitters", compute_buffer);
				}
			}
			{ //Amplitude Colors Transfer
				interference_shader.SetVector("max_amplitude_color", new Vector4(1, 0, 0, 1));
				interference_shader.SetVector("min_amplitude_color", new Vector4(0, 0, 0, 1));
			}
            { // Field Size Transfer
				float field_width = float.Parse(SettingsController.Instance.OverallGetter("Field Width").Item2);
				float field_height = float.Parse(SettingsController.Instance.OverallGetter("Field Height").Item2);

				interference_shader.SetVector("texture_size", new Vector4(field_width, field_height, 0, 0));
			}
            { // Field Resolutioon Transfer
				interference_shader.SetVector("resolution", new Vector4(resolution.x, resolution.y, 0, 0));
            }
			interference_shader.Dispatch(0, resolution.x / 8, resolution.y / 8, 1);
			OnCapture();
		}
		public void OnCapture()
        {//frames creation during capturing
			int frame_count = frame_rate * capture_time;

			if (frames == null)
				frames = new List<Image>();
			frames.Clear();
			Texture2D actual_texture = new Texture2D(resolution.x, resolution.y);

			bool switcher = false;

			for (int i = 0; i < frame_count; i++)
			{
				interference_shader.SetBool("switcher", false);
				interference_shader.SetFloat("time", (float)i / frame_rate);
				interference_shader.Dispatch(0, resolution.x / 8, resolution.y / 8, 1);

				while (!switcher)
				{ }

				//interference_shader.SetBuffer

				RenderTexture.active = current_frame;
				actual_texture.ReadPixels(new Rect(0, 0, resolution.x, resolution.y), 0, 0);
				//RenderTexture.active = null;

				frames.Add(new Image(actual_texture));
			}

			OnCaptureEnd();
		}
		public void OnCaptureEnd()
        {//all frames was done, creating a gif
			Encode();
        }
	}
}