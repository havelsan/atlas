
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
    public partial class PresVoucherReturnDocMatForm : VoucherReturnDocumentMaterialForm
    {
        protected TTObjectClasses.PresVoucherReturnDocMat _PresVoucherReturnDocMat
        {
            get { return (TTObjectClasses.PresVoucherReturnDocMat)_ttObject; }
        }

        protected ITTTabPage PrescriptionPaperTabPage;
        protected ITTGrid PrescriptionPaperOutDetails;
        protected ITTListBoxColumn PrescriptionPaperPrescriptionPaperOutDetail;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox endNo;
        protected ITTTextBox startNo;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTTextBox seriNo;
        protected ITTLabel ttlabel3;
        protected ITTButton ttbutton1;
        override protected void InitializeControls()
        {
            PrescriptionPaperTabPage = (ITTTabPage)AddControl(new Guid("e2b9f19f-bef6-417e-b44b-f56a4cb1f65c"));
            PrescriptionPaperOutDetails = (ITTGrid)AddControl(new Guid("8cd28d85-5044-4fd7-9b39-8acba125ec80"));
            PrescriptionPaperPrescriptionPaperOutDetail = (ITTListBoxColumn)AddControl(new Guid("b729dba3-4a9b-42b2-a59d-e5195e714ec1"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("835041c0-9da5-4b66-b8e5-aa998ac444c1"));
            endNo = (ITTTextBox)AddControl(new Guid("5c9c71bf-9bd2-4198-827e-a72cb4c9b16c"));
            startNo = (ITTTextBox)AddControl(new Guid("7369fd3a-6f9f-40b6-b68a-77a2c2506480"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("c57563ff-5a8c-4e20-b9ef-f06e5cdc27bd"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("5ced5388-acd4-4543-8af4-18788ab6de5c"));
            seriNo = (ITTTextBox)AddControl(new Guid("36cafdb0-7633-4d28-b759-86d502974bb6"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("f31d1e1d-855b-4903-b14d-c51fb6bad856"));
            ttbutton1 = (ITTButton)AddControl(new Guid("db3f56f1-e41d-417f-ab58-c1866debe78b"));
            base.InitializeControls();
        }

        public PresVoucherReturnDocMatForm() : base("PRESVOUCHERRETURNDOCMAT", "PresVoucherReturnDocMatForm")
        {
        }

        protected PresVoucherReturnDocMatForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}