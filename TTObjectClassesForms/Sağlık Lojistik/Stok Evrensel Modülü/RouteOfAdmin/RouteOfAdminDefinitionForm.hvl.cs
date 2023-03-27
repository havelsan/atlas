
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
    /// İlaç Uygulama Şekli Tanımı
    /// </summary>
    public partial class RouteOfAdminDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Uygulama Şekli
    /// </summary>
        protected TTObjectClasses.RouteOfAdmin _RouteOfAdmin
        {
            get { return (TTObjectClasses.RouteOfAdmin)_ttObject; }
        }

        protected ITTLabel labelDrugUsageType;
        protected ITTEnumComboBox DrugUsageType;
        protected ITTLabel labelSPTSRouteOfAdminID;
        protected ITTTextBox SPTSRouteOfAdminID;
        protected ITTTextBox QREF;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelQREF;
        protected ITTLabel labelName;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelDrugUsageType = (ITTLabel)AddControl(new Guid("3eb6d26e-48ae-41a8-8165-c0d262389b8c"));
            DrugUsageType = (ITTEnumComboBox)AddControl(new Guid("795b9c17-c7cc-42bb-8ac5-d23a096f7b37"));
            labelSPTSRouteOfAdminID = (ITTLabel)AddControl(new Guid("9682afe5-72c4-4e05-ad6b-bfe7fc5a439f"));
            SPTSRouteOfAdminID = (ITTTextBox)AddControl(new Guid("7625fad2-4743-4162-b789-b72eb227b634"));
            QREF = (ITTTextBox)AddControl(new Guid("f0877be6-fb42-48a9-a1e9-972f6ffe8b03"));
            Name = (ITTTextBox)AddControl(new Guid("26c81edf-3f4f-439c-8093-15df95b4ae7a"));
            Code = (ITTTextBox)AddControl(new Guid("7028ff53-1886-4b4a-9f12-ab9cf7fdb9bb"));
            labelQREF = (ITTLabel)AddControl(new Guid("00fce4ff-0860-44ea-a498-072ee87a6c2e"));
            labelName = (ITTLabel)AddControl(new Guid("42891328-f4dd-4003-a5b7-08ad9c6c4ae8"));
            labelCode = (ITTLabel)AddControl(new Guid("9a5c734f-e969-4d6f-a2b6-df3ecbe02d0c"));
            base.InitializeControls();
        }

        public RouteOfAdminDefinitionForm() : base("ROUTEOFADMIN", "RouteOfAdminDefinitionForm")
        {
        }

        protected RouteOfAdminDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}