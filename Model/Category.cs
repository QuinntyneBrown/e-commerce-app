using System;
using System.Collections.Generic;
using ECommerceApp.Data.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static ECommerceApp.Constants;

namespace ECommerceApp.Model
{
    [SoftDelete("IsDeleted")]
    public class Category: ILoggable
    {
        public int Id { get; set; }        
		[ForeignKey("Tenant")]
        public int? TenantId { get; set; }        
		[Index("CategoryNameIndex", IsUnique = false)]
        [Column(TypeName = "VARCHAR")]     
        [StringLength(MaxStringLength)]		   
		public string Name { get; set; }        
		public DateTime CreatedOn { get; set; }        
		public DateTime LastModifiedOn { get; set; }       
		public string CreatedBy { get; set; }        
		public string LastModifiedBy { get; set; }        
		public bool IsDeleted { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
