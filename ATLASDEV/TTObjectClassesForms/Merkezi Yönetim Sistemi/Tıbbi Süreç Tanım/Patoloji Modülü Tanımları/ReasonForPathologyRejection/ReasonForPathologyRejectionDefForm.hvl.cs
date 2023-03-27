
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
    /// Patoloji Red Nedeni Tanımlama Ekranı
    /// </summary>
    public partial class ReasonForPathologyRejectionDefForm : TTDefinitionForm
    {
    /// <summary>
    /// Patoloji Red Sebebi
    /// </summary>
        protected TTObjectClasses.ReasonForPathologyRejection _ReasonForPathologyRejection
        {
            get { return (TTObjectClasses.ReasonForPathologyRejection)_ttObject; }
        }

        protected ITTCheckBox ISACTIVE;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            ISACTIVE = (ITTCheckBox)AddControl(new Guid("c555b7d1-26b2-42d3-a2f7-00f1d31fae00"));
            labelDescription = (ITTLabel)AddControl(new Guid("8d4518ee-d59e-4036-9c4c-dc2826022e45"));
            Description = (ITTTextBox)AddControl(new Guid("61505533-7171-4ffb-9fd3-a75e95fbd787"));
            Code = (ITTTextBox)AddControl(new Guid("40be715e-f3ab-49a9-b3a1-c63b52163a95"));
            labelCode = (ITTLabel)AddControl(new Guid("8ec86a73-465f-438e-872d-50ff6b58432b"));
            base.InitializeControls();
        }

        public ReasonForPathologyRejectionDefForm() : base("REASONFORPATHOLOGYREJECTION", "ReasonForPathologyRejectionDefForm")
        {
        }

        protected ReasonForPathologyRejectionDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}