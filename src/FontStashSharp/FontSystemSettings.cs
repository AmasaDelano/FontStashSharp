﻿using System;
using FontStashSharp.Interfaces;

#if MONOGAME || FNA
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#elif STRIDE
using Stride.Core.Mathematics;
using Stride.Graphics;
using Texture2D = Stride.Graphics.Texture;
#else
using System.Drawing;
using System.Numerics;
using Texture2D = System.Object;
#endif

namespace FontStashSharp
{
	public enum FontSystemEffect
	{
		None,
		Blurry,
		Stroked
	}

	public class FontSystemSettings
	{
		internal static readonly FontSystemSettings Default = new FontSystemSettings();

		private int _effectAmount = 0;
		public FontSystemEffect Effect = FontSystemEffect.None;

		private int _textureWidth = 1024, _textureHeight = 1024;
		private float _fontResolutionFactor = 1.0f;
		private int _kernelWidth = 0, _kernelHeight = 0;

		public int EffectAmount
		{
			get
			{
				return _effectAmount;
			}

			set
			{
				if (value < 0 || value > 20)
				{
					throw new ArgumentOutOfRangeException("value");
				}

				_effectAmount = value;
			}
		}

		public int TextureWidth
		{
			get
			{
				return _textureWidth;
			}

			set
			{
				if (value <= 0)
				{
					throw new ArgumentOutOfRangeException("value");

				}

				_textureWidth = value;
			}
		}

		public int TextureHeight
		{
			get
			{
				return _textureHeight;
			}

			set
			{
				if (value <= 0)
				{
					throw new ArgumentOutOfRangeException("value");

				}

				_textureHeight = value;
			}
		}

		public bool PremultiplyAlpha = true;

		public float FontResolutionFactor
		{
			get
			{
				return _fontResolutionFactor;
			}

			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("value", value, "This cannot be smaller than 0");
				}

				_fontResolutionFactor = value;
			}
		}

		public int KernelWidth
		{
			get
			{
				return _kernelWidth;
			}

			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("value", value, "This cannot be smaller than 0");
				}

				_kernelWidth = value;
			}
		}

		public int KernelHeight
		{
			get
			{
				return _kernelHeight;
			}

			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("value", value, "This cannot be smaller than 0");
				}

				_kernelHeight = value;
			}
		}

		/// <summary>
		/// Use existing texture for storing glyphs
		/// If this is set, then TextureWidth & TextureHeight are ignored
		/// </summary>
		public Texture2D ExistingTexture { get; set; }

		/// <summary>
		/// Defines rectangle of the used space in the ExistingTexture
		/// </summary>
		public Rectangle ExistingTextureUsedSpace { get; set; }

		/// <summary>
		/// Font Rasterizer. If set to null then default rasterizer(StbTrueTypeSharp) is used.
		/// </summary>
		public IFontLoader FontLoader { get; set; }

		public FontSystemSettings Clone()
		{
			return new FontSystemSettings
			{
				Effect = Effect,
				EffectAmount = EffectAmount,
				TextureWidth = TextureWidth,
				TextureHeight = TextureHeight,
				PremultiplyAlpha = PremultiplyAlpha,
				FontResolutionFactor = FontResolutionFactor,
				KernelWidth = KernelWidth,
				KernelHeight = KernelHeight,
				ExistingTexture = ExistingTexture,
				ExistingTextureUsedSpace = ExistingTextureUsedSpace,
				FontLoader = FontLoader
			};
		}
	}
}