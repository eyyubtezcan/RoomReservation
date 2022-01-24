using RoomReservationProject.Domain.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Data.Seeds
{
    class RoomStatusSeed : IEntityTypeConfiguration<RoomStatus>
    {
        private readonly int[] _ids;

        public RoomStatusSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<RoomStatus> builder)
        {
            builder.HasData(
                new RoomStatus
                {
                    Id = 1,
                    Description = "Booked",
                    IsActive = true,
                    CreatedById = 1,
                    CreatedDate = DateTime.Now
                },
                new RoomStatus
                {
                    Id = 2,
                    Description = "Cleaning Up...",
                    IsActive = true,
                    CreatedById = 1,
                    CreatedDate = DateTime.Now
                },
                new RoomStatus
                {
                    Id = 3,
                    Description = "Bookable",
                    IsActive = true,
                    CreatedById = 1,
                    CreatedDate = DateTime.Now
                },
                 new RoomStatus
                 {
                     Id = 4,
                     Description = "Unserviceable",
                     IsActive = true,
                     CreatedById = 1,
                     CreatedDate = DateTime.Now
                 }


                );
        }
    }
}
