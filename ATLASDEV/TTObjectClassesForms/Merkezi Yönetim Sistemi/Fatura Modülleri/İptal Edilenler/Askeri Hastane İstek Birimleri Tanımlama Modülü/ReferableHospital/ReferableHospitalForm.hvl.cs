
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
    /// XXXXXX XXXXXX İstek Bölümleri Kaynak Tanımları
    /// </summary>
    public partial class ReferableHospitalForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.ReferableHospital _ReferableHospital
        {
            get { return (TTObjectClasses.ReferableHospital)_ttObject; }
        }

        protected ITTGrid ReferableResources;
        protected ITTTextBoxColumn ResourceObjectID;
        protected ITTTextBoxColumn ResourceName;
        override protected void InitializeControls()
        {
            ReferableResources = (ITTGrid)AddControl(new Guid("4a024cd7-f7ea-45b1-b515-4c89d303e5dd"));
            ResourceObjectID = (ITTTextBoxColumn)AddControl(new Guid("e4581497-e92f-4ef6-ada9-17e963dc4ce0"));
            ResourceName = (ITTTextBoxColumn)AddControl(new Guid("1f34014f-5a48-430d-af13-cce1b4c08b24"));
            base.InitializeControls();
        }

        public ReferableHospitalForm() : base("REFERABLEHOSPITAL", "ReferableHospitalForm")
        {
        }

        protected ReferableHospitalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}