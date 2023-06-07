using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BO
{
    public class employee_saleBO
    {
        public string ECODE { get; set; }

        public string ID { get; set; }
        public int VESTING_DETAIL_ID { get; set; }

        public double OPTION_SALE { get; set; }
        public string TRANCH_VESTING { get; set; }
        //public double TOTAL_AMOUNT { get; set; }
        public string PAYMENT_MODE { get; set; }

        public string CHEQUE_BANK_NAME { get; set; }
        public string CHEQUE_BRANCH_NAME { get; set; }
        public string CHEQUE_ACC_NO { get; set; }
        public string CHEQUE_IFSC { get; set; }
        public string CHEQUE_MICR { get; set; }
        public string CHEQUE_FILE_NAME { get; set; }
        public string CHEQUE_FILE_PATH { get; set; }
        public string CHEQUE_NUMBER { get; set; }
        public DateTime CHEQUE_DATE { get; set; }
        public double CHEQUE_AMOUNT { get; set; }

        public string NEFT_BANK_NAME { get; set; }
        public string NEFT_BRANCH_NAME { get; set; }
        public string NEFT_ACC_NO { get; set; }
        public string NEFT_IFSC { get; set; }
        public string NEFT_FILE_NAME { get; set; }
        public string NEFT_FILE_PATH { get; set; }
        public string NEFT_UTR_NO { get; set; }

        public string LOAN_LENDER_BANK_NAME { get; set; }
        public double LOAN_AMOUNT { get; set; }
        public double LOAN_MARGIN_AMOUNT { get; set; }
        public string LOAN_MARGIN_PAYMENT_MODE { get; set; }

        public string SECURITY_NAME { get; set; }
        public string DPID { get; set; }
        public string CLIENT_ID { get; set; }
        public string MEMBER_TYPE { get; set; }
        public string DEMAT_FILE_PATH { get; set; }
        public string PAN_FILE_PATH { get; set; }

        public string SALE_OFFER_FILE_PATH { get; set; }
        public string SALE_DECLARATION_FILE_PATH { get; set; }
        public string SALE_TRANSACTION_RECEIPT_FILE_PATH { get; set; }
        public string DIS_STATUS { get; set; }
        public string APPROVE_STATUS { get; set; }
        public string DIS_DATE { get; set; }
        public string APPROVE_DATE { get; set; }
        public string CREATEDBY { get; set; }
        public string MODIFIEDBY { get; set; }
        //---------------------------------------------------

        public int _SALE_TRAN_ID { get; set; }
        public int _GRANT_ID { get; set; }
        public int _VESTING_DETAIL_ID { get; set; }
        public string _ECODE { get; set; }
        public string _ENAME { get; set; }
        public string _GRANT_NAME { get; set; }
        public string _VESTING_DETAIL_CODE { get; set; }
        public DateTime _VESTING_DATE { get; set; }
        public double _NO_OF_VESTING { get; set; }
        public double _GRANT_PRICE { get; set; }
        public double _EXERCISE_FMV_PRICE { get; set; }
        public double _SALE_FMV_PRICE { get; set; }
        public double _NO_OF_SALE { get; set; }
        public DateTime _SALE_DATE { get; set; }
        //////public double _TAXABLE_INCOME { get; set; }
        //////public double _EXERCISE_CONSIDERATION { get; set; }
        //////public double _FMV_GRANT_OPTION_EXERCISE { get; set; }
        //////public double _REVISED_TAXABLE_INCOME { get; set; }
        //////public double _TAX_PER_OPTION { get; set; }
        //////public double _PERQ_TAX_AMOUNT { get; set; }
        public double TOTAL_AMOUNT { get; set; }
        //////public double _AMOUNT_DEPOSITED { get; set; }
        //////public double _FUNDING_AMOUNT { get; set; }
        public string _SECURITY_NAME { get; set; }
        public string _DPID { get; set; }
        public string _CLIENT_ID { get; set; }
        public string _MEMBER_TYPE { get; set; }
        public string _PAYMENT_MODE { get; set; }
        public string _BANK_NAME { get; set; }
        public string _BANK_BRANCH { get; set; }
        public string _ACC_NO { get; set; }
        public string _IFSC { get; set; }
        public string _MICR { get; set; }
        public string _CHEQUE_NUMBER { get; set; }
        public DateTime _CHEQUE_DATE { get; set; }
        public string _CREATEDBY { get; set; }
        public DateTime _CREATEDDATE { get; set; }
        public string _MODIFIEDBY { get; set; }
        public DateTime _MODIFIEDDATE { get; set; }
        public string _ISDELETED { get; set; }
        public string _ISACTIVE { get; set; }

        public string Remark { get; set; }
        public string Status { get; set; }
        public int SALE_WINDOW_ID { get; set; }
        public string SALE_WINDOW_START_DATE { get; set; }
        public string ErrorString { get; set; }
        public string RecStatus { get; set; }
        public string VALUED_BY { get; set; }                          //Added by Krutika on 18-11-22

        public string _Str_VESTING_DATE { get; set; }

        public string _STR_SALE_DATE { get; set; }

    }
}
