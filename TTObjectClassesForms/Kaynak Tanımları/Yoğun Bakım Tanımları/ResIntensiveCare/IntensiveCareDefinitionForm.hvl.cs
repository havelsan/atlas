
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
    /// Yoğun Bakım Tanımı
    /// </summary>
    public partial class IntensiveCareDefinitionForm : TTForm
    {
    /// <summary>
    /// Yoğun Bakım
    /// </summary>
        protected TTObjectClasses.ResIntensiveCare _ResIntensiveCare
        {
            get { return (TTObjectClasses.ResIntensiveCare)_ttObject; }
        }

        protected ITTLabel labelLocation;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTTextBox InpatientQuota;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTLabel labelDeskPhoneNumber;
        protected ITTLabel labelInpatientQuota;
        protected ITTCheckBox IgnoreQuotaControl;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelDepartment;
        protected ITTObjectListBox Department;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox ttcheckbox2;
        protected ITTGrid ResourceSpecialities;
        protected ITTListBoxColumn Speciality;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            labelLocation = (ITTLabel)AddControl(new Guid("a1455088-63b0-40c3-81a7-c8263d130533"));
            Location = (ITTTextBox)AddControl(new Guid("8645a604-d2bd-410a-8a8d-16bb3562bf28"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("080a13e4-da6a-48da-bd8f-4ea14ebe127c"));
            InpatientQuota = (ITTTextBox)AddControl(new Guid("5b47f57b-e374-4da3-bfc0-b23badfab59a"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("c4f4d1eb-dfc4-44c6-92ab-22207177bbda"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("6efccfed-906e-496f-b60d-d704cb60fc87"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("325a4922-bf20-435e-9bda-31372babfb42"));
            labelInpatientQuota = (ITTLabel)AddControl(new Guid("fb95c237-f016-4232-95d0-bab437c7dd55"));
            IgnoreQuotaControl = (ITTCheckBox)AddControl(new Guid("113becf2-6f41-4e0b-be8a-940f83027ac7"));
            labelStore = (ITTLabel)AddControl(new Guid("705cc377-b4eb-43b1-9264-aaeabb7af856"));
            Store = (ITTObjectListBox)AddControl(new Guid("393775c5-158a-4c6a-af04-dcbb4f3800fa"));
            labelDepartment = (ITTLabel)AddControl(new Guid("2c8b6d2c-7c7e-40a0-aceb-89a6bf9c53b4"));
            Department = (ITTObjectListBox)AddControl(new Guid("c2071393-9f70-4f15-9a81-b38584135fd5"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("083e0692-fc35-4927-b335-f5ecdde14c48"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("30435422-ddf9-408d-a588-476f80022b23"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("99bebbb4-b103-4b63-90a0-ed588c5a33bb"));
            ResourceSpecialities = (ITTGrid)AddControl(new Guid("2940f5dd-5534-4d99-8bc3-20ae45f6044e"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("6e5b78cc-066f-4cbf-b6a2-afb2d6512197"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("3d867751-229a-4bf2-9835-abd186191d09"));
            base.InitializeControls();
        }

        public IntensiveCareDefinitionForm() : base("RESINTENSIVECARE", "IntensiveCareDefinitionForm")
        {
        }

        protected IntensiveCareDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}