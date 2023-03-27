
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
    /// Radyoloji Şablon Tanım Formu
    /// </summary>
    public partial class RadiologyAcceptTemplateForm : TTDefinitionForm
    {
    /// <summary>
    /// Radyoloji Şablon Tanımı
    /// </summary>
        protected TTObjectClasses.RadiologyAcceptTemplateDefinition _RadiologyAcceptTemplateDefinition
        {
            get { return (TTObjectClasses.RadiologyAcceptTemplateDefinition)_ttObject; }
        }

        protected ITTLabel ttlabel4;
        protected ITTGrid GRIDUSERRESOURCES;
        protected ITTListBoxColumn Test;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTTextBox NAME;
        protected ITTObjectListBox RESUSER;
        override protected void InitializeControls()
        {
            ttlabel4 = (ITTLabel)AddControl(new Guid("456b0e34-ef8f-4d25-bac3-ec7319c6a2cd"));
            GRIDUSERRESOURCES = (ITTGrid)AddControl(new Guid("43826b14-e90b-4cc3-8b1e-a6bbf33b2e1c"));
            Test = (ITTListBoxColumn)AddControl(new Guid("e34d8467-f050-4eaf-85c9-79266f7cf824"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("23af5046-fc61-4df8-a05f-e2870e676ea1"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("fee0d11e-be59-4802-89f2-8854bfe4c206"));
            NAME = (ITTTextBox)AddControl(new Guid("91fd2490-a843-4a90-b577-18dc724e3be4"));
            RESUSER = (ITTObjectListBox)AddControl(new Guid("1aa1dd4f-13cc-44bc-bd68-2e4b2ba16c5c"));
            base.InitializeControls();
        }

        public RadiologyAcceptTemplateForm() : base("RADIOLOGYACCEPTTEMPLATEDEFINITION", "RadiologyAcceptTemplateForm")
        {
        }

        protected RadiologyAcceptTemplateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}