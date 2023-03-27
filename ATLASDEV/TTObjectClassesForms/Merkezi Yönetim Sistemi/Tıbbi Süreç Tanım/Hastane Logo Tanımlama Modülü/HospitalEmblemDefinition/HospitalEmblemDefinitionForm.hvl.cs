
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
    /// XXXXXX Logo Tanımlama Formu
    /// </summary>
    public partial class HospitalEmblemDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// XXXXXX Logo Tanımlama
    /// </summary>
        protected TTObjectClasses.HospitalEmblemDefinition _HospitalEmblemDefinition
        {
            get { return (TTObjectClasses.HospitalEmblemDefinition)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        protected ITTPictureBoxControl ttpictureboxcontrol1;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("acabf1a0-38e5-476a-b255-88b7c43bd17e"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("e31edaac-23e7-4555-9aae-9d5f8604ba27"));
            ttpictureboxcontrol1 = (ITTPictureBoxControl)AddControl(new Guid("182aaf40-9bbb-4dc3-8342-debbb6454f9a"));
            base.InitializeControls();
        }

        public HospitalEmblemDefinitionForm() : base("HOSPITALEMBLEMDEFINITION", "HospitalEmblemDefinitionForm")
        {
        }

        protected HospitalEmblemDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}