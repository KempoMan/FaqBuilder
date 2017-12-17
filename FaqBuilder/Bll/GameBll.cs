using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FaqBuilder.Dal;
using FaqBuilder.DbContext;
using FaqBuilder.Helpers;
using FaqBuilder.Models;
using FaqBuilder.ViewModels;

namespace FaqBuilder.Bll
{
    public class GameBll
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new FaqBuilderDbContext());

        public IEnumerable<GameViewModel> GetAllGameVms()
        {
            var entities = _unitOfWork.Games.GetAll();
            var viewModels = Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(entities);

            return viewModels;
        }

        public GameViewModel GetNewGameVm()
        {
            var viewModel = new GameViewModel();        

            return GetListsForViewModel(viewModel);
        }

        public GameViewModel GetListsForViewModel(GameViewModel viewModel)
        {
            viewModel.Platforms = _unitOfWork.Platforms.GetAll();

            return viewModel;
        }

        public GameViewModel CreateGame(GameViewModel viewModel)
        {
            try
            {
                var existing = _unitOfWork.Games
                    .Find(t => t.Name == viewModel.Name || t.ShortName == viewModel.ShortName)
                    .FirstOrDefault();

                if (existing != null)
                {
                    viewModel.Success = false;
                    viewModel.Error = $"There is already a game named {viewModel.Name} ({viewModel.ShortName}).";
                }
                else
                {
                    _unitOfWork.Games.Add(Mapper.Map(viewModel, new Game()));
                    _unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                ErrorHelper.SetError(viewModel, e);
            }

            return viewModel;
        }

        public GameViewModel GetGameVmById(int id)
        {
            var entity = _unitOfWork.Games.Get(id);

            return Mapper.Map(entity, GetNewGameVm());
        }

        public GameViewModel UpdateGame(GameViewModel viewModel)
        {
            try
            {
                Mapper.Map(viewModel, _unitOfWork.Games.Get(viewModel.Id));
                _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                ErrorHelper.SetError(viewModel, e);
            }

            return viewModel;
        }
    }
}