
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
    public partial class FixedAssetChangeUpdateForm : BaseDataCorrectionForm
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
            FixedAssetChangeDetails = (ITTGrid)AddControl(new Guid("6e21e382-6ddb-4cf7-9cce-f08d08ecd2ce"));
            UpdateFixedAssetChangeDetail = (ITTCheckBoxColumn)AddControl(new Guid("a1cfb53b-b55f-4b3d-b36f-af40de46104f"));
            DateFixedAssetChangeDetail = (ITTDateTimePickerColumn)AddControl(new Guid("28561a2c-af5f-4e07-83d1-85adc91c5ed5"));
            DescriptionFixedAssetChangeDetail = (ITTTextBoxColumn)AddControl(new Guid("ea44eb57-e451-462f-bc5b-4ac6d94967b4"));
            SiteFixedAssetChangeDetail = (ITTListBoxColumn)AddControl(new Guid("380aff7f-6149-46de-aeef-4e99edc0e734"));
            ChangeActionObjectIDFixedAssetChangeDetail = (ITTTextBoxColumn)AddControl(new Guid("b5486eba-4a33-4463-9466-96dc85a073e1"));
            cmdGetChangeAction = (ITTButton)AddControl(new Guid("5a809d63-499a-4cb6-8592-2173766573b2"));
            labelFixedAssetDefinition = (ITTLabel)AddControl(new Guid("ffdf81ff-b82a-4d08-bac0-398b56b1dd78"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("2ac264fa-0bc8-4eb2-ad3b-6a783a0408b9"));
            base.InitializeControls();
        }

        public FixedAssetChangeUpdateForm() : base("FIXEDASSETCHANGEUPDATE", "FixedAssetChangeUpdateForm")
        {
        }

        protected FixedAssetChangeUpdateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}