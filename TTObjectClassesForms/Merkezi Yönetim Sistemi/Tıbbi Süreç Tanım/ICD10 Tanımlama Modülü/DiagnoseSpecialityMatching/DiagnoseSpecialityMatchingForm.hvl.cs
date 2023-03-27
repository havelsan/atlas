
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
    /// Tanı-Uzmanlık Dalı Eşleştirme Tanımları
    /// </summary>
    public partial class DiagnoseSpecialityMatchingForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Tanı-Uzmanlık Dalı Eşleştirme Tanımları
    /// </summary>
        protected TTObjectClasses.DiagnoseSpecialityMatching _DiagnoseSpecialityMatching
        {
            get { return (TTObjectClasses.DiagnoseSpecialityMatching)_ttObject; }
        }

        protected ITTGrid Diagnosis;
        protected ITTListBoxColumn DiagnosisDefinition;
        protected ITTLabel labelSpeciality;
        protected ITTObjectListBox Speciality;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            Diagnosis = (ITTGrid)AddControl(new Guid("b448810d-03b5-45f4-9ea0-e91a0896effe"));
            DiagnosisDefinition = (ITTListBoxColumn)AddControl(new Guid("002e40be-2199-4fad-8bd8-fec9fce381b9"));
            labelSpeciality = (ITTLabel)AddControl(new Guid("90b714a4-7b97-4323-b0e2-4b24e447c4e0"));
            Speciality = (ITTObjectListBox)AddControl(new Guid("c8ece834-aa3c-403e-a452-4ac45657f22b"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("7d9e8ff8-0417-46d3-9d2e-b8663dc41a40"));
            base.InitializeControls();
        }

        public DiagnoseSpecialityMatchingForm() : base("DIAGNOSESPECIALITYMATCHING", "DiagnoseSpecialityMatchingForm")
        {
        }

        protected DiagnoseSpecialityMatchingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}