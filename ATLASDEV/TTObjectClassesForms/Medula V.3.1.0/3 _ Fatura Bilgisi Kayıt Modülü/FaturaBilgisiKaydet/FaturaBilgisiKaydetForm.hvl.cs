
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
    /// Fatura Bilgisi Kaydet
    /// </summary>
    public partial class FaturaBilgisiKaydetForm : TTForm
    {
    /// <summary>
    /// Fatura Bilgisi Kaydet
    /// </summary>
        protected TTObjectClasses.FaturaBilgisiKaydet _FaturaBilgisiKaydet
        {
            get { return (TTObjectClasses.FaturaBilgisiKaydet)_ttObject; }
        }

        protected ITTLabel labelsaglikTesisKoduFaturaGirisDVO;
        protected ITTValueListBox saglikTesisKoduFaturaGirisDVO;
        protected ITTGrid hizmetDetaylariHizmetDetayDVO;
        protected ITTTextBoxColumn takipNoHizmetDetayDVO;
        protected ITTTextBoxColumn protokolNoHizmetDetayDVO;
        protected ITTListDefComboBoxColumn taburcuKoduHizmetDetayDVO;
        protected ITTTextBoxColumn aciklamaHizmetDetayDVO;
        protected ITTDateTimePickerColumn CreationDateHizmetDetayDVO;
        protected ITTLabel labelfaturaTarihiDateTimeFaturaGirisDVO;
        protected ITTDateTimePicker faturaTarihiDateTimeFaturaGirisDVO;
        protected ITTLabel labelhastaBasvuruNoFaturaGirisDVO;
        protected ITTTextBox hastaBasvuruNoFaturaGirisDVO;
        protected ITTTextBox faturaTarihiFaturaGirisDVO;
        protected ITTLabel labelfaturaRefNoFaturaGirisDVO;
        protected ITTTextBox faturaRefNoFaturaGirisDVO;
        override protected void InitializeControls()
        {
            labelsaglikTesisKoduFaturaGirisDVO = (ITTLabel)AddControl(new Guid("0069acae-4d77-494e-b9fb-1948a290eb2b"));
            saglikTesisKoduFaturaGirisDVO = (ITTValueListBox)AddControl(new Guid("2418b586-a054-4305-bd16-67d24ea84c47"));
            hizmetDetaylariHizmetDetayDVO = (ITTGrid)AddControl(new Guid("3bcea3ed-1a8b-47e7-a9f2-a2d1031ff5d1"));
            takipNoHizmetDetayDVO = (ITTTextBoxColumn)AddControl(new Guid("b4f4a6e1-1a03-45e7-9ca6-a1280cce4085"));
            protokolNoHizmetDetayDVO = (ITTTextBoxColumn)AddControl(new Guid("766eb7a4-8cd4-4a25-afae-d5601740050c"));
            taburcuKoduHizmetDetayDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("116510eb-a7ea-413c-a4f8-de0489e9d6e4"));
            aciklamaHizmetDetayDVO = (ITTTextBoxColumn)AddControl(new Guid("4850b8d5-1202-448f-bd7a-fe77cd8e3a45"));
            CreationDateHizmetDetayDVO = (ITTDateTimePickerColumn)AddControl(new Guid("997f97cf-7856-43af-98b9-f1b2b2e28404"));
            labelfaturaTarihiDateTimeFaturaGirisDVO = (ITTLabel)AddControl(new Guid("941851a3-64f5-47f3-a841-0ea6076d3902"));
            faturaTarihiDateTimeFaturaGirisDVO = (ITTDateTimePicker)AddControl(new Guid("35ec892a-bd84-46fb-a84b-63c72d8e2562"));
            labelhastaBasvuruNoFaturaGirisDVO = (ITTLabel)AddControl(new Guid("f2945103-c347-4568-ad86-59a9d28fd68b"));
            hastaBasvuruNoFaturaGirisDVO = (ITTTextBox)AddControl(new Guid("474cb435-56b7-4108-81f3-142e3d7ee65b"));
            faturaTarihiFaturaGirisDVO = (ITTTextBox)AddControl(new Guid("b12b4d6e-c564-4bca-9a7c-f15e2a6ec71a"));
            labelfaturaRefNoFaturaGirisDVO = (ITTLabel)AddControl(new Guid("427a6aa4-071e-4a44-8f14-1f5e44529af1"));
            faturaRefNoFaturaGirisDVO = (ITTTextBox)AddControl(new Guid("6af23e8b-0faa-4a62-941f-0634f2a68c38"));
            base.InitializeControls();
        }

        public FaturaBilgisiKaydetForm() : base("FATURABILGISIKAYDET", "FaturaBilgisiKaydetForm")
        {
        }

        protected FaturaBilgisiKaydetForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}