
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
    /// Ameliyat Salonu Tanımı
    /// </summary>
    public partial class SurgeryRoomDefinitonForm : TTForm
    {
    /// <summary>
    /// Ameliyat Salonu
    /// </summary>
        protected TTObjectClasses.ResSurgeryRoom _ResSurgeryRoom
        {
            get { return (TTObjectClasses.ResSurgeryRoom)_ttObject; }
        }

        protected ITTLabel labelSurgeryDepartment;
        protected ITTObjectListBox SurgeryDepartment;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel ttlabel4;
        protected ITTCheckBox ttcheckbox2;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            labelSurgeryDepartment = (ITTLabel)AddControl(new Guid("b1e79410-cdab-4b5e-9b5a-66a53e24e0f3"));
            SurgeryDepartment = (ITTObjectListBox)AddControl(new Guid("af1543e0-637f-4b72-a939-2164d85cce49"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("60afffc2-5041-435d-8033-e05402eaefa6"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("e002c387-c751-4de3-99ef-1ac1e431c26d"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("66a7b63f-9751-4fe3-bfa3-2c823ae5964b"));
            Location = (ITTTextBox)AddControl(new Guid("ecfc4ab6-72a5-4540-b6af-cce74a077a82"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("637d2da2-82b6-4775-a104-395592d3c371"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("08b7f217-c2d7-4ec8-b952-b32cb049dcf2"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("fb61e081-c482-4d9c-8fb8-251793bff007"));
            labelLocation = (ITTLabel)AddControl(new Guid("5d0aaefb-a082-4cc5-ae84-09d79e821589"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("13dc24f6-0b52-45d8-8275-ab4f86c50dc1"));
            base.InitializeControls();
        }

        public SurgeryRoomDefinitonForm() : base("RESSURGERYROOM", "SurgeryRoomDefinitonForm")
        {
        }

        protected SurgeryRoomDefinitonForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}