using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BabyLife.Api.Devices.DTO
{
    public class PostDeviceDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Indicator { get; set; }
    }
}
