
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
    /// İlaç Ara Cevap
    /// </summary>
    public partial class IlacAraCevapForm : BaseIlacAraForm
    {
    /// <summary>
    /// İlaç Ara
    /// </summary>
        protected TTObjectClasses.IlacAra _IlacAra
        {
            get { return (TTObjectClasses.IlacAra)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid ilaclarIlacListDVO;
        protected ITTTextBoxColumn barkodIlacListDVO;
        protected ITTTextBoxColumn ilacAdiIlacListDVO;
        protected ITTTextBoxColumn kullanimBirimiIlacListDVO;
        protected ITTLabel labelsonucMesajiBaseMedulaCevap;
        protected ITTTextBox sonucMesajiBaseMedulaCevap;
        protected ITTLabel labelsonucKoduBaseMedulaCevap;
        protected ITTTextBox sonucKoduBaseMedulaCevap;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("5b0e95ec-1007-42de-873a-a8720bdf9573"));
            ilaclarIlacListDVO = (ITTGrid)AddControl(new Guid("9384f4b1-64e4-482e-bc2d-5206e475781a"));
            barkodIlacListDVO = (ITTTextBoxColumn)AddControl(new Guid("6ec7d1ca-87db-4c39-8cc6-be3cb9674553"));
            ilacAdiIlacListDVO = (ITTTextBoxColumn)AddControl(new Guid("513741d6-873e-4f23-bb77-1d5218577ab6"));
            kullanimBirimiIlacListDVO = (ITTTextBoxColumn)AddControl(new Guid("e7745c0d-22ba-44bd-8d83-5b34bc0060da"));
            labelsonucMesajiBaseMedulaCevap = (ITTLabel)AddControl(new Guid("18b52dd8-423b-4454-969d-658371db24f7"));
            sonucMesajiBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("58c86799-0f6c-4ef8-82ef-613da3a6500b"));
            labelsonucKoduBaseMedulaCevap = (ITTLabel)AddControl(new Guid("d805dfb6-cc00-47d3-9ff6-45af94e0ec06"));
            sonucKoduBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("2e5c7230-f7aa-4d65-9e8d-80f6ef372ded"));
            base.InitializeControls();
        }

        public IlacAraCevapForm() : base("ILACARA", "IlacAraCevapForm")
        {
        }

        protected IlacAraCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}