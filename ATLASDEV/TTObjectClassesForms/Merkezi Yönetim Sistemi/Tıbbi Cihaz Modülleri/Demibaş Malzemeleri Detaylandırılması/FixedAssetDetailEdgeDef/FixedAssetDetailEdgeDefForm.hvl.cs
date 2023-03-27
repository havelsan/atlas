
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Uç Yapısı Tanımı
    /// </summary>
    public partial class FixedAssetDetailEdgeDefForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.FixedAssetDetailEdgeDef _FixedAssetDetailEdgeDef
        {
            get { return (TTObjectClasses.FixedAssetDetailEdgeDef)_ttObject; }
        }

        protected ITTLabel labelFixedAssetDetailBodyDef;
        protected ITTObjectListBox FixedAssetDetailBodyDef;
        protected ITTLabel labelEdgeName;
        protected ITTTextBox EdgeName;
        override protected void InitializeControls()
        {
            labelFixedAssetDetailBodyDef = (ITTLabel)AddControl(new Guid("3035380b-526f-48b2-b072-bcec1fc5c0b8"));
            FixedAssetDetailBodyDef = (ITTObjectListBox)AddControl(new Guid("9290b7d4-2587-45af-a0f6-29a4dc9757bc"));
            labelEdgeName = (ITTLabel)AddControl(new Guid("e74c47f0-729b-445c-99bd-032dae55bb69"));
            EdgeName = (ITTTextBox)AddControl(new Guid("ba511e25-37ed-4f97-a15a-e685bc738e40"));
            base.InitializeControls();
        }

        public FixedAssetDetailEdgeDefForm() : base("FIXEDASSETDETAILEDGEDEF", "FixedAssetDetailEdgeDefForm")
        {
        }

        protected FixedAssetDetailEdgeDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}