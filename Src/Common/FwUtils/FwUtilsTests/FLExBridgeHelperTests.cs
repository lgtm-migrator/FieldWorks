// Copyright (c) 2021-2021 SIL International
// This software is licensed under the LGPL, version 2.1 or later
// (http://www.gnu.org/licenses/lgpl-2.1.html)

using NUnit.Framework;

namespace SIL.FieldWorks.Common.FwUtils
{
	[TestFixture]
	public class FlexBridgeListenerTests
	{
		/// <remarks>Requires FLEx Bridge to be available</remarks>
		[Test]
		[Category("ByHand")]
		public void FlexBridgeDataVersion()
		{
			var result = FLExBridgeHelper.FlexBridgeDataVersion;
			Assert.That(result, Is.Not.Null.Or.Empty);
			Assert.That(result, Is.EqualTo(result.Trim()));
			Assert.That(result.Length, Is.GreaterThanOrEqualTo(3));
		}
	}
}
