
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
    public partial class PresVoucherDistDocMaterialForm : VoucherReturnDocumentMaterialForm
    {
        protected TTObjectClasses.PresVoucherDistDocMaterial _PresVoucherDistDocMaterial
        {
            get { return (TTObjectClasses.PresVoucherDistDocMaterial)_ttObject; }
        }

        protected ITTTabPage PrescriptionPaperTabPage;
        protected ITTGrid PrescriptionPaperOutDetails;
        protected ITTListBoxColumn PrescriptionPaperPrescriptionPaperOutDetail;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox endNo;
        protected ITTTextBox startNo;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTButton ttbutton1;
        protected ITTLabel ttlabel3;
        protected ITTTextBox seriNo;
        override protected void InitializeControls()
        {
            PrescriptionPaperTabPage = (ITTTabPage)AddControl(new Guid("1681a99a-1f28-4f3e-b2ac-8164309c88ad"));
            PrescriptionPaperOutDetails = (ITTGrid)AddControl(new Guid("e15ca3af-0910-4b53-89c0-5bb3974dd6ea"));
            PrescriptionPaperPrescriptionPaperOutDetail = (ITTListBoxColumn)AddControl(new Guid("bd660b4c-1920-41c5-a341-967e67dd37f8"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("74154c72-bf87-496d-9248-180ed5ca9410"));
            endNo = (ITTTextBox)AddControl(new Guid("dcb17d71-1617-4d28-89a0-49290cb62149"));
            startNo = (ITTTextBox)AddControl(new Guid("eba14a4a-d818-4eea-a2ab-70e121b183af"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("baf75f71-7057-4df9-8bb9-947f82023d2d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("10d37ddb-e232-412b-a294-bf1dee54d271"));
            ttbutton1 = (ITTButton)AddControl(new Guid("ac3e76ac-e4dc-42df-835c-1e02435ae59f"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("0ca2c6d6-8dad-43fe-b28d-e009e19accaf"));
            seriNo = (ITTTextBox)AddControl(new Guid("78ba32da-0f13-4d75-9e1a-539aafe1e8af"));
            base.InitializeControls();
        }

        public PresVoucherDistDocMaterialForm() : base("PRESVOUCHERDISTDOCMATERIAL", "PresVoucherDistDocMaterialForm")
        {
        }

        protected PresVoucherDistDocMaterialForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}