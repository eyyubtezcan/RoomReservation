using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RoomReservationProject.Domain.Base
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public DateTime CreatedDate { get; set; }
       
        public DateTime LastModifiedDate { get; set; }


        //public bool IsDeleted { get; set; }
  
        public bool IsActive { get; set; } 
 
        public int CreatedById { get; set; }

        public int ModifiedById { get; set; } 
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            LastModifiedDate = DateTime.Now;
            //IsDeleted = false;
            IsActive = true;
            CreatedById = 1;
            ModifiedById = 1;

        }
    }
}
