using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FaqBuilder.Dal;
using FaqBuilder.DbContext;
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
            viewModel.Games = _unitOfWork.Games.GetAll();

            return viewModel;
        }
    }
}