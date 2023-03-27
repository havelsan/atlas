
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
    public partial class PresDistributionDocMaterialForm : DistributionDocumentMaterialForm
    {
        protected TTObjectClasses.PresDistributionDocMaterial _PresDistributionDocMaterial
        {
            get { return (TTObjectClasses.PresDistributionDocMaterial)_ttObject; }
        }

        protected ITTTabPage PrescriptionPaperTabPage;
        protected ITTButton ttbutton1;
        protected ITTTextBox seriNo;
        protected ITTLabel ttlabel3;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox endNo;
        protected ITTTextBox startNo;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTGrid PrescriptionPaperOutDetails;
        protected ITTListBoxColumn PrescriptionPaperPrescriptionPaperOutDetail;
        override protected void InitializeControls()
        {
            PrescriptionPaperTabPage = (ITTTabPage)AddControl(new Guid("dbb01485-9904-440e-8bbf-6a9ecba0cd8b"));
            ttbutton1 = (ITTButton)AddControl(new Guid("ead557b1-9397-42c6-97a3-c48953c2a49a"));
            seriNo = (ITTTextBox)AddControl(new Guid("93da4650-9bea-49c2-881f-95db20c26d27"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("39bcd842-e460-46c8-8260-6e1ec74bb59a"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("9c151033-558c-4158-9250-6c878aa81275"));
            endNo = (ITTTextBox)AddControl(new Guid("37c31458-4d93-4542-94fe-3721953aebed"));
            startNo = (ITTTextBox)AddControl(new Guid("53ad5254-fd03-4942-953a-56e998712ac2"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("bd54ac59-f9ba-4632-8f47-18ec9b9ddb89"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("adbce158-a4e4-4556-9a0b-764551c351a0"));
            PrescriptionPaperOutDetails = (ITTGrid)AddControl(new Guid("3e2599ee-174d-407f-89b3-b3becc0be8e0"));
            PrescriptionPaperPrescriptionPaperOutDetail = (ITTListBoxColumn)AddControl(new Guid("f3f2ff4d-3cec-4dc4-840a-87653b86b82e"));
            base.InitializeControls();
        }

        public PresDistributionDocMaterialForm() : base("PRESDISTRIBUTIONDOCMATERIAL", "PresDistributionDocMaterialForm")
        {
        }

        protected PresDistributionDocMaterialForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}