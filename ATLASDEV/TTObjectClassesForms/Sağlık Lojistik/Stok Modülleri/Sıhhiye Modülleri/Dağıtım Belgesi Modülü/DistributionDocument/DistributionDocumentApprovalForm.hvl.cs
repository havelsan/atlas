
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
    /// Sayman Onayı
    /// </summary>
    public partial class DistributionDocumentApprovalForm : BaseDistributionDocumentForm
    {
    /// <summary>
    /// Dağıtım Belgesi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.DistributionDocument _DistributionDocument
        {
            get { return (TTObjectClasses.DistributionDocument)_ttObject; }
        }

        protected ITTCheckBox IsAutoDistribution;
        override protected void InitializeControls()
        {
            IsAutoDistribution = (ITTCheckBox)AddControl(new Guid("914c6a3c-2c49-4465-9080-869bff582115"));
            base.InitializeControls();
        }

        public DistributionDocumentApprovalForm() : base("DISTRIBUTIONDOCUMENT", "DistributionDocumentApprovalForm")
        {
        }

        protected DistributionDocumentApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}