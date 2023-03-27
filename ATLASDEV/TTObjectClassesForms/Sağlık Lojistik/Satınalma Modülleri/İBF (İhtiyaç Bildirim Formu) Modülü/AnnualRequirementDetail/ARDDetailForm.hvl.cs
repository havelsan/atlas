
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
    /// İstek Detayları
    /// </summary>
    public partial class ARDDetailForm : TTForm
    {
        protected TTObjectClasses.AnnualRequirementDetail _AnnualRequirementDetail
        {
            get { return (TTObjectClasses.AnnualRequirementDetail)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid StocksGrid;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTTextBoxColumn Amount2;
        protected ITTTextBoxColumn SurplusNeed;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn datagridviewcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTLabel ttlabel1;
        protected ITTButton cmdRefresh;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("125edbf5-03fb-4bdd-b19a-be4f9bfa0eaf"));
            StocksGrid = (ITTGrid)AddControl(new Guid("a9523ade-ed68-47de-a296-e7eb07f6339d"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("da3880e0-b5bc-4b46-b4c2-7b3fc7e7726a"));
            Amount2 = (ITTTextBoxColumn)AddControl(new Guid("700dfd21-e217-4b64-bd40-b0216594ea6d"));
            SurplusNeed = (ITTTextBoxColumn)AddControl(new Guid("c5a7397e-0303-464e-a2cd-404b54b03f6c"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("9fff4e80-f9a5-4cd2-8ecd-46a4660c4c75"));
            datagridviewcolumn1 = (ITTListBoxColumn)AddControl(new Guid("615f0a5e-d0d5-4534-9922-33e1118ca388"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("cc4873e7-54f0-44bc-afc8-c212ede1d6e1"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("bd4cfecf-37ea-4ea5-a466-9c51d42403d0"));
            cmdRefresh = (ITTButton)AddControl(new Guid("9aac0705-68fb-4619-96fc-b75da33c770b"));
            base.InitializeControls();
        }

        public ARDDetailForm() : base("ANNUALREQUIREMENTDETAIL", "ARDDetailForm")
        {
        }

        protected ARDDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}