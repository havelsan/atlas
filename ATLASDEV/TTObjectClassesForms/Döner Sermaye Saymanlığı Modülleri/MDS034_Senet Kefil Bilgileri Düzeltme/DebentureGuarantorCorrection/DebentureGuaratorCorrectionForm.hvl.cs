
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
    /// Kefil Bilgileri Düzeltme
    /// </summary>
    public partial class DebentureGuaratorCorrectionForm : TTForm
    {
    /// <summary>
    /// Kefil Bilgileri Düzeltme
    /// </summary>
        protected TTObjectClasses.DebentureGuarantorCorrection _DebentureGuarantorCorrection
        {
            get { return (TTObjectClasses.DebentureGuarantorCorrection)_ttObject; }
        }

        protected ITTTabControl TabDebenturesInfo;
        protected ITTTabPage tttabpage1;
        protected ITTGrid GridDebentures;
        protected ITTTextBoxColumn DEBENTURENO;
        protected ITTDateTimePickerColumn DEBENTUREDUEDATE;
        protected ITTTextBoxColumn DEBENTUREPRICE;
        protected ITTTextBoxColumn STATUS;
        protected ITTButtonColumn GUARANTORINFO;
        protected ITTCheckBoxColumn CHANGED;
        protected ITTTextBoxColumn DEBENTUREOBJECTID;
        override protected void InitializeControls()
        {
            TabDebenturesInfo = (ITTTabControl)AddControl(new Guid("a2cbb901-a2c6-408e-8e74-b5cc2fbdb618"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("d7326ff7-afb2-449c-98ca-f7b3741f9653"));
            GridDebentures = (ITTGrid)AddControl(new Guid("cc7a1960-aabc-4d6e-ab53-f25341cffa52"));
            DEBENTURENO = (ITTTextBoxColumn)AddControl(new Guid("afa88097-622d-42db-8bd1-e23bc4128e95"));
            DEBENTUREDUEDATE = (ITTDateTimePickerColumn)AddControl(new Guid("eb2281fa-b567-4a59-aeae-42d919344949"));
            DEBENTUREPRICE = (ITTTextBoxColumn)AddControl(new Guid("3620bfa2-ec39-45ba-8998-cde58c7cef95"));
            STATUS = (ITTTextBoxColumn)AddControl(new Guid("4bbf58e9-b685-4fe5-baba-9b024cff7dc7"));
            GUARANTORINFO = (ITTButtonColumn)AddControl(new Guid("c42b1e70-cda6-4249-a059-39bcc3702b0c"));
            CHANGED = (ITTCheckBoxColumn)AddControl(new Guid("6cdcc686-80cd-4ad8-a8cc-aeabfad099b4"));
            DEBENTUREOBJECTID = (ITTTextBoxColumn)AddControl(new Guid("bce19868-22fd-4b59-a767-e6892b06c85e"));
            base.InitializeControls();
        }

        public DebentureGuaratorCorrectionForm() : base("DEBENTUREGUARANTORCORRECTION", "DebentureGuaratorCorrectionForm")
        {
        }

        protected DebentureGuaratorCorrectionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}