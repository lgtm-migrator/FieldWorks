﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LanguageExplorer.Areas.Grammar {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class GrammarResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal GrammarResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LanguageExplorer.Areas.Grammar.GrammarResources", typeof(GrammarResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        ///&lt;parameters area=&quot;grammar&quot; id=&quot;POSList&quot; clerk=&quot;categories&quot; field=&quot;PartsOfSpeech&quot; altTitleId=&quot;PartOfSpeech-Plural&quot; filterBar=&quot;true&quot; editable=&quot;false&quot;&gt;
        ///&lt;!-- Please increment BrowseViewer.kBrowseViewVersion when you change these specs,
        /// so that XmlBrowseViewBaseVc can invalidate obsoleted columns that have been saved in each current control&apos;s ColumnList --&gt;
        ///	&lt;columns&gt;
        ///		&lt;column label=&quot;Name&quot; width=&quot;16%&quot; layout=&quot;Name&quot; ws=&quot;$ws=best analysis&quot; field=&quot;Name&quot;/&gt;
        ///		&lt;column la [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string GrammarCategoryBrowserParameters {
            get {
                return ResourceManager.GetString("GrammarCategoryBrowserParameters", resourceCulture);
            }
        }
    }
}
