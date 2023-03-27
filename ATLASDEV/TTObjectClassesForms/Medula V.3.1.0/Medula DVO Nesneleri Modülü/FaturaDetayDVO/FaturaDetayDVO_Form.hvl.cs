
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
    /// Fatura Detay
    /// </summary>
    public partial class FaturaDetayDVO : TTForm
    {
        protected TTObjectClasses.FaturaDetayDVO _FaturaDetayDVO
        {
            get { return (TTObjectClasses.FaturaDetayDVO)_ttObject; }
        }

        protected ITTGrid islemDetaylari;
        protected ITTTextBoxColumn islemSiraNoIslemDetayDVO;
        protected ITTTextBoxColumn islemTutariIslemDetayDVO;
        protected ITTDateTimePickerColumn CreationDateIslemDetayDVO;
        protected ITTLabel labeltakipToplamTutar;
        protected ITTTextBox takipToplamTutar;
        protected ITTLabel labeltakipNo;
        protected ITTTextBox takipNo;
        override protected void InitializeControls()
        {
            islemDetaylari = (ITTGrid)AddControl(new Guid("933bd3a2-c32d-45c5-a2d0-d8fb25c31e9d"));
            islemSiraNoIslemDetayDVO = (ITTTextBoxColumn)AddControl(new Guid("af548cc2-cd6e-4547-aeb2-4f9c57d7b535"));
            islemTutariIslemDetayDVO = (ITTTextBoxColumn)AddControl(new Guid("a1808eb0-ab7d-4850-8e4e-9b6e487b4a2c"));
            CreationDateIslemDetayDVO = (ITTDateTimePickerColumn)AddControl(new Guid("9d258472-6928-448d-b5fa-7a4b7351cd17"));
            labeltakipToplamTutar = (ITTLabel)AddControl(new Guid("60cc0182-9c43-495e-9122-bb281d156e9a"));
            takipToplamTutar = (ITTTextBox)AddControl(new Guid("92a72c69-71ae-4b80-8fb8-7bf207751a31"));
            labeltakipNo = (ITTLabel)AddControl(new Guid("4c8c7ec8-33ab-4371-9234-c594ab91f0a7"));
            takipNo = (ITTTextBox)AddControl(new Guid("0ed60502-72d2-4324-a3ea-9cabdf8af5d6"));
            base.InitializeControls();
        }

        public FaturaDetayDVO() : base("FATURADETAYDVO", "FaturaDetayDVO")
        {
        }

        protected FaturaDetayDVO(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}