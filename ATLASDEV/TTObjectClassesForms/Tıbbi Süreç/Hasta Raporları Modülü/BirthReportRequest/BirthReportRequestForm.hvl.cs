
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
    /// Doğum Raporları Giriş
    /// </summary>
    public partial class BirthReportRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Birden Fazla Doğum Raporunun Yazılması İçin Kullanılan NEsnedir
    /// </summary>
        protected TTObjectClasses.BirthReportRequest _BirthReportRequest
        {
            get { return (TTObjectClasses.BirthReportRequest)_ttObject; }
        }

        protected ITTButton btnAddBirthReport;
        protected ITTGrid BirthReports;
        protected ITTDateTimePickerColumn BabyBirthDate;
        protected ITTDateTimePickerColumn BirthTime;
        protected ITTEnumComboBoxColumn Sex;
        protected ITTListBoxColumn BornType;
        protected ITTEnumComboBoxColumn BabyStatus;
        protected ITTEnumComboBoxColumn AestesiaType;
        override protected void InitializeControls()
        {
            btnAddBirthReport = (ITTButton)AddControl(new Guid("7b8a8c24-c633-4878-8c6b-82b92fa74aee"));
            BirthReports = (ITTGrid)AddControl(new Guid("58746276-af86-4b7a-a844-704b5f548905"));
            BabyBirthDate = (ITTDateTimePickerColumn)AddControl(new Guid("01d13f52-bc90-4f85-abf8-9f0b745537e7"));
            BirthTime = (ITTDateTimePickerColumn)AddControl(new Guid("098a1bcb-644b-4578-a86d-7fb9b6808ec8"));
            Sex = (ITTEnumComboBoxColumn)AddControl(new Guid("c2026bcf-a7f8-47fa-bb03-f428c81e082a"));
            BornType = (ITTListBoxColumn)AddControl(new Guid("0cf95fe0-c06a-4b1e-92f7-77835fce69ac"));
            BabyStatus = (ITTEnumComboBoxColumn)AddControl(new Guid("e5be81ae-3566-409b-a2d8-997377f4763c"));
            AestesiaType = (ITTEnumComboBoxColumn)AddControl(new Guid("85f260ec-b495-4cad-ba91-ef892c33f294"));
            base.InitializeControls();
        }

        public BirthReportRequestForm() : base("BIRTHREPORTREQUEST", "BirthReportRequestForm")
        {
        }

        protected BirthReportRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}