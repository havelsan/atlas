
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
    public partial class PresDeleteRecordDocumentDestroyableMaterialOutForm : BaseStockActionDetailOutForm
    {
        protected TTObjectClasses.PresDelRecDoctDesMatlOut _PresDelRecDoctDesMatlOut
        {
            get { return (TTObjectClasses.PresDelRecDoctDesMatlOut)_ttObject; }
        }

        protected ITTTabPage PrescriptionPaperTabPage;
        protected ITTGrid PrescriptionPaperOutDetails;
        protected ITTListBoxColumn PrescriptionPaperPrescriptionPaperOutDetail;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTTextBox basNo;
        protected ITTTextBox bitNo;
        protected ITTLabel ttlabel3;
        protected ITTButton ttbutton1;
        protected ITTTextBox seriNo;
        override protected void InitializeControls()
        {
            PrescriptionPaperTabPage = (ITTTabPage)AddControl(new Guid("31357b56-c7f4-4fc2-94f6-e7189c10328e"));
            PrescriptionPaperOutDetails = (ITTGrid)AddControl(new Guid("5bd3af37-4568-4ca1-b041-b58749ced23c"));
            PrescriptionPaperPrescriptionPaperOutDetail = (ITTListBoxColumn)AddControl(new Guid("addae398-917c-4403-ab69-b5171088a80e"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("5a71c59f-ed1c-4774-914a-7b79b622f53f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f465fa37-56bf-41c9-aa22-0901e7edb8a4"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("8cf050bd-c187-4236-9310-f7ad06ddee75"));
            basNo = (ITTTextBox)AddControl(new Guid("4a967420-6e23-495c-a672-756ed9c34d60"));
            bitNo = (ITTTextBox)AddControl(new Guid("b0ce926c-beef-4f42-9bb6-f065570ba32b"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("5706d54b-b4ee-4478-a672-33ef1da7e010"));
            ttbutton1 = (ITTButton)AddControl(new Guid("bb6ce175-c24f-4770-a204-3d4a99c12c31"));
            seriNo = (ITTTextBox)AddControl(new Guid("0b7d5398-aeaf-45e8-a5c6-ab0eb97ac3d0"));
            base.InitializeControls();
        }

        public PresDeleteRecordDocumentDestroyableMaterialOutForm() : base("PRESDELRECDOCTDESMATLOUT", "PresDeleteRecordDocumentDestroyableMaterialOutForm")
        {
        }

        protected PresDeleteRecordDocumentDestroyableMaterialOutForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}