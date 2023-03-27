
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
    public partial class BondDetail : TTObject
    {
        [TTStorageManager.Attributes.TTSerializeProperty]
        public string Status { get; set; }

        public void ControlPaid()
        {
            if (CurrentStateDefID == BondDetail.States.Paid && !PaymentDate.HasValue)
                throw new TTException(TTUtils.CultureService.GetText("M26648", "Ödeme tarihi boş geçilemez!"));

            if (Bond.BondDetails.Where(x => x.Date < Date && x.CurrentStateDefID == BondDetail.States.New).Count() > 0)
                throw new TTException("Ara tarihli vade ödemesi yapılamaz!");

            //if (this.Bond.BondDetails.Where(x => x.Paid == true).Count() == this.Bond.BondDetails.Count)
            //    this.Bond.CurrentStateDefID = Bond.States.Paid;
        }

        protected override void PreInsert()
        {
            
        }

        protected override void PreUpdate()
        {
            if (CurrentStateDefID == BondDetail.States.Paid)
                ControlPaid();

            //if ((Bond.BondDetails.Where(x => x.Paid == false).Count() == Bond.BondDetails.Count) && (Bond.CurrentStateDefID == Bond.States.PartialPaid || Bond.CurrentStateDefID == Bond.States.Paid))
            //    throw new TTException("Hiçbir vadesi ödenmemiş senet Ödenmedi durumunda olmalıdır!");

            //if ((Bond.BondDetails.Where(x => x.Paid == true).Count() == Bond.BondDetails.Count) && Bond.CurrentStateDefID != Bond.States.Paid)
            //    throw new TTException("Tüm vadeleri ödenmiş senet Ödendi durumunda olmalıdır!");
        }
    }
}