
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
    /// Araç Listesi
    /// </summary>
    public partial class VehicleListForm : TTForm
    {
    /// <summary>
    /// Araç
    /// </summary>
        protected TTObjectClasses.MNZVehicle _MNZVehicle
        {
            get { return (TTObjectClasses.MNZVehicle)_ttObject; }
        }

        protected ITTLabel labelSecretInformation;
        protected ITTObjectListBox Model;
        protected ITTLabel labelModel;
        protected ITTTextBox LicencePlate;
        protected ITTObjectListBox Person;
        protected ITTObjectListBox Mark;
        protected ITTLabel labelDescription;
        protected ITTLabel labelMark;
        protected ITTEnumComboBox Color;
        protected ITTDateTimePicker BannedDate;
        protected ITTLabel labelLicencePlate;
        protected ITTLabel labelColor;
        protected ITTTextBox SecretInformation;
        protected ITTCheckBox IsForbidden;
        protected ITTLabel labelPerson;
        protected ITTTextBox Description;
        protected ITTGrid ttgrid1;
        protected ITTLabel labelBannedDate;
        override protected void InitializeControls()
        {
            labelSecretInformation = (ITTLabel)AddControl(new Guid("9533126a-9f16-40eb-84e6-2a4382b69ba9"));
            Model = (ITTObjectListBox)AddControl(new Guid("fa062c15-66b4-4070-8f1c-be1a8726e6cc"));
            labelModel = (ITTLabel)AddControl(new Guid("c1fc0d36-0573-4707-948b-d49fef46fbdf"));
            LicencePlate = (ITTTextBox)AddControl(new Guid("3ec8ba2e-062d-465a-8997-bd0b096d9806"));
            Person = (ITTObjectListBox)AddControl(new Guid("9b2f9e21-0297-42bc-8286-bbe64b4fd8c4"));
            Mark = (ITTObjectListBox)AddControl(new Guid("e6c4a81c-6d24-4c76-888e-9cf461b5e444"));
            labelDescription = (ITTLabel)AddControl(new Guid("c3a5304b-d295-459e-b87f-b6b228f7581c"));
            labelMark = (ITTLabel)AddControl(new Guid("4531cffe-083e-469a-9b4b-929b8f6050cb"));
            Color = (ITTEnumComboBox)AddControl(new Guid("50a097f3-b222-4b8a-a008-9e833d576ccc"));
            BannedDate = (ITTDateTimePicker)AddControl(new Guid("5177c565-2960-45f8-a54b-65388bc1ec0f"));
            labelLicencePlate = (ITTLabel)AddControl(new Guid("383e6919-d916-402c-b0a6-72ab6c57e0e0"));
            labelColor = (ITTLabel)AddControl(new Guid("db17f40a-df5e-464a-b5b7-5b466de3d503"));
            SecretInformation = (ITTTextBox)AddControl(new Guid("cae061f5-829e-447d-852f-55b6877ad8dc"));
            IsForbidden = (ITTCheckBox)AddControl(new Guid("31deddc4-5552-4795-a237-69e9532b18ed"));
            labelPerson = (ITTLabel)AddControl(new Guid("d4aba21f-6617-42f8-8dcf-467de3691c1c"));
            Description = (ITTTextBox)AddControl(new Guid("bcc67776-b5e4-4bdc-9dbb-1661e484c3e4"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("455c1105-5477-41a4-8ae9-ff24e9599304"));
            labelBannedDate = (ITTLabel)AddControl(new Guid("42c2a401-be3d-471e-aeb4-ef633c50332b"));
            base.InitializeControls();
        }

        public VehicleListForm() : base("MNZVEHICLE", "VehicleListForm")
        {
        }

        protected VehicleListForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}