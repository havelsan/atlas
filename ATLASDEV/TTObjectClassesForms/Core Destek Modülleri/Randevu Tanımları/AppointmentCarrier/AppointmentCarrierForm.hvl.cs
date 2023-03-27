
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
    /// Randevu Taşıyıcı
    /// </summary>
    public partial class AppointmentCarrierForm : TTForm
    {
        protected TTObjectClasses.AppointmentCarrier _AppointmentCarrier
        {
            get { return (TTObjectClasses.AppointmentCarrier)_ttObject; }
        }

        protected ITTTextBox MasterResourceFilter;
        protected ITTGrid AppointmentCarrierUserTypes;
        protected ITTEnumComboBoxColumn UserType;
        protected ITTLabel labelSubResource;
        protected ITTTextBox SubResource;
        protected ITTLabel labelRelationParentName;
        protected ITTTextBox RelationParentName;
        protected ITTLabel labelMasterResourceFilter;
        protected ITTLabel labelMasterResorce;
        protected ITTTextBox MasterResource;
        protected ITTLabel labelAppointmentType;
        protected ITTEnumComboBox AppointmentType;
        protected ITTLabel labelAppointmentDuration;
        protected ITTTextBox AppointmentDuration;
        protected ITTLabel labelAppointmentCount;
        protected ITTTextBox AppointmentCount;
        protected ITTLabel ttlabel1;
        protected ITTTextBox CarrierName;
        protected ITTLabel ttlabel2;
        protected ITTTextBox MasterResourceCaption;
        protected ITTLabel ttlabel3;
        protected ITTTextBox SubResourceCaption;
        protected ITTGrid AppointmentTypes;
        protected ITTEnumComboBoxColumn Type;
        override protected void InitializeControls()
        {
            MasterResourceFilter = (ITTTextBox)AddControl(new Guid("3d4a9e5e-45ad-41f0-8e84-993af8782639"));
            AppointmentCarrierUserTypes = (ITTGrid)AddControl(new Guid("043c1ac6-2f9f-42b3-8a48-75a1786d7809"));
            UserType = (ITTEnumComboBoxColumn)AddControl(new Guid("edf04a89-fc05-4869-a929-57b4e45b822e"));
            labelSubResource = (ITTLabel)AddControl(new Guid("f6e130ec-c75c-4e6c-b7e7-e4e3a08620d8"));
            SubResource = (ITTTextBox)AddControl(new Guid("1f1f59bb-21db-4dd9-981a-154df046adc5"));
            labelRelationParentName = (ITTLabel)AddControl(new Guid("a20057dc-5c1f-42b6-b344-b7cb4d2f56ed"));
            RelationParentName = (ITTTextBox)AddControl(new Guid("ed50f5bd-2834-46f5-81fc-6bf297b4b620"));
            labelMasterResourceFilter = (ITTLabel)AddControl(new Guid("5aed3804-39f3-470c-9d50-bfe437d4af0e"));
            labelMasterResorce = (ITTLabel)AddControl(new Guid("fe877614-2605-4a88-8e58-c25f848f254c"));
            MasterResource = (ITTTextBox)AddControl(new Guid("40fb6001-3e6c-4b3a-953d-bc47b3f3fe71"));
            labelAppointmentType = (ITTLabel)AddControl(new Guid("779ef25e-7568-4fd5-8377-1738802a21e5"));
            AppointmentType = (ITTEnumComboBox)AddControl(new Guid("febc7664-01c5-4342-8824-1de18f474089"));
            labelAppointmentDuration = (ITTLabel)AddControl(new Guid("14625b01-ce55-4fea-84dc-d7e9cfb0d071"));
            AppointmentDuration = (ITTTextBox)AddControl(new Guid("2753a866-bd02-4797-b277-f6af38c81e60"));
            labelAppointmentCount = (ITTLabel)AddControl(new Guid("d419d380-936a-4ff9-949b-21e1c8bb9584"));
            AppointmentCount = (ITTTextBox)AddControl(new Guid("ad496cf7-61b0-4592-93b9-6c6ff5d7b61d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("345d0e58-bd7c-49d2-a2f0-725b82eacd41"));
            CarrierName = (ITTTextBox)AddControl(new Guid("94c2477b-1ca9-41dc-9657-8819fad76d0e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("d34d3ee0-95a8-435c-9e05-48842eb57705"));
            MasterResourceCaption = (ITTTextBox)AddControl(new Guid("2a9df205-fb04-4864-8b45-fbae88172f51"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("601ded6f-acce-4dec-9569-0f91d8ea22b8"));
            SubResourceCaption = (ITTTextBox)AddControl(new Guid("1d83a058-a552-4260-8a20-0241ed365da2"));
            AppointmentTypes = (ITTGrid)AddControl(new Guid("186a7fa1-540e-424f-9d31-9defef17342a"));
            Type = (ITTEnumComboBoxColumn)AddControl(new Guid("7f82952b-2ac6-4da1-9b9c-16e049d0992e"));
            base.InitializeControls();
        }

        public AppointmentCarrierForm() : base("APPOINTMENTCARRIER", "AppointmentCarrierForm")
        {
        }

        protected AppointmentCarrierForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}