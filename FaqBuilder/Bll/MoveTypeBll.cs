using System;
using FaqBuilder.Dal;
using FaqBuilder.Helpers;
using FaqBuilder.Models;
using FaqBuilder.ViewModels;
using System.Linq;

namespace FaqBuilder.Bll
{
    public class MoveTypeBll
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new DbContext.FaqBuilderDbContext());


        public MoveTypesViewModel GetMoveTypesForGame(int id)
        {
            var entity = _unitOfWork.Games.Get(id);

            var viewModel = new MoveTypesViewModel { GameId = id, Game = entity, MoveTypes = entity.MoveTypes };
            
            return viewModel;
        }

        public MoveTypeViewModel GetNewMoveTypeVm(int gameId)
        {
            return new MoveTypeViewModel
            {
                GameId = gameId
            };
        }

        public MoveTypeViewModel CreateMoveType(MoveTypeViewModel viewModel)
        {
            try
            {
                var entity = new MoveType
                {                    
                    Name = viewModel.Name,
                    Description = viewModel.Description
                };

                var game = _unitOfWork.Games.Get(viewModel.GameId);

                if (game == null)
                    throw new NullReferenceException($"Game id {viewModel.GameId} was not found.");
                if (game.MoveTypes.FirstOrDefault(t => t.Name == viewModel.Name) != null)
                    throw new Exception($"There is already a Move Type named \"{viewModel.Name}\" in the database.");

                game.MoveTypes.Add(entity);
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