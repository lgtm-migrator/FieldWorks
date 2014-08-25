using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace XCore
{
	public interface IImageCollection : IDisposable
	{
		/// <summary/>
		bool IsDisposed { get; }

		/// <summary/>
		ImageList ImageList { get; }

		/// <summary>
		/// append the images in this list to our ImageList
		/// </summary>
		/// <param name="list">the ImageList to append</param>
		/// <param name="labels">the labels, in order, for each imaging the list</param>
		void AddList (ImageList list, string[] labels);

		/// <summary/>
		Image GetImage(string label);

		/// <summary/>
		int GetImageIndex(string label);

		/// <summary/>
		void AddList(XmlNodeList nodes);
	}
}