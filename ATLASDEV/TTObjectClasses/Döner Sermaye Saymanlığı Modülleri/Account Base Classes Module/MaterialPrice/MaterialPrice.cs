
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


namespace TTObjectClasses
{
    /// <summary>
    /// Malzeme Fiyat Eşleştirme Tanımı
    /// </summary>
    public  partial class MaterialPrice : TerminologyManagerDef
    {
        public partial class MaterialPriceNQL_Class : TTReportNqlObject 
        {
        }

        public partial class MaterialPriceByMaterialAndPriceList_Class : TTReportNqlObject 
        {
        }

        public partial class MaterialPriceByMaterialForDefinition_Class : TTReportNqlObject 
        {
        }

        public partial class MaterialPriceByMaterial_Class : TTReportNqlObject 
        {
        }

        protected override void PostInsert()
        {
#region PostInsert
            
            base.PostInsert();
//            // Malzemenin aynı fiyat listesinden ikinci bir fiyatla eşleştirilmemesi için kontrol (ilaçlar için yapılmıyor bu kontrol)
//            if (!(this.Material is DrugDefinition))
//            {
//                IList<MaterialPriceByMaterialAndPriceList_Class> list = MaterialPriceByMaterialAndPriceList(this.PricingDetail.PricingList.ObjectID.ToString(), this.Material.ObjectID.ToString());
//                if (list.Count > 0)
//                    throw new TTUtils.TTException(SystemMessage.GetMessage(1268));
//            }

#endregion PostInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            
            base.PostUpdate();
            // Malzemenin aynı fiyat listesinden ikinci bir fiyatla eşleştirilmemesi için kontrol (ilaçlar için yapılmıyor bu kontrol)
//            if (!(this.Material is DrugDefinition))
//            {
//                IList<MaterialPriceByMaterialAndPriceList_Class> list = MaterialPriceByMaterialAndPriceList(this.PricingDetail.PricingList.ObjectID.ToString(), this.Material.ObjectID.ToString());
//                if (list.Count > 0)
//                    throw new TTUtils.TTException(SystemMessage.GetMessage(1268));
//            }

#endregion PostUpdate
        }

        protected override void PreDelete()
        {
#region PreDelete
            base.PreDelete();

#endregion PreDelete
        }

        protected override void PostDelete()
        {
#region PostDelete
            
            base.PostDelete();

//            List<Sites> targetSites = new List<Sites>();
//            foreach (KeyValuePair<Guid, Sites> site in Sites.AllActiveSitesWithoutCurrentSiteAndLOCALHOST)
//                targetSites.Add(site.Value);
//            
//          TerminologyManagerDef.RunSendTerminologyManagerDef(this,targetSites);
//          InfoBox.Show("Tüm Sahalardan Çıkartıldı.",MessageIconEnum.ErrorMessage);

            

#endregion PostDelete
        }

#region Methods
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.MaterialPriceInfo;
        }
        
#endregion Methods

    }
}