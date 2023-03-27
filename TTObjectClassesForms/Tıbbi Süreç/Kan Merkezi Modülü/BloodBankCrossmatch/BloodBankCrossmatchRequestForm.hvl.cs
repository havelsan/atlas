
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
    /// Kan Bankası Crossmatch Testi İstek Ekranı
    /// </summary>
    public partial class BloodBankCrossmatchRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Crossmatch Testi
    /// </summary>
        protected TTObjectClasses.BloodBankCrossmatch _BloodBankCrossmatch
        {
            get { return (TTObjectClasses.BloodBankCrossmatch)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("d1ab5d19-21f6-4eb2-858c-9c09cc6ccf54"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("4d8e5a52-07e0-457c-bc83-e88e296ef800"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("cd6c24e4-d517-49c2-bb44-35cf113f4a1f"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("e1888d67-aae6-43d7-a5bd-1d475fe2d1aa"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("bda6d717-f563-46a1-bddc-dac1270e62de"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("eed912ab-3363-4362-abce-a31daa12eb0c"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("6801d71c-49b7-4ce3-9211-9f53cc6ae2be"));
            base.InitializeControls();
        }

        public BloodBankCrossmatchRequestForm() : base("BLOODBANKCROSSMATCH", "BloodBankCrossmatchRequestForm")
        {
        }

        protected BloodBankCrossmatchRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}