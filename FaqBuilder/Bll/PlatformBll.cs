using System.Collections.Generic;
using AutoMapper;
using FaqBuilder.Dal;
using FaqBuilder.DbContext;
using FaqBuilder.Models;
using FaqBuilder.ViewModels;
using System.Linq;

namespace FaqBuilder.Bll
{
    public class PlatformBll
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new FaqBuilderDbContext());

        public IEnumerable<PlatformViewModel> GetAllPlatformVms()
        {
            var entities = _unitOfWork.Platforms.GetAll();
            var viewModels = Mapper.Map<IEnumerable<Platform>, IEnumerable<PlatformViewModel>>(entities);
            return viewModels;
        }

        public PlatformViewModel GetNewPlatformVm()
        {
            return new PlatformViewModel();
        }

        public PlatformViewModel CreatePlatform(PlatformViewModel viewModel)
        {
            var existing = _unitOfWork.Platforms.Find(t => t.Name == viewModel.Name).FirstOrDefault();

            if (existing != null)
            {
                viewModel.Success = false;
                viewModel.Error = $"There is already a platform named {viewModel.Name}.";
            }
            else
            {
                var newPlatform = new Platform();
                Mapper.Map(viewModel, newPlatform);
                _unitOfWork.Platforms.Add(newPlatform);
                _unitOfWork.Complete();
            }

            return viewModel;
        }

        public PlatformViewModel GetPlatformVmById(int id)
        {
            var entity = _unitOfWork.Platforms.Get(id);
            var viewModel = new PlatformViewModel();

            if (entity == null)
            {
                viewModel.Success = false;
                viewModel.Error = $"Platform with Id: {id} was not found.";
            }
            else
            {                
                Mapper.Map(entity, viewModel);
            }
            
            return viewModel;
        }

        public PlatformViewModel UpdatePlatform(PlatformViewModel viewModel)
        {
            var entity = _unitOfWork.Platforms.Get(viewModel.Id);
            Mapper.Map(viewModel, entity);
            _unitOfWork.Complete();

            return viewModel;
        }
    }
}