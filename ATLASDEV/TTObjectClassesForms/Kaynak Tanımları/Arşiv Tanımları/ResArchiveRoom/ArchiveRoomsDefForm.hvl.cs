
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
    public partial class ArchiveRoomsDefForm : TTDefinitionForm
    {
    /// <summary>
    /// Arşiv Odası Tanımları
    /// </summary>
        protected TTObjectClasses.ResArchiveRoom _ResArchiveRoom
        {
            get { return (TTObjectClasses.ResArchiveRoom)_ttObject; }
        }

        protected ITTLabel labelLocation;
        protected ITTTextBox Location;
        protected ITTTextBox ContactPhone;
        protected ITTTextBox Name;
        protected ITTLabel labelContactPhone;
        protected ITTLabel labelName;
        protected ITTLabel labelResFloor;
        protected ITTObjectListBox ResFloor;
        protected ITTLabel labelResBuildingWing;
        protected ITTObjectListBox ResBuildingWing;
        protected ITTLabel labelResBuilding;
        protected ITTObjectListBox ResBuilding;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            labelLocation = (ITTLabel)AddControl(new Guid("810f9140-c979-4fe1-8245-4c8c3b3f2bfa"));
            Location = (ITTTextBox)AddControl(new Guid("4f687982-ef1f-4b79-962a-f15c8f430430"));
            ContactPhone = (ITTTextBox)AddControl(new Guid("95eaf8f8-0d56-4014-bfbe-49cf0dcef378"));
            Name = (ITTTextBox)AddControl(new Guid("a8398bf5-c889-4068-919e-5118afefbcbd"));
            labelContactPhone = (ITTLabel)AddControl(new Guid("c6b4963d-e60c-42da-baa5-c4d7493cf164"));
            labelName = (ITTLabel)AddControl(new Guid("67e41cf8-f3f4-41e2-9af2-268cae0c2bbd"));
            labelResFloor = (ITTLabel)AddControl(new Guid("acc1db91-b748-4984-ae93-675e68c59099"));
            ResFloor = (ITTObjectListBox)AddControl(new Guid("40898a41-d7dc-4ae0-894d-0fdfd35229ee"));
            labelResBuildingWing = (ITTLabel)AddControl(new Guid("df424fb2-e187-401a-ac44-746aa75c307d"));
            ResBuildingWing = (ITTObjectListBox)AddControl(new Guid("74250455-07d4-4194-ac6e-3e3a7b77d1fd"));
            labelResBuilding = (ITTLabel)AddControl(new Guid("1f073f92-3c0b-422e-8c95-fd40fdaef198"));
            ResBuilding = (ITTObjectListBox)AddControl(new Guid("55edd5ff-c11f-440f-8138-21656f3d7595"));
            IsActive = (ITTCheckBox)AddControl(new Guid("f0c5514e-9ebf-4367-8fb3-c979055db75b"));
            base.InitializeControls();
        }

        public ArchiveRoomsDefForm() : base("RESARCHIVEROOM", "ArchiveRoomsDefForm")
        {
        }

        protected ArchiveRoomsDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}