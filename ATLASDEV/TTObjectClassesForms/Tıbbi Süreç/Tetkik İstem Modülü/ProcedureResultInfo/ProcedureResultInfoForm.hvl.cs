
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
    public partial class ProcedureResultInfoForm : BaseAdditionalInfoForm
    {
    /// <summary>
    /// İşlem Sonucu
    /// </summary>
        protected TTObjectClasses.ProcedureResultInfo _ProcedureResultInfo
        {
            get { return (TTObjectClasses.ProcedureResultInfo)_ttObject; }
        }

        protected ITTLabel labelResult;
        protected ITTTextBox Result;
        override protected void InitializeControls()
        {
            labelResult = (ITTLabel)AddControl(new Guid("faf9c1cb-94c1-4ec2-a1fe-db222ef47ee2"));
            Result = (ITTTextBox)AddControl(new Guid("fe26a574-29f3-4251-bba2-836983d0f4b2"));
            base.InitializeControls();
        }

        public ProcedureResultInfoForm() : base("PROCEDURERESULTINFO", "ProcedureResultInfoForm")
        {
        }

        protected ProcedureResultInfoForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}