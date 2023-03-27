
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
    /// Tanı Tedavi Koltuk Tanımları
    /// </summary>
    public partial class TreatmentDiagnosisChairForm : TTForm
    {
    /// <summary>
    /// Tanı Tedavi Kotukları Tanımları
    /// </summary>
        protected TTObjectClasses.ResTreatmentDiagnosisChair _ResTreatmentDiagnosisChair
        {
            get { return (TTObjectClasses.ResTreatmentDiagnosisChair)_ttObject; }
        }

        protected ITTLabel labelTreatmentDiagnosisRoom;
        protected ITTObjectListBox TreatmentDiagnosisRoom;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTCheckBox IsActive;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        protected ITTLabel labelQref;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            labelTreatmentDiagnosisRoom = (ITTLabel)AddControl(new Guid("1635267d-7065-45d9-8586-67554502b7f3"));
            TreatmentDiagnosisRoom = (ITTObjectListBox)AddControl(new Guid("51688be8-28b0-4dfc-bd97-8961e785b362"));
            labelStore = (ITTLabel)AddControl(new Guid("240524f5-e722-4910-b4f3-10f008cb01c5"));
            Store = (ITTObjectListBox)AddControl(new Guid("84d2e80e-e413-4adc-b3f5-748a5af93ab8"));
            Qref = (ITTTextBox)AddControl(new Guid("cc2bfeae-9d72-4ddf-99f5-0408623dfc10"));
            Name = (ITTTextBox)AddControl(new Guid("fe453488-8895-4c71-bc8d-fc66c63f170b"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("efab5f8a-1cda-4f2e-bcdb-6256e0a208e4"));
            Location = (ITTTextBox)AddControl(new Guid("05c2b0f2-6f6e-49cc-8c21-667cc724fbdd"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("76d01c66-683f-4cd1-824a-d6d30de80f52"));
            IsActive = (ITTCheckBox)AddControl(new Guid("aee53d0a-725f-45fb-b4b6-9293cf12b486"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("bdcc5a2d-3453-4f17-8aca-a8b2833f29ac"));
            labelLocation = (ITTLabel)AddControl(new Guid("3153093e-7ba0-4249-a2ba-3ea4a626bfcd"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("630a6612-ed05-4f73-99b4-476aca4380ea"));
            labelQref = (ITTLabel)AddControl(new Guid("b224a460-fdbc-4b16-9f22-fc8aa875d358"));
            labelName = (ITTLabel)AddControl(new Guid("c0bf47d6-fb70-45f3-ba91-b2bef11fad46"));
            base.InitializeControls();
        }

        public TreatmentDiagnosisChairForm() : base("RESTREATMENTDIAGNOSISCHAIR", "TreatmentDiagnosisChairForm")
        {
        }

        protected TreatmentDiagnosisChairForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}