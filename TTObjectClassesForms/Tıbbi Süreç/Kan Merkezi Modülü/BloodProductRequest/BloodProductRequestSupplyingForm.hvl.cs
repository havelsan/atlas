
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
    /// Kan Ürünü İstek Karşılama
    /// </summary>
    public partial class BloodProductRequestSupplyingForm : EpisodeActionForm
    {
    /// <summary>
    /// Kan Ürünü İstek
    /// </summary>
        protected TTObjectClasses.BloodProductRequest _BloodProductRequest
        {
            get { return (TTObjectClasses.BloodProductRequest)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox tttextbox1;
        protected ITTCheckBox ttcheckbox3;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox ttcheckbox1;
        protected ITTCheckBox ttcheckbox2;
        protected ITTCheckBox ttcheckbox4;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox ttcheckbox5;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn ttlistbox1;
        protected ITTTextBoxColumn txtAmount;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("8c52cef9-728f-4366-b473-34049988ed73"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("74d3a915-9e87-4790-a7b2-bf6da4e5e755"));
            ttcheckbox3 = (ITTCheckBox)AddControl(new Guid("551a279b-e4c2-480e-a545-d1fdaaa87a00"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("48a609e5-8327-4b00-8c0b-91848ec5158d"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("5ccbff46-07a5-4d8c-9783-f9466b18c011"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("7db66a67-1701-4a5f-8deb-dec3edcbf684"));
            ttcheckbox4 = (ITTCheckBox)AddControl(new Guid("091fce34-2bdd-4067-b5ca-659703db6d57"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a8f40060-27d2-494b-9f40-54f13753fd99"));
            ttcheckbox5 = (ITTCheckBox)AddControl(new Guid("0cfd3608-9255-46d2-ab55-e957ace5ce0f"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("b2c1521b-1855-4d57-976b-cc7156d3e125"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("5f4c9177-09d8-41d4-be77-0ccabf3def7c"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("a988caf1-9d78-4e1d-b07e-01657eb4ebfb"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("60ec4480-4ee8-4757-ae9b-b86630e8433f"));
            ttlistbox1 = (ITTListBoxColumn)AddControl(new Guid("91009a8a-ceca-4fb1-9efe-09510ed1c050"));
            txtAmount = (ITTTextBoxColumn)AddControl(new Guid("4d76f03c-2943-4347-a694-5ffff81ea1f3"));
            base.InitializeControls();
        }

        public BloodProductRequestSupplyingForm() : base("BLOODPRODUCTREQUEST", "BloodProductRequestSupplyingForm")
        {
        }

        protected BloodProductRequestSupplyingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}