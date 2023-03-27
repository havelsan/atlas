
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
    /// Stok hareketlerinde çıkış detaylarını barındıran sınıftır. Stok modüllerindeki çıkış tipindeki detay sınıfları bu sınıftan türer
    /// </summary>
    public abstract partial class StockActionDetailOut : StockActionDetail, IStockActionDetailOut
    {
        public partial class GetStoreNameForMaterialRequestReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetReturningByStoreIDForMaterialRequestReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetReturningForMaterialRequestReportQuery_Class : TTReportNqlObject
        {
        }

        #region ITTCoreObject Members

        public TTObjectDef GetObjectDef()
        {
            return ObjectDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }
        #endregion

        public override void OnContextDispose()
        {
            base.OnContextDispose();
            _totalPrice = TotalPrice;
            _price = Price;
            _unitPrice = UnitPrice;
            _aproximateUnitPrice = AproximateUnitPrice;
        }


        /// <summary>
        /// Toplam Tutar
        /// </summary>

        private Currency? _totalPrice = null;
        [TTStorageManager.Attributes.TTSerializeProperty]
        public Currency? TotalPrice
        {
            get
            {
                try
                {
                    if (_totalPrice.HasValue)
                        return _totalPrice.Value;
                    #region TotalPrice_GetScript                    
                    CalculatePrice();
                    return _outPrice;
                    #endregion TotalPrice_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "TotalPrice") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Toplam Tutar
        /// </summary>
        private BigCurrency? _price = null;
        [TTStorageManager.Attributes.TTSerializeProperty]
        public BigCurrency? Price
        {
            get
            {
                try
                {
                    if (_price.HasValue)
                        return _price.Value;

                    #region Price_GetScript                    
                    CalculatePrice();
                    return _outPrice;
                    #endregion Price_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "Price") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Birim Fiyatı
        /// </summary>
        private BigCurrency? _unitPrice = null;
        [TTStorageManager.Attributes.TTSerializeProperty]
        public BigCurrency? UnitPrice
        {
            get
            {
                try
                {
                    if (_unitPrice.HasValue)
                        return _unitPrice.Value;

                    #region UnitPrice_GetScript                    
                    CalculatePrice();
                    return _outUnitPrice;
                    #endregion UnitPrice_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "UnitPrice") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Çıkış Yapılmadan Önceki Tahmini Birim Fiyat
        /// </summary>
        private Currency? _aproximateUnitPrice = null;
        [TTStorageManager.Attributes.TTSerializeProperty]
        public Currency? AproximateUnitPrice
        {
            get
            {
                try
                {
                    if (_aproximateUnitPrice.HasValue)
                        return _aproximateUnitPrice.Value;

                    #region AproximateUnitPrice_GetScript              

                    CalculatePrice(false);
                    return _outUnitPrice;

                    #endregion AproximateUnitPrice_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "AproximateUnitPrice") + " : " + ex.Message, ex);
                }
            }
        }

        protected override void PreDelete()
        {
            #region PreDelete





            base.PreDelete();

            if (StockReservation != null)
                StockReservation.CurrentStateDefID = StockReservation.States.Cancelled;

            List<OuttableLot> deletedOuttableLots = new List<OuttableLot>();
            foreach (OuttableLot outtableLot in OuttableLots)
                deletedOuttableLots.Add(outtableLot);

            foreach (OuttableLot deletedOuttableLot in deletedOuttableLots)
                ((ITTObject)deletedOuttableLot).Delete();




            #endregion PreDelete
        }

        #region Methods
        public Accountancy setaccountancy;

        #endregion Methods

    }
}