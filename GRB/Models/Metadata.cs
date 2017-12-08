using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace GRB
{
    public class InmatesMetadata
    {
        [Display(Name = "Name")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string In_Name;

        [Display(Name = "Gender")]
        [Required]        
        public string Gender;

    }

    public class ProjMetadata
    {
        public int Proj_Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Titie")]
        public string Proj_Title { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        [Display(Name = "Description")]
        public string Proj_Desc { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Proj_Status { get; set; }
               
    }

    public class ProjectsMetadata
    {
        public int Proj_Id { get; set; }

        [Required]
        [StringLength(100,MinimumLength =3)]
        [Display(Name ="Titie")]
        public string Proj_Title { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        [Display(Name = "Description")]
        public string Proj_Desc { get; set; }

        [Required]        
        [Display(Name = "Status")]
        public string Proj_Status { get; set; }
                
        public HttpPostedFileBase UploadedFile { get; set; }
    }

    public class ProfileMetadata
    {
        public int P_Id{get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 3)]
        [Display(Name = "Name")]
        public string P_Name { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 3)]
        [Display(Name = "Designation")]
        public string P_Designation { get; set; }

        [StringLength(10000, MinimumLength = 10)]
        [Display(Name = "Description")]
        public string P_Desc { get; set; }
    }

    public class StaffMetadata
    {
        public int S_Id { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 3)]
        [Display(Name = "Name")]
        public string S_Name { get; set; }

        [Required]
        [StringLength(10000, MinimumLength = 3)]
        [Display(Name = "Responsibility")]
        public string S_Responsibilities { get; set; }
    }

    public class GoaRehabMetadata
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 3)]
        [Display(Name = "Mission")]
        public string Mission { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 5)]
        [Display(Name = "Vision")]
        public string Vision { get; set; }

    }

    public class NewsMetadata
    {
        public int N_Id { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 3)]
        [Display(Name = "Title")]
        public string N_Title { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        [Display(Name = "Description")]
        public string N_Desc { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime N_Date { get; set; }
                
        [Display(Name = "Status")]
        public string N_Status { get; set; }
    }

    //public class GoaRbMetadata
    //{
    //    public int Id { get; set; }

    //    [Required]
    //    [StringLength(1000, MinimumLength = 5)]
    //    [Display(Name = "Mission")]
    //    public string Mission { get; set; }

    //    [Required]
    //    [StringLength(1000, MinimumLength = 5)]
    //    [Display(Name = "Vision")]
    //    public string Vision { get; set; }

    //}
    //public class EmpTypeMetadata
    //{
    //    [Display(Name = "Employee Type")]
    //    public int EmpTypeID;

    //    [Display(Name = "Employee Type")]
    //    [StringLength(50, MinimumLength = 3)]
    //    [Required]
    //    public int EmpType;

    //    [Display(Name = "Has Daily Allowance")]
    //    public bool HasDailyAllowance;
    //}

    //public class EDocTypeMetadata
    //{
    //    [Display(Name = "Employee Document Type")]
    //    public int EDocTypeID;

    //    [Display(Name = "Document Type")]
    //    [StringLength(50, MinimumLength = 3)]
    //    [Required]
    //    public string EDocType;


    //}

    //public class AllowanceTypeMetadata
    //{
    //    [Display(Name = "Allowance Type")]
    //    public int ATID;

    //    [Display(Name = "Allowance Type")]
    //    [StringLength(50, MinimumLength = 3)]
    //    [Required]
    //    public string AllowanceType;
    //}

    //public class EmployeesMetadata
    //{
    //    [Display(Name = "Name")]
    //    [StringLength(250, MinimumLength = 2)]
    //    [Required]
    //    public string Name;

    //    [Display(Name = "Nickname")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string NickName;

    //    [Display(Name = "Job Title")]
    //    [StringLength(150, MinimumLength = 3)]
    //    public string JobTitle;

    //    [Display(Name = "Mobile No.")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string Mobile;

    //    [Display(Name = "Emergency Contact No.")]
    //    [StringLength(50, MinimumLength = 3)]
    //    [Required]
    //    public string EmContactNo;

    //    [Display(Name = "Emergency Contact Name, Address(250 chars)")]
    //    [StringLength(250, MinimumLength = 3)]
    //    public string EmContactName;

    //    [Display(Name = "Relation with Emergency Contact")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string EmContactReln;

    //    [Display(Name = "is HDFC")]
    //    public bool IsHDFC;

    //    [Display(Name = "Category A or B?")]
    //    public string CatAB;


    //    [Display(Name = "HDFC Bank A/c")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string RegBankAc;

    //    [Display(Name = "Non HDFC bank A/c")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string NRegBankAc;

    //    [Display(Name = "Non. HDFC Bank Name")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string NRegBank;

    //    [Display(Name = "Non. HDFC Bank IFSC")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string NRegIFSC;

    //    [Display(Name = "Bonus Pay Month")]
    //    [Required]
    //    [Range(1, 12)]
    //    public int BonusPayMonth;

    //    [Display(Name = "PF No.")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string PFno;

    //    [Display(Name = "ESI No.")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string ESIno;


    //}

    //public class EmpDocsMetadata
    //{
    //    [Display(Name = "Employee")]
    //    public int EmpID;

    //    [Display(Name = "Document Type")]
    //    public int EDocTypeID;

    //    [Display(Name = "Employee")]
    //    public Employees Employees;

    //    [Display(Name = "Document Type")]
    //    public EDocTypes EDocTypes;

    //    [Display(Name = "Hide")]
    //    public bool Renewed;

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Expiry Date")]        
    //    public DateTime ExpiryDate;
    //}

    //public class EmploymentHistoryMetadata
    //{
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Join Date")]
    //    [Required]
    //    public DateTime JoinDate;

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Registration Date")]
    //    public DateTime RegistrationDate;

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Exit Date")]
    //    public DateTime ExitDate;

    //    [Display(Name = "Reason for leaving")]
    //    public string ExitReason;
    //}

    //public class LoansMetadata
    //{
    //    [Display(Name = "Loan")]
    //    public int LoanID;


    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Loan Date")]
    //    public DateTime LoanDate;

    //    [Display(Name = "Loan Amount")]
    //    [Required]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal Amount;

    //    [Display(Name = "Payback period (months)")]
    //    [Required]
    //    [Range(1, 48)]
    //    public int PayMonths;
    //}

    //public class LoanSkipMetadata
    //{
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Apply Date")]
    //    public DateTime PayDate;

    //    [Display(Name = "Amount payable (min 0)")]
    //    [Required]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal Amount;
    //}

    //public class WagesMetadata
    //{
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "With Effect From")]
    //    [Required]
    //    public DateTime WEF;

    //    [Display(Name = "Amount payable (min 0)")]
    //    [Required]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal Amount;
    //}

    //public class AllowanceMetadata
    //{
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "With Effect From")]
    //    [Required]
    //    public DateTime WEF;

    //    [Display(Name = "Percentage of Wage")]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal PercOfWage;

    //    [Display(Name = "Amount")]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal Amount;

    //}

    //public class AdvanceMetadata
    //{
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Advance taken on")]
    //    [Required]
    //    public DateTime AdvDate;

    //    [Display(Name = "Amount")]
    //    [Required]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal Amount;
    //}

    //public class BonusMetadata
    //{
    //    [Display(Name = "System Bonus")]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal SysBonus;

    //    [Display(Name = "Manual Override")]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal UsrBonus;
    //}

    //public class PayrollMetadata
    //{
    //    [Display(Name = "Days Worked")]        
    //    public int DaysWorked;

    //    [Display(Name = "Loan Amt.")]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal LoanAmt;

    //    [Display(Name = "Loan")]
    //    public String LoanCmt;

    //    [Display(Name = "Bank")]
    //    public String BankName;

    //    [Display(Name = "Account")]
    //    public String BankAccount;

    //    [Display(Name = "Adjustment")]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal AdjAmt;

    //    [Display(Name = "Reason")]
    //    public String AdjRemark;
    //}


}