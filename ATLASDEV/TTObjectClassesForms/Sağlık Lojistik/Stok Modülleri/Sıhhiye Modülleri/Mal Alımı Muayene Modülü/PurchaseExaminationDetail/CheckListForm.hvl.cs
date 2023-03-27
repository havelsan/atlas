
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
    /// Muayene Detayları
    /// </summary>
    public partial class CheckListForm : TTForm
    {
    /// <summary>
    /// Geçici Kabulde malzeme detaylarını tutan sınıftır
    /// </summary>
        protected TTObjectClasses.PurchaseExaminationDetail _PurchaseExaminationDetail
        {
            get { return (TTObjectClasses.PurchaseExaminationDetail)_ttObject; }
        }

        protected ITTGrid CheckListGrid;
        protected ITTTextBoxColumn ClauseNo;
        protected ITTRichTextBoxControlColumn Clause;
        protected ITTCheckBoxColumn Confirmed;
        protected ITTTextBoxColumn ExaminationValue;
        protected ITTListBoxColumn RelatedUnit;
        protected ITTEnumComboBoxColumn ExaminationDetailType;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            CheckListGrid = (ITTGrid)AddControl(new Guid("1734a844-d855-418c-b0fc-48056cc836aa"));
            ClauseNo = (ITTTextBoxColumn)AddControl(new Guid("ca8948fa-3691-4a9a-83c5-6a70bccffbcd"));
            Clause = (ITTRichTextBoxControlColumn)AddControl(new Guid("834534a9-454a-47bc-95c4-3c607f57c513"));
            Confirmed = (ITTCheckBoxColumn)AddControl(new Guid("bb078bc7-3d61-4f22-9782-dcc05d2779a1"));
            ExaminationValue = (ITTTextBoxColumn)AddControl(new Guid("ae448bff-25f5-4699-8f49-e7eb59193aa2"));
            RelatedUnit = (ITTListBoxColumn)AddControl(new Guid("a0c42289-b16d-46f4-b2e6-a9deb7ca361c"));
            ExaminationDetailType = (ITTEnumComboBoxColumn)AddControl(new Guid("b5f83099-2528-4751-b1a0-cf81443c1be3"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("2ef09e99-f1d0-4a1b-a034-4f26d52d4381"));
            base.InitializeControls();
        }

        public CheckListForm() : base("PURCHASEEXAMINATIONDETAIL", "CheckListForm")
        {
        }

        protected CheckListForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}