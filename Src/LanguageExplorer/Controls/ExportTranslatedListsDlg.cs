// Copyright (c) 2010-2020 SIL International
// This software is licensed under the LGPL, version 2.1 or later
// (http://www.gnu.org/licenses/lgpl-2.1.html)

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using DialogAdapters;
using SIL.FieldWorks.Common.FwUtils;
using SIL.LCModel;
using SIL.LCModel.Core.WritingSystems;

namespace LanguageExplorer.Controls
{
	/// <summary>
	/// This dialog allows the user to select specific lists to export in specific writing
	/// systems.
	/// </summary>
	internal sealed partial class ExportTranslatedListsDlg : Form
	{
		private IPropertyTable m_propertyTable;
		private LcmCache m_cache;
		private string m_titleFrag;
		private string m_defaultExt;
		private string m_filter;
		private Dictionary<int, bool> m_excludedListFlids = new Dictionary<int, bool>();

		/// <summary />
		internal ExportTranslatedListsDlg()
		{
			InitializeComponent();
			m_btnExport.Enabled = false;
			// We don't want to deal with these lists, at least for now.
			m_excludedListFlids.Add(MoMorphDataTags.kflidProdRestrict, true);
			m_excludedListFlids.Add(ReversalIndexTags.kflidPartsOfSpeech, true);
			m_excludedListFlids.Add(PhPhonDataTags.kflidPhonRuleFeats, true);
			m_excludedListFlids.Add(LangProjectTags.kflidAffixCategories, true);
			m_excludedListFlids.Add(LangProjectTags.kflidAnnotationDefs, true);
			m_excludedListFlids.Add(LangProjectTags.kflidCheckLists, true);
			m_columnLists.Width = m_lvLists.Width - 25;
			m_columnWs.Width = m_lvWritingSystems.Width - 25;
		}

		/// <summary>
		/// Initialize the dialog with all needed information.
		/// </summary>
		internal void Initialize(IPropertyTable propertyTable, LcmCache cache, string titleFrag, string defaultExt, string filter)
		{
			m_propertyTable = propertyTable;
			m_cache = cache;
			m_titleFrag = titleFrag;
			m_defaultExt = defaultExt;
			m_filter = filter;
			FillInLists();
			FillInWritingSystems();
		}

		/// <summary>
		/// Get the selected output filename.
		/// </summary>
		internal string FileName => m_tbFilepath.Text;

		/// <summary>
		/// Get the list of selected writing systems.
		/// </summary>
		internal List<int> SelectedWritingSystems
		{
			get
			{
				var list = new List<int>(m_lvWritingSystems.CheckedItems.Count);
				foreach (var item in m_lvWritingSystems.CheckedItems)
				{
					Debug.Assert(item is ListViewItem);
					var lvi = item as ListViewItem;
					Debug.Assert(lvi.Tag is CoreWritingSystemDefinition);
					list.Add(((CoreWritingSystemDefinition)lvi.Tag).Handle);
				}
				return list;
			}
		}

		/// <summary>
		/// Get the list of selected lists.
		/// </summary>
		internal List<ICmPossibilityList> SelectedLists
		{
			get
			{
				var list = new List<ICmPossibilityList>(m_lvLists.CheckedItems.Count);
				foreach (var item in m_lvLists.CheckedItems)
				{
					Debug.Assert(item is ListViewItem);
					var lvi = item as ListViewItem;
					Debug.Assert(lvi.Tag is ICmPossibilityList);
					list.Add(lvi.Tag as ICmPossibilityList);
				}
				return list;
			}
		}

		private void FillInLists()
		{
			var repo = m_cache.ServiceLocator.GetInstance<ICmPossibilityListRepository>();
			foreach (var list in repo.AllInstances())
			{
				if (list.Owner == null || list.Owner == m_cache.LangProject.TranslatedScriptureOA || m_excludedListFlids.ContainsKey(list.OwningFlid))
				{
					continue;
				}
				var lvi = new ListViewItem
				{
					Text = list.Name.UserDefaultWritingSystem.Text
				};
				if (string.IsNullOrEmpty(lvi.Text) || lvi.Text == list.Name.NotFoundTss.Text)
				{
					lvi.Text = list.Name.BestAnalysisVernacularAlternative.Text;
				}
				lvi.Tag = list;
				m_lvLists.Items.Add(lvi);
			}
			m_lvLists.Sort();
		}

		private void FillInWritingSystems()
		{
			foreach (var xws in m_cache.LangProject.AnalysisWritingSystems)
			{
				if (xws.IcuLocale != "en")
				{
					m_lvWritingSystems.Items.Add(CreateListViewItemForWs(xws));
				}
			}
			foreach (var xws in m_cache.LangProject.VernacularWritingSystems)
			{
				if (xws.IcuLocale != "en")
				{
					m_lvWritingSystems.Items.Add(CreateListViewItemForWs(xws));
				}
			}
			m_lvWritingSystems.Sort();
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			m_columnLists.Width = m_lvLists.Width - 25;
			m_columnWs.Width = m_lvWritingSystems.Width - 25;
		}

		private ListViewItem CreateListViewItemForWs(CoreWritingSystemDefinition xws)
		{
			var lvi = new ListViewItem
			{
				Text = xws.DisplayLabel,
				Tag = xws,
				Checked = xws.Handle == m_cache.DefaultAnalWs
			};
			return lvi;
		}

		private void m_btnBrowse_Click(object sender, EventArgs e)
		{
			using (var dlg = new SaveFileDialogAdapter())
			{
				dlg.AddExtension = true;
				dlg.DefaultExt = string.IsNullOrEmpty(m_defaultExt) ? ".xml" : m_defaultExt;
				dlg.Filter = string.IsNullOrEmpty(m_filter) ? "*.xml" : m_filter;
				dlg.Title = string.Format(LanguageExplorerResources.ExportTo0, string.IsNullOrEmpty(m_titleFrag) ? "Translated List" : m_titleFrag);
				dlg.InitialDirectory = m_propertyTable.GetValue("ExportDir", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
				if (dlg.ShowDialog(this) != DialogResult.OK)
				{
					return;
				}
				m_tbFilepath.Text = dlg.FileName;
				EnableExportButton();
			}
		}

		private void m_btnExport_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void m_btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void m_lvLists_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			EnableExportButton();
		}

		private void m_lvWritingSystems_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			EnableExportButton();
		}

		private void EnableExportButton()
		{
			if (string.IsNullOrEmpty(m_tbFilepath.Text) || string.IsNullOrEmpty(m_tbFilepath.Text.Trim()))
			{
				m_btnExport.Enabled = false;
				return;
			}
			if (m_lvLists.CheckedItems.Count == 0)
			{
				m_btnExport.Enabled = false;
				return;
			}
			if (m_lvWritingSystems.CheckedItems.Count == 0)
			{
				m_btnExport.Enabled = false;
				return;
			}
			m_btnExport.Enabled = true;
		}

		private void m_btnHelp_Click(object sender, EventArgs e)
		{
			ShowHelp.ShowHelpTopic(m_propertyTable.GetValue<IHelpTopicProvider>(LanguageExplorerConstants.HelpTopicProvider), "khtpExportTranslatedListsDlg");
		}

		private void m_btnSelectAll_Click(object sender, EventArgs e)
		{
			foreach (var obj in m_lvLists.Items)
			{
				((ListViewItem)obj).Checked = true;
			}
		}

		private void m_btnClearAll_Click(object sender, EventArgs e)
		{
			foreach (var obj in m_lvLists.Items)
			{
				((ListViewItem)obj).Checked = false;
			}
		}

		private void m_tbFilepath_TextChanged(object sender, EventArgs e)
		{
			EnableExportButton();
		}
	}
}