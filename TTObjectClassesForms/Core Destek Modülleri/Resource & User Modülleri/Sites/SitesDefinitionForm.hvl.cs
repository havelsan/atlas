
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
    public partial class SitesDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.Sites _Sites
        {
            get { return (TTObjectClasses.Sites)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTTextBox IP;
        protected ITTTextBox ASyncTCPPort;
        protected ITTTextBox Description;
        protected ITTTextBox ShortName;
        protected ITTTextBox SyncTCPPort;
        protected ITTTextBox Name;
        protected ITTTextBox DatabaseName;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelIP;
        protected ITTLabel labelASyncTCPPort;
        protected ITTLabel labelSyncTCPPort;
        protected ITTLabel labelDescription;
        protected ITTLabel labelShortName;
        protected ITTEnumComboBox SiteType;
        protected ITTLabel labelName;
        protected ITTCheckBox IsPatientExist;
        protected ITTLabel labelDatabaseName;
        protected ITTLabel labelSiteType;
        protected ITTCheckBox Active;
        protected ITTCheckBox IsTerminologyManagerSite;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("6a7cf252-695d-4197-9dd0-22985d8c6d60"));
            IP = (ITTTextBox)AddControl(new Guid("f1eff53f-7865-4a32-a757-af0b6c302d64"));
            ASyncTCPPort = (ITTTextBox)AddControl(new Guid("5bba4e52-5c1d-4183-9c77-4efde6bde507"));
            Description = (ITTTextBox)AddControl(new Guid("3c371b50-dc78-46cc-aa7c-b8dd41c1b02d"));
            ShortName = (ITTTextBox)AddControl(new Guid("2d973fef-8e71-46fb-80f6-675a2d3de6d4"));
            SyncTCPPort = (ITTTextBox)AddControl(new Guid("5f7f7e85-f435-4b82-812f-c39cd652ae76"));
            Name = (ITTTextBox)AddControl(new Guid("cb19997f-2727-44d3-b7d9-2d345bf554e7"));
            DatabaseName = (ITTTextBox)AddControl(new Guid("acbf4fe7-1034-4394-ac9c-cf1717daf86b"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("dec697c7-b3d7-4067-9819-313ae0cd9965"));
            labelIP = (ITTLabel)AddControl(new Guid("0aa2f743-7fa8-4608-9246-327a9084b727"));
            labelASyncTCPPort = (ITTLabel)AddControl(new Guid("14ecc751-fc42-4048-ae46-c1335f07b4de"));
            labelSyncTCPPort = (ITTLabel)AddControl(new Guid("bb233c95-d16a-4ee3-8514-a106060a1712"));
            labelDescription = (ITTLabel)AddControl(new Guid("44ab8837-59d0-4fa2-83f8-126d057809c4"));
            labelShortName = (ITTLabel)AddControl(new Guid("93639e87-4fae-4cf9-8cb5-957cacb06be1"));
            SiteType = (ITTEnumComboBox)AddControl(new Guid("2e4984c1-b4a8-402f-a6d0-6db30f39bb32"));
            labelName = (ITTLabel)AddControl(new Guid("888b0ec6-33fd-43f6-879d-b9078bd086d7"));
            IsPatientExist = (ITTCheckBox)AddControl(new Guid("3e1a87b8-64e2-4565-bc41-200ad15010a7"));
            labelDatabaseName = (ITTLabel)AddControl(new Guid("a2cf69ae-e584-435d-b7b6-a82d8a616075"));
            labelSiteType = (ITTLabel)AddControl(new Guid("d7d73ef9-8706-46df-8141-28defc1ef2f8"));
            Active = (ITTCheckBox)AddControl(new Guid("6cedcf59-bd15-4917-907f-5c2f4b28e741"));
            IsTerminologyManagerSite = (ITTCheckBox)AddControl(new Guid("e5e19957-74ad-4fc1-b63e-e057a095b970"));
            base.InitializeControls();
        }

        public SitesDefinitionForm() : base("SITES", "SitesDefinitionForm")
        {
        }

        protected SitesDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}