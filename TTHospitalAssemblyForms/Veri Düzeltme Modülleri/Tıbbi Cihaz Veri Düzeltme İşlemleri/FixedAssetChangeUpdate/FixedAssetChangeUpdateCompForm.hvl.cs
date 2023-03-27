
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
    /// Demirbaş Tipi Değiştirme İşlemi Güncelleme
    /// </summary>
    public partial class FixedAssetChangeUpdateCompForm : BaseDataCorrectionForm
    {
    /// <summary>
    /// Demirbaş Tipi Değiştirme İşlemi Güncelleme
    /// </summary>
        protected TTObjectClasses.FixedAssetChangeUpdate _FixedAssetChangeUpdate
        {
            get { return (TTObjectClasses.FixedAssetChangeUpdate)_ttObject; }
        }

        protected ITTGrid FixedAssetChangeDetails;
        protected ITTCheckBoxColumn UpdateFixedAssetChangeDetail;
        protected ITTDateTimePickerColumn DateFixedAssetChangeDetail;
        protected ITTTextBoxColumn DescriptionFixedAssetChangeDetail;
        protected ITTListBoxColumn SiteFixedAssetChangeDetail;
        protected ITTTextBoxColumn ChangeActionObjectIDFixedAssetChangeDetail;
        protected ITTButton cmdGetChangeAction;
        protected ITTLabel labelFixedAssetDefinition;
        protected ITTObjectListBox FixedAssetDefinition;
        override protected void InitializeControls()
        {
            FixedAssetChangeDetails = (ITTGrid)AddControl(new Guid("cfe59b33-c107-43b9-9592-3b63e4c2859a"));
            UpdateFixedAssetChangeDetail = (ITTCheckBoxColumn)AddControl(new Guid("e4b2cba1-80bb-4734-9763-0ac573091625"));
            DateFixedAssetChangeDetail = (ITTDateTimePickerColumn)AddControl(new Guid("192381cc-3c2b-487b-a846-1c81b81d2c67"));
            DescriptionFixedAssetChangeDetail = (ITTTextBoxColumn)AddControl(new Guid("296c9a65-a1bc-4e28-b355-0673dc3fe71e"));
            SiteFixedAssetChangeDetail = (ITTListBoxColumn)AddControl(new Guid("6c21c06c-5fe4-48c4-b4ab-38b1c3f721b8"));
            ChangeActionObjectIDFixedAssetChangeDetail = (ITTTextBoxColumn)AddControl(new Guid("f1f50cf5-64ba-4a1f-bd3f-4fd802a7fb02"));
            cmdGetChangeAction = (ITTButton)AddControl(new Guid("f479dd38-879b-4338-8756-dff40555a699"));
            labelFixedAssetDefinition = (ITTLabel)AddControl(new Guid("40dfb38a-9458-48d3-b2e9-fb58fd91e635"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("e5c2366a-9f6f-4fe8-bef5-109e2ebb70d3"));
            base.InitializeControls();
        }

        public FixedAssetChangeUpdateCompForm() : base("FIXEDASSETCHANGEUPDATE", "FixedAssetChangeUpdateCompForm")
        {
        }

        protected FixedAssetChangeUpdateCompForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}