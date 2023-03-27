
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Uygulama
    /// </summary>
    public partial class InpatientDrugOrderDetailForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region InpatientDrugOrderDetailForm_PreScript
    InpatientDrugOrderDetail inpatientDrugOrderDetail = _InpatientDrugOrderDetail ;
            
            switch (inpatientDrugOrderDetail.CurrentStateDefID.Value.ToString())
            {
                case "130b83ab-b2c7-4592-94c6-c4be2c9338df":
                    Stage.Text = "Bu ilacın bulunduğu Reçete Henüz Dağıtılmadı!";
                    this.DropStateButton(InpatientDrugOrderDetail.States.Request);
                    break;
                case "e8c841da-d833-41fb-94dd-b17ad07ea603":
                    Stage.Text = "Bu ilacın bulunduğu Reçete Dağıtıldı.Henüz Eczane Tarafından Karşılanmadı !";
                    this.DropStateButton(InpatientDrugOrderDetail.States.Supply);
                    break;
                case "1d516c6e-4b74-46b6-b0f0-89e3402a3819":
                    Stage.Text = "Bu ilacın bulunduğu Reçete Dağıtıldı.Eczane Tarafından Karşılandı!";
                    break;
                case "6613a06d-4359-46a2-9547-1413e80592a1":
                    Stage.Text = "Uygulandı";
                    break;
                case "d20a8d9f-b209-476a-9448-875b66a11548":
                    Stage.Text = "Uygulama İptal Edildi!";
                    break;
                default:
                    throw new TTException(SystemMessage.GetMessage(987));
            }
#endregion InpatientDrugOrderDetailForm_PreScript

            }
                }
}