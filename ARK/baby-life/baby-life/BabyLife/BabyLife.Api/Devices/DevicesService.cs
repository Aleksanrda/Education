using BabyLife.Api.Devices.DTO;
using BabyLife.Core.Entities;
using BabyLife.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api.Devices
{
    public class DevicesService : IDevicesService
    {
        private readonly IUnitOfWork unitOfWork;

        public DevicesService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Device> GetDevices()
        {
            var result = unitOfWork.Devices.GetAll();

            return result;
        }

        public Device GetDevice(int id)
        {
            var result = unitOfWork.Devices.GetByID(id);

            return result;
        }

        public async Task<Device> CreateDevice(Device device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            var newDevice = new Device()
            {
                Name = device.Name,
                Indicator = device.Indicator,
            };

            if (newDevice != null)
            {
                unitOfWork.Devices.Create(newDevice);
                await unitOfWork.SaveChangesAsync();

                return newDevice;
            }

            return null;
        }

        public async Task<Device> UpdateDevice(int id, Device device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            var devices = unitOfWork.Devices.GetAll();
            var editDevice = devices.FirstOrDefault(
                device => device.Id == id);

            if (editDevice != null)
            {
                editDevice.Name = device.Name;
                editDevice.Indicator = device.Indicator;
                unitOfWork.Devices.Update(editDevice);
                await unitOfWork.SaveChangesAsync();
                return editDevice;
            }

            return null;
        }

        public async Task<string> DeleteDevice(int id)
        {
            var device = unitOfWork.Devices.GetByID(id);

            if (device != null)
            {
                unitOfWork.Devices.Delete(device);
                await unitOfWork.SaveChangesAsync();
                return "Ok";
            }

            return "Error";
        }
    }
}
