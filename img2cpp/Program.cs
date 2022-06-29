using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;

namespace img2cpp
{
	class Program
	{
		static readonly string Filepath = Assembly.GetEntryAssembly().GetModules()[0].FullyQualifiedName;
		static readonly string Name = Path.GetFileNameWithoutExtension(Filepath);
		static void Main(string[] args)
		{
#if !DEBUG
			try
			{
#endif
			string name = null;
			string headerfile = null;
			var type = Img2CppType.Cpp;
			var jpg = false;
			var cvt16bpp = false;
			var bigEndian = false;
			var arduino = false;
			var typeSet = false;
			Size size = Size.Empty;
			if (args.Length < 1)
			{
				PrintUsage();
			}

			for (var i = 1; i < args.Length; ++i)
			{
				string arg = args[i];
				switch (arg.ToLowerInvariant())
				{
					case "/name":
						if (i == args.Length - 1)
						{
							throw new ArgumentException("No name was specified");
						}
						++i;
						name = Img2CppGen.PathToCppName(args[i]);
						break;
					case "/be":
						bigEndian = true;
						break;
					case "/gfx14":
						if(typeSet)
						{
							throw new ArgumentException("Multiple gfx bindings selected");
						}
						typeSet = true;
						type = Img2CppType.Gfx14;
						break;
					case "/gfx17":
						if (typeSet)
						{
							throw new ArgumentException("Multiple gfx bindings selected");
						}
						typeSet = true;
						type = Img2CppType.Gfx17;
						break;
					case "/jpg":
						if (cvt16bpp)
						{
							throw new ArgumentException("/16bpp cannot be specified with /jpg");
						}
						jpg = true;
						break;
					case "/arduino":
						arduino = true;
						break;
					case "/16bpp":
						if(jpg)
						{
							throw new ArgumentException("/16bpp cannot be specified with /jpg");
						}
						cvt16bpp = true;
						break;
					case "/resize":
						if (i == args.Length - 1)
						{
							throw new ArgumentException("No size was specified");
						}
						++i;
						size = ParseSize(args[i]);
						break;
					case "/out":
						if (i == args.Length - 1)
						{
							throw new ArgumentException("No header file was specified");
						}
						++i;
						headerfile = args[i];
						break;
					default:
						throw new ArgumentException("Unknown command line argument");
				}
			}
			TextWriter output = Console.Out;
			if (headerfile != null)
			{
				try
				{
					File.Delete(headerfile);
				}
				catch
				{
				}
				output = new StreamWriter(File.OpenWrite(headerfile), Encoding.ASCII);
			}
			Img2CppGen.Generate(args[0], name, type, jpg,bigEndian, cvt16bpp,arduino, size, output);
			if(output!=Console.Out)
			{
				output.Close();
			}
#if !DEBUG
			}
			catch(Exception ex)
			{
				Console.Error.WriteLine("Error: {0}",ex.Message);
				Console.Error.WriteLine();
				PrintUsage();
			}
#endif
		}
		static Size ParseSize(string arg)
		{
			if(string.IsNullOrEmpty(arg))
			{
				return Size.Empty;
			}
			arg = arg.ToLowerInvariant();
			if(arg[0]=='x')
			{
				if (arg.Length==1)
				{
					return Size.Empty;
				}
				return new Size(0, int.Parse(arg.Substring(1)));
			}
			int i = arg.IndexOf('x');
			if(0>i)
			{
				return new Size(int.Parse(arg), 0);
			}
			var sa = arg.Split('x');
			if(sa.Length!=2)
			{
				return Size.Empty;
			}
			return new Size(int.Parse(sa[0]), int.Parse(sa[1]));
			
		}
		static void PrintUsage(TextWriter writer=null)
		{
			if(writer==null)
			{
				writer = Console.Error;
			}
			writer.Write("Usage: {0} ", Path.GetFileName(Filepath));
			writer.WriteLine("<imagefile> [/name <name>] [/jpg|/16bpp]");
			writer.WriteLine("  [/gfx14|/gfx17] [/be]");
			writer.WriteLine("  [/resize [<width>][x<height>]]");
			writer.WriteLine("  [/arduino] [/out <headerfile>]");
			writer.WriteLine();
			writer.WriteLine("  <imagefile>   The image to convert");
			writer.WriteLine("  <name>        The base name to use in the header");
			writer.WriteLine("  <jpg>         Embed as JPG image");
			writer.WriteLine("  <16bpp>       Convert to 16bpp");
			writer.WriteLine("  <gfx14/gfx17> Use gfx14 or 17 bindings");
			writer.WriteLine("  <be>          Use big-endian format");
			writer.WriteLine("  <resize>      Resize the image. If one dimension");
			writer.WriteLine("                isn't specified, the aspect ratio");
			writer.WriteLine("                is preserved.");
			writer.WriteLine("  <arduino>     Create code for Arduino");
			
			writer.WriteLine("  <headerfile>  The output header to generate");
			
		}
	}
}
