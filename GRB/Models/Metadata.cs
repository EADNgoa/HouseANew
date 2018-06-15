using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

    public class RtiTblMetadata
    {
        [AllowHtml]
        public string RTI { get; set; }

        [AllowHtml]
        public string PIO { get; set; }

        [AllowHtml]
        public string APIO { get; set; }
    }


    }