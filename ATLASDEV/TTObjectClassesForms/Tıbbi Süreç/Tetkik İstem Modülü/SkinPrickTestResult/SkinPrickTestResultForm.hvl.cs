
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
    /// Deri Prick Testi Sonuç Formu
    /// </summary>
    public partial class SkinPrickTestResultForm : BaseAdditionalInfoForm
    {
    /// <summary>
    /// Deri Prick Test Sonuç Alanı
    /// </summary>
        protected TTObjectClasses.SkinPrickTestResult _SkinPrickTestResult
        {
            get { return (TTObjectClasses.SkinPrickTestResult)_ttObject; }
        }

        protected ITTGrid SkinPrickTestDetail;
        protected ITTCheckBoxColumn NegativeSkinPrickTestDetail;
        protected ITTCheckBoxColumn PositiveSkinPrickTestDetail;
        protected ITTTextBoxColumn DescriptionSkinPrickTestDetail;
        override protected void InitializeControls()
        {
            SkinPrickTestDetail = (ITTGrid)AddControl(new Guid("695d5f27-d043-4040-b8d7-565db1d7078a"));
            NegativeSkinPrickTestDetail = (ITTCheckBoxColumn)AddControl(new Guid("4ee60c88-785f-4434-942e-445d36c33482"));
            PositiveSkinPrickTestDetail = (ITTCheckBoxColumn)AddControl(new Guid("e447f9a6-f9a7-4d15-9906-c49e207a29b3"));
            DescriptionSkinPrickTestDetail = (ITTTextBoxColumn)AddControl(new Guid("9e901de0-04fc-43c5-971d-f3861f69d295"));
            base.InitializeControls();
        }

        public SkinPrickTestResultForm() : base("SKINPRICKTESTRESULT", "SkinPrickTestResultForm")
        {
        }

        protected SkinPrickTestResultForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}