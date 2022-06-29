using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
namespace img2cpp
{
	enum Img2CppType
	{
		Cpp = 0,
		Gfx14 = 1,
		Gfx17 = 2
	}
	class Img2CppGen
	{
		public static string PathToCppName(string path)
		{
			var sb = new StringBuilder();
			var fn = Path.GetFileNameWithoutExtension(path);
			if (string.IsNullOrEmpty(fn)) return null;
			if (!char.IsLetter(fn[0]))
			{
				sb.Append("_");
			}
			else 
			{
				sb.Append(fn[0]);
			}
			for(var i = 1;i<fn.Length;++i)
			{
				if(char.IsLetterOrDigit(fn[i]))
				{
					sb.Append(fn[i]);
				} else
				{
					sb.Append("_");
				}
			}
			return sb.ToString();
		}
		public static void Generate(string path,string name,Img2CppType type,bool jpg, bool bigEndian, bool cvt16bpp, bool arduino,Size size, TextWriter writer)
		{
			if(string.IsNullOrEmpty(path))
			{
				return;
			}
			if(jpg==true && cvt16bpp==true)
			{
				return;
			}
			if(string.IsNullOrEmpty(name))
			{
				name = PathToCppName(path);
			}
			writer.WriteLine("#pragma once");
			if(arduino)
			{
				writer.WriteLine("#include <Arduino.h>");
				writer.WriteLine("#ifndef ESP32");
				writer.WriteLine("    #include <avr/pgmspace.h>");
				writer.WriteLine("#else");
				writer.WriteLine("    #include <pgmspace.h>");
				writer.WriteLine("#endif");
			}
			switch(type)
			{
				case Img2CppType.Cpp:
					if (!arduino)
					{
						writer.WriteLine("#include <stdint.h>");
					}
					break;
				case Img2CppType.Gfx14:
					writer.WriteLine("#include <gfx_cpp14.hpp>");
					break;
				case Img2CppType.Gfx17:
					writer.WriteLine("#include <gfx.hpp>");
					break;
			}
			writer.WriteLine();
			using (var bmp = (Bitmap)Bitmap.FromFile(path))
			{
				var tbmp = bmp;
				if (!size.IsEmpty)
				{
					if(size.Width == 0)
					{
						var ar = ((double)bmp.Width / (double)bmp.Height);
						size.Width = (int)(size.Height * ar);
					} else if (size.Height == 0)
					{
						var ar = ((double)bmp.Width / (double)bmp.Height);
						size.Height = (int)(size.Width / ar);
					}
					tbmp = new Bitmap(bmp, size);
				} else
				{
					size = bmp.Size;
				}
				switch (type)
				{
					case Img2CppType.Cpp:
						writer.WriteLine("struct {");
						writer.WriteLine("\tuint16_t width;");
						writer.WriteLine("\tuint16_t height;");
						writer.Write("} ");
						writer.Write("{0}_size = ", name);
						break;
					case Img2CppType.Gfx14:
					case Img2CppType.Gfx17:
						writer.Write("gfx::size16 {0}_size = ", name);
						break;
				}
				writer.Write("{ ");
				writer.Write("{0}, {1} ", size.Width, size.Height);
				writer.WriteLine("};");
				byte[] data;
				if (jpg)
				{
					using (var mem = new MemoryStream())
					{
						tbmp.Save(mem, ImageFormat.Jpeg);
						data = mem.ToArray();
					}
				}
				else
				{
					Rectangle r = default;
					r.X = 0;
					r.Y = 0;
					r.Width = size.Width;
					r.Height = size.Height;
					BitmapData bd = tbmp.LockBits(r, ImageLockMode.ReadOnly,cvt16bpp?PixelFormat.Format16bppRgb565:PixelFormat.Format24bppRgb);
					IntPtr ptr = bd.Scan0;

					// Declare an array to hold the bytes of the bitmap.
					int bytes = tbmp.Width* tbmp.Height*(cvt16bpp?2:3);
					var tmp = new byte[bytes];

					// Copy the RGB values into the array.
					Marshal.Copy(ptr, tmp, 0, bytes);

					if (!cvt16bpp)
					{
						data = new byte[bd.Width * bd.Height * 3];
						for (int y = 0; y < bd.Height; ++y)
						{
							IntPtr mem = (IntPtr)((long)bd.Scan0 + y * bd.Stride);
							Marshal.Copy( mem, data, y * bd.Width * 3, bd.Width * 3);
						}
					} else
					{
						data = new byte[bd.Width * bd.Height * 2];
						for (int y = 0; y < bd.Height; ++y)
						{
							IntPtr mem = (IntPtr)((long)bd.Scan0 + y * bd.Stride);
							Marshal.Copy(mem, data, y * bd.Width * 2, bd.Width * 2);
						}
					}
					// Unlock the bits.
					tbmp.UnlockBits(bd);
					if (tbmp != bmp)
					{
						tbmp.Dispose();
					}
				}
				if (cvt16bpp && (bigEndian&&BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian))
				{
					
					for(var i = 0;i<data.Length;i+=2)
					{
						byte tmp = data[i];
						data[i] = data[i + 1];
						data[i + 1] = tmp;
					}
				}
				writer.Write("const uint8_t {0}[] ",type != Img2CppType.Cpp?name+"_data":name);
				if(arduino)
				{
					writer.Write("PROGMEM ");
				}
				writer.WriteLine("= {");
				writer.Write("\t");
				int cc = 0;
				for(var i = 0;i<data.Length;++i)
				{
					writer.Write("0x");
					writer.Write(data[i].ToString("x2"));
					if (i < data.Length - 1)
					{
						writer.Write(",");
					}
					++cc;
					if (0 == (cc % 16))
					{
						writer.WriteLine();
						if (i < data.Length - 1)
						{
							writer.Write("\t");
						}
					} else
					{
						writer.Write(" ");
					}
					
				}
				writer.WriteLine();
				writer.WriteLine("};");
			}
			if(type!=Img2CppType.Cpp)
			{
				writer.Write("using {0}_t = gfx::const_bitmap<gfx::rgb_pixel<", name);
				if (cvt16bpp)
				{
					writer.Write("16");
				} else {
					writer.Write("24");
				}
				writer.WriteLine(">>;");
				writer.WriteLine("const {0}_t {0}({0}_size,{0}_data);",name);
				
			}
		}
	}
}
