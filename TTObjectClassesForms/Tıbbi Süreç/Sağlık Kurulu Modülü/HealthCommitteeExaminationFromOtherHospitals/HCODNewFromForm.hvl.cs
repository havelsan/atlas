
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
    /// Diğer XXXXXX(ler)den Sağlık Kurulu Muayenesi 
    /// </summary>
    public partial class HCODNewFrom : EpisodeActionForm
    {
    /// <summary>
    /// Diğer XXXXXX(ler)den Sağlık Kurulu Muayenesi
    /// </summary>
        protected TTObjectClasses.HealthCommitteeExaminationFromOtherHospitals _HealthCommitteeExaminationFromOtherHospitals
        {
            get { return (TTObjectClasses.HealthCommitteeExaminationFromOtherHospitals)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTTextBox TempText;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel labelNumberOfDocuments;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("cefd1502-7e2e-4e5b-aa69-f0f98a2df486"));
            TempText = (ITTTextBox)AddControl(new Guid("c4d7ad58-63c9-4ddc-8e1d-331357a0a43c"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("8fd76947-4871-4dfa-b2f0-d9f9fded56a4"));
            labelNumberOfDocuments = (ITTLabel)AddControl(new Guid("1680726b-e8b4-4ce9-b7a2-52f9e370cf28"));
            base.InitializeControls();
        }

        public HCODNewFrom() : base("HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS", "HCODNewFrom")
        {
        }

        protected HCODNewFrom(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}