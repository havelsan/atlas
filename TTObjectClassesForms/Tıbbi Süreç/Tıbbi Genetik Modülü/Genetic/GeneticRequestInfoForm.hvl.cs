
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
    /// Genetik İstek Açıklama Formu
    /// </summary>
    public partial class GeneticRequestInfoForm : TTForm
    {
    /// <summary>
    /// Tıbbi Genetik İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Genetic _Genetic
        {
            get { return (TTObjectClasses.Genetic)_ttObject; }
        }

        protected ITTLabel labelPreInformation;
        protected ITTTextBox PREDIAGNOSIS;
        protected ITTTextBox txtRequestCorrectionReason;
        protected ITTTextBox SendenMaterial;
        protected ITTLabel lblRequestCorrectionReason;
        protected ITTLabel ttlabel7;
        protected ITTCheckBox EmergencyCheckBox;
        override protected void InitializeControls()
        {
            labelPreInformation = (ITTLabel)AddControl(new Guid("0ef8f31f-66de-421a-9bc2-f26c2211a727"));
            PREDIAGNOSIS = (ITTTextBox)AddControl(new Guid("2fe84ad3-9d41-4cc2-a1c1-51a6b7bf6e62"));
            txtRequestCorrectionReason = (ITTTextBox)AddControl(new Guid("81678115-0f78-465c-8a5d-8df440bb9fc2"));
            SendenMaterial = (ITTTextBox)AddControl(new Guid("179d6f72-ebfb-4401-a58b-3808ed6b81e2"));
            lblRequestCorrectionReason = (ITTLabel)AddControl(new Guid("2ec2f7dd-87db-4c42-940c-4b7f356b4bc7"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("4223d5b5-6d8f-4df5-858c-077fe2f484f4"));
            EmergencyCheckBox = (ITTCheckBox)AddControl(new Guid("3d1c82a1-2662-42ae-abca-18fbc50a6385"));
            base.InitializeControls();
        }

        public GeneticRequestInfoForm() : base("GENETIC", "GeneticRequestInfoForm")
        {
        }

        protected GeneticRequestInfoForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}