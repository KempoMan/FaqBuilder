using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaqBuilder.Dal;
using FaqBuilder.Helpers;
using FaqBuilder.Models;
using FaqBuilder.ViewModels;

namespace FaqBuilder.Bll
{
    public class InputMapBll
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new DbContext.FaqBuilderDbContext());

        public InputMapViewModel GetNewInputMapViewModelForGame(int gameId)
        {
            return new InputMapViewModel {GameId = gameId};
        }

        public InputMapViewModel CreateInputMap(InputMapViewModel viewModel)
        {
            try
            {
                var newInputMap = new InputMap
                {
                    GameId = viewModel.GameId,
                    Input = viewModel.Input,
                    ConvertedInput = viewModel.ConvertedInput
                };

                var game = _unitOfWork.Games.Get(viewModel.GameId);
                game.InputMaps.Add(newInputMap);
                //_unitOfWork.InputMaps.Add(newEntity);
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