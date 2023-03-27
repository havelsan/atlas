
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
    /// Yatak Tanımı
    /// </summary>
    public partial class BedDefinitionForm : TTForm
    {
    /// <summary>
    /// Yatak
    /// </summary>
        protected TTObjectClasses.ResBed _ResBed
        {
            get { return (TTObjectClasses.ResBed)_ttObject; }
        }

        protected ITTLabel labelBedProcedureType;
        protected ITTEnumComboBox BedProcedureType;
        protected ITTLabel labelLocation;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox OrderNo;
        protected ITTLabel labelDeskPhoneNumber;
        protected ITTCheckBox IsVentilator;
        protected ITTLabel labelRoom;
        protected ITTObjectListBox Room;
        protected ITTLabel labelBedProcedure;
        protected ITTObjectListBox BedProcedure;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox ttcheckbox2;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelOrder;
        override protected void InitializeControls()
        {
            labelBedProcedureType = (ITTLabel)AddControl(new Guid("536531d8-0b26-4918-82e1-216e2d0c46fc"));
            BedProcedureType = (ITTEnumComboBox)AddControl(new Guid("26a13d5e-d5f9-45a8-92eb-9994dbc40e9c"));
            labelLocation = (ITTLabel)AddControl(new Guid("069b7a05-a771-4938-8f6c-0518f8b2da52"));
            Location = (ITTTextBox)AddControl(new Guid("fa947cab-2b0a-4c38-8c38-2ecf62868f9e"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("8cf4eaa0-fb70-4e8d-9781-8cc0943c8cda"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("392775ab-03ed-44ff-adf0-188affa071d6"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("e5db068c-c4fa-406b-b60c-681b84187956"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("148327fd-7d84-4f19-832d-db04aadac020"));
            OrderNo = (ITTTextBox)AddControl(new Guid("f5dd263d-03e4-4007-a17b-0678f2bf827e"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("d696fd8c-7d93-4d5d-a8c3-ff545dccfeff"));
            IsVentilator = (ITTCheckBox)AddControl(new Guid("4a7597e1-22d7-479e-97e5-9b36322c4d7b"));
            labelRoom = (ITTLabel)AddControl(new Guid("44a6b33e-1d3a-47e2-a9cc-e3356b851969"));
            Room = (ITTObjectListBox)AddControl(new Guid("7c24aecd-de42-4aa3-b13e-801aa41d4088"));
            labelBedProcedure = (ITTLabel)AddControl(new Guid("9cb6439c-4bd3-4adb-880d-07a2727e1013"));
            BedProcedure = (ITTObjectListBox)AddControl(new Guid("b50c82aa-9ad6-4c0a-a235-c0eb53db7c7c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c096055a-3674-45a9-9f4b-fe0540535cd2"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("34cce071-7744-4427-8537-14f979fb5642"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("76afddd9-6054-4ef5-a9ce-9024e4aac0ad"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("35908a69-25d8-4941-90ca-dd85afd19b9a"));
            labelOrder = (ITTLabel)AddControl(new Guid("e4abdefe-8cf1-4359-8e0a-920858a50ecd"));
            base.InitializeControls();
        }

        public BedDefinitionForm() : base("RESBED", "BedDefinitionForm")
        {
        }

        protected BedDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}