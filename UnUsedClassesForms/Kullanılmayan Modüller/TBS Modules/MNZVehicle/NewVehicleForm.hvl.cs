
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
    /// Araç Giriş Formu
    /// </summary>
    public partial class NewVehicleForm : TTForm
    {
    /// <summary>
    /// Araç
    /// </summary>
        protected TTObjectClasses.MNZVehicle _MNZVehicle
        {
            get { return (TTObjectClasses.MNZVehicle)_ttObject; }
        }

        protected ITTLabel labelLicencePlate;
        protected ITTDateTimePicker BannedDate;
        protected ITTLabel labelMark;
        protected ITTLabel labelDescription;
        protected ITTObjectListBox Color;
        protected ITTTextBox Description;
        protected ITTLabel labelColor;
        protected ITTTextBox LicencePlate;
        protected ITTLabel labelBannedDate;
        protected ITTObjectListBox Mark;
        protected ITTLabel labelModel;
        protected ITTTextBox SecretInformation;
        protected ITTObjectListBox Model;
        protected ITTLabel labelSecretInformation;
        override protected void InitializeControls()
        {
            labelLicencePlate = (ITTLabel)AddControl(new Guid("361dc58d-2fb4-4b0b-b1c4-0561037f3292"));
            BannedDate = (ITTDateTimePicker)AddControl(new Guid("d6c13627-da85-484e-88ed-1c9de66620ea"));
            labelMark = (ITTLabel)AddControl(new Guid("673e2171-e123-4a7f-9f67-4da18ea749ad"));
            labelDescription = (ITTLabel)AddControl(new Guid("98419064-6435-429a-ac9e-2fc9216d6768"));
            Color = (ITTObjectListBox)AddControl(new Guid("d3454564-66ee-4fa8-b64d-5822c7438683"));
            Description = (ITTTextBox)AddControl(new Guid("bac6597f-164a-49e6-b71b-7562e13d738d"));
            labelColor = (ITTLabel)AddControl(new Guid("573ed483-bcc0-420a-9507-70f4770f48fe"));
            LicencePlate = (ITTTextBox)AddControl(new Guid("965b03b4-836f-44f1-ae61-5dd46b45adbd"));
            labelBannedDate = (ITTLabel)AddControl(new Guid("d8650f69-7a8e-4d7d-a715-47b9bde8ccf6"));
            Mark = (ITTObjectListBox)AddControl(new Guid("eceea021-6f28-4ee4-8744-7fe7449f5c4b"));
            labelModel = (ITTLabel)AddControl(new Guid("be100f50-4353-4f49-9b38-9049798bf07d"));
            SecretInformation = (ITTTextBox)AddControl(new Guid("b7a41d5b-c3b6-47ea-a676-903c1f2a3f06"));
            Model = (ITTObjectListBox)AddControl(new Guid("49ba5205-7319-4486-924e-b50593b659fe"));
            labelSecretInformation = (ITTLabel)AddControl(new Guid("616b5573-b8e9-4ea2-8f5c-c0e24b247b0c"));
            base.InitializeControls();
        }

        public NewVehicleForm() : base("MNZVEHICLE", "NewVehicleForm")
        {
        }

        protected NewVehicleForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}