
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
    /// PSK Üye Klinik Tanımı
    /// </summary>
    public partial class HCPMemberClinicsDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// PSK Üye Klinik Tanımları
    /// </summary>
        protected TTObjectClasses.HCPMemberClinicsDefinition _HCPMemberClinicsDefinition
        {
            get { return (TTObjectClasses.HCPMemberClinicsDefinition)_ttObject; }
        }

        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        protected ITTLabel labelMemberClinic;
        protected ITTObjectListBox MemberClinic;
        override protected void InitializeControls()
        {
            labelCode = (ITTLabel)AddControl(new Guid("86658cb1-988e-4a2d-ab1b-6c083580b432"));
            Code = (ITTTextBox)AddControl(new Guid("880605a9-5d3f-485c-9a53-447ac635c7be"));
            labelMemberClinic = (ITTLabel)AddControl(new Guid("3c0b99c3-221b-4482-bb3d-837b4f6e90f6"));
            MemberClinic = (ITTObjectListBox)AddControl(new Guid("24ad1033-2450-4e1d-a59a-45efd7708448"));
            base.InitializeControls();
        }

        public HCPMemberClinicsDefinitionForm() : base("HCPMEMBERCLINICSDEFINITION", "HCPMemberClinicsDefinitionForm")
        {
        }

        protected HCPMemberClinicsDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}