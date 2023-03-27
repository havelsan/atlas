
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
    public  partial class CompleteBloodProducts : BaseScheduledTask
    {
#region Methods
        public override void TaskScript()
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            double expireLimit = Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("BLOODPRODUCTEXPIRELIMIT","72"));  // Değer saat türünde
            DateTime expireDate = Common.RecTime().AddHours(-(expireLimit));
            string objectDetails = String.Empty;
            
            IList products = BloodBankBloodProducts.GetExpiredBloodProducts(objectContext, expireDate);
            foreach(BloodBankBloodProducts product in products)
            {
                objectDetails = "BloodBankBloodProducts.ObjectID = " + product.ObjectID.ToString();
                bool hasUncompletedProduct = false;
                try
                {
                    if(product.BloodProductRequest.CurrentStateDefID == BloodProductRequest.States.BloodProductUsage)
                    {
                        if (product.CurrentStateDefID == BloodBankBloodProducts.States.New)
                        {
                            product.Used = true;
                            product.CurrentStateDefID = BloodBankBloodProducts.States.Completed;
                        }
                                                
                        foreach(BloodBankBloodProducts otherProduct in product.BloodProductRequest.BloodProducts)
                        {
                            if(otherProduct.ProductNumber != String.Empty && otherProduct.ProductDate != null && otherProduct.CurrentStateDefID == BloodBankBloodProducts.States.New)
                            {
                                hasUncompletedProduct = true;
                                break;
                            }
                        }
                        
                        if(hasUncompletedProduct == false)
                            product.BloodProductRequest.CurrentStateDefID = BloodProductRequest.States.Completed;
                        
                        objectContext.Save();
                        AddLog(product.ProductNumber + " torba numaralı ürün otomatik olarak tamamlandı.\r\n" + objectDetails);
                    }
                }
                catch (Exception ex)
                {
                    AddLog(ex.Message+" "+ objectDetails);
                }
            }
        }
        
#endregion Methods

    }
}