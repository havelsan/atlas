
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
    public partial class CheckStockActionInDetail : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
#region Body
            string errorMessage = string.Empty;

            foreach (StockActionDetailIn inDetail in Interface.GetStockActionInDetails())
            {
                if (inDetail.StockAction is IBasePrescriptionTransaction)
                {
                    if (inDetail.PrescriptionPaperInDetails.Count != inDetail.Amount)
                    {
                        if (errorMessage == string.Empty)
                            errorMessage = inDetail.Material.Name + " isimli malzemenin reçete detayları girilmemiş veya eksik girilmiştir.\r\n";
                        else
                            errorMessage = errorMessage + inDetail.Material.Name + " isimli malzemenin reçete detayları girilmemiş veya eksik girilmiştir.\r\n";
                    }
                }
                else
                {
                    StockMethodEnum stockMethod = (StockMethodEnum)inDetail.Material.StockCard.StockMethod;
                    switch (stockMethod)
                    {
                        case (StockMethodEnum.ExpirationDated):
                            if (string.IsNullOrEmpty(inDetail.LotNo))
                            {
                                if (errorMessage == string.Empty)
                                    errorMessage = inDetail.Material.Name + " isimli malzemenin lot numarası girilmemiştir.\r\n";
                                else
                                    errorMessage = errorMessage + inDetail.Material.Name + " isimli malzemenin lot numarası girilmemiştir.\r\n";
                            }
                            if (inDetail.ExpirationDate == null)
                            {
                                if (errorMessage == string.Empty)
                                    errorMessage = inDetail.Material.Name + " isimli malzemenin son kullanma tarihi girilmemiştir.\r\n";
                                else
                                    errorMessage = errorMessage + inDetail.Material.Name + " isimli malzemenin son kullanma tarihi girilmemiştir.\r\n";
                            }
                            break;
                        case (StockMethodEnum.LotUsed):
                            if (string.IsNullOrEmpty(inDetail.LotNo))
                            {
                                if (errorMessage == string.Empty)
                                    errorMessage = inDetail.Material.Name + " isimli malzemenin lot numarası girilmemiştir.\r\n";
                                else
                                    errorMessage = errorMessage + inDetail.Material.Name + " isimli malzemenin lot numarası girilmemiştir.\r\n";
                            }
                            break;
                        case (StockMethodEnum.QRCodeUsed):
                            double packageAmount = (double)inDetail.Material.PackageAmount;
                            double qrCodeCount = Math.Floor((double)inDetail.Amount / packageAmount);

                            if (inDetail.QRCodeInDetails.Count < qrCodeCount || inDetail.QRCodeInDetails.Count == 0)
                            {
                                if (errorMessage == string.Empty)
                                    errorMessage = inDetail.Material.Name + " isimli malzemenin karekodları girilmemiştir.\r\n";
                                else
                                    errorMessage = errorMessage + inDetail.Material.Name + " isimli malzemenin karekodları girilmemiştir.\r\n";
                            }
                            break;
                        case (StockMethodEnum.SerialNumbered):
                            if (inDetail.FixedAssetInDetails.Count < inDetail.Amount || inDetail.FixedAssetInDetails.Count == 0)
                            {
                                if (errorMessage == string.Empty)
                                    errorMessage = inDetail.Material.Name + " isimli malzemenin demirbaş detayları girilmemiştir.\r\n";
                                else
                                    errorMessage = errorMessage + inDetail.Material.Name + " isimli malzemenin demirbaş detayları girilmemiştir.\r\n";
                            }

                            foreach(FixedAssetInDetail fIndetail in inDetail.FixedAssetInDetails)
                            {
                                if(fIndetail.FixedAssetMaterialDefDetail == null)
                                {
                                    if (errorMessage == string.Empty)
                                        errorMessage = inDetail.Material.Name + " isimli malzemenin demirbaş detayları girilmemiştir.\r\n";
                                    else
                                        errorMessage = errorMessage + inDetail.Material.Name + " isimli malzemenin demirbaş detayları girilmemiştir.\r\n";
                                }
                            }
                            break;
                        case (StockMethodEnum.StockNumbered):
                            break;
                    }
                }
            }

            if (string.IsNullOrEmpty(errorMessage) == false)
                throw new TTException(errorMessage);
#endregion Body
        }

        public override void Check(TTAttribute attribute)
        {
#region CheckBody
        
#endregion CheckBody
        }
    }
}