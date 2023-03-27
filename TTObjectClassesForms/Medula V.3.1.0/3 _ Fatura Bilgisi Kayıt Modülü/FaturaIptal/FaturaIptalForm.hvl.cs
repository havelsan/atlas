
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
    /// Fatura İptal
    /// </summary>
    public partial class FaturaIptalForm : BaseMedulaActionForm
    {
    /// <summary>
    /// Fatura İptal
    /// </summary>
        protected TTObjectClasses.FaturaIptal _FaturaIptal
        {
            get { return (TTObjectClasses.FaturaIptal)_ttObject; }
        }

        protected ITTGrid faturaTeslimNoDVOsFaturaTeslimNoDVO;
        protected ITTTextBoxColumn faturaTeslimNoFaturaTeslimNoDVO;
        protected ITTDateTimePickerColumn CreationDateFaturaTeslimNoDVO;
        protected ITTLabel labelsaglikTesisKoduFaturaIptalGirisDVO;
        protected ITTValueListBox saglikTesisKoduFaturaIptalGirisDVO;
        override protected void InitializeControls()
        {
            faturaTeslimNoDVOsFaturaTeslimNoDVO = (ITTGrid)AddControl(new Guid("c730b99b-ae4c-4e7c-b89f-20c47f03cae1"));
            faturaTeslimNoFaturaTeslimNoDVO = (ITTTextBoxColumn)AddControl(new Guid("15c61db0-7b29-45f1-9b24-908089e85d2a"));
            CreationDateFaturaTeslimNoDVO = (ITTDateTimePickerColumn)AddControl(new Guid("4e48e1ee-0e89-4167-99f2-b3956ba6e1b1"));
            labelsaglikTesisKoduFaturaIptalGirisDVO = (ITTLabel)AddControl(new Guid("2339e49b-65ee-4cfd-9789-31195a718cff"));
            saglikTesisKoduFaturaIptalGirisDVO = (ITTValueListBox)AddControl(new Guid("53f868d1-4d08-43d3-9d69-a379bd847da8"));
            base.InitializeControls();
        }

        public FaturaIptalForm() : base("FATURAIPTAL", "FaturaIptalForm")
        {
        }

        protected FaturaIptalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}