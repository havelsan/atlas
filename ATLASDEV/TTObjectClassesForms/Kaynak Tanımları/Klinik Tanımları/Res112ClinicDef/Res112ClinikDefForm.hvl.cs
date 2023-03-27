
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
    public partial class Res112ClinikDefForm : TTDefinitionForm
    {
    /// <summary>
    /// 112 Klinik Tanımları
    /// </summary>
        protected TTObjectClasses.Res112ClinicDef _Res112ClinicDef
        {
            get { return (TTObjectClasses.Res112ClinicDef)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("c74ddf47-d86d-464b-ab4f-2a53f867c618"));
            Name = (ITTTextBox)AddControl(new Guid("49dd2665-a779-47e4-8c76-775fa07258a4"));
            Code = (ITTTextBox)AddControl(new Guid("9771b608-fae4-45bd-95b7-f7961acfb1e0"));
            labelCode = (ITTLabel)AddControl(new Guid("cd5acd27-f5bf-44e2-a5e8-65025c70ab55"));
            base.InitializeControls();
        }

        public Res112ClinikDefForm() : base("RES112CLINICDEF", "Res112ClinikDefForm")
        {
        }

        protected Res112ClinikDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}