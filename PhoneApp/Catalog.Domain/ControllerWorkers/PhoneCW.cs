using Catalog.Domain.DTO;
using Catalog.Infrastructure.DTO;
using Catalog.Infrastructure.DTO.Mappers;
using Catalog.Infrastructure.Factories;
using Catalog.Infrastructure.Models;
using Catalog.Infrastructure.Models.Catalog.Infrastructure.Models;
using Catalog.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalog.Domain.ControllerWorkers
{
    public class PhoneCW: InterfacePhoneCW
    {
        private UnitOfWork<PhoneContext> Uow = new UnitOfWork<PhoneContext>(new PhoneContextFactory());
        private readonly InterfaceRepository<Phone> phoneRepository;

        public PhoneCW()
        {
            phoneRepository = Uow.GetRepository<Phone>();
        }

        public PhoneCW(InterfaceRepository<Phone> mockRepository)
        {
            phoneRepository = mockRepository;
        }

        public List<PhoneDto> getPhones()
        {
            try
            {
                List<PhoneDto> result;

                result = phoneRepository.FindAll().Select(x => Mapper.Phone_To_PhoneDto(x)).ToList();

                return result;
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public PhoneDto getPhoneById(int id)
        {
            try
            {
                PhoneDto result = null;
                var data = phoneRepository.FindById(id);
                if (data != null) { result = Mapper.Phone_To_PhoneDto(data); }
                return result;
            }
            catch (Exception ex)
            {           
                throw ex;
            }
        }

        public List<PhonePriceDto> getPricesByIds(List<int> ids)
        {
            try
            {
                List<PhonePriceDto> data = phoneRepository.FindAll(phone => ids.Any(id => id == phone.Id))
                                                                 .Select(z => new PhonePriceDto { PhoneId= z.Id, PhonePrice= z.Price }).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
