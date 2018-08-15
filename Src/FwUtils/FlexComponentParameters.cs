// Copyright (c) 2016-2017 SIL International
// This software is licensed under the LGPL, version 2.1 or later
// (http://www.gnu.org/licenses/lgpl-2.1.html)

using System;

namespace SIL.FieldWorks.Common.FwUtils
{
	/// <summary>
	/// Class that contains the three interfaces used in the IFlexComponent interface.
	/// </summary>
	public class FlexComponentParameters
	{
		/// <summary />
		public FlexComponentParameters(IPropertyTable propertyTable, IPublisher publisher, ISubscriber subscriber)
		{
			PropertyTable = propertyTable;
			Publisher = publisher;
			Subscriber = subscriber;
		}

		/// <summary>
		/// Get the property table.
		/// </summary>
		public IPropertyTable PropertyTable { get; }

		/// <summary>
		/// Get the publisher
		/// </summary>
		public IPublisher Publisher { get; }

		/// <summary>
		/// Get the subscriber
		/// </summary>
		public ISubscriber Subscriber { get; }

		/// <summary>
		/// Check to make sure an IFlexComponent can be initialized.
		/// </summary>
		public static void CheckInitializationValues(FlexComponentParameters sourceFlexComponentParameters, FlexComponentParameters targetFlexComponentParameters)
		{
			if (sourceFlexComponentParameters == null)
			{
				throw new ArgumentNullException(nameof(sourceFlexComponentParameters));
			}
			if (targetFlexComponentParameters == null)
			{
				throw new ArgumentNullException(nameof(targetFlexComponentParameters));
			}

			// The three source values must not be null.
			if (sourceFlexComponentParameters.PropertyTable == null)
			{
				throw new InvalidOperationException("No source property table.");
			}
			if (sourceFlexComponentParameters.Publisher == null)
			{
				throw new InvalidOperationException("No source publisher.");
			}
			if (sourceFlexComponentParameters.Subscriber == null)
			{
				throw new InvalidOperationException("No source subscriber.");
			}

			// Three target values must be null.
			if (targetFlexComponentParameters.PropertyTable != null)
			{
				throw new InvalidOperationException("target property table must be null");
			}
			if (targetFlexComponentParameters.Publisher != null)
			{
				throw new InvalidOperationException(" target publisher must be null");
			}
			if (targetFlexComponentParameters.Subscriber != null)
			{
				throw new InvalidOperationException("target subscriber must be null");
			}
		}
	}
}