﻿// Copyright (c) 2015-2020 SIL International
// This software is licensed under the LGPL, version 2.1 or later
// (http://www.gnu.org/licenses/lgpl-2.1.html)

using System;
using System.Windows.Forms;
// using SIL.FieldWorks.Common.Framework;
using SIL.FieldWorks.Common.FwUtils;

namespace LanguageExplorer.Controls
{
	internal partial class RestoreDefaultsDlg : Form
	{
		private const string s_helpTopic = "khtpRestoreDefaults";
		private IFlexApp m_app;

		public RestoreDefaultsDlg()
		{
			InitializeComponent();
		}

		public RestoreDefaultsDlg(IFlexApp app)
			: this()
		{
			m_app = app;
		}

		private void m_btnHelp_Click(object sender, EventArgs e)
		{
			ShowHelp.ShowHelpTopic(m_app, s_helpTopic);
		}

		private void m_btnYes_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Yes;
			Close();
		}
	}
}
