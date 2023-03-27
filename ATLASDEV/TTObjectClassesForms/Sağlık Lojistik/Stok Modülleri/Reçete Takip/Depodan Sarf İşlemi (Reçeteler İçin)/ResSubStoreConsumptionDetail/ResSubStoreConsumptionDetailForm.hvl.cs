
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
    public partial class ResSubStoreConsumptionDetailForm : BaseStockActionDetailOutForm
    {
        protected TTObjectClasses.ResSubStoreConsumptionDetail _ResSubStoreConsumptionDetail
        {
            get { return (TTObjectClasses.ResSubStoreConsumptionDetail)_ttObject; }
        }

        protected ITTTabPage PrescriptionPaperTabPage;
        protected ITTGrid PrescriptionPaperOutDetails;
        protected ITTListBoxColumn PrescriptionPaperPrescriptionPaperOutDetail;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox endNo;
        protected ITTTextBox startNo;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel3;
        protected ITTButton ttbutton1;
        protected ITTTextBox seriNo;
        override protected void InitializeControls()
        {
            PrescriptionPaperTabPage = (ITTTabPage)AddControl(new Guid("fc16b050-6b96-4c79-8546-fe0acffccc0c"));
            PrescriptionPaperOutDetails = (ITTGrid)AddControl(new Guid("4b769d6a-dc2e-4688-9058-9c69f80a7911"));
            PrescriptionPaperPrescriptionPaperOutDetail = (ITTListBoxColumn)AddControl(new Guid("d5592c88-714a-4300-9e46-b055c2481558"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("1a5ae42c-0a7b-41b8-b30a-1ad59e873eac"));
            endNo = (ITTTextBox)AddControl(new Guid("ed814304-42f7-4ad8-84e9-2fb3b0702369"));
            startNo = (ITTTextBox)AddControl(new Guid("14c2c637-cfad-4715-82bf-6498eda5ab89"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("c57df3b6-5813-4001-892f-9e9cec6a9157"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("06744c65-db96-4f9c-8b2b-f0600270305b"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("0912a9d5-c83f-4a8b-8d64-c6e008a3c200"));
            ttbutton1 = (ITTButton)AddControl(new Guid("75684605-4398-4ffe-9dc0-e1295b7a1dc1"));
            seriNo = (ITTTextBox)AddControl(new Guid("09b888c0-2fd1-456e-a304-038f160d56e0"));
            base.InitializeControls();
        }

        public ResSubStoreConsumptionDetailForm() : base("RESSUBSTORECONSUMPTIONDETAIL", "ResSubStoreConsumptionDetailForm")
        {
        }

        protected ResSubStoreConsumptionDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}