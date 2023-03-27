
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
    /// Malzeme Detayları
    /// </summary>
    public partial class PresCensusFixedMaterialInForm : BaseStockActionDetailInForm
    {
        protected TTObjectClasses.PresCensusFixedMaterialIn _PresCensusFixedMaterialIn
        {
            get { return (TTObjectClasses.PresCensusFixedMaterialIn)_ttObject; }
        }

        protected ITTTabPage PrescriptionPaperTabPage;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox bitNo;
        protected ITTTextBox basNo;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel9;
        protected ITTTextBox seriNo;
        protected ITTGrid PrescriptionPaperInDetails;
        protected ITTTextBoxColumn SerialNoPrescriptionPaperInDetail;
        protected ITTTextBoxColumn VolumeNoPrescriptionPaperInDetail;
        protected ITTLabel ttCiltno;
        protected ITTButton ttbuttonSorgula;
        override protected void InitializeControls()
        {
            PrescriptionPaperTabPage = (ITTTabPage)AddControl(new Guid("210d85c0-4cf9-4058-a0fd-a883ac25bcf2"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("28c09ffc-4cd1-458e-856d-4ce58605d264"));
            bitNo = (ITTTextBox)AddControl(new Guid("22f49404-6c69-40ec-b858-aab0fba4cc18"));
            basNo = (ITTTextBox)AddControl(new Guid("efe77503-67dc-4c72-ac64-c5124a82f99d"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("5972204d-768e-41cc-8749-7780579168fd"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("34fa4766-c269-4b70-8d0e-0d3f6c9103d8"));
            seriNo = (ITTTextBox)AddControl(new Guid("0c132998-ca1a-4971-9fc2-c42c9878fee1"));
            PrescriptionPaperInDetails = (ITTGrid)AddControl(new Guid("2581a3a9-ea4b-44ff-ba7c-a183c5a7854b"));
            SerialNoPrescriptionPaperInDetail = (ITTTextBoxColumn)AddControl(new Guid("174007f6-ccb5-48de-8d2a-0247304ea3e3"));
            VolumeNoPrescriptionPaperInDetail = (ITTTextBoxColumn)AddControl(new Guid("21927098-55de-4da0-9e96-5df7ad433c6a"));
            ttCiltno = (ITTLabel)AddControl(new Guid("9ccf0261-b41f-4a91-8f28-91975c870f99"));
            ttbuttonSorgula = (ITTButton)AddControl(new Guid("9c47b265-733b-4b31-9665-e418d28c6bc2"));
            base.InitializeControls();
        }

        public PresCensusFixedMaterialInForm() : base("PRESCENSUSFIXEDMATERIALIN", "PresCensusFixedMaterialInForm")
        {
        }

        protected PresCensusFixedMaterialInForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}