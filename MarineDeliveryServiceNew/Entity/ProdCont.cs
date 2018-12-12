using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class ProdCont
    {
        public int ProdContID { get; set; }
        public int ProdID { get; set; }
        public int ContID { get; set; }
        public string Explanation { get; set; }
        public int? HzrdMaterialID { get; set; }
        public int? MaterialSafetyDataID { get; set; }
        public string DefActiveToSell { get; set; }
        public string DefActiveToPurch { get; set; }
        public string DefCostMethod { get; set; }
        public int? DefCountUOMID { get; set; }
        public int DefCountFrequencyID { get; set; }
        public decimal? DefMaxOnhand { get; set; }
        public decimal? DefMinOnhand { get; set; }
        public int DefOnHandUOMID { get; set; }
        public int? DefConversionUOMID { get; set; }
        public decimal? DefConversionFactor { get; set; }
        public string DefReportNegative { get; set; }
        public string DefReportCommitted { get; set; }
        public int DefGLCodeID { get; set; }
        public int? ProdFrtGroupID { get; set; }
        public int? ProdTaxGroupID { get; set; }
        public string GLMacroSub { get; set; }
        public string CompanyID { get; set; }
        public int? ProdTypeID { get; set; }
        public string ActiveForPO { get; set; }
        public int? PurchGroupID { get; set; }
        public decimal? TargetDaysOnHandQty { get; set; }
        public string ClientID { get; set; }
        public string LastModifiedDtTm { get; set; }
        public string LastModifiedUser { get; set; }
        public decimal? Weight { get; set; }
        public int? DefBlendRecipeID { get; set; }
        public string CostingStyle { get; set; }
        public string OrderQtyCalcMethod { get; set; }
        public char ActiveMarneDelvApp { get; set; }
        public char EnterAsNegativeOrderedQuantity { get; set; }

    }
}