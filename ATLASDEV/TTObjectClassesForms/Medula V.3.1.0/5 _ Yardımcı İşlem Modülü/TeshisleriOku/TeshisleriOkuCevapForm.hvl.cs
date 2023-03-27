
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
    public partial class TeshisleriOkuCevapForm : BaseTeshisleriOkuForm
    {
        protected TTObjectClasses.TeshisleriOku _TeshisleriOku
        {
            get { return (TTObjectClasses.TeshisleriOku)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid teshislerTeshisDVO;
        protected ITTTextBoxColumn koduTeshisDVO;
        protected ITTTextBoxColumn adiTeshisDVO;
        protected ITTDateTimePickerColumn CreationDateTeshisDVO;
        protected ITTLabel labelsonucMesajiBaseMedulaCevap;
        protected ITTTextBox sonucMesajiBaseMedulaCevap;
        protected ITTLabel labelsonucKoduBaseMedulaCevap;
        protected ITTTextBox sonucKoduBaseMedulaCevap;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("f3decc4d-1751-48c5-8be8-f15d25d37aa3"));
            teshislerTeshisDVO = (ITTGrid)AddControl(new Guid("dca7b8d1-e627-4687-af0e-9f3019be24fe"));
            koduTeshisDVO = (ITTTextBoxColumn)AddControl(new Guid("d5ac266c-b9b0-43aa-bc73-19fbd23f6ffc"));
            adiTeshisDVO = (ITTTextBoxColumn)AddControl(new Guid("5a0e8a31-8ff3-451b-920d-0ad46d591dc1"));
            CreationDateTeshisDVO = (ITTDateTimePickerColumn)AddControl(new Guid("4b5a2aca-20c9-47e1-83d9-bd868fdb7806"));
            labelsonucMesajiBaseMedulaCevap = (ITTLabel)AddControl(new Guid("7c85bfce-24b5-41eb-838b-f90b50e3a0ba"));
            sonucMesajiBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("7a552f2b-8a02-442a-a385-4894b5fb608d"));
            labelsonucKoduBaseMedulaCevap = (ITTLabel)AddControl(new Guid("a66ad083-4858-45fe-888e-edef9ccf4d18"));
            sonucKoduBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("f7d13146-f47c-4497-acc2-00625810428e"));
            base.InitializeControls();
        }

        public TeshisleriOkuCevapForm() : base("TESHISLERIOKU", "TeshisleriOkuCevapForm")
        {
        }

        protected TeshisleriOkuCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}