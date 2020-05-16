using BabyLife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api.Devices
{
    public interface IDevicesService
    {
        IEnumerable<Device> GetDevices();

        Device GetDevice(int id);

        Task<Device> CreateDevice(Device device);

        Task<Device> UpdateDevice(Device device);

        Task<string> DeleteDevice(int id);

        bool IsFeedingBaby(Feeding feeding, int babyId);
    }
}
