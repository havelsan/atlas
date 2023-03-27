
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
    /// Uzunluk Yapısı Tanımlama
    /// </summary>
    public partial class FixedAssetDetailLengthDefForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.FixedAssetDetailLengthDef _FixedAssetDetailLengthDef
        {
            get { return (TTObjectClasses.FixedAssetDetailLengthDef)_ttObject; }
        }

        protected ITTLabel labelProposedStockcardName;
        protected ITTTextBox ProposedStockcardName;
        protected ITTTextBox ProposedNATOStockNo;
        protected ITTTextBox Length;
        protected ITTLabel labelProposedNATOStockNo;
        protected ITTLabel labelEdgeNameFixedAssetDetailEdgeDef;
        protected ITTObjectListBox FixedAssetDetailEdgeDef;
        protected ITTLabel labelLength;
        override protected void InitializeControls()
        {
            labelProposedStockcardName = (ITTLabel)AddControl(new Guid("4c295bbf-76d3-43bd-9810-33cfa481cf02"));
            ProposedStockcardName = (ITTTextBox)AddControl(new Guid("6dbe2a73-acc9-493c-8b5f-e277d281529c"));
            ProposedNATOStockNo = (ITTTextBox)AddControl(new Guid("e15f380c-aedb-4add-b168-344121112358"));
            Length = (ITTTextBox)AddControl(new Guid("3d91a9cc-182d-4e9b-83c5-39a626c52f82"));
            labelProposedNATOStockNo = (ITTLabel)AddControl(new Guid("01c28150-8d8d-4970-b18c-08701e95a952"));
            labelEdgeNameFixedAssetDetailEdgeDef = (ITTLabel)AddControl(new Guid("cacf2b30-1731-4eaf-ad15-c0b76c70ebe2"));
            FixedAssetDetailEdgeDef = (ITTObjectListBox)AddControl(new Guid("827e3424-a624-42ee-bcb7-e27a0b651427"));
            labelLength = (ITTLabel)AddControl(new Guid("b401e9d6-e8d1-443c-9bd1-c2a452c42b1e"));
            base.InitializeControls();
        }

        public FixedAssetDetailLengthDefForm() : base("FIXEDASSETDETAILLENGTHDEF", "FixedAssetDetailLengthDefForm")
        {
        }

        protected FixedAssetDetailLengthDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}