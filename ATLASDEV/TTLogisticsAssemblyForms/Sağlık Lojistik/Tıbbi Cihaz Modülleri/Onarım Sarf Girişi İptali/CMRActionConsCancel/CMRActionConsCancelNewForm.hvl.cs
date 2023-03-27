
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
    /// Onarım Sarf Giriş İptal 
    /// </summary>
    public partial class CMRActionConsCancelNewForm : ActionForm
    {
    /// <summary>
    /// Onarım Sarf Girişi İptali
    /// </summary>
        protected TTObjectClasses.CMRActionConsCancel _CMRActionConsCancel
        {
            get { return (TTObjectClasses.CMRActionConsCancel)_ttObject; }
        }

        protected ITTButton cmdConsDetail;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox ID;
        protected ITTTextBox CMRActionRequestNo;
        protected ITTButton cmdFindCMRAction;
        protected ITTGrid CMRActionConsCancelDetails;
        protected ITTCheckBoxColumn CancelCMRActionConsCancelDetail;
        protected ITTListBoxColumn MaterialName2;
        protected ITTTextBoxColumn Amount;
        protected ITTLabel labelID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelCMRActionRequestNo;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            cmdConsDetail = (ITTButton)AddControl(new Guid("d8b49068-1f62-477e-aa4a-bf6ce1eec226"));
            labelDescription = (ITTLabel)AddControl(new Guid("b121f1d9-8618-4113-a344-98c25be9e632"));
            Description = (ITTTextBox)AddControl(new Guid("32779bac-4e8a-496e-9f70-9778f2d64fa8"));
            ID = (ITTTextBox)AddControl(new Guid("ac8bb000-e88f-43ce-82c0-21aa98dd09d9"));
            CMRActionRequestNo = (ITTTextBox)AddControl(new Guid("b657bde4-3001-4fb4-8b83-01645db115dc"));
            cmdFindCMRAction = (ITTButton)AddControl(new Guid("5729e9c6-3e88-4f32-a9f6-79a0bc2792cb"));
            CMRActionConsCancelDetails = (ITTGrid)AddControl(new Guid("5b56155e-2df8-4174-bf50-71d0689b8b46"));
            CancelCMRActionConsCancelDetail = (ITTCheckBoxColumn)AddControl(new Guid("fa2142b3-1f3f-41e4-908a-26427a31582d"));
            MaterialName2 = (ITTListBoxColumn)AddControl(new Guid("a695fd99-e935-44aa-84db-04a1a4af7b53"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("563f9ea0-8cfd-4b4a-88fa-e5bd55aeec10"));
            labelID = (ITTLabel)AddControl(new Guid("ae7637af-c143-4739-bda7-8c30b538a851"));
            labelActionDate = (ITTLabel)AddControl(new Guid("2ec9f076-5365-4998-bf63-e106975fa4a1"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("8d911e4a-20d4-4eb8-8806-d91ae5f973e5"));
            labelCMRActionRequestNo = (ITTLabel)AddControl(new Guid("b1b89d0b-06fd-46ef-bec9-6c94e0a1da73"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("83606cf3-285d-4a62-983f-cc4e3167488b"));
            base.InitializeControls();
        }

        public CMRActionConsCancelNewForm() : base("CMRACTIONCONSCANCEL", "CMRActionConsCancelNewForm")
        {
        }

        protected CMRActionConsCancelNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}